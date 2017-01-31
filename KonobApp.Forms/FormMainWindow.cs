using DAL.Repositories;
using KonobApp.Interfaces;
using KonobApp.Model.Models;
using KonobApp.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonobApp.Forms
{
    public partial class FormMainWindow : Form
    {
        IMainController _mainController;
        CaffeRepository _caffeRepository;
        CaffeModel _currentCaffe;
        List<ReceiptModel> ordersList;

        public FormMainWindow(IMainController mainController)
        {
            _mainController = mainController;
            _mainController.FormMainWindow = this;
            _caffeRepository = CaffeRepository.GetInstance();
            InitializeComponent();

            ordersList = new List<ReceiptModel>();
            cbSound.Checked = true;

            if (_mainController.IsNotificationConnectionActive())
            {
                lblConnectionInfo.Text = "Aktivna";
                lblConnectionInfo.ForeColor = Color.Green;
                btnActivateOrders.Text = "Odspoji";
            } else
            {
                lblConnectionInfo.Text = "Nije spojeno";
                lblConnectionInfo.ForeColor = Color.Red;
                btnActivateOrders.Text = "Aktiviraj narudžbe";
            }

            //if ((int)Properties.Settings.Default["CaffeId"] == -1)
            //{
            //    _mainController.ShowOptions();
            //}
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            lblUsername.Text = _mainController.Login();
            _currentCaffe = _caffeRepository.FindCaffeByID(_mainController.GetCurrentCaffeId());
            refreshTablesInfo();
        }

        private void btnArticles_Click(object sender, EventArgs e)
        {
            _mainController.ShowArticles();
        }

        private void btnNewReceipt_Click(object sender, EventArgs e)
        {
            _mainController.NewReceipt();
        }

        private void FormMainWindow_Load(object sender, EventArgs e)
        {
          
            //_mainController.InitialLoadAll();
            string username = _mainController.Login();
            if (String.IsNullOrEmpty((username)))
            {
                Application.Exit();
            }
            else
            {
                lblUsername.Text = username;
                _currentCaffe = _caffeRepository.FindCaffeByID(_mainController.GetCurrentCaffeId());
                lblCaffe.Text = _currentCaffe.Name;
                refreshTablesInfo();
            }
            
        }

        private void btnActivateOrders_Click(object sender, EventArgs e)
        {
            if (_mainController.IsNotificationConnectionActive())
            {
                lblConnectionInfo.Text = "Odspajanje...";
            } else
            {
                lblConnectionInfo.Text = "Spajanje...";
            }
            lblConnectionInfo.ForeColor = Color.Orange;
            this.Refresh();
            _mainController.ChangeNotificationState();
            btnActivateOrders.Enabled = false;
            if (_mainController.IsNotificationConnectionActive())
            {
                lblConnectionInfo.Text = "Aktivna";
                lblConnectionInfo.ForeColor = Color.Green;
                btnActivateOrders.Text = "Odspoji";
                
            } else
            {
                lblConnectionInfo.Text = "Nije spojeno";
                lblConnectionInfo.ForeColor = Color.Red;
                btnActivateOrders.Text = "Aktiviraj narudžbe";
            }
            btnActivateOrders.Enabled = true;
        }

        private void btnViewReceipts_Click(object sender, EventArgs e)
        {
            _mainController.ShowReceipts();
        }

        private void FormMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.I:
                    _mainController.ShowArticles();
                    break;
                case Keys.R:
                    _mainController.NewReceipt();
                    break;
                case Keys.P:
                    _mainController.ShowReceipts();
                    break;
                case Keys.S:
                    _mainController.ShowTables();
                    break;
            }
        }

        public void AddNewOrder(ReceiptModel receipt)
        {
            ordersList.Add(receipt);
            ordersList = ordersList.OrderBy(t => t.Date).ToList();
            refreshOrdersList();
            if (cbSound.Checked)
            {
                playNotificationSound();
            }
        }

        private void refreshOrdersList()
        {
            lvOrders.Items.Clear();
            
            foreach(ReceiptModel order in ordersList)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[1].Text = order.Date.TimeOfDay.ToString();
                item.SubItems[2].Text = order.TotalCost.ToString("0.00");
                lvOrders.Items.Add(item);
            }
            // TODO!
        }

        private void refreshTablesInfo()
        {
            List<TableModel> tables = _caffeRepository.ListAllTablesInCaffe(_currentCaffe.IDCaffe).ToList();
            lblTablesAvailable.Text = tables.Where(t => !t.IsOccupied).Count().ToString();
            lblTablesOccupied.Text = tables.Where(t => t.IsOccupied).Count().ToString();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            _mainController.ShowTables();
            refreshTablesInfo();
        }

        private void playNotificationSound()
        {
            string notificationSoundPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            notificationSoundPath = notificationSoundPath.Substring(0, notificationSoundPath.Length - 20) + @"KonobApp.Forms\Sounds\NotificationSound.wav";
            try
            {
                SoundPlayer notificationSound = new SoundPlayer(notificationSoundPath);
                notificationSound.Play();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\nNotification sound path:" + notificationSoundPath);
            }
        }
    }
}
