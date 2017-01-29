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
        List<ArticleInCaffeModel> _artInCaffeList;
        public FormArticlesList(IMainController mainController, ICaffeRepository caffeRepository)
        {
            _mainController = mainController;
            _caffeRepository = caffeRepository;

            InitializeComponent();

            _artInCaffeList = _caffeRepository.ArticlesInCaffe.Where(t => t.IDCaffe == _mainController.GetCurrentCaffeId()).ToList();
            fillDataGrid(_artInCaffeList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCloseAndSave_Click(object sender, EventArgs e)
        {
            List<ArticleInCaffeModel> editList = new List<ArticleInCaffeModel>();
            foreach (DataGridViewRow row in dgvArticles.Rows)
            {
                ArticleInCaffeModel current = _artInCaffeList.FirstOrDefault(t => t.IDArticle == (int)row.Cells[0].Value);
                if (current.IsAvailable != (bool)row.Cells[3].Value)
                {
                    editList.Add(current);
                }
            }
            if (editList.Count > 0)
            {
                _caffeRepository.UpdateListArtInCaff(editList);
            }
            this.Close();
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
