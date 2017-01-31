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
    public partial class FormTablesList : Form
    {
        IMainController _mainController;
        ICaffeRepository _caffeRepository;
        IList<TableModel> _tablesList;
        public FormTablesList(IMainController mainController, ICaffeRepository caffeRepository)
        {
            _mainController = mainController;
            _caffeRepository = caffeRepository;
            InitializeComponent();

            _tablesList = caffeRepository.ListAllTablesInCaffe(_mainController.GetCurrentCaffeId());

            refreshTablesList();
        }

        private void dgvTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnAccept.PerformClick();
            }
        }

        private void refreshTablesList()
        {
            dgvTables.Rows.Clear();
            foreach(TableModel table in _tablesList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvTables);
                row.Cells[0].Value = table.IDTable;
                row.Cells[1].Value = table.IsOccupied;
                dgvTables.Rows.Add(row);
            }
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<TableModel> updateList = new List<TableModel>();
            foreach(DataGridViewRow row in dgvTables.Rows)
            {
                TableModel current = _tablesList.FirstOrDefault(t => t.IDTable == (int)row.Cells[0].Value);
                current.IsOccupied = (bool)row.Cells[1].Value;
                updateList.Add(current);
            }
            if (updateList.Count > 0)
            {
                _caffeRepository.UpdateListTables(updateList);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
