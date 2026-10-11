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
    public partial class feltoltes : Form
    {
        private readonly int adottazon;
        public feltoltes()
        {
            InitializeComponent();

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
                SELECT MAX(azon) from dolgozok where 1";

                using (var reader = parancs.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int maxAzon = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        txbazon.Text = (maxAzon + 1).ToString();
                    }
                }
            }
        }
        private void btnvissza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmentes_Click(object sender, EventArgs e)
        {
            if (txbadoszam.Text == "" || txbanyja.Text == "" || txbvezetek.Text == "" || txbkereszt.Text == "")
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                INSERT INTO dolgozok (azon, vezeteknev, keresztnev, adoszam, anyjaneve)
                VALUES (@azon, @vezetek, @kereszt, @adoszam, @anyjaneve)";

                int azon = Convert.ToInt32(txbazon.Text);
                int adoszam = Convert.ToInt32(txbadoszam.Text);
                parancs.Parameters.AddWithValue("@azon", azon);
                parancs.Parameters.AddWithValue("@vezetek", txbvezetek.Text);
                parancs.Parameters.AddWithValue("@kereszt", txbkereszt.Text);
                parancs.Parameters.AddWithValue("@adoszam", adoszam);
                parancs.Parameters.AddWithValue("@anyjaneve", txbanyja.Text);
                parancs.ExecuteNonQuery();
            }
        }
    }
}
