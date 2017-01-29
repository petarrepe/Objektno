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
        Form FormMainWindow { set; }
        void LoadAll();
        string Login();
        bool CheckCredentials(Form form, string username, string password);
        bool CheckLoginSuccessStatus();

        int GetCurrentCaffeId();

        void ShowReceipts();
        void NewReceipt();
        void NewReceipt(ReceiptModel receipt);
        void ShowAddArticleToNewReceipt();
        int AddArticleToNewReceipt(Form form, int articleId, int amount);
        void AddReceipt();
        void UpdateReceipt(int receiptId);
        void DeleteReceipt(int receiptId);

        void ShowArticles();
        void SetArticleAvailable(int articleId);
        void SetArticleUnavailable(int articleId);

        void ShowTables();

        void ShowOptions();
        void ChangeNotificationState();
        bool IsNotificationConnectionActive();

        void AddNewOrder(ReceiptModel receiptModel);
    }
}
