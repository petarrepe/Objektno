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
    public partial class FormInitialLoad : Form
    {
        public FormInitialLoad(int taskCount)
        {
            InitializeComponent();

            progressBar1.Maximum = taskCount;
            progressBar1.Value = 0;
        }

        public void SetInfoText(string infoText)
        {
            lblInfo.Text = infoText;
            Refresh();
        }

        public void IncrementProgressBar()
        {
            if (progressBar1.Maximum > progressBar1.Value)
                progressBar1.Value += 1;
            Refresh();
        }
    }
}
