﻿namespace KonobApp.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainWindow));
            this.btnActivateOrders = new System.Windows.Forms.Button();
            this.btnArticles = new System.Windows.Forms.Button();
            this.btnNewReceipt = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lvOrders = new System.Windows.Forms.ListView();
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
            this.gbTables = new System.Windows.Forms.GroupBox();
            this.btnTables = new System.Windows.Forms.Button();
            this.lblTablesOccupied = new System.Windows.Forms.Label();
            this.lblTablesAvailable = new System.Windows.Forms.Label();
            this.lblTablesOccupiedName = new System.Windows.Forms.Label();
            this.lblTableAvailableName = new System.Windows.Forms.Label();
            this.cbSound = new System.Windows.Forms.CheckBox();
            this.gbUserData.SuspendLayout();
            this.gbTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActivateOrders
            // 
            this.btnActivateOrders.Location = new System.Drawing.Point(337, 184);
            this.btnActivateOrders.Name = "btnActivateOrders";
            this.btnActivateOrders.Size = new System.Drawing.Size(155, 39);
            this.btnActivateOrders.TabIndex = 0;
            this.btnActivateOrders.Text = "Aktiviraj narudžbe";
            this.btnActivateOrders.UseVisualStyleBackColor = true;
            this.btnActivateOrders.Click += new System.EventHandler(this.btnActivateOrders_Click);
            // 
            // btnArticles
            // 
            this.btnArticles.Location = new System.Drawing.Point(337, 294);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Size = new System.Drawing.Size(232, 53);
            this.btnArticles.TabIndex = 1;
            this.btnArticles.Text = "Pregled inventara (I)";
            this.btnArticles.UseVisualStyleBackColor = true;
            this.btnArticles.Click += new System.EventHandler(this.btnArticles_Click);
            // 
            // btnNewReceipt
            // 
            this.btnNewReceipt.Location = new System.Drawing.Point(337, 353);
            this.btnNewReceipt.Name = "btnNewReceipt";
            this.btnNewReceipt.Size = new System.Drawing.Size(232, 53);
            this.btnNewReceipt.TabIndex = 2;
            this.btnNewReceipt.Text = "Novi račun (R)";
            this.btnNewReceipt.UseVisualStyleBackColor = true;
            this.btnNewReceipt.Click += new System.EventHandler(this.btnNewReceipt_Click);
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
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colTime,
            this.colTotal});
            this.lvOrders.Location = new System.Drawing.Point(15, 32);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(316, 356);
            this.lvOrders.TabIndex = 6;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
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
            this.lblConnection.Location = new System.Drawing.Point(334, 137);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(86, 17);
            this.lblConnection.TabIndex = 9;
            this.lblConnection.Text = "Stanje veze:";
            // 
            // lblConnectionInfo
            // 
            this.lblConnectionInfo.AutoSize = true;
            this.lblConnectionInfo.Location = new System.Drawing.Point(426, 137);
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.Size = new System.Drawing.Size(195, 17);
            this.lblConnectionInfo.TabIndex = 10;
            this.lblConnectionInfo.Text = "Aktivna/Spajanje/Nije spojeno";
            // 
            // btnViewReceipts
            // 
            this.btnViewReceipts.Location = new System.Drawing.Point(337, 412);
            this.btnViewReceipts.Name = "btnViewReceipts";
            this.btnViewReceipts.Size = new System.Drawing.Size(232, 53);
            this.btnViewReceipts.TabIndex = 11;
            this.btnViewReceipts.Text = "Pregled računa (P)";
            this.btnViewReceipts.UseVisualStyleBackColor = true;
            this.btnViewReceipts.Click += new System.EventHandler(this.btnViewReceipts_Click);
            // 
            // gbTables
            // 
            this.gbTables.Controls.Add(this.btnTables);
            this.gbTables.Controls.Add(this.lblTablesOccupied);
            this.gbTables.Controls.Add(this.lblTablesAvailable);
            this.gbTables.Controls.Add(this.lblTablesOccupiedName);
            this.gbTables.Controls.Add(this.lblTableAvailableName);
            this.gbTables.Location = new System.Drawing.Point(15, 394);
            this.gbTables.Name = "gbTables";
            this.gbTables.Size = new System.Drawing.Size(316, 70);
            this.gbTables.TabIndex = 12;
            this.gbTables.TabStop = false;
            this.gbTables.Text = "Stanje stolova:";
            // 
            // btnTables
            // 
            this.btnTables.Location = new System.Drawing.Point(172, 18);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(138, 34);
            this.btnTables.TabIndex = 4;
            this.btnTables.Text = "Pregled stolova (S)";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // lblTablesOccupied
            // 
            this.lblTablesOccupied.AutoSize = true;
            this.lblTablesOccupied.Location = new System.Drawing.Point(71, 35);
            this.lblTablesOccupied.Name = "lblTablesOccupied";
            this.lblTablesOccupied.Size = new System.Drawing.Size(87, 17);
            this.lblTablesOccupied.TabIndex = 3;
            this.lblTablesOccupied.Text = "brojZauzetih";
            // 
            // lblTablesAvailable
            // 
            this.lblTablesAvailable.AutoSize = true;
            this.lblTablesAvailable.Location = new System.Drawing.Point(71, 18);
            this.lblTablesAvailable.Name = "lblTablesAvailable";
            this.lblTablesAvailable.Size = new System.Drawing.Size(95, 17);
            this.lblTablesAvailable.TabIndex = 2;
            this.lblTablesAvailable.Text = "brojSlobodnih";
            // 
            // lblTablesOccupiedName
            // 
            this.lblTablesOccupiedName.AutoSize = true;
            this.lblTablesOccupiedName.Location = new System.Drawing.Point(6, 35);
            this.lblTablesOccupiedName.Name = "lblTablesOccupiedName";
            this.lblTablesOccupiedName.Size = new System.Drawing.Size(59, 17);
            this.lblTablesOccupiedName.TabIndex = 1;
            this.lblTablesOccupiedName.Text = "Zauzeti:";
            // 
            // lblTableAvailableName
            // 
            this.lblTableAvailableName.AutoSize = true;
            this.lblTableAvailableName.Location = new System.Drawing.Point(6, 18);
            this.lblTableAvailableName.Name = "lblTableAvailableName";
            this.lblTableAvailableName.Size = new System.Drawing.Size(52, 17);
            this.lblTableAvailableName.TabIndex = 0;
            this.lblTableAvailableName.Text = "Prazni:";
            // 
            // cbSound
            // 
            this.cbSound.AutoSize = true;
            this.cbSound.Checked = true;
            this.cbSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSound.Location = new System.Drawing.Point(337, 157);
            this.cbSound.Name = "cbSound";
            this.cbSound.Size = new System.Drawing.Size(140, 21);
            this.cbSound.TabIndex = 13;
            this.cbSound.Text = "Zvuk za obavijest";
            this.cbSound.UseVisualStyleBackColor = true;
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 476);
            this.Controls.Add(this.cbSound);
            this.Controls.Add(this.gbTables);
            this.Controls.Add(this.btnViewReceipts);
            this.Controls.Add(this.lblConnectionInfo);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.gbUserData);
            this.Controls.Add(this.lvOrders);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnNewReceipt);
            this.Controls.Add(this.btnArticles);
            this.Controls.Add(this.btnActivateOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KonobApp - Glavni izbornik";
            this.Load += new System.EventHandler(this.FormMainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainWindow_KeyDown);
            this.gbUserData.ResumeLayout(false);
            this.gbUserData.PerformLayout();
            this.gbTables.ResumeLayout(false);
            this.gbTables.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActivateOrders;
        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.Button btnNewReceipt;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.ListView lvOrders;
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
        private System.Windows.Forms.GroupBox gbTables;
        private System.Windows.Forms.Label lblTableAvailableName;
        private System.Windows.Forms.Label lblTablesOccupiedName;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Label lblTablesOccupied;
        private System.Windows.Forms.Label lblTablesAvailable;
        private System.Windows.Forms.CheckBox cbSound;
    }
}

