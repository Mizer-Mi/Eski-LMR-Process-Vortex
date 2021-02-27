using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMR_Process_Vortex
{
    public partial class ayarlar_Mizer_Sirtuex : Form
    {
        public ayarlar_Mizer_Sirtuex()
        {
            InitializeComponent();
        }
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string adminadi { get; set; }
        public string eG80LPJJCimP { get; set; }
        public string Id4SGF8YIcyg9y { get; set; }
        public string Neof_Wotf { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }

        /// <summary>

        /// <param name="e"></param>
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };

                Button confirmation = new Button() { Text = "Gir", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                textBox.PasswordChar = '*';
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;


                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }


        }
        private void ayarlar_Mizer_Sirtuex_Load(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Program Ayarları", "Program Ayarları Görüntülendi", "Program Ayarları Görüntülendi");
            pg_ayar_ck();
            felek_donsunmu();
        }
        private void log_gonder(string kadi, string isim, string bolum, string islem, string aciklama)
        {
            
            try
            {
                string log_komutu = "insert into kullanici_islemleri(kullanici_adi,isim,bolum,islem,aciklama) values(@1,@2,@3,@4,@5)";
                MySqlCommand log_command = new MySqlCommand(log_komutu, mysqlbaglan);
                log_command.Parameters.AddWithValue("@1", kadi);
                log_command.Parameters.AddWithValue("@2", isim);
                log_command.Parameters.AddWithValue("@3", bolum);
                log_command.Parameters.AddWithValue("@4", islem);
                log_command.Parameters.AddWithValue("@5", aciklama);
                mysqlbaglan.Open();
                log_command.ExecuteNonQuery();
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {

            }

        }
        private void pg_ayar_ck()
        {
            try
            {
           string sql = "Select * from program_ayarlari where mizer=666";
           if (mysqlbaglan.State == ConnectionState.Closed) { mysqlbaglan.Open(); }
            MySqlCommand cmd = new MySqlCommand(sql,mysqlbaglan);
            MySqlDataReader oku = cmd.ExecuteReader();
            if(oku.Read())
            {
                if (oku["z_girisi_kapat"].ToString() == "Evet") { z_girisi_kapat.Checked = true;  } else { z_girisi_kapat.Checked = false; }
                if (oku["p_girisi_kapat"].ToString() == "Evet") { p_girisi_kapat.Checked = true; } else { p_girisi_kapat.Checked = false; }
                if (oku["f_silerken_ss"].ToString() == "Evet") { f_silerken_ss.Checked = true; } else { f_silerken_ss.Checked = false; }
                if (oku["m_girerken_ss"].ToString() == "Evet") { m_girerken_ss.Checked = true; } else { m_girerken_ss.Checked = false; }
                if (oku["ci_girerken_ss"].ToString() == "Evet") { ci_girerken_ss.Checked = true; } else { ci_girerken_ss.Checked = false; }
                if (oku["hgl_girerken_ss"].ToString() == "Evet") { hgl_girerken_ss.Checked = true; } else { hgl_girerken_ss.Checked = false; }
                if (oku["kl_girerken_ss"].ToString() == "Evet") { kl_girerken_ss.Checked = true; } else { kl_girerken_ss.Checked = false; }
                if (oku["ya_girerken_ss"].ToString() == "Evet") { ya_girerken_ss.Checked = true; } else { ya_girerken_ss.Checked = false; }
                if (oku["k_girerken_ss"].ToString() == "Evet") { k_girerken_ss.Checked = true; } else { k_girerken_ss.Checked = false; }

                }
            if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -11", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }




        }
        private void felek_donsunmu()
        {
            try
            {
                string sql = "Select * from version_guvenlik_Mizer";
                if (mysqlbaglan.State == ConnectionState.Closed) { mysqlbaglan.Open(); }
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    felek_donuyorr_agaaaa = oku["Super_Sifre"].ToString();
                    Allahin_sillesi_geliyorrrr_BEN_NAPAMM_BEN_NERELERE_GIDEM_BOKUMLA_GULLE_OYNAYAM= oku["Mizer_Sifre"].ToString();

                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -8", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }
        }
        public string Allahin_sillesi_geliyorrrr_BEN_NAPAMM_BEN_NERELERE_GIDEM_BOKUMLA_GULLE_OYNAYAM;
        public string felek_donuyorr_agaaaa;
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                pg_ayar_ck();
                felek_donsunmu();

                string THE_MIGHTY_GOD_MR_MIZER_IS_HERE_DONT_SCARE_DUDE_IF_YOU_COME_HEAR_TO_FUCK_ME_I_SWEAR_NAME_OF_MIZER_I_WILL_HUNT_YOU = Prompt.ShowDialog("Lütfen Veri_Tabanı Şifresini giriniz... ", "LMR - Mizer");
               if (Allahin_sillesi_geliyorrrr_BEN_NAPAMM_BEN_NERELERE_GIDEM_BOKUMLA_GULLE_OYNAYAM == THE_MIGHTY_GOD_MR_MIZER_IS_HERE_DONT_SCARE_DUDE_IF_YOU_COME_HEAR_TO_FUCK_ME_I_SWEAR_NAME_OF_MIZER_I_WILL_HUNT_YOU)
                {
                    using (xD_____Mizer__Crimson_Neo_Worf_Sirtuex BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU = new xD_____Mizer__Crimson_Neo_Worf_Sirtuex())
                    {
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.ekleyen_adi = ekleyen_adi;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.gercek_yetki = gercek_yetki;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.adminadi = adminadi;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.eG80LPJJCimP = eG80LPJJCimP;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.kadi_getir = adminadi;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.mysqlbaglan = mysqlbaglan;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.Neof_Wotf = Neof_Wotf;
                        BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.ShowDialog();
                    }


                }
                else
                {
                    MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch
            {

            }


           





        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (ss_degis_check.Checked == true)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          DialogResult=  DialogResult.OK;
        }
        private void ss_degis()
        {
          
            string guncelle = "update `version_guvenlik_Mizer` set Super_Sifre=@mm ";
            MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

            guncel.Parameters.AddWithValue("@mm", yeni_ss1.Text);
            mysqlbaglan.Open();
            guncel.ExecuteNonQuery();
            mysqlbaglan.Close();
            log_gonder(adminadi, ekleyen_adi, "Program Ayarları", "Süper Şifre Değiştirildi.", "Süper Şifre Değiştirildi.");

        }
       private void program_ayar_degis()
        {
            string z_girisi_kapat_v = "";
            string p_girisi_kapat_v = "";
            string f_silerken_ss_v = "";
            string m_girerken_ss_v = "";
            string ci_girerken_ss_v = "";
            string hgl_girerken_ss_v = "";
            string kl_girerken_ss_v = "";
            string ya_girerken_ss_v = "";
            string k_girerken_ss_v = "";
            if (z_girisi_kapat.Checked == true) { z_girisi_kapat_v = "Evet"; } else { z_girisi_kapat_v = "Hayır"; }
            if (p_girisi_kapat.Checked == true) { p_girisi_kapat_v = "Evet"; } else { p_girisi_kapat_v = "Hayır"; }
            if (f_silerken_ss.Checked == true) { f_silerken_ss_v = "Evet"; } else { f_silerken_ss_v = "Hayır"; }
            if (m_girerken_ss.Checked == true) { m_girerken_ss_v = "Evet"; } else { m_girerken_ss_v = "Hayır"; }
            if (ci_girerken_ss.Checked == true) { ci_girerken_ss_v = "Evet"; } else { ci_girerken_ss_v = "Hayır"; }
            if (hgl_girerken_ss.Checked == true) { hgl_girerken_ss_v = "Evet"; } else { hgl_girerken_ss_v = "Hayır"; }
            if (kl_girerken_ss.Checked == true) { kl_girerken_ss_v = "Evet"; } else { kl_girerken_ss_v = "Hayır"; }
            if (ya_girerken_ss.Checked == true) { ya_girerken_ss_v = "Evet"; } else { ya_girerken_ss_v = "Hayır"; }
            if (k_girerken_ss.Checked == true) { k_girerken_ss_v = "Evet"; } else { k_girerken_ss_v = "Hayır"; }

            try
            {
                string guncelle = "update `program_ayarlari` set z_girisi_kapat=@z,p_girisi_kapat=@p,f_silerken_ss=@f,m_girerken_ss=@m,ci_girerken_ss=@ci,hgl_girerken_ss=@hgl,kl_girerken_ss=@kl,ya_girerken_ss=@ya,k_girerken_ss=@k where mizer=666";
                MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                guncel.Parameters.AddWithValue("@z", z_girisi_kapat_v);
                guncel.Parameters.AddWithValue("@p", p_girisi_kapat_v);
                guncel.Parameters.AddWithValue("@f", f_silerken_ss_v);
                guncel.Parameters.AddWithValue("@m", m_girerken_ss_v);
                guncel.Parameters.AddWithValue("@ci", ci_girerken_ss_v);
                guncel.Parameters.AddWithValue("@hgl", hgl_girerken_ss_v);
                guncel.Parameters.AddWithValue("@kl", kl_girerken_ss_v);
                guncel.Parameters.AddWithValue("@ya", ya_girerken_ss_v);
                guncel.Parameters.AddWithValue("@k", k_girerken_ss_v);
                mysqlbaglan.Open();
                guncel.ExecuteNonQuery();
                mysqlbaglan.Close();
                MessageBox.Show("Program Ayarları Güncellendi.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log_gonder(adminadi, ekleyen_adi, "Program Ayarları", "Program Ayarları Güncellendi.", "Program Ayarları Güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -9", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

          

            try
            { 
                if (ss_degis_check.Checked == true)
                {
                     if (eski_ss.Text == felek_donuyorr_agaaaa)
                    {
                        if(yeni_ss1.Text==yeni_ss2.Text) { ss_degis(); program_ayar_degis(); ayarlar_Mizer_Sirtuex_Load(null, null); }
                        else { MessageBox.Show("Yeni Şifreler doğrulanamadı.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        ///
                      

                     ///
                    }
                     else
                    {
                        MessageBox.Show("Eski şifre doğru değil...", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                }
                else
                {
                    program_ayar_degis();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -10", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            z_girisi_kapat.Checked = false;
            p_girisi_kapat.Checked = false;
            ya_girerken_ss.Checked = false;
            ci_girerken_ss.Checked = false;
            f_silerken_ss.Checked = true;
            hgl_girerken_ss.Checked = false;
            kl_girerken_ss.Checked = false;
            k_girerken_ss.Checked = false;
            m_girerken_ss.Checked = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (Rapor_Dizayn_Ayarlar_Mizer BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU = new Rapor_Dizayn_Ayarlar_Mizer())
            {
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.ekleyen_adi = ekleyen_adi;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.gercek_yetki = gercek_yetki;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.adminadi = adminadi;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.eG80LPJJCimP = eG80LPJJCimP;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.kadi_getir = adminadi;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.mysqlbaglan = mysqlbaglan;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.Neof_Wotf = Neof_Wotf;
                BOOOOOOOOOOOOOO_KORKTUNMU_ORUMCEK_KORKTUNMU.ShowDialog();
            }
        }
    }
}
