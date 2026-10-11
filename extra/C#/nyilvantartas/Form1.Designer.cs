namespace nyilvantartas
{
    partial class Form1
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
            this.btnuj = new System.Windows.Forms.Button();
            this.btnmentes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMenu.Location = new System.Drawing.Point(25, 64);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(750, 322);
            this.panelMenu.TabIndex = 8;
            // 
            // btnuj
            // 
            this.btnuj.Location = new System.Drawing.Point(25, 413);
            this.btnuj.Name = "btnuj";
            this.btnuj.Size = new System.Drawing.Size(370, 23);
            this.btnuj.TabIndex = 9;
            this.btnuj.Text = "Új dolgozó felvétele";
            this.btnuj.UseVisualStyleBackColor = true;
            this.btnuj.Click += new System.EventHandler(this.btnuj_Click);
            // 
            // btnmentes
            // 
            this.btnmentes.Location = new System.Drawing.Point(401, 413);
            this.btnmentes.Name = "btnmentes";
            this.btnmentes.Size = new System.Drawing.Size(366, 23);
            this.btnmentes.TabIndex = 10;
            this.btnmentes.Text = "Adatok frissítése";
            this.btnmentes.UseVisualStyleBackColor = true;
            this.btnmentes.Click += new System.EventHandler(this.btnmentes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnmentes);
            this.Controls.Add(this.btnuj);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnuj;
        private System.Windows.Forms.Button btnmentes;
    }
}

