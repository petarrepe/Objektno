using KonobApp.Interfaces;
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
    public partial class FormMainWindow : Form
    {
        IMainController _mainController;
        public FormMainWindow(IMainController mainController)
        {
            _mainController = mainController;

            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _mainController.Login();
        }

        private void btnArticles_Click(object sender, EventArgs e)
        {
            _mainController.ShowArticles();
        }

        private void btnNewReceipt_Click(object sender, EventArgs e)
        {
            _mainController.NewReceipt();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            _mainController.ShowOptions();
        }

        private void FormMainWindow_Load(object sender, EventArgs e)
        {
            _mainController.CreateDatabase();
            _mainController.LoadAll();
            _mainController.Login();
        }

        private void btnActivateOrders_Click(object sender, EventArgs e)
        {
            _mainController.ChangeNotificationState();
        }
    }
}
