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
    public partial class FormReceiptsList : Form, IObserver
    {
        private IMainController _mainController;
        private IReceiptRepository _receiptRepository;
        public FormReceiptsList(IMainController mainController, IReceiptRepository receiptRepository)
        {
            _mainController = mainController;
            _receiptRepository = receiptRepository;

            InitializeComponent();

            updateReceiptList();
        }

        public void UpdateView()
        {
            updateReceiptList();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            updateReceiptList();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            updateReceiptList();
        }

        private void updateReceiptList()
        {
            double total = 0;
            lvReceipts.Items.Clear();
            List<ReceiptModel> receiptList = _receiptRepository.GetFilteredReceipts(dtpFrom.Value, dtpTo.Value);
            if (receiptList.Count > 0)
            {
                foreach (ReceiptModel receipt in receiptList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = receipt.IDReceipt.ToString();
                    item.SubItems[0].Text = receipt.Date.ToString();
                    item.SubItems[1].Text = receipt.TotalCost.ToString("0.00");
                    lvReceipts.Items.Add(item);
                    total += receipt.TotalCost;
                }
                lvReceipts.Items[0].Selected = true;
                if (lvReceipts.Items[0].Text != tbId.Text) updateCurrentReceipt();
            }
            tbTotalFiltered.Text = total.ToString("0.00");
        }

        private void updateCurrentReceipt()
        {
            lvArticles.Items.Clear();
            if (lvReceipts.Items.Count < 1)
            {
                tbWaiter.Text = string.Empty;
                tbUser.Text = string.Empty;
                tbPaymentMethod.Text = string.Empty;
                tbDiscount.Text = string.Empty;
                tbTotal.Text = string.Empty;
            } else
            {
                if (lvReceipts.SelectedItems.Count < 1)
                {
                    lvReceipts.Items[0].Selected = true;
                }
                

                int receiptId;
                if (!Int32.TryParse(lvReceipts.SelectedItems[0].Text, out receiptId))
                {
                    MessageBox.Show("Greška prilikom učitavanja identifikacijskog broja računa sa popisa", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbWaiter.Text = string.Empty;
                    tbUser.Text = string.Empty;
                    tbPaymentMethod.Text = string.Empty;
                    tbDiscount.Text = string.Empty;
                    lvArticles.Items.Clear();
                    tbTotal.Text = string.Empty;
                } else
                {
                    ReceiptModel receipt = _receiptRepository.FindReceiptByID(receiptId);

                    tbWaiter.Text = receipt.Waiter.GetFullName();

                    if (receipt.User != null) tbUser.Text = receipt.User.GetFullName();
                    else tbUser.Text = string.Empty;

                    tbPaymentMethod.Text = receipt.PaymentMethod.TypePaymentMethod;
                    tbDiscount.Text = receipt.Discount.ToString("0.00") + "%";
                    tbTotal.Text = receipt.TotalCost.ToString("0.00");

                    double total = 0;
                    foreach (ArticleReceiptModel artRec in receipt.ArtRec)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = artRec.IDArticle.ToString();
                        item.SubItems[0].Text = artRec.Article.Name;
                        item.SubItems[1].Text = artRec.PriceOfOne.ToString("0.00");
                        item.SubItems[2].Text = artRec.Quantity.ToString();
                        item.SubItems[3].Text = (artRec.PriceOfOne * artRec.Quantity).ToString("0.00");
                        lvArticles.Items.Add(item);
                        total += artRec.PriceOfOne * artRec.Quantity;
                    }

                    tbTotal.Text = total.ToString("0.00");
                }
            }
        }
    }
}
