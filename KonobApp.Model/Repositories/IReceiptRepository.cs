using KonobApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model
{
    public interface IReceiptRepository
    {
        IList<Receipt> Receipts { get; }
        IList<Article> Articles { get; }
        Receipt CurrentReceipt { get; }
        User CurrentUser { get; }
        Waiter CurrentWaiter { get; }

        void LoadAll();
        void LoadArticles();
        void LoadReceipts();
    }
}
