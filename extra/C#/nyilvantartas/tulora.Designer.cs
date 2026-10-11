namespace nyilvantartas
{
    partial class tulora
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.txbtuloraora = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txbpenz = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMenu.Location = new System.Drawing.Point(25, 38);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(750, 322);
            this.panelMenu.TabIndex = 9;
            // 
            // txbtuloraora
            // 
            this.txbtuloraora.Enabled = false;
            this.txbtuloraora.Location = new System.Drawing.Point(323, 378);
            this.txbtuloraora.Name = "txbtuloraora";
            this.txbtuloraora.Size = new System.Drawing.Size(202, 20);
            this.txbtuloraora.TabIndex = 92;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(244, 378);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(73, 13);
            this.lbl1.TabIndex = 91;
            this.lbl1.Text = "Összes túlóra:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(244, 410);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(77, 13);
            this.lbl2.TabIndex = 90;
            this.lbl2.Text = "túlóra kifizetés:";
            // 
            // txbpenz
            // 
            this.txbpenz.Location = new System.Drawing.Point(323, 407);
            this.txbpenz.Name = "txbpenz";
            this.txbpenz.Size = new System.Drawing.Size(202, 20);
            this.txbpenz.TabIndex = 89;
            // 
            // tulora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbtuloraora);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txbpenz);
            this.Controls.Add(this.panelMenu);
            this.Name = "tulora";
            this.Text = "tulora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.TextBox txbtuloraora;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txbpenz;
    }
}