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
    public partial class FormNewReceipt : Form, IObserver
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
            refreshListView();
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
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    btnDelete.PerformClick();
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }
        }

        public void UpdateView()
        {
            refreshListView();
        }

        private void refreshListView()
        {
            double total = 0;
            lvArticles.Items.Clear();
            foreach(ArticleReceiptModel artRec in _receiptRepository.CurrentReceipt.ArtRec)
            {
                ListViewItem item = new ListViewItem();
                item.Text = artRec.IDArticle.ToString();
                item.SubItems.Add(artRec.Article.Name);
                item.SubItems.Add(artRec.Quantity.ToString());
                item.SubItems.Add(artRec.PriceOfOne.ToString("0.00"));
                item.SubItems.Add((artRec.PriceOfOne * artRec.Quantity).ToString("0.00"));
                lvArticles.Items.Add(item);
                total += artRec.PriceOfOne * artRec.Quantity;
            }
            tbTotal.Text = total.ToString("0.00");
        }
    }
}
