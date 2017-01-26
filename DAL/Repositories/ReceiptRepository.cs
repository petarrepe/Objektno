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
    class ReceiptRepository : Subject, IReceiptRepository
    {
        private static ReceiptRepository _instance = null;

        private IList<ReceiptModel> _receipts = new List<ReceiptModel>();
        private IList<ArticleModel> _articles = new List<ArticleModel>();
        private ReceiptModel _currentReceipt;
        private UserModel _currentUser;
        private WaiterModel _currentWaiter;

        public IList<ArticleModel> Articles { get { return _articles; } }

        public ReceiptModel CurrentReceipt { get { return _currentReceipt; } }
        public UserModel CurrentUser { get { return _currentUser; } }
        public WaiterModel CurrentWaiter { get { return _currentWaiter; } }
        public IList<ReceiptModel> Receipts { get { return _receipts; } }

        private ISession nhibernateSession;

        private ReceiptRepository()
        {

        }

        public static ReceiptRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReceiptRepository();
            }
            return _instance;
        }

        public void LoadAll()
        {
            LoadArticles();
            LoadReceipts();
        }

        public void LoadArticles()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Article");
                _articles = query.List<ArticleModel>();
            }
        }

        public void LoadReceipts()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Receipt");
                _receipts = query.List<ReceiptModel>();
            }
        }
    }
}
