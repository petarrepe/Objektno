namespace KonobApp.Forms
{
    partial class FormMainWindow
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
            this.btnActivateOrders = new System.Windows.Forms.Button();
            this.btnArticles = new System.Windows.Forms.Button();
            this.btnNewReceipt = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLogout = new System.Windows.Forms.Button();
            this.gbUserData = new System.Windows.Forms.GroupBox();
            this.lblCaffe = new System.Windows.Forms.Label();
            this.lblCaffeName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsernameName = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblConnectionInfo = new System.Windows.Forms.Label();
            this.btnViewReceipts = new System.Windows.Forms.Button();
            this.gbUserData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActivateOrders
            // 
            this.btnActivateOrders.Location = new System.Drawing.Point(337, 173);
            this.btnActivateOrders.Name = "btnActivateOrders";
            this.btnActivateOrders.Size = new System.Drawing.Size(155, 39);
            this.btnActivateOrders.TabIndex = 0;
            this.btnActivateOrders.Text = "Aktiviraj narudžbe";
            this.btnActivateOrders.UseVisualStyleBackColor = true;
            this.btnActivateOrders.Click += new System.EventHandler(this.btnActivateOrders_Click);
            // 
            // btnArticles
            // 
            this.btnArticles.Location = new System.Drawing.Point(337, 252);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Size = new System.Drawing.Size(232, 53);
            this.btnArticles.TabIndex = 1;
            this.btnArticles.Text = "Pregled inventara (I)";
            this.btnArticles.UseVisualStyleBackColor = true;
            this.btnArticles.Click += new System.EventHandler(this.btnArticles_Click);
            // 
            // btnNewReceipt
            // 
            this.btnNewReceipt.Location = new System.Drawing.Point(337, 311);
            this.btnNewReceipt.Name = "btnNewReceipt";
            this.btnNewReceipt.Size = new System.Drawing.Size(232, 53);
            this.btnNewReceipt.TabIndex = 2;
            this.btnNewReceipt.Text = "Novi račun (R)";
            this.btnNewReceipt.UseVisualStyleBackColor = true;
            this.btnNewReceipt.Click += new System.EventHandler(this.btnNewReceipt_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(459, 429);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(110, 35);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "Postavke";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Location = new System.Drawing.Point(12, 12);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(126, 17);
            this.lblOrders.TabIndex = 5;
            this.lblOrders.Text = "Pristigle narudžbe:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colTime,
            this.colTotal});
            this.listView1.Location = new System.Drawing.Point(15, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(316, 432);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "(Id:)";
            // 
            // colTime
            // 
            this.colTime.Text = "Vrijeme:";
            this.colTime.Width = 115;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total:";
            this.colTotal.Width = 100;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(6, 72);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(98, 44);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Odjavi se";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // gbUserData
            // 
            this.gbUserData.Controls.Add(this.lblCaffe);
            this.gbUserData.Controls.Add(this.lblCaffeName);
            this.gbUserData.Controls.Add(this.lblUsername);
            this.gbUserData.Controls.Add(this.btnLogout);
            this.gbUserData.Controls.Add(this.lblUsernameName);
            this.gbUserData.Location = new System.Drawing.Point(337, 12);
            this.gbUserData.Name = "gbUserData";
            this.gbUserData.Size = new System.Drawing.Size(232, 122);
            this.gbUserData.TabIndex = 8;
            this.gbUserData.TabStop = false;
            this.gbUserData.Text = "Prijavljeni korisnik";
            // 
            // lblCaffe
            // 
            this.lblCaffe.AutoSize = true;
            this.lblCaffe.Location = new System.Drawing.Point(74, 52);
            this.lblCaffe.Name = "lblCaffe";
            this.lblCaffe.Size = new System.Drawing.Size(37, 17);
            this.lblCaffe.TabIndex = 9;
            this.lblCaffe.Text = "kafić";
            // 
            // lblCaffeName
            // 
            this.lblCaffeName.AutoSize = true;
            this.lblCaffeName.Location = new System.Drawing.Point(6, 52);
            this.lblCaffeName.Name = "lblCaffeName";
            this.lblCaffeName.Size = new System.Drawing.Size(43, 17);
            this.lblCaffeName.TabIndex = 8;
            this.lblCaffeName.Text = "Kafić:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(74, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(93, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "korisničkoIme";
            // 
            // lblUsernameName
            // 
            this.lblUsernameName.AutoSize = true;
            this.lblUsernameName.Location = new System.Drawing.Point(6, 30);
            this.lblUsernameName.Name = "lblUsernameName";
            this.lblUsernameName.Size = new System.Drawing.Size(62, 17);
            this.lblUsernameName.TabIndex = 0;
            this.lblUsernameName.Text = "Korisnik:";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(334, 153);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(86, 17);
            this.lblConnection.TabIndex = 9;
            this.lblConnection.Text = "Stanje veze:";
            // 
            // lblConnectionInfo
            // 
            this.lblConnectionInfo.AutoSize = true;
            this.lblConnectionInfo.Location = new System.Drawing.Point(426, 153);
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.Size = new System.Drawing.Size(195, 17);
            this.lblConnectionInfo.TabIndex = 10;
            this.lblConnectionInfo.Text = "Aktivna/Spajanje/Nije spojeno";
            // 
            // btnViewReceipts
            // 
            this.btnViewReceipts.Location = new System.Drawing.Point(337, 370);
            this.btnViewReceipts.Name = "btnViewReceipts";
            this.btnViewReceipts.Size = new System.Drawing.Size(232, 53);
            this.btnViewReceipts.TabIndex = 11;
            this.btnViewReceipts.Text = "Pregled računa (P)";
            this.btnViewReceipts.UseVisualStyleBackColor = true;
            this.btnViewReceipts.Click += new System.EventHandler(this.btnViewReceipts_Click);
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 476);
            this.Controls.Add(this.btnViewReceipts);
            this.Controls.Add(this.lblConnectionInfo);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.gbUserData);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnNewReceipt);
            this.Controls.Add(this.btnArticles);
            this.Controls.Add(this.btnActivateOrders);
            this.KeyPreview = true;
            this.Name = "FormMainWindow";
            this.Text = "KonobApp - Glavni izbornik";
            this.Load += new System.EventHandler(this.FormMainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainWindow_KeyDown);
            this.gbUserData.ResumeLayout(false);
            this.gbUserData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActivateOrders;
        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.Button btnNewReceipt;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox gbUserData;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUsernameName;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label lblConnectionInfo;
        private System.Windows.Forms.Button btnViewReceipts;
        private System.Windows.Forms.Label lblCaffe;
        private System.Windows.Forms.Label lblCaffeName;
    }
}

