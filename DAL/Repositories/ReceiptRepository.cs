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

        private ReceiptModel _currentReceipt;
        private UserModel _currentUser;
        private WaiterModel _currentWaiter;

        public IList<ReceiptModel> Receipts { get { return _receipts; } }
        public IList<ArticleModel> Articles { get { return _articles; } }
        public IList<PaymentMethodModel> PaymentMethods { get { return _paymentMethods; } }

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

            if (_articles == null) LoadArticles();
            if (_paymentMethods == null) LoadPaymentMethods();

            // punjenje podataka o articlima:
            foreach(ReceiptModel receipt in _receipts)
            {
                receipt.ArtRec = artRecList.Where(t => t.IDReceipt == receipt.IDReceipt).ToList();
                foreach(ArticleReceiptModel artRec in receipt.ArtRec)
                {
                    artRec.Article = _articles.FirstOrDefault(t => t.IDArticle == artRec.IDArticle);
                }
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

        #endregion

        #region Current Receipt methods
        public void SetCurrentReceipt(int receiptId)
        {
            _currentReceipt = _receipts.FirstOrDefault(t => t.IDReceipt == receiptId);
        }

        public void AddArticleToCurrentReceipt(int articleId)
        {
            if (_articles == null)
            {
                LoadArticles();
            }
            if (_currentReceipt == null)
            {
                return;
            }
            ArticleModel articleToAdd = _articles.FirstOrDefault(t => t.IDArticle == articleId);
            if (articleToAdd == null)
            {
                return;
            }
            _currentReceipt.Articles.Add(articleToAdd);
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
        }

        public void SetPaymentMethodToCurrentReceipt(int paymentMethodId)
        {
            if (_paymentMethods == null) LoadPaymentMethods();
        }

        public void SaveCurrentReceiptChanges()
        {
            throw new NotImplementedException();
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
