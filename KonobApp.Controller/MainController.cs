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
        private WaiterModel _currentWaiter;
        private CaffeModel _currentCaffe;

        readonly ReceiptRepository _receiptRepository = ReceiptRepository.GetInstance();
        readonly AccountRepository _accountRepository = AccountRepository.GetInstance();
        readonly CaffeRepository _caffeRepository = CaffeRepository.GetInstance();

        private NotificationController _notificationController;

        private FormMainWindow _formMainWindow;

        

        #region Constructors
        public MainController()
        {
            _notificationController = new NotificationController(this);
        }

        #endregion

        #region Public Variables

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

        public WaiterModel GetCurrentWaiter()
        {
            return _currentWaiter;
        }

        #endregion

        

        public Form FormMainWindow
        {
            set
            {
                if (value.GetType() == typeof(FormMainWindow))
                {
                    
                    _formMainWindow = (FormMainWindow)value;
                }
            }
        }

        #region Load

        public void InitialLoadAll()
        {
            FormInitialLoad initialForm = new FormInitialLoad(3);
            initialForm.Show();

            initialForm.SetInfoText("Učitavanje računa...");
            _receiptRepository.LoadAll();
            initialForm.IncrementProgressBar();

            initialForm.SetInfoText("Učitavanje korisničkih računa...");
            _accountRepository.LoadWaiters();
            initialForm.IncrementProgressBar();

            initialForm.SetInfoText("Učitavanje podataka o kafiću...");
            _caffeRepository.LoadAll();
            initialForm.IncrementProgressBar();

            initialForm.SetInfoText("Gotovo!");
            initialForm.Close();
        }

        public void LoadAll()
        {
            _receiptRepository.LoadAll();
            _accountRepository.LoadWaiters();
            _caffeRepository.LoadAll();
        }

        #endregion

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
                _receiptRepository.CurrentWaiter = _currentWaiter;
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
            FormReceiptsList receiptsList = new FormReceiptsList(this, _receiptRepository);
            receiptsList.ShowDialog();
        }

        public void NewReceipt()
        {
            FormNewReceipt newReceipt = new FormNewReceipt(this, _receiptRepository);
            _receiptRepository.Attatch(newReceipt);
            newReceipt.ShowDialog();
            _receiptRepository.Delete(newReceipt);
        }

        public void SaveCurrentReceipt(Form form)
        {
            string message = _receiptRepository.ValidateCurrentReceipt();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _receiptRepository.SaveCurrentReceiptChanges();
            form.Close();
        }

        public void NewReceipt(ReceiptModel receipt)
        {

        }

        public void ShowAddArticleToNewReceipt()
        {
            FormNewReceiptArticle newRecArticle = new FormNewReceiptArticle(this, _receiptRepository, _caffeRepository);
            
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


        #endregion

        #region Tables
        public void ShowTables()
        {
            FormTablesList formTables = new FormTablesList(this, _caffeRepository);
            formTables.ShowDialog();
        }

        #endregion


        #region Notifications
        

        public void ChangeNotificationState()
        {
            if (_notificationController.IsStarted)
            {
                try
                {
                    _notificationController.StopListening();
                    _caffeRepository.SetCaffeClosed(_currentCaffe);
                } catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            } else
            {
                try
                {
                    _notificationController.StartListening();
                    _caffeRepository.SetCaffeOpened(_currentCaffe);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        public bool IsNotificationConnectionActive()
        {
            return _notificationController.IsStarted;
        }

        #endregion


        #region Orders

        public void AddNewOrder(ReceiptModel receiptModel)
        {

        }

        #endregion
    }
}
