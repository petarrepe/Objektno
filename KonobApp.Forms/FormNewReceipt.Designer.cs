﻿namespace KonobApp.Forms
{
    partial class FormNewReceipt
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
            this.lblWaiter = new System.Windows.Forms.Label();
            this.tbWaiter = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbGeneralData = new System.Windows.Forms.GroupBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblArticles = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnNewArticle = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriceSingle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbGeneralData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWaiter
            // 
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.Location = new System.Drawing.Point(15, 28);
            this.lblWaiter.Name = "lblWaiter";
            this.lblWaiter.Size = new System.Drawing.Size(66, 17);
            this.lblWaiter.TabIndex = 0;
            this.lblWaiter.Text = "Konobar:";
            // 
            // tbWaiter
            // 
            this.tbWaiter.Enabled = false;
            this.tbWaiter.Location = new System.Drawing.Point(144, 25);
            this.tbWaiter.Name = "tbWaiter";
            this.tbWaiter.Size = new System.Drawing.Size(194, 22);
            this.tbWaiter.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(15, 56);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(101, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Korisnik (web):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 22);
            this.textBox1.TabIndex = 3;
            // 
            // gbGeneralData
            // 
            this.gbGeneralData.Controls.Add(this.numericUpDown1);
            this.gbGeneralData.Controls.Add(this.cbPaymentMethod);
            this.gbGeneralData.Controls.Add(this.lblDiscount);
            this.gbGeneralData.Controls.Add(this.lblPaymentMethod);
            this.gbGeneralData.Controls.Add(this.lblWaiter);
            this.gbGeneralData.Controls.Add(this.textBox1);
            this.gbGeneralData.Controls.Add(this.tbWaiter);
            this.gbGeneralData.Controls.Add(this.lblUser);
            this.gbGeneralData.Location = new System.Drawing.Point(12, 12);
            this.gbGeneralData.Name = "gbGeneralData";
            this.gbGeneralData.Size = new System.Drawing.Size(344, 148);
            this.gbGeneralData.TabIndex = 4;
            this.gbGeneralData.TabStop = false;
            this.gbGeneralData.Text = "Osnovne informacije:";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(15, 84);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(105, 17);
            this.lblPaymentMethod.TabIndex = 4;
            this.lblPaymentMethod.Text = "Način plačanja:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(15, 113);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(107, 17);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "Popust (0-100):";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(144, 81);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(194, 24);
            this.cbPaymentMethod.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(144, 111);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(194, 22);
            this.numericUpDown1.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colAmount,
            this.colPriceSingle,
            this.colTotal});
            this.listView1.Location = new System.Drawing.Point(12, 183);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(344, 226);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // lblArticles
            // 
            this.lblArticles.AutoSize = true;
            this.lblArticles.Location = new System.Drawing.Point(12, 163);
            this.lblArticles.Name = "lblArticles";
            this.lblArticles.Size = new System.Drawing.Size(101, 17);
            this.lblArticles.TabIndex = 6;
            this.lblArticles.Text = "Uneseni artikli:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(189, 424);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 17);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Ukupno:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(256, 421);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 8;
            // 
            // btnNewArticle
            // 
            this.btnNewArticle.Location = new System.Drawing.Point(12, 415);
            this.btnNewArticle.Name = "btnNewArticle";
            this.btnNewArticle.Size = new System.Drawing.Size(166, 28);
            this.btnNewArticle.TabIndex = 9;
            this.btnNewArticle.Text = "Novi artikl (N)";
            this.btnNewArticle.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(12, 498);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(166, 42);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Gotov unos (G)";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(184, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 42);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Odustani (E)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // colId
            // 
            this.colId.Text = "(Id)";
            this.colId.Width = 40;
            // 
            // colName
            // 
            this.colName.Text = "Naziv";
            this.colName.Width = 100;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Količina";
            // 
            // colPriceSingle
            // 
            this.colPriceSingle.Text = "Cij. pojed.";
            this.colPriceSingle.Width = 80;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Ukupno";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 449);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(166, 28);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Izbriši odabrano (DEL)";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // FormNewReceipt
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(368, 552);
            this.ControlBox = false;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnNewArticle);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblArticles);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.gbGeneralData);
            this.Name = "FormNewReceipt";
            this.ShowIcon = false;
            this.Text = "FormNewReceipt";
            this.gbGeneralData.ResumeLayout(false);
            this.gbGeneralData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWaiter;
        private System.Windows.Forms.TextBox tbWaiter;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbGeneralData;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblArticles;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnNewArticle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colPriceSingle;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Button btnDelete;
    }
}