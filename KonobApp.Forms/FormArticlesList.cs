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
        IArticleRepository _articleRepository;
        public FormArticlesList(IMainController mainController, IArticleRepository articleRepository)
        {
            _mainController = mainController;
            _articleRepository = articleRepository;

            InitializeComponent();

            BindingList<ArticleModel> bindingList = _articleRepository.GetArticlesBindingList();
            dgvArticles.DataSource = bindingList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseAndSave_Click(object sender, EventArgs e)
        {

        }
    }
}
