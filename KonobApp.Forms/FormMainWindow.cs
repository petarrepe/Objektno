﻿using KonobApp.Interfaces;
using KonobApp.Model.Models;
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
        List<ReceiptModel> ordersList;

        public FormMainWindow(IMainController mainController)
        {
            _mainController = mainController;
            _mainController.FormMainWindow = this;
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
            _mainController.LoadAll();
            lblUsername.Text = _mainController.Login();
        }

        private void btnActivateOrders_Click(object sender, EventArgs e)
        {
            lblConnectionInfo.Text = "Spajanje...";
            lblConnectionInfo.ForeColor = Color.Orange;
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
                string notificationSoundPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Sounds\NotificationSound.wav";
                SoundPlayer notificationSound = new SoundPlayer(notificationSoundPath);
                notificationSound.Play();
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

        private void btnTables_Click(object sender, EventArgs e)
        {
            _mainController.ShowTables();
        }
    }
}
