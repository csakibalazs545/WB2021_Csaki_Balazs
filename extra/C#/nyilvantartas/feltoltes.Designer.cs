namespace nyilvantartas
{
    partial class feltoltes
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
            this.txbazon = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txbvezetek = new System.Windows.Forms.TextBox();
            this.lblfirm = new System.Windows.Forms.Label();
            this.lblmodel = new System.Windows.Forms.Label();
            this.lblsimicc = new System.Windows.Forms.Label();
            this.txbanyja = new System.Windows.Forms.TextBox();
            this.txbadoszam = new System.Windows.Forms.TextBox();
            this.txbkereszt = new System.Windows.Forms.TextBox();
            this.btnvissza = new System.Windows.Forms.Button();
            this.btnmentes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbazon
            // 
            this.txbazon.Enabled = false;
            this.txbazon.Location = new System.Drawing.Point(99, 69);
            this.txbazon.Name = "txbazon";
            this.txbazon.Size = new System.Drawing.Size(202, 20);
            this.txbazon.TabIndex = 88;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(60, 72);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(33, 13);
            this.lbl1.TabIndex = 87;
            this.lbl1.Text = "azon:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(26, 105);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(67, 13);
            this.lbl2.TabIndex = 86;
            this.lbl2.Text = "Vezetéknév:";
            // 
            // txbvezetek
            // 
            this.txbvezetek.Location = new System.Drawing.Point(99, 98);
            this.txbvezetek.Name = "txbvezetek";
            this.txbvezetek.Size = new System.Drawing.Size(202, 20);
            this.txbvezetek.TabIndex = 85;
            // 
            // lblfirm
            // 
            this.lblfirm.AutoSize = true;
            this.lblfirm.Location = new System.Drawing.Point(30, 203);
            this.lblfirm.Name = "lblfirm";
            this.lblfirm.Size = new System.Drawing.Size(63, 13);
            this.lblfirm.TabIndex = 84;
            this.lblfirm.Text = "Anyja neve:";
            // 
            // lblmodel
            // 
            this.lblmodel.AutoSize = true;
            this.lblmodel.Location = new System.Drawing.Point(43, 168);
            this.lblmodel.Name = "lblmodel";
            this.lblmodel.Size = new System.Drawing.Size(53, 13);
            this.lblmodel.TabIndex = 83;
            this.lblmodel.Text = "Adoszám:";
            // 
            // lblsimicc
            // 
            this.lblsimicc.AutoSize = true;
            this.lblsimicc.Location = new System.Drawing.Point(32, 140);
            this.lblsimicc.Name = "lblsimicc";
            this.lblsimicc.Size = new System.Drawing.Size(63, 13);
            this.lblsimicc.TabIndex = 82;
            this.lblsimicc.Text = "Keresztnév:";
            // 
            // txbanyja
            // 
            this.txbanyja.Location = new System.Drawing.Point(99, 203);
            this.txbanyja.Name = "txbanyja";
            this.txbanyja.Size = new System.Drawing.Size(202, 20);
            this.txbanyja.TabIndex = 81;
            // 
            // txbadoszam
            // 
            this.txbadoszam.Location = new System.Drawing.Point(99, 168);
            this.txbadoszam.Name = "txbadoszam";
            this.txbadoszam.Size = new System.Drawing.Size(202, 20);
            this.txbadoszam.TabIndex = 80;
            // 
            // txbkereszt
            // 
            this.txbkereszt.Location = new System.Drawing.Point(99, 133);
            this.txbkereszt.Name = "txbkereszt";
            this.txbkereszt.Size = new System.Drawing.Size(202, 20);
            this.txbkereszt.TabIndex = 79;
            // 
            // btnvissza
            // 
            this.btnvissza.Location = new System.Drawing.Point(277, 289);
            this.btnvissza.Name = "btnvissza";
            this.btnvissza.Size = new System.Drawing.Size(75, 23);
            this.btnvissza.TabIndex = 89;
            this.btnvissza.Text = "Vissza";
            this.btnvissza.UseVisualStyleBackColor = true;
            this.btnvissza.Click += new System.EventHandler(this.btnvissza_Click);
            // 
            // btnmentes
            // 
            this.btnmentes.Location = new System.Drawing.Point(46, 289);
            this.btnmentes.Name = "btnmentes";
            this.btnmentes.Size = new System.Drawing.Size(75, 23);
            this.btnmentes.TabIndex = 90;
            this.btnmentes.Text = "Mentés";
            this.btnmentes.UseVisualStyleBackColor = true;
            this.btnmentes.Click += new System.EventHandler(this.btnmentes_Click);
            // 
            // feltoltes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 321);
            this.Controls.Add(this.btnmentes);
            this.Controls.Add(this.btnvissza);
            this.Controls.Add(this.txbazon);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txbvezetek);
            this.Controls.Add(this.lblfirm);
            this.Controls.Add(this.lblmodel);
            this.Controls.Add(this.lblsimicc);
            this.Controls.Add(this.txbanyja);
            this.Controls.Add(this.txbadoszam);
            this.Controls.Add(this.txbkereszt);
            this.Name = "feltoltes";
            this.Text = "feltoltes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbazon;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txbvezetek;
        private System.Windows.Forms.Label lblfirm;
        private System.Windows.Forms.Label lblmodel;
        private System.Windows.Forms.Label lblsimicc;
        private System.Windows.Forms.TextBox txbanyja;
        private System.Windows.Forms.TextBox txbadoszam;
        private System.Windows.Forms.TextBox txbkereszt;
        private System.Windows.Forms.Button btnvissza;
        private System.Windows.Forms.Button btnmentes;
    }
}