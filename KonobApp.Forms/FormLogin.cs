using KonobApp.Interfaces;
using KonobApp.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonobApp.Forms
{
    public partial class FormLogin : Form
    {
        IMainController _mainController;
        IAccountRepository _accountRepository;
        public FormLogin(IMainController mainController, IAccountRepository accountRepository)
        {
            _mainController = mainController;
            _accountRepository = accountRepository;
            InitializeComponent();

            lblError.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_mainController.CheckCredentials(this, tbUsername.Text, tbPassword.Text))
            {
                lblError.Text = string.Empty;
                this.Close();
            } else
            {
                lblError.Text = "Krivi podaci upisani!";
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_mainController.CheckLoginSuccessStatus())
            {
                Application.Exit();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_mainController.CheckLoginSuccessStatus())
            {
                Application.Exit();
            }
        }
    }
}
