using KonobApp.Interfaces;
using KonobApp.Model;
using KonobApp.Model.Models;
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
    public partial class FormNewReceipt : Form
    {
        IMainController _mainController;
        IReceiptRepository _receiptRepository;

        public FormNewReceipt(IMainController mainController, IReceiptRepository receiptRepository)
        {
            _mainController = mainController;
            _receiptRepository = receiptRepository;
            _receiptRepository.SetNewCurrentReceipt();
            InitializeComponent();

            cbPaymentMethod.DataSource = _receiptRepository.PaymentMethods;
            cbPaymentMethod.DisplayMember = "TypePaymentMethod";
            cbPaymentMethod.ValueMember = "IDPaymentMethod";

            tbWaiter.Text = _mainController.GetCurrentWaiter().GetFullName();
            tbUser.Text = "-";
        }

        public FormNewReceipt(IMainController mainController, IReceiptRepository receiptRepository, ReceiptModel receipt)
        {
            _mainController = mainController;
            _receiptRepository = receiptRepository;
        }

        private void FormNewReceipt_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string errorMessage = _receiptRepository.ValidateCurrentReceipt();
            if (!String.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _receiptRepository.SaveCurrentReceiptChanges();
        }

        private void btnNewArticle_Click(object sender, EventArgs e)
        {
            _mainController.ShowAddArticleToNewReceipt();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAmountPlus_Click(object sender, EventArgs e)
        {

        }

        private void btnAmountMinus_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cbPaymentMethod_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    btnNewArticle.PerformClick();
                    e.SuppressKeyPress = true; ;
                    break;
                case Keys.Delete:
                    btnDelete.PerformClick();
                    e.SuppressKeyPress = true;
                    break;
            }
        }
    }
}
