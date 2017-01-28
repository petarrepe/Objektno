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
    public partial class FormNewReceiptArticle : Form
    {
        IMainController _mainController;
        IReceiptRepository _receiptRepository;

        
        public FormNewReceiptArticle(IMainController mainController, IReceiptRepository receiptRepository)
        {
            _mainController = mainController;
            _receiptRepository = receiptRepository;

            InitializeComponent();

            numAmount.Value = 1;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (lvArticles.Items.Count < 1)
            {
                MessageBox.Show("Pretraga nije našla rezultate, nije moguće staviti artikl u račun.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index = lvArticles.SelectedIndices[0];
            int articleId = Int32.Parse(lvArticles.Items[index].SubItems[0].Text);
            int amount = (int)numAmount.Value;
            _receiptRepository.AddArticleToCurrentReceipt(articleId, amount);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNewReceiptArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Add)
            {
                numAmount.Value += 1;
                e.SuppressKeyPress = true;
            } else if (e.KeyCode == Keys.Subtract)
            {
                if (numAmount.Value > 1)
                {
                    numAmount.Value -= 1;
                    e.SuppressKeyPress = true;
                }
                    
            } else if (e.KeyCode == Keys.Up)
            {
                int index = lvArticles.SelectedIndices[0];
                if (index < lvArticles.Items.Count - 1)
                {
                    lvArticles.Items[index + 1].Focused = true;
                    lvArticles.Items[index + 1].Selected = true;
                }
                // select up in list view
            } else if (e.KeyCode == Keys.Down)
            {
                int index = lvArticles.SelectedIndices[0];
                if (index > 0)
                {
                    lvArticles.Items[index + 1].Focused = true;
                    lvArticles.Items[index + 1].Selected = true;
                }
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                FormNewReceiptArticle_KeyDown(sender, e);
                return;
            }
            if (String.IsNullOrEmpty(tbSearch.Text))
            {
                fillArticleListView(_receiptRepository.Articles);
            } else
            {
                fillArticleListView(_receiptRepository.GetFastArticleSearchResult(tbSearch.Text));
            }
        }

        private void fillArticleListView(IList<ArticleModel> articles)
        {
            lvArticles.Items.Clear();
            foreach(ArticleModel article in articles)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(article.IDArticle.ToString());
                item.SubItems.Add(article.Name);
                item.SubItems.Add(article.Price.ToString());
            }
        }
    }
}
