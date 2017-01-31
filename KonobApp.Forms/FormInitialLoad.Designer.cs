namespace KonobApp.Forms
{
    partial class FormInitialLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInitialLoad));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWelcome.Location = new System.Drawing.Point(85, 37);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(226, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Dobrodošli u KonobApp!";
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Location = new System.Drawing.Point(85, 85);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(226, 17);
            this.lblPleaseWait.TabIndex = 1;
            this.lblPleaseWait.Text = "Učitavanje baze, molimo pričekajte";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(90, 154);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(221, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(87, 133);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(45, 17);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "lblInfo";
            // 
            // FormInitialLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 236);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.lblWelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInitialLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInitialLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblInfo;
    }
}