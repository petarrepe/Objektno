using KonobApp.Interfaces;
using KonobApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ReceiptRepository : Subject, IReceiptRepository
    {
        private IList<Receipt> _receipts;
        private IList<Article> _articles;

        public IList<Article> Articles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Receipt CurrentReceipt
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public User CurrentUser
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Waiter CurrentWaiter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<Receipt> Receipts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void LoadAll()
        {
            throw new NotImplementedException();
        }

        public void LoadArticles()
        {
            throw new NotImplementedException();
        }

        public void LoadReceipts()
        {
            throw new NotImplementedException();
        }
    }
}
