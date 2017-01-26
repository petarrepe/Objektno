using KonobApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Repositories
{
    public interface IReceiptRepository
    {
        IList<Receipt> Receipts { get; }
        Receipt CurrentReceipt { get; }
        User CurrentUser { get; }
        Waiter CurrentWaiter { get; }

        void LoadAll();
        void LoadArticles();
    }
}
