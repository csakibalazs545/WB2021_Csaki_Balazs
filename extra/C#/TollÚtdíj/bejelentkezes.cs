using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace TollÚtdíj
{
    public partial class Login : Form
    {
        private Bejelentkezessegito UIkisegito;

        public Login()
        {
            InitializeComponent();
            this.ActiveControl = txbusername;
            UIkisegito = new Bejelentkezessegito(
                lblhibas,
                lbluser,
                lblpass,
                txbpass,
                txbusername,
                lbl1,
                btnlogin,
                chkrememberme,
                pictureBox1
                );
        }

        // Segitő osztály a bejelentkezési form hibáinak kezelésére és a vezérlők láthatóságának állítására
        public class Bejelentkezessegito
        {
            private Label lblhibas;
            private Label lblUser;
            private Label lblPass;
            private TextBox txbPass;
            private TextBox txbUsername;
            private Label lbl1;
            private Button btnLogin;
            private CheckBox chkrememberme;
            private PictureBox logoPicture;

            public Bejelentkezessegito(
                Label lblhibas,
                Label lblUser,
                Label lblPass,
                TextBox txbPass,
                TextBox txbUsername,
                Label lbl1,
                Button btnLogin,
                CheckBox chkrememberme,
                PictureBox logoPicture)
            {
                this.lblhibas = lblhibas;
                this.lblUser = lblUser;
                this.lblPass = lblPass;
                this.txbPass = txbPass;
                this.txbUsername = txbUsername;
                this.lbl1 = lbl1;
                this.btnLogin = btnLogin;
                this.chkrememberme = chkrememberme;
                this.logoPicture = logoPicture;
            }
            // Metódus a hibaállapot megjelenítésére: elrejti a bejelentkezési vezérlőket és megjeleníti a hibaüzenetet
            public void ShowErrorState()
            {
                lblhibas.Visible = true;
                lblUser.Visible = true;
                lblPass.Visible = true;
                txbPass.Visible = true;
                txbUsername.Visible = true;
                lbl1.Visible = true;
                btnLogin.Visible = true;
                chkrememberme.Visible = true;
                if (logoPicture != null)
                {
                    logoPicture.Visible = true;
                }

                txbPass.Text = "";
                txbPass.Focus();
            }

            public void RestoreLoginState()
            {
                // elrejti a hibaüzenetet és visszaállítja a bejelentkezési vezérlők láthatóságát
                lblhibas.Visible = false;
                lblUser.Visible = true;
                lblPass.Visible = true;
                txbPass.Visible = true;
                txbUsername.Visible = true;
                lbl1.Visible = true;
                btnLogin.Visible = true;
                chkrememberme.Visible = true;
                if (logoPicture != null)
                {
                    logoPicture.Visible = true;
                }

                // kitörli a jelszó mezőt és visszahelyezi a fókuszt a felhasználónév mezőre
                txbPass.Text = string.Empty;
                txbUsername.Focus();
            }
        }
        // Bejelentkezés gomb eseménykezelője
        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            // Először ellenőrzi, hogy a felhasználónév és a jelszó mezők nincsenek-e üresen, és ha igen, akkor a fókuszt a hiányzó mezőre helyezi
            if (txbusername.Text != "" && txbpass.Text == "")
            {
                txbpass.Focus();
                return;
            }

            if (txbusername.Text == "" && txbpass.Text != "")
            {
                txbusername.Focus();
                return;
            }

            
            lblhibas.Visible = false;
            pictureBox1.Visible = false;
            lbluser.Visible = false;
            lblpass.Visible = false;
            lblhibas.Visible = false;
            txbpass.Visible = false;
            txbusername.Visible = false;
            lbl1.Visible = false;
            btnlogin.Visible = false;
            chkrememberme.Visible = false;


            // Backend műveletek: adatbázis kapcsolat létrehozása, felhasználó ellenőrzése, jelszó validálása, session kezelés
            #region Backend
            MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "mysql",
                Database = "tollutdijadatbazis"
            };


            // Kapcsolat létrehozása és megnyitása az adatbázissal, hiba esetén hibaüzenet megjelenítése
            using (MySqlConnection kapcsolat = new MySqlConnection(build.ConnectionString))
            {
                try
                {
                    kapcsolat.Open();
                }
                catch (Exception)
                {
                    lblhibas.Text = "Adatbetöltési hiba.\r\nEllenőrizze az internetkapcsolatot, majd próbálja újra.";
                    UIkisegito.ShowErrorState();
                    return;
                }

                string felhasznalonev = txbusername.Text;
                string jelszo = txbpass.Text;

                var parancs = kapcsolat.CreateCommand();
                parancs.CommandText = "SELECT id, ceg_id, jelszo_hash, aktiv, role FROM felhasznalok WHERE email = @email";
                parancs.Parameters.AddWithValue("@email", felhasznalonev);

                var read = parancs.ExecuteReader();

                // Ha nincs találat a megadott email címre, hibaüzenet megjelenítése

                if (!read.HasRows)
                {
                    lblhibas.Text = "Kérjük, ellenőrizze a jelszavát\r\nés az E-mail címét, majd próbálja újra.";
                    UIkisegito.ShowErrorState();
                    return;
                }

                // Ha van találat, jelszó validálása és további ellenőrzések (fiók aktiváltsága, szerepkör) elvégzése

                read.Read();
                string JelszoHash = read.GetString("jelszo_hash");
                bool validjelszo = BCrypt.Net.BCrypt.Verify(jelszo, JelszoHash);
                int aktiv = read.GetInt32("aktiv");
                string szerep = read.GetString("role");
                int cegId = read.GetInt32("ceg_id");


                // Ha a jelszó helyes, de a fiók nincs aktiválva, hibaüzenet megjelenítése

                if (validjelszo)
                {
                    if (aktiv == 0)
                    {
                        lblhibas.Text = "A fiók nincs aktiválva.\r\nForduljon az adminisztrátorhoz.";
                        UIkisegito.ShowErrorState();
                        return;
                    }


                    // Ha a jelszó helyes és a fiók aktiválva van, kezeljük a "remember me" funkciót:
                    // ha be van jelölve, generálunk egy session tokent, elmentjük az adatbázisban és a helyi beállításokban;
                    // ha nincs bejelölve, töröljük a session tokent a helyi beállításokból
                    if (chkrememberme.Checked)
                    {
                        string sessionToken = Guid.NewGuid().ToString("N");

                        using (var sessionCmd = kapcsolat.CreateCommand())
                        {
                            
                            sessionCmd.CommandText = @"
                                INSERT INTO felhasznalo_sessionok 
                                    (felhasznalo_id, token, created_at, lejart_at)
                                VALUES (
                                    @felhasznalo_id, 
                                    @token, 
                                    UTC_TIMESTAMP(), 
                                    DATE_ADD(UTC_TIMESTAMP(), INTERVAL 30 MINUTE)
                                )";
                            sessionCmd.Parameters.AddWithValue("@felhasznalo_id", read.GetInt32("id"));
                            sessionCmd.Parameters.AddWithValue("@token", sessionToken);

                            
                            read.Close();
                            sessionCmd.ExecuteNonQuery();
                        }

                        Properties.Settings.Default.SessionToken = sessionToken;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        
                        if (!read.IsClosed)
                        {
                            read.Close();
                        }
                        Properties.Settings.Default.SessionToken = "";
                        Properties.Settings.Default.Save();
                    }



                    var ui = new userinterface(szerep, cegId);
                    ui.FormClosed += (s, args) =>
                    {
                        // ha a session token még mindig érvényes (pl. a "remember me" be volt jelölve),
                        // akkor bezárjuk a bejelentkezési formot anélkül, hogy visszaállítanánk a vezérlők állapotát
                        if (!string.IsNullOrEmpty(Properties.Settings.Default.SessionToken))
                        {
                            this.Close();
                            return;
                        }

                        // egyébként visszaállítjuk a bejelentkezési form vezérlőinek állapotát, megjelenítjük a logót és újra megjelenítjük a formot
                        UIkisegito.RestoreLoginState();
                        pictureBox1.Visible = true;
                        this.Show();
                        this.Activate();
                    };
                    this.Hide();
                    ui.Show();
                }
                else
                {
                    lblhibas.Text = "Kérjük, ellenőrizze a jelszavát\r\nés az E-mail címét, majd próbálja újra.";
                    UIkisegito.ShowErrorState();
                    return;
                }
            }
            #endregion
        }



       
    }
}
