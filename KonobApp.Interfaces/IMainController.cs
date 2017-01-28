using KonobApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonobApp.Interfaces
{
    public interface IMainController
    {
        void LoadAll();
        void Login();
        bool CheckCredentials(Form form, string username, string password);

        void ShowReceipts();
        void NewReceipt();
        void NewReceipt(ReceiptModel receipt);
        void AddReceipt();
        void UpdateReceipt(int receiptId);
        void DeleteReceipt(int receiptId);

        void ShowArticles();
        void SetArticleAvailable(int articleId);
        void SetArticleUnavailable(int articleId);

        void ShowOptions();
        void ChangeNotificationState();
        bool IsNotificationConnectionActive();
    }
}
