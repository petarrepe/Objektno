﻿using KonobApp.Model.Models;
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
        IList<ArticleReceiptModel> ArticleReceipts { get; }

        ReceiptModel CurrentReceipt { get; }
        UserModel CurrentUser { get; }
        WaiterModel CurrentWaiter { get; }

        void LoadAll();
        void LoadArticles();
        void LoadReceipts();
        void LoadArtRec();

        void AddArtRec(int receiptID, int articleID, int quantity, float priceOfOne);
        void UpdateArtRec(int ID, int receiptID, int articleID, int quantity, float priceOfOne);
        void DeleteArtRec(int ID);

        void SetCurrentReceipt(int receiptId);
        void SetNewCurrentReceipt();
        void AddArticleToCurrentReceipt(int articleId, int amount);
        void RemoveArticleFromCurrentReceipt(int articleId);
        void SetPaymentMethodToCurrentReceipt(int paymentMethodId);
        string ValidateCurrentReceipt();
        void SaveCurrentReceiptChanges();
        IList<ArticleModel> GetFastArticleSearchResult(string searchString);
        ArticleReceiptModel FindArtRecByID(int ID);
        ReceiptModel FindReceiptByID(int ID);
        void SetCurrentUser(UserModel user);
        void SetCurrentWaiter(WaiterModel waiter);
    }
}
