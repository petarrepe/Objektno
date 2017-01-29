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
        void SetNewCurrentReceipt();
        void AddArticleToCurrentReceipt(int articleId, int amount);
        void RemoveArticleFromCurrentReceipt(int articleId);
        void SetPaymentMethodToCurrentReceipt(int paymentMethodId);
        string ValidateCurrentReceipt();
        void SaveCurrentReceiptChanges();
        IList<ArticleModel> GetFastArticleSearchResult(string searchString);

        void SetCurrentUser(UserModel user);
        void SetCurrentWaiter(WaiterModel waiter);

        void SetCaffeOpened(CaffeModel caffeModel);
        void SetCaffeClosed(CaffeModel caffeModel);
    }
}
