using KonobApp.Interfaces;
using KonobApp.Model;
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
    public partial class FormReceiptsList : Form
    {
        IMainController _mainController;
        IReceiptRepository _receiptRepository;
        public FormReceiptsList(IMainController mainController, IReceiptRepository receiptRepository)
        {
            _mainController = mainController;
            _receiptRepository = receiptRepository;

            InitializeComponent();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
