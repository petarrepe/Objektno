namespace KonobApp.Forms
{
    partial class FormReceiptsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.gbDateFilter = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.gbCurrentBill = new System.Windows.Forms.GroupBox();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblArticles = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriceOne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tbPaymentMethod = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbWaiter = new System.Windows.Forms.TextBox();
            this.lblWaiter = new System.Windows.Forms.Label();
            this.lblTotalFiltered = new System.Windows.Forms.Label();
            this.tbTotalFiltered = new System.Windows.Forms.TextBox();
            this.gbDateFilter.SuspendLayout();
            this.gbCurrentBill.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(9, 26);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(31, 17);
            this.lblDateFrom.TabIndex = 0;
            this.lblDateFrom.Text = "Od:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(9, 54);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(30, 17);
            this.lblDateTo.TabIndex = 1;
            this.lblDateTo.Text = "Do:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(55, 21);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(55, 49);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 22);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // gbDateFilter
            // 
            this.gbDateFilter.Controls.Add(this.dtpTo);
            this.gbDateFilter.Controls.Add(this.lblDateFrom);
            this.gbDateFilter.Controls.Add(this.dtpFrom);
            this.gbDateFilter.Controls.Add(this.lblDateTo);
            this.gbDateFilter.Location = new System.Drawing.Point(12, 12);
            this.gbDateFilter.Name = "gbDateFilter";
            this.gbDateFilter.Size = new System.Drawing.Size(268, 92);
            this.gbDateFilter.TabIndex = 4;
            this.gbDateFilter.TabStop = false;
            this.gbDateFilter.Text = "Filter:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 110);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(268, 312);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // gbCurrentBill
            // 
            this.gbCurrentBill.Controls.Add(this.tbTotal);
            this.gbCurrentBill.Controls.Add(this.lblTotal);
            this.gbCurrentBill.Controls.Add(this.lblArticles);
            this.gbCurrentBill.Controls.Add(this.listView2);
            this.gbCurrentBill.Controls.Add(this.tbDiscount);
            this.gbCurrentBill.Controls.Add(this.tbPaymentMethod);
            this.gbCurrentBill.Controls.Add(this.tbUser);
            this.gbCurrentBill.Controls.Add(this.lblDiscount);
            this.gbCurrentBill.Controls.Add(this.lblPaymentMethod);
            this.gbCurrentBill.Controls.Add(this.lblUser);
            this.gbCurrentBill.Controls.Add(this.tbWaiter);
            this.gbCurrentBill.Controls.Add(this.lblWaiter);
            this.gbCurrentBill.Location = new System.Drawing.Point(286, 12);
            this.gbCurrentBill.Name = "gbCurrentBill";
            this.gbCurrentBill.Size = new System.Drawing.Size(466, 456);
            this.gbCurrentBill.TabIndex = 6;
            this.gbCurrentBill.TabStop = false;
            this.gbCurrentBill.Text = "Odabrani račun:";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(312, 428);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(148, 22);
            this.tbTotal.TabIndex = 11;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(245, 431);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 17);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Ukupno:";
            // 
            // lblArticles
            // 
            this.lblArticles.AutoSize = true;
            this.lblArticles.Location = new System.Drawing.Point(9, 139);
            this.lblArticles.Name = "lblArticles";
            this.lblArticles.Size = new System.Drawing.Size(106, 17);
            this.lblArticles.TabIndex = 9;
            this.lblArticles.Text = "Artikli u računu:";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colPriceOne,
            this.colAmount,
            this.colTotalPrice});
            this.listView2.Location = new System.Drawing.Point(6, 162);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(454, 260);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "(Id)";
            // 
            // colName
            // 
            this.colName.Text = "Naziv";
            this.colName.Width = 150;
            // 
            // colPriceOne
            // 
            this.colPriceOne.Text = "Cij. pojed.";
            this.colPriceOne.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Količina";
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Text = "Ukupna cijena";
            this.colTotalPrice.Width = 80;
            // 
            // tbDiscount
            // 
            this.tbDiscount.Location = new System.Drawing.Point(145, 105);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.ReadOnly = true;
            this.tbDiscount.Size = new System.Drawing.Size(254, 22);
            this.tbDiscount.TabIndex = 7;
            // 
            // tbPaymentMethod
            // 
            this.tbPaymentMethod.Location = new System.Drawing.Point(145, 77);
            this.tbPaymentMethod.Name = "tbPaymentMethod";
            this.tbPaymentMethod.ReadOnly = true;
            this.tbPaymentMethod.Size = new System.Drawing.Size(254, 22);
            this.tbPaymentMethod.TabIndex = 6;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(145, 49);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(254, 22);
            this.tbUser.TabIndex = 5;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(6, 108);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(115, 17);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Popust (0-100%)";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(6, 80);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(105, 17);
            this.lblPaymentMethod.TabIndex = 3;
            this.lblPaymentMethod.Text = "Način plačanja:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 52);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(101, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Korisnik (web):";
            // 
            // tbWaiter
            // 
            this.tbWaiter.Enabled = false;
            this.tbWaiter.Location = new System.Drawing.Point(145, 21);
            this.tbWaiter.Name = "tbWaiter";
            this.tbWaiter.ReadOnly = true;
            this.tbWaiter.Size = new System.Drawing.Size(254, 22);
            this.tbWaiter.TabIndex = 1;
            // 
            // lblWaiter
            // 
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Location = new System.Drawing.Point(6, 24);
            this.lblWaiter.Name = "lblWaiter";
            this.lblWaiter.Size = new System.Drawing.Size(66, 17);
            this.lblWaiter.TabIndex = 0;
            this.lblWaiter.Text = "Konobar:";
            // 
            // lblTotalFiltered
            // 
            this.lblTotalFiltered.AutoSize = true;
            this.lblTotalFiltered.Location = new System.Drawing.Point(8, 425);
            this.lblTotalFiltered.Name = "lblTotalFiltered";
            this.lblTotalFiltered.Size = new System.Drawing.Size(186, 17);
            this.lblTotalFiltered.TabIndex = 7;
            this.lblTotalFiltered.Text = "Ukupno svih računa sa liste:";
            // 
            // tbTotalFiltered
            // 
            this.tbTotalFiltered.Enabled = false;
            this.tbTotalFiltered.Location = new System.Drawing.Point(12, 446);
            this.tbTotalFiltered.Name = "tbTotalFiltered";
            this.tbTotalFiltered.ReadOnly = true;
            this.tbTotalFiltered.Size = new System.Drawing.Size(182, 22);
            this.tbTotalFiltered.TabIndex = 8;
            // 
            // FormReceiptsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 479);
            this.Controls.Add(this.tbTotalFiltered);
            this.Controls.Add(this.lblTotalFiltered);
            this.Controls.Add(this.gbCurrentBill);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.gbDateFilter);
            this.Name = "FormReceiptsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KonobApp - Pregled računa";
            this.gbDateFilter.ResumeLayout(false);
            this.gbDateFilter.PerformLayout();
            this.gbCurrentBill.ResumeLayout(false);
            this.gbCurrentBill.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.GroupBox gbDateFilter;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox gbCurrentBill;
        private System.Windows.Forms.Label lblWaiter;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblArticles;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPriceOne;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colTotalPrice;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TextBox tbPaymentMethod;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbWaiter;
        private System.Windows.Forms.Label lblTotalFiltered;
        private System.Windows.Forms.TextBox tbTotalFiltered;
    }
}