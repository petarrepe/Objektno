using KonobApp.Interfaces;
using KonobApp.Model;
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

        private IList<Receipt> _receipts = new List<Receipt>();
        private IList<Article> _articles = new List<Article>();
        private Receipt _currentReceipt;
        private User _currentUser;
        private Waiter _currentWaiter;

        public IList<Article> Articles { get { return _articles; } }

        public Receipt CurrentReceipt { get { return _currentReceipt; } }
        public User CurrentUser { get { return _currentUser; } }
        public Waiter CurrentWaiter { get { return _currentWaiter; } }
        public IList<Receipt> Receipts { get { return _receipts; } }

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
            using (ISession nhibernateSession = NHibernateService.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Article");
                _articles = query.List<Article>();
            }
        }

        public void LoadReceipts()
        {
            using (ISession nhibernateSession = NHibernateService.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Receipt");
                _receipts = query.List<Receipt>();
            }
        }
    }
}
