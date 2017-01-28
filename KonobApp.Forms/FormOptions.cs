using KonobApp.Interfaces;
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
    public partial class FormOptions : Form
    {
        IMainController _mainController;
        ICaffeRepository _caffeRepository;
        public FormOptions(IMainController mainController, ICaffeRepository caffeRepository)
        {
            _mainController = mainController;
            _caffeRepository = caffeRepository;

            InitializeComponent();

            Dictionary<int, string> caffeDictionary = _caffeRepository.Caffes.OrderBy(t => t.Name).ToDictionary(t => t.IDCaffe, t => t.Name);
            cbCaffes.DataSource = caffeDictionary;
            cbCaffes.DisplayMember = "Value";
            cbCaffes.ValueMember = "Key";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int caffeId = (int)cbCaffes.SelectedValue;
            Properties.Settings.Default["CaffeId"] = caffeId;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
