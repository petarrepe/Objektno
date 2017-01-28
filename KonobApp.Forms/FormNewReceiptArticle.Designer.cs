namespace KonobApp.Forms
{
    partial class FormNewReceiptArticle
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvArticles = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResults = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(13, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Pretraga:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(86, 16);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(243, 22);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(17, 286);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(154, 39);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Unesi artikl (ENT)";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(177, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 39);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Odustani (ESC)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvArticles
            // 
            this.lvArticles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colPrice});
            this.lvArticles.Location = new System.Drawing.Point(15, 102);
            this.lvArticles.MultiSelect = false;
            this.lvArticles.Name = "lvArticles";
            this.lvArticles.Size = new System.Drawing.Size(314, 178);
            this.lvArticles.TabIndex = 4;
            this.lvArticles.UseCompatibleStateImageBehavior = false;
            this.lvArticles.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "(Id)";
            this.colId.Width = 50;
            // 
            // colName
            // 
            this.colName.Text = "Naziv";
            this.colName.Width = 200;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Cijena";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(13, 82);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(125, 17);
            this.lblResults.TabIndex = 5;
            this.lblResults.Text = "Rezultati pretrage:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 53);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(61, 17);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Količina:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(86, 51);
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(243, 22);
            this.numAmount.TabIndex = 7;
            // 
            // FormNewReceiptArticle
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(343, 337);
            this.ControlBox = false;
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lvArticles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.KeyPreview = true;
            this.Name = "FormNewReceiptArticle";
            this.ShowIcon = false;
            this.Text = "Pretraga artikala";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormNewReceiptArticle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvArticles;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
    }
}