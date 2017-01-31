using KonobApp.Model;
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
        public WaiterModel CurrentWaiter { get { return _currentWaiter; } }


        private ISession nhibernateSession;

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
                receipt.User = _users.Where(u => u.IDUser == receipt.IDUser).First();

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
        }

        public void SetNewCurrentReceipt()
        {
            _currentReceipt = new ReceiptModel
            {
                Date = DateTime.Now,
                Waiter = _currentWaiter,
                PaymentMethod = _paymentMethods.FirstOrDefault(t => t.TypePaymentMethod.ToLower() == "gotovina"),
                ArtRec = new List<ArticleReceiptModel>(),
                Articles = new List<ArticleModel>()
            };
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
            ArticleReceiptModel artInCaff = new ArticleReceiptModel
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
            _currentReceipt.ArtRec.Add(artInCaff);

            NotifyObservers();
        }

        public void RemoveArticleFromCurrentReceipt(int articleId)
        {
            if (_currentReceipt == null) return;

            ArticleModel articleToRemove = _currentReceipt.Articles.FirstOrDefault(t => t.IDArticle == articleId);
            if (articleToRemove == null)
            {
                return;
            }
            _currentReceipt.Articles.Remove(articleToRemove);
            NotifyObservers();
        }

        public void SetPaymentMethodToCurrentReceipt(int paymentMethodId)
        {
            if (_paymentMethods == null) LoadPaymentMethods();
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
            throw new NotImplementedException();
        }

        public IList<ArticleModel> GetFastArticleSearchResult(string searchString)
        {
            return _articles.Where(t => t.Name.ToLower().Contains(searchString) || t.IDArticle.ToString().Equals(searchString)).ToList();
        }

        public ReceiptModel FindReceiptByID(int ID)
        {
            return _receipts.Where(r => r.IDReceipt == ID).First();
        }

        #endregion

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
