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

            BindingList<ArticleModel> bindingList = new System.ComponentModel.BindingList<ArticleModel>(_caffeRepository.ListArticlesInCaffe((int)Properties.Settings.Default["CaffeId"]));
            dgvArticles.DataSource = bindingList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCloseAndSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
