using DAL.Repositories;
using KonobApp.Forms;
using KonobApp.Interfaces;
using KonobApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonobApp.Controller
{
    public class MainController : IMainController
    {
        public bool LoginSuccessful = false;
        private bool _notificationConnectionActive = false;

        readonly ReceiptRepository _receiptRepository = ReceiptRepository.GetInstance();
        readonly AccountRepository _accountRepository = AccountRepository.GetInstance();

        public void LoadAll()
        {
            _receiptRepository.LoadAll();
        }

        #region Login

        public void Login()
        {
            LoginSuccessful = false;
            FormLogin formLogin = new FormLogin(this, _accountRepository);
        }

        public bool CheckCredentials(Form formLogin, string username, string password)
        {
            WaiterModel current = _accountRepository.CheckCredentials(username, password);

            if(current != null)
            {
                LoginSuccessful = true;
                formLogin.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Receipts

        public void ShowReceipts()
        {

        }

        public void NewReceipt()
        {

        }

        public void NewReceipt(ReceiptModel receipt)
        {

        }

        public void AddReceipt()
        {
            throw new NotImplementedException();
        }

        public void UpdateReceipt(int receiptId)
        {
            throw new NotImplementedException();
        }

        public void DeleteReceipt(int receiptId)
        {
            _receiptRepository.Receipts.Remove(_receiptRepository.Receipts.Where(t => t.IDReceipt == receiptId).First());
        }

        public void ShowArticles()
        {
            throw new NotImplementedException();
        }

        public void SetArticleAvailable(int articleId)
        {
            throw new NotImplementedException();
        }

        public void SetArticleUnavailable(int articleId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Options

        public void ShowOptions()
        {

        }

        public void ChangeNotificationState()
        {

        }

        public bool IsNotificationConnectionActive()
        {
            return _notificationConnectionActive;
        }

        #endregion

    }
}
