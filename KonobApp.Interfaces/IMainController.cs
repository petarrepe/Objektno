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
        void InitialLoadAll();
        string Login();
        bool CheckCredentials(Form form, string username, string password);
        bool CheckLoginSuccessStatus();

        int GetCurrentCaffeId();
        WaiterModel GetCurrentWaiter();

        void ShowReceipts();
        void NewReceipt();
        void SaveCurrentReceipt(Form form);
        void NewReceipt(ReceiptModel receipt);
        void ShowAddArticleToNewReceipt();
        int AddArticleToNewReceipt(Form form, int articleId, int amount);
        void AddReceipt();
        void UpdateReceipt(int receiptId);
        void DeleteReceipt(int receiptId);

        void ShowArticles();

        void ShowTables();
        
        void ChangeNotificationState();
        bool IsNotificationConnectionActive();

        void AddNewOrder(ReceiptModel receiptModel);
    }
}
