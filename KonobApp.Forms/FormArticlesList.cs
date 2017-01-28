using KonobApp.Interfaces;
using KonobApp.Model.Models;
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
    public partial class FormArticlesList : Form
    {
        IMainController _mainController;
        ICaffeRepository _caffeRepository;
        public FormArticlesList(IMainController mainController, ICaffeRepository caffeRepository)
        {
            _mainController = mainController;
            _caffeRepository = caffeRepository;

            InitializeComponent();

            fillDataGrid(_caffeRepository.ArticlesInCaffe.Where(t => t.IDCaffe == _mainController.GetCurrentCaffeId()).ToList());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCloseAndSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void fillDataGrid(IList<ArticleInCaffeModel> list)
        {
            dgvArticles.Rows.Clear();
            foreach(ArticleInCaffeModel item in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvArticles);
                row.Cells[0].Value = item.IDArticle;
                row.Cells[1].Value = item.Article.Name;
                row.Cells[2].Value = item.Article.Price.ToString("0.00");
                row.Cells[3].Value = item.IsAvailable;
                dgvArticles.Rows.Add(row);
            }
        }
    }
}
