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
        IList<ReceiptModel> Receipts { get; }
        ReceiptModel CurrentReceipt { get; }
        UserModel CurrentUser { get; }
        WaiterModel CurrentWaiter { get; }

        void LoadAll();
        void LoadArticles();
    }
}
