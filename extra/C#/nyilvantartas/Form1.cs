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
    public partial class Form1 : Form
    {

        private List<int> azon = new List<int>();
        private List<string> vezeteknev = new List<string>();
        private List<string> keresztnev = new List<string>();
        private List<int> adoszam = new List<int>();
        private List<string> anyjaneve = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panel alap = new Panel();
            alap.Width = panelMenu.Width - 25;
            alap.Height = 40;
            alap.Location = new Point(10, 0);
            alap.BackColor = Color.Green;


             TextBox azonositoja = new TextBox();
             azonositoja.Text = "azonosító";
            azonositoja.Location = new Point(54, 10);
            azonositoja.Width = 80;
            azonositoja.Enabled = false;
            

            TextBox vezetekneve = new TextBox();
            vezetekneve.Text = "Vezetéknév";
            vezetekneve.Location = new Point(145, 10);
            vezetekneve.Width = 80;
            vezetekneve.Enabled = false;

            TextBox keresztneve = new TextBox();
            keresztneve.Text = "Keresztnév";
            keresztneve.Location = new Point(255, 10);
            keresztneve.Width = 80;
            keresztneve.Enabled = false;


            TextBox adoszama = new TextBox();
            adoszama.Text = "Adószám";
            adoszama.Location = new Point(345, 10);
            adoszama.Width = 80;
            adoszama.Enabled = false;

            TextBox anyjanakneve = new TextBox();
            anyjanakneve.Text = "Anyja neve";
            anyjanakneve.Location = new Point(445, 10);
            anyjanakneve.Width = 80;
            anyjanakneve.Enabled = false;

            alap.Controls.Add(azonositoja);
            alap.Controls.Add(vezetekneve);
            alap.Controls.Add(keresztneve);
            alap.Controls.Add(adoszama);
            alap.Controls.Add(anyjanakneve);

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
                SELECT * from dolgozok where 1";


                using (var reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        azon.Add(reader.GetInt32("azon"));
                        vezeteknev.Add(reader.GetString("vezeteknev"));
                        keresztnev.Add(reader.GetString("keresztnev"));
                        adoszam.Add(reader.GetInt32("adoszam"));
                        anyjaneve.Add(reader.GetString("anyjaneve"));
                    }
                }
            }
            int y = 50;
            for (int i = 0; i < azon.Count; i++)
            {
                Panel sorPanel = new Panel();
                sorPanel.Width = panelMenu.Width - 25;
                sorPanel.Height = 40;
                sorPanel.Location = new Point(10, y);
                sorPanel.BackColor = Color.Green;


                TextBox azonbox = new TextBox();
                azonbox.Text = Convert.ToString(azon[i]);
                azonbox.Location = new Point(55, 10);
                azonbox.Width = 80;
                azonbox.ReadOnly = true;
                azonbox.DoubleClick += (s, ev) => megnyitas();


                TextBox vezetekbox = new TextBox();
                vezetekbox.Text = vezeteknev[i];
                vezetekbox.Location = new Point(145, 10);
                vezetekbox.Width = 80;
                

                TextBox keresztbox = new TextBox();
                keresztbox.Text = keresztnev[i];
                keresztbox.Location = new Point(255, 10);
                keresztbox.Width = 80;
        

                TextBox adoszambox = new TextBox();
                adoszambox.Text = Convert.ToString(adoszam[i]);
                adoszambox.Location = new Point(345, 10);
                adoszambox.Width = 80;
               

                TextBox anyjabox = new TextBox();
                anyjabox.Text = Convert.ToString(anyjaneve[i]);
                anyjabox.Location = new Point(445, 10);
                anyjabox.Width = 80;
      

                sorPanel.Controls.Add(azonbox);
                sorPanel.Controls.Add(vezetekbox);
                sorPanel.Controls.Add(keresztbox);
                sorPanel.Controls.Add(adoszambox);
                sorPanel.Controls.Add(anyjabox);

                panelMenu.Controls.Add(sorPanel);
                y += 50;

            }
        }

         void megnyitas()
        {

            foreach (Panel sor in panelMenu.Controls)
            {
                TextBox azonbox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 55);
                TextBox vezetekbox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 145);
                TextBox keresztbox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 255);
                TextBox adoszambox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 345);
                TextBox anyjabox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 445);
                if (azonbox != null && vezetekbox != null && keresztbox != null && adoszambox != null && anyjabox != null)
                {
                    int adottazon = Convert.ToInt32(azonbox.Text);
                    string vezeteknev = vezetekbox.Text;
                    string keresztnev = keresztbox.Text;
                    int adoszam = Convert.ToInt32(adoszambox.Text);
                    string anyjaneve = anyjabox.Text;

                    var f = new tulora(adottazon);
                    f.FormClosed += (s, args) =>
                    {
                        this.Show();
                        this.Activate();
                    };
                    this.Hide();
                    f.Show();
                }


                
            }

                
        }


        private void btnuj_Click(object sender, EventArgs e)
        {
            var f = new feltoltes();
            f.FormClosed += (s, args) =>
            {
                this.Show();
                this.Activate();
            };

            this.Hide();
            f.Show();
            azon.Clear();
            vezeteknev.Clear();
            keresztnev.Clear();
            adoszam.Clear();
            anyjaneve.Clear();

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
                SELECT * from dolgozok where 1";


                using (var reader = parancs.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        

                        azon.Add(reader.GetInt32("azon"));
                        vezeteknev.Add(reader.GetString("vezeteknev"));
                        keresztnev.Add(reader.GetString("keresztnev"));
                        adoszam.Add(reader.GetInt32("adoszam"));
                        anyjaneve.Add(reader.GetString("anyjaneve"));
                    }
                }
            }
            int y = 50;

            panelMenu.Controls.Clear();
            Panel alap = new Panel();
            alap.Width = panelMenu.Width - 25;
            alap.Height = 40;
            alap.Location = new Point(10, 0);
            alap.BackColor = Color.Green;


            TextBox azonositoja = new TextBox();
            azonositoja.Text = "azonosító";
            azonositoja.Location = new Point(54, 10);
            azonositoja.Width = 80;
            azonositoja.Enabled = false;

            TextBox vezetekneve = new TextBox();
            vezetekneve.Text = "Vezetéknév";
            vezetekneve.Location = new Point(145, 10);
            vezetekneve.Width = 80;
            vezetekneve.Enabled = false;

            TextBox keresztneve = new TextBox();
            keresztneve.Text = "Keresztnév";
            keresztneve.Location = new Point(255, 10);
            keresztneve.Width = 80;
            keresztneve.Enabled = false;


            TextBox adoszama = new TextBox();
            adoszama.Text = "Adószám";
            adoszama.Location = new Point(345, 10);
            adoszama.Width = 80;
            adoszama.Enabled = false;

            TextBox anyjanakneve = new TextBox();
            anyjanakneve.Text = "Anyja neve";
            anyjanakneve.Location = new Point(445, 10);
            anyjanakneve.Width = 80;
            anyjanakneve.Enabled = false;

            alap.Controls.Add(azonositoja);
            alap.Controls.Add(vezetekneve);
            alap.Controls.Add(keresztneve);
            alap.Controls.Add(adoszama);
            alap.Controls.Add(anyjanakneve);

            panelMenu.Controls.Add(alap);
            for (int i = 0; i < azon.Count; i++)
            {
                Panel sorPanel = new Panel();
                sorPanel.Width = panelMenu.Width - 25;
                sorPanel.Height = 40;
                sorPanel.Location = new Point(10, y);
                sorPanel.BackColor = Color.Green;


                TextBox azonbox = new TextBox();
                azonbox.Text = Convert.ToString(azon[i]);
                azonbox.Location = new Point(55, 10);
                azonbox.Width = 80;
                azonbox.Enabled = false;

                TextBox vezetekbox = new TextBox();
                vezetekbox.Text = vezeteknev[i];
                vezetekbox.Location = new Point(145, 10);
                vezetekbox.Width = 80;
        

                TextBox keresztbox = new TextBox();
                keresztbox.Text = keresztnev[i];
                keresztbox.Location = new Point(255, 10);
                keresztbox.Width = 80;
               


                TextBox adoszambox = new TextBox();
                adoszambox.Text = Convert.ToString(adoszam[i]);
                adoszambox.Location = new Point(345, 10);
                adoszambox.Width = 80;
             

                TextBox anyjabox = new TextBox();
                anyjabox.Text = Convert.ToString(anyjaneve[i]);
                anyjabox.Location = new Point(445, 10);
                anyjabox.Width = 80;
                

                sorPanel.Controls.Add(azonbox);
                sorPanel.Controls.Add(vezetekbox);
                sorPanel.Controls.Add(keresztbox);
                sorPanel.Controls.Add(adoszambox);
                sorPanel.Controls.Add(anyjabox);

                panelMenu.Controls.Add(sorPanel);
                y += 50;

            }
        
        }

        private void btnmentes_Click(object sender, EventArgs e)
        {
            foreach (Panel sor in panelMenu.Controls)
            {
                TextBox azonbox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 55);
                TextBox vezetekbox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 145);
                TextBox keresztbox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 255);
                TextBox adoszambox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 345);
                TextBox anyjabox = sor.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Location.X == 445);
                if (azonbox != null && vezetekbox != null && keresztbox != null && adoszambox != null && anyjabox != null)
                {
                    int azon = Convert.ToInt32(azonbox.Text);
                    string vezeteknev = vezetekbox.Text;
                    string keresztnev = keresztbox.Text;
                    int adoszam = Convert.ToInt32(adoszambox.Text);
                    string anyjaneve = anyjabox.Text;
                    MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder
                    {
                        Server = "localhost",
                        UserID = "root",
                        Password = "mysql",
                        Database = "nyilvantartas"
                    };
                    using (MySqlConnection kapcsolat = new MySqlConnection(build.ConnectionString))
                    {
                        kapcsolat.Open();
                        var parancs = kapcsolat.CreateCommand();
                        parancs.CommandText = @"
                            UPDATE dolgozok
                            SET vezeteknev = @vezeteknev, keresztnev = @keresztnev, adoszam = @adoszam, anyjaneve = @anyjaneve
                            WHERE azon = @azon";
                        parancs.Parameters.AddWithValue("@azon", azon);
                        parancs.Parameters.AddWithValue("@vezeteknev", vezeteknev);
                        parancs.Parameters.AddWithValue("@keresztnev", keresztnev);
                        parancs.Parameters.AddWithValue("@adoszam", adoszam);
                        parancs.Parameters.AddWithValue("@anyjaneve", anyjaneve);
                        parancs.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
