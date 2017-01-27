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
        IList<ReceiptModel> Receipts { get; }
        IList<ArticleModel> Articles { get; }
        ReceiptModel CurrentReceipt { get; }
        UserModel CurrentUser { get; }
        WaiterModel CurrentWaiter { get; }

        void LoadAll();
        void LoadArticles();
        void LoadReceipts();

        void SetCurrentReceipt(int receiptId);
        void AddArticleToCurrentReceipt(int articleId);
        void RemoveArticleFromCurrentReceipt(int articleId);
        void SetPaymentMethodToCurrentReceipt(int paymentMethodId);
        void SaveCurrentReceiptChanges();

        void SetCurrentUser(UserModel user);
        void SetCurrentWaiter(WaiterModel waiter);
    }
}
