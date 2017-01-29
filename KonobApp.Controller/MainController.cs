﻿using DAL.Repositories;
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


        public MainController()
        {
            _notificationController = new NotificationController(this);
        }

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

        public void LoadAll()
        {
            _receiptRepository.LoadAll();
            _accountRepository.LoadWaiters();
            _caffeRepository.LoadAll();
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
            FormReceiptsList receiptsList = new FormReceiptsList(this, _receiptRepository);
            receiptsList.ShowDialog();
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

        public void SetArticleAvailable(int articleId)
        {
            throw new NotImplementedException();
        }

        public void SetArticleUnavailable(int articleId)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void ShowTables()
        {
            throw new NotImplementedException();
        }

        #region Options

        public void ShowOptions()
        {

        }
        

        public void ChangeNotificationState()
        {
            if (_notificationController.IsStarted)
            {
                _notificationController.StopListening();
                _caffeRepository.SetCaffeClosed(_currentCaffe);
            } else
            {
                _notificationController.StartListening();
                _caffeRepository.SetCaffeOpened(_currentCaffe);
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
