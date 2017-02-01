namespace KonobApp.Forms
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
            this.tbUser = new System.Windows.Forms.TextBox();
            this.gbGeneralData = new System.Windows.Forms.GroupBox();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lvArticles = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriceSingle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblArticles = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.btnNewArticle = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAmountPlus = new System.Windows.Forms.Button();
            this.btnAmountMinus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbGeneralData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
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
            this.tbWaiter.Location = new System.Drawing.Point(134, 25);
            this.tbWaiter.Name = "tbWaiter";
            this.tbWaiter.Size = new System.Drawing.Size(295, 22);
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
            // tbUser
            // 
            this.tbUser.Enabled = false;
            this.tbUser.Location = new System.Drawing.Point(134, 53);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(295, 22);
            this.tbUser.TabIndex = 3;
            // 
            // gbGeneralData
            // 
            this.gbGeneralData.Controls.Add(this.numDiscount);
            this.gbGeneralData.Controls.Add(this.cbPaymentMethod);
            this.gbGeneralData.Controls.Add(this.lblDiscount);
            this.gbGeneralData.Controls.Add(this.lblPaymentMethod);
            this.gbGeneralData.Controls.Add(this.lblWaiter);
            this.gbGeneralData.Controls.Add(this.tbUser);
            this.gbGeneralData.Controls.Add(this.tbWaiter);
            this.gbGeneralData.Controls.Add(this.lblUser);
            this.gbGeneralData.Location = new System.Drawing.Point(12, 12);
            this.gbGeneralData.Name = "gbGeneralData";
            this.gbGeneralData.Size = new System.Drawing.Size(435, 148);
            this.gbGeneralData.TabIndex = 4;
            this.gbGeneralData.TabStop = false;
            this.gbGeneralData.Text = "Osnovne informacije:";
            // 
            // numDiscount
            // 
            this.numDiscount.Location = new System.Drawing.Point(134, 111);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(295, 22);
            this.numDiscount.TabIndex = 7;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(134, 81);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(295, 24);
            this.cbPaymentMethod.TabIndex = 6;
            this.cbPaymentMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPaymentMethod_KeyDown);
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
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(15, 84);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(105, 17);
            this.lblPaymentMethod.TabIndex = 4;
            this.lblPaymentMethod.Text = "Način plačanja:";
            // 
            // lvArticles
            // 
            this.lvArticles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colAmount,
            this.colPriceSingle,
            this.colTotal});
            this.lvArticles.FullRowSelect = true;
            this.lvArticles.GridLines = true;
            this.lvArticles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvArticles.HideSelection = false;
            this.lvArticles.Location = new System.Drawing.Point(12, 183);
            this.lvArticles.MultiSelect = false;
            this.lvArticles.Name = "lvArticles";
            this.lvArticles.Size = new System.Drawing.Size(435, 226);
            this.lvArticles.TabIndex = 5;
            this.lvArticles.UseCompatibleStateImageBehavior = false;
            this.lvArticles.View = System.Windows.Forms.View.Details;
            this.lvArticles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvArticles_KeyDown);
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
            this.lblTotal.Location = new System.Drawing.Point(238, 455);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 17);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Ukupno:";
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Location = new System.Drawing.Point(305, 452);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(100, 22);
            this.tbTotal.TabIndex = 8;
            // 
            // btnNewArticle
            // 
            this.btnNewArticle.Location = new System.Drawing.Point(61, 415);
            this.btnNewArticle.Name = "btnNewArticle";
            this.btnNewArticle.Size = new System.Drawing.Size(166, 28);
            this.btnNewArticle.TabIndex = 9;
            this.btnNewArticle.Text = "Novi artikl (N)";
            this.btnNewArticle.UseVisualStyleBackColor = true;
            this.btnNewArticle.Click += new System.EventHandler(this.btnNewArticle_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(61, 498);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(166, 42);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Gotov unos (ENT)";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(233, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 42);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Odustani (ESC)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(61, 449);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(166, 28);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Izbriši odabrano (DEL)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAmountPlus
            // 
            this.btnAmountPlus.Location = new System.Drawing.Point(305, 418);
            this.btnAmountPlus.Name = "btnAmountPlus";
            this.btnAmountPlus.Size = new System.Drawing.Size(31, 23);
            this.btnAmountPlus.TabIndex = 13;
            this.btnAmountPlus.Text = "+";
            this.btnAmountPlus.UseVisualStyleBackColor = true;
            this.btnAmountPlus.Click += new System.EventHandler(this.btnAmountPlus_Click);
            // 
            // btnAmountMinus
            // 
            this.btnAmountMinus.Location = new System.Drawing.Point(342, 418);
            this.btnAmountMinus.Name = "btnAmountMinus";
            this.btnAmountMinus.Size = new System.Drawing.Size(31, 23);
            this.btnAmountMinus.TabIndex = 14;
            this.btnAmountMinus.Text = "-";
            this.btnAmountMinus.UseVisualStyleBackColor = true;
            this.btnAmountMinus.Click += new System.EventHandler(this.btnAmountMinus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Količina:";
            // 
            // FormNewReceipt
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(459, 552);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAmountMinus);
            this.Controls.Add(this.btnAmountPlus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnNewArticle);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblArticles);
            this.Controls.Add(this.lvArticles);
            this.Controls.Add(this.gbGeneralData);
            this.Name = "FormNewReceipt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNewReceipt";
            this.Load += new System.EventHandler(this.FormNewReceipt_Load);
            this.gbGeneralData.ResumeLayout(false);
            this.gbGeneralData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWaiter;
        private System.Windows.Forms.TextBox tbWaiter;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.GroupBox gbGeneralData;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ListView lvArticles;
        private System.Windows.Forms.Label lblArticles;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Button btnNewArticle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colPriceSingle;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAmountPlus;
        private System.Windows.Forms.Button btnAmountMinus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
    }
}