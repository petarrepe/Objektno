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
            PaymentMethodModel payMet = (PaymentMethodModel)cbPaymentMethod.SelectedItem;
            _receiptRepository.SetPaymentMethodToCurrentReceipt(payMet.IDPaymentMethod);
            _receiptRepository.SetDiscountToCurrentReceipt((float)numDiscount.Value / 100);
            string errorMessage = _receiptRepository.ValidateCurrentReceipt();

            _mainController.SaveCurrentReceipt(this);
        }

        private void btnNewArticle_Click(object sender, EventArgs e)
        {
            _mainController.ShowAddArticleToNewReceipt();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvArticles.SelectedItems.Count < 1) return;

            int articleId;
            if (!Int32.TryParse(lvArticles.SelectedItems[0].Text, out articleId))
            {
                MessageBox.Show("Greška prilikom učitavanja identifikacijskog broja artikla.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _receiptRepository.RemoveArticleFromCurrentReceipt(articleId);
        }

        private void btnAmountPlus_Click(object sender, EventArgs e)
        {
            addAmountToCurrentlySelectedItem(1);
        }

        private void btnAmountMinus_Click(object sender, EventArgs e)
        {
            addAmountToCurrentlySelectedItem(-1);
        }

        private void addAmountToCurrentlySelectedItem(int value)
        {
            if (lvArticles.SelectedItems.Count < 1) return;
            int amount;
            if (!Int32.TryParse(lvArticles.SelectedItems[0].SubItems[2].Text, out amount))
            {
                MessageBox.Show("Greška prilikom učitavanja trenutne vrijednosti količine.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (amount < 2 && value < 0) return;

            int articleId;
            if (!Int32.TryParse(lvArticles.SelectedItems[0].Text, out articleId))
            {
                MessageBox.Show("Greška prilikom učitavanja identifikacijskog broja artikla.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _receiptRepository.AddAmountToArticleInReceipt(articleId, value);

            //if (value > 0) amount++;
            //else if (value < 0) amount--;

            //lvArticles.SelectedItems[0].SubItems[2].Text = amount.ToString();

            //Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Jeste li sigurni da želite odbaciti trenutni unos?", "Potvrda", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void cbPaymentMethod_KeyDown(object sender, KeyEventArgs e)
        {
            checkUserInputForShortcuts(e);
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
            if (lvArticles.Items.Count > 0)
            {
                lvArticles.Items[0].Selected = true;
            }
            tbTotal.Text = total.ToString("0.00");
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (numDiscount.Value > 100) numDiscount.Value = 100;
            if (numDiscount.Value < 0) numDiscount.Value = 0;
        }

        private void lvArticles_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkUserInputForShortcuts(e)) e.Handled = true;
        }

        private bool checkUserInputForShortcuts(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                btnAmountMinus.PerformClick();
                e.Handled = true;
                return true;
            }
            else if (e.KeyCode == Keys.Add)
            {
                btnAmountPlus.PerformClick();
                e.Handled = true;
                return true;
            }
            else if (e.KeyCode == Keys.N)
            {
                btnNewArticle.PerformClick();
                e.Handled = true;
                return true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
                e.Handled = true;
                return true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnAccept.PerformClick();
                e.Handled = true;
                return true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
                e.Handled = true;
                return true;
            }
            return false;
        }
    }
}
