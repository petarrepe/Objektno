namespace KonobApp.Forms
{
    partial class FormArticlesList
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
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.colArticleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCloseAndSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticles
            // 
            this.dgvArticles.AllowUserToAddRows = false;
            this.dgvArticles.AllowUserToDeleteRows = false;
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArticleId,
            this.colArticleName,
            this.colPrice,
            this.colAvailable});
            this.dgvArticles.Location = new System.Drawing.Point(12, 12);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowTemplate.Height = 24;
            this.dgvArticles.Size = new System.Drawing.Size(593, 350);
            this.dgvArticles.TabIndex = 0;
            // 
            // colArticleId
            // 
            this.colArticleId.HeaderText = "(Id)";
            this.colArticleId.Name = "colArticleId";
            this.colArticleId.Width = 50;
            // 
            // colArticleName
            // 
            this.colArticleName.HeaderText = "Naziv";
            this.colArticleName.Name = "colArticleName";
            this.colArticleName.ReadOnly = true;
            this.colArticleName.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Cijena";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colAvailable
            // 
            this.colAvailable.HeaderText = "Dostupan";
            this.colAvailable.Name = "colAvailable";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(310, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(206, 41);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Zatvori (ESC)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseAndSave
            // 
            this.btnCloseAndSave.Location = new System.Drawing.Point(98, 368);
            this.btnCloseAndSave.Name = "btnCloseAndSave";
            this.btnCloseAndSave.Size = new System.Drawing.Size(206, 41);
            this.btnCloseAndSave.TabIndex = 2;
            this.btnCloseAndSave.Text = "Spremi i zatvori (ENT)";
            this.btnCloseAndSave.UseVisualStyleBackColor = true;
            this.btnCloseAndSave.Click += new System.EventHandler(this.btnCloseAndSave_Click);
            // 
            // FormArticlesList
            // 
            this.AcceptButton = this.btnCloseAndSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(617, 421);
            this.ControlBox = false;
            this.Controls.Add(this.btnCloseAndSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvArticles);
            this.Name = "FormArticlesList";
            this.ShowIcon = false;
            this.Text = "FormArticlesList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCloseAndSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAvailable;
    }
}