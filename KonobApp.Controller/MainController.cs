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
        private WaiterModel _currentWaiter;
        private CaffeModel _currentCaffe;

        readonly ReceiptRepository _receiptRepository = ReceiptRepository.GetInstance();
        readonly AccountRepository _accountRepository = AccountRepository.GetInstance();
        readonly CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

        private NotificationController norificationController = new NotificationController();

        public int GetCurrentCaffeId()
        {
            if (_currentCaffe == null)
            {
                throw new NotImplementedException();
            } else
            {
                return _currentCaffe.IDCaffe;
            }
        }

        public void LoadAll()
        {
            _receiptRepository.LoadAll();
            _accountRepository.LoadWaiters();
            _caffeRepository.LoadAll();
            //_caffeRepository.LoadCaffe();
        }

        #region Login

        public string Login()
        {
            LoginSuccessful = false;
            FormLogin formLogin = new FormLogin(this, _accountRepository);
            formLogin.ShowDialog();

            if (_currentWaiter != null)
            {
                return _currentWaiter.GetFullName();
            } 
            else
            {
                return string.Empty;
            }
        }

        public bool CheckCredentials(Form formLogin, string username, string password)
        {
            WaiterModel current = _accountRepository.CheckCredentials(username, password);
            

            if(current != null)
            {
                _currentWaiter = current;
                _currentCaffe = _caffeRepository.FindCaffeByID(current.IDCaffe);
                LoginSuccessful = true;
                formLogin.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckLoginSuccessStatus()
        {
            return LoginSuccessful;
        }

        #endregion

        #region Receipts

        public void ShowReceipts()
        {

        }

        public void NewReceipt()
        {
            FormNewReceipt newReceipt = new FormNewReceipt(this, _receiptRepository);
            newReceipt.ShowDialog();
        }

        public void NewReceipt(ReceiptModel receipt)
        {

        }

        public void ShowAddArticleToNewReceipt()
        {
            FormNewReceiptArticle newRecArticle = new FormNewReceiptArticle(this, _receiptRepository);
            newRecArticle.ShowDialog();
        }

        public int AddArticleToNewReceipt(Form form, int articleId, int amount)
        {
            _receiptRepository.AddArticleToCurrentReceipt(articleId, amount);
            form.Close();

            // TODO: ovo ne valja, ispraviti
            return articleId;
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

        #endregion

        #region Articles

        public void ShowArticles()
        {
            FormArticlesList formArticlesList = new FormArticlesList(this, _caffeRepository);
            formArticlesList.ShowDialog();
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
