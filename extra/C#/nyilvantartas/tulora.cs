using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nyilvantartas
{
    public partial class tulora : Form
    {
        private readonly int adottazon;
        public tulora(int adottazon)
        {
            InitializeComponent();
            this.adottazon = adottazon;






        Panel alap = new Panel();
            alap.Width = panelMenu.Width - 25;
            alap.Height = 40;
            alap.Location = new Point(10, 0);
            alap.BackColor = Color.Green;


            TextBox munkakezdeteszoveg = new TextBox();
            munkakezdeteszoveg.Text = "Munka kezdete";
            munkakezdeteszoveg.Location = new Point(54, 10);
            munkakezdeteszoveg.Width = 80;
            munkakezdeteszoveg.Enabled = false;


            TextBox munkavegeszoveg = new TextBox();
            munkavegeszoveg.Text = "Munka vége:";
            munkavegeszoveg.Location = new Point(145, 10);
            munkavegeszoveg.Width = 80;
            munkavegeszoveg.Enabled = false;

            TextBox tuloraszoveg = new TextBox();
            tuloraszoveg.Text = "Keresztnév";
            tuloraszoveg.Location = new Point(255, 10);
            tuloraszoveg.Width = 80;
            tuloraszoveg.Enabled = false;


            alap.Controls.Add(munkakezdeteszoveg);
            alap.Controls.Add(munkavegeszoveg);
            alap.Controls.Add(tuloraszoveg);
            panelMenu.Controls.Add(alap);



            MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "mysql",
                Database = "nyilvantartas"
            };

            using (MySqlConnection kapcsolat = new MySqlConnection(build.ConnectionString))
            {
                try
                {
                    kapcsolat.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Adatbetöltési hiba.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var parancs = kapcsolat.CreateCommand();
                parancs.CommandText = @"
                SELECT munkakezdet, munkavege, tulora
                FROM tulora
                WHERE azon = @azon";
                parancs.Parameters.AddWithValue("@azon", adottazon);
                using (var reader = parancs.ExecuteReader())
                {
                    if (reader.Read())
                    {


                        DateTime munkakezdet = reader.GetDateTime(0);
                        DateTime munkavege = reader.GetDateTime(1);
                        int tulora = reader.GetInt32(2);

                        Panel adatpanel = new Panel();
                        adatpanel.Width = panelMenu.Width - 25;
                        adatpanel.Height = 40;
                        adatpanel.Location = new Point(10, 50);
                        adatpanel.BackColor = Color.Green;

                        TextBox munkakezdettextbox = new TextBox();
                        munkakezdettextbox.Text = munkakezdet.ToString("yyyy-MM-dd HH:mm:ss");
                        munkakezdettextbox.Location = new Point(54, 50);
                        munkakezdettextbox.Width = 80;
                        munkakezdettextbox.Enabled = false;

                        TextBox munkavegetextbox = new TextBox();
                        munkavegetextbox.Text = munkavege.ToString("yyyy-MM-dd HH:mm:ss");
                        munkavegetextbox.Location = new Point(145, 50);
                        munkavegetextbox.Width = 80;
                        munkavegetextbox.Enabled = false;

                        TextBox tuloratextbox = new TextBox();
                        tuloratextbox.Text = tulora.ToString();
                        tuloratextbox.Location = new Point(255, 50);
                        tuloratextbox.Width = 80;
                        tuloratextbox.Enabled = false;

                        

                        adatpanel.Controls.Add(munkakezdettextbox);
                        adatpanel.Controls.Add(munkavegetextbox);
                        adatpanel.Controls.Add(tuloratextbox);
                        panelMenu.Controls.Add(adatpanel);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
