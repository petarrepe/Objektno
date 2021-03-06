﻿using KonobApp.Model;
using KonobApp.Model.Models;
using KonobApp.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReceiptRepository : Subject, IReceiptRepository
    {
        private static ReceiptRepository _instance = null;

        private IList<ReceiptModel> _receipts = new List<ReceiptModel>();
        private IList<ArticleModel> _articles = new List<ArticleModel>();
        private IList<PaymentMethodModel> _paymentMethods = new List<PaymentMethodModel>();
        private IList<ArticleReceiptModel> _artRec = new List<ArticleReceiptModel>();
        private IList<UserModel> _users = new List<UserModel>();
        private IList<WaiterModel> _waiters = new List<WaiterModel>();


        private ReceiptModel _currentReceipt;
        private bool _isCurrentRecNew;
        private UserModel _currentUser;
        private WaiterModel _currentWaiter;

        public IList<ReceiptModel> Receipts { get { return _receipts; } }
        public IList<ArticleModel> Articles { get { return _articles; } }
        public IList<PaymentMethodModel> PaymentMethods { get { return _paymentMethods; } }
        public IList<ArticleReceiptModel> ArticleReceipts { get { return _artRec; } }
        public IList<UserModel> Users { get { return _users; } }
        public IList<WaiterModel> Waiters { get { return _waiters; } }

        public ReceiptModel CurrentReceipt { get { return _currentReceipt; } }
        public UserModel CurrentUser { get { return _currentUser; } }
        public WaiterModel CurrentWaiter { get { return _currentWaiter; } set { _currentWaiter = value; } }


        //private ISession nhibernateSession;

        private ReceiptRepository()
        {
            _currentUser = null;
        }

        public static ReceiptRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReceiptRepository();
            }
            return _instance;
        }

        #region Load

        public void LoadAll()
        {
            // Nije potrebno ucitati articles i payment method jer ce se
            // ucitavanjem racuna automatski ucitati i ostale stvari.
            LoadReceipts();
        }

        public void LoadReceipts()
        {
            IList<ArticleReceiptModel> artRecList = null;
            using (Facade facade = new Facade())
            {
                _receipts = facade.FetchAll<ReceiptModel>();
                artRecList = facade.FetchAll<ArticleReceiptModel>();
            }

            if (_articles.Count() == 0) LoadArticles();
            if (_paymentMethods.Count() == 0) LoadPaymentMethods();

            using(Facade facade = new Facade())
            {
                _users = facade.FetchAll<UserModel>();
            }
            
            using (Facade facade = new Facade())
            {
                _waiters = facade.FetchAll<WaiterModel>();
            }
            // punjenje podataka o articlima:
            foreach (ReceiptModel receipt in _receipts)
            {
                receipt.ArtRec = artRecList.Where(t => t.IDReceipt == receipt.IDReceipt).ToList();
                foreach (ArticleReceiptModel artRec in receipt.ArtRec)
                {
                    artRec.Article = _articles.FirstOrDefault(t => t.IDArticle == artRec.IDArticle);
                }
                receipt.PaymentMethod = _paymentMethods.Where(p => p.IDPaymentMethod == receipt.IDPaymentMethod).First();
                receipt.Waiter = _waiters.Where(w => w.IDWaiter == receipt.IDWaiter).First();
                if (receipt.IDUser != null) receipt.User = _users.Where(u => u.IDUser == receipt.IDUser).First();

            }
            
        }

        public void LoadArticles()
        {
            using (Facade facade = new Facade())
            {
                _articles = facade.FetchAll<ArticleModel>();
            }
        }

        public void LoadPaymentMethods()
        {
            using (Facade facade = new Facade())
            {
                _paymentMethods = facade.FetchAll<PaymentMethodModel>();
            }
        }

        public void LoadArtRec()
        {
            using (Facade facade = new Facade())
            {
                _artRec = facade.FetchAll<ArticleReceiptModel>();
            }

            if (_articles.Count() == 0) LoadArticles();
            if (_receipts.Count() == 0) LoadReceipts();

            foreach (ArticleReceiptModel artRec in _artRec)
            {
                artRec.Article = _articles.Where(a => a.IDArticle == artRec.IDArticle).First();
            }

            foreach (ArticleReceiptModel artRec in _artRec)
            {
                artRec.Receipt = _receipts.Where(c => c.IDReceipt == artRec.IDReceipt).First();
            }
        }

        #endregion

        #region Current Receipt methods

        public void SetCurrentReceipt(int receiptId)
        {
            _currentReceipt = _receipts.FirstOrDefault(t => t.IDReceipt == receiptId);
            _isCurrentRecNew = false;
        }

        public void SetNewCurrentReceipt()
        {
            _currentReceipt = new ReceiptModel
            {
                Date = DateTime.Now,
                Waiter = _currentWaiter,
                PaymentMethod = _paymentMethods.FirstOrDefault(t => t.TypePaymentMethod.ToLower() == "gotovina"),
                ArtRec = new List<ArticleReceiptModel>(),
                Articles = new List<ArticleModel>(),
                IDWaiter = _currentWaiter.IDWaiter
            };
            _isCurrentRecNew = true;
        }

        public void AddArticleToCurrentReceipt(int articleId, int amount)
        {
            if (_articles == null)
            {
                LoadArticles();
            }
            if (_currentReceipt == null)
            {
                throw new Exception("Current receipt not initialised.");
            }
            if (amount < 1)
            {
                throw new ArgumentException("Amount of articles in receipt cannot be less than 1.");
            }
            ArticleModel articleToAdd = _articles.FirstOrDefault(t => t.IDArticle == articleId);
            ArticleReceiptModel artRec = new ArticleReceiptModel
            {
                IDArticle = articleToAdd.IDArticle,
                Article = articleToAdd,
                Quantity = amount,
                PriceOfOne = articleToAdd.Price
            };
            if (articleToAdd == null)
            {
                return;
            }
            _currentReceipt.Articles.Add(articleToAdd);
            _currentReceipt.ArtRec.Add(artRec);

            NotifyObservers();
        }

        public void RemoveArticleFromCurrentReceipt(int articleId)
        {
            if (_currentReceipt == null) return;

            ArticleModel articleToRemove = _currentReceipt.Articles.FirstOrDefault(t => t.IDArticle == articleId);
            _currentReceipt.Articles.Remove(articleToRemove);

            ArticleReceiptModel artRecToRemove = _currentReceipt.ArtRec.FirstOrDefault(t => t.IDArticle == articleId);
            _currentReceipt.ArtRec.Remove(artRecToRemove);

            NotifyObservers();
        }

        public void SetPaymentMethodToCurrentReceipt(int paymentMethodId)
        {
            if (_paymentMethods == null) LoadPaymentMethods();
            PaymentMethodModel pay = _paymentMethods.FirstOrDefault(t => t.IDPaymentMethod == paymentMethodId);
            _currentReceipt.PaymentMethod = pay;
            _currentReceipt.IDPaymentMethod = pay.IDPaymentMethod;
        }

        public void SetDiscountToCurrentReceipt(float discount)
        {
            if (discount > 1 || discount < 0) _currentReceipt.Discount = 0;
        }

        public void AddAmountToArticleInReceipt(int idArticle, int value)
        {
            ArticleReceiptModel artRec = _currentReceipt.ArtRec.FirstOrDefault(t => t.IDArticle == idArticle);
            if (artRec == null) return;
            if (artRec.Quantity < 2 && value < 0) return;

            if (value > 0) artRec.Quantity++;
            else if (value < 0) artRec.Quantity--;

            NotifyObservers();
        }

        public string ValidateCurrentReceipt()
        {
            
            if (_currentReceipt.ArtRec.Count < 1)
            {
                return "Račun mora imati najmanje jedan artikl!";
            }
            return string.Empty;
        }

        public void SaveCurrentReceiptChanges()
        {
            if (!string.IsNullOrEmpty(ValidateCurrentReceipt())) return;
            if (_isCurrentRecNew)
            {
                AddReceiptWithArticles(_currentReceipt);
            }
        }

        #endregion

        #region Article

        /// <summary>
        /// Matches search string with given <code>searchString</code> with IDs and article names
        /// from in-memory articles (without reloading database)
        /// </summary>
        /// <param name="searchString">Search parameter</param>
        /// <returns>List with search results</returns>
        public IList<ArticleModel> GetFastArticleSearchResult(string searchString)
        {
            return _articles.Where(t => t.Name.ToLower().Contains(searchString) || t.IDArticle.ToString().Equals(searchString)).ToList();
        }

        #endregion

        #region Various Receipt Get Methods

        public ReceiptModel FindReceiptByID(int ID)
        {
            ReceiptModel result = _receipts.Where(r => r.IDReceipt == ID).First();
            if (result == null) return null;

            if (result.Waiter == null) result.Waiter = _waiters.FirstOrDefault(t => t.IDWaiter == result.IDWaiter);
            if (result.User == null && result.IDUser != 0) result.User = _users.FirstOrDefault(t => t.IDUser == result.IDUser);
            if (result.PaymentMethod == null) result.PaymentMethod = _paymentMethods.FirstOrDefault(t => t.IDPaymentMethod == result.IDPaymentMethod);
            if (result.ArtRec == null) result = fillReceiptWithArtRec(result);
            else if (result.ArtRec.Count < 1) result = fillReceiptWithArtRec(result);
            else if (result.ArtRec.Count < 1) result = fillReceiptWithArtRec(result);
            
            return result;
        }

        private ReceiptModel fillReceiptWithArtRec(ReceiptModel receipt)
        {
            receipt.ArtRec = new List<ArticleReceiptModel>();
            List<ArticleReceiptModel> artRecList = _artRec.Where(t => t.IDReceipt == receipt.IDReceipt).ToList();
            foreach(ArticleReceiptModel artRec in artRecList)
            {
                if (artRec.Article == null) artRec.Article = _articles.FirstOrDefault(t => t.IDArticle == artRec.IDArticle);
                receipt.ArtRec.Add(artRec);
            }
            return receipt;
        }

        public List<ReceiptModel> GetFilteredReceipts(DateTime timeFrom, DateTime timeTo)
        {
            return _receipts.Where(t => t.Date.Date <= timeTo.Date && t.Date.Date >= timeFrom.Date).ToList();
        }

        #endregion

        public void DeleteReceipt(int receiptID)
        {
            ReceiptModel receipt = FindReceiptByID(receiptID);

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(receipt);
                    transaction.Commit();
                }
            }

            _receipts.Remove(receipt);
            NotifyObservers();
        }

        public void AddReceipt(DateTime date, int waiterID, int paymentID, int userID, float totalCost, float discount)
        {
            ReceiptModel receipt = new ReceiptModel();

            receipt.IDReceipt = GetNewReceiptID();
            receipt.Date = date;
            receipt.IDWaiter = waiterID;
            receipt.IDPaymentMethod = paymentID;
            receipt.IDUser = userID;
            receipt.TotalCost = totalCost;
            receipt.Discount = discount;

            using (Facade facade = new Facade())
            {
                facade.InsertReceipt(receipt);
            }

            _receipts.Add(receipt);
            NotifyObservers();
        }

        public int GetNewReceiptID()
        {
            if (_receipts.Count() == 0) LoadReceipts();
            return _receipts.OrderBy(t => t.IDReceipt).Last().IDReceipt + 1; //zadnji plus 1
        }

        public ReceiptModel AddReceiptWithArticles(ReceiptModel receipt)
        {
            receipt.IDReceipt = GetNewReceiptID();
            if (receipt.ArtRec == null) return null;
            if (receipt.ArtRec.Count < 1) return null;

            List<ArticleReceiptModel> artRecList = receipt.ArtRec.ToList();

            receipt.ArtRec = new List<ArticleReceiptModel>();

            using (Facade facade = new Facade())
            {
                facade.InsertReceipt(receipt);
            }

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach(ArticleReceiptModel artRec in artRecList)
                    {
                        artRec.IDReceipt = receipt.IDReceipt;
                        artRec.Receipt = receipt;
                        artRec.IDArticle = artRec.Article.IDArticle;
                        artRec.PriceOfOne = artRec.Article.Price;
                        session.Save(artRec);
                    }
                    transaction.Commit();
                }
            }

            _receipts.Add(receipt);
            NotifyObservers();
            return receipt;
        }

        


        #region ArticleReceipt methods

        public void AddArtRec(int receiptID, int articleID, int quantity, float priceOfOne)
        {
            ArticleReceiptModel artRec = new ArticleReceiptModel();

            artRec.IDArticle = articleID;
            artRec.IDReceipt = receiptID;
            artRec.Quantity = quantity;
            artRec.PriceOfOne = priceOfOne;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(artRec);
                    transaction.Commit();
                }
            }

            _artRec.Add(artRec);
            NotifyObservers();
        }

        public void UpdateArtRec(int ID, int receiptID, int articleID, int quantity, float priceOfOne)
        {
            ArticleReceiptModel artRec = new ArticleReceiptModel();

            artRec.IDArticle = articleID;
            artRec.IDReceipt = receiptID;
            artRec.ID = ID;
            artRec.Quantity = quantity;
            artRec.PriceOfOne = priceOfOne;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(artRec);
                    transaction.Commit();
                }
            }

            NotifyObservers();
        }

        public void DeleteArtRec(int ID)
        {
            ArticleReceiptModel artRec = FindArtRecByID(ID);

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(artRec);
                    transaction.Commit();
                }
            }

            _artRec.Remove(artRec);
            NotifyObservers();
        }

        public ArticleReceiptModel FindArtRecByID(int ID)
        {
            return _artRec.Where(a => a.ID == ID).First();
        }
        #endregion
        


        #region Current User and Waiter methods

        public void SetCurrentUser(UserModel user)
        {
            _currentUser = user;
        }

        public void SetCurrentWaiter(WaiterModel waiter)
        {
            _currentWaiter = waiter;
        }

        #endregion
    }
}
