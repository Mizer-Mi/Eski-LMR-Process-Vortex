using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMR_Process_Vortex
{
    public partial class anamenu : Form
    {

        public anamenu()
        {
            InitializeComponent();
        }
        public MySqlConnection mysqlbaglan { get; set; }
        public string ekleyen_ismi_cek { get; set; }
        public string gercek_yetki { get; set; }
        public string adminadi { get; set; }
        public string Neof_Wotf { get; set; }
        private void yenilemeaq()
        {
            try
            {
                toolStripStatusLabel1.Text = gercek_yetki + " Girişi Yapıldı";

                toolStripStatusLabel2.Text = " | Tarih: " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " | ";
                toolStripStatusLabel4.Text = "Hoşgeldin " + ekleyen_ismi_cek + " |";

            }
            catch
            {

            }
        }

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
        private void Anamenu_Yetki_sorgulama()
        {
            try
            { 
            string komutu = "select * from kullanicilar where kadi='" + adminadi + "'";
            MySqlCommand komut_getir = new MySqlCommand(komutu, mysqlbaglan);
            mysqlbaglan.Open();
            MySqlDataReader sorgulama = komut_getir.ExecuteReader();
            if (sorgulama.Read())
            {
                string yetkiniz = sorgulama["yetki"].ToString();
                if (yetkiniz == "SüperAdmin")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;
                    button10.Enabled = true;
                    sifre_Degis_Ac.Enabled = true;
                        garanti_ac.Enabled = true;
                        cari_islemler_ac.Enabled = true;
                        Dokumanlar_ac.Enabled = true;
                        yazilimlari_ac.Enabled = true;
                        kullanıcıLoglarıToolStripMenuItem.Enabled = true;
                        hatalıGirişLoglarıToolStripMenuItem.Enabled = true;

                        kullanıcıAyarlarıToolStripMenuItem.Enabled = true;
                        markaAyarlarıToolStripMenuItem.Enabled = true;
                        programAyarlarıToolStripMenuItem.Enabled = true;






                        mysqlbaglan.Close();
                }
                else if (yetkiniz== "Yetkili Personel")
                {
                        mysqlbaglan.Close();
                        Anamenu_Yetkili_personeli_sorgulama();
                }
                else
                {
                        mysqlbaglan.Close();
                        MessageBox.Show("Yetkisiz Personel! - Hata Kodu:M22zer : Yetkisiz Personel ", "LMR-Process Vortex - Sirtuex", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }

            }
            else
            {
                    mysqlbaglan.Close();
                    MessageBox.Show("Yetkisiz Personel ya da Silik kullanıcı - Hata Kodu:M21zer : Yetki Doğrulanamadı. ","LMR-Process Vortex - Sirtuex",MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            }
            catch
            {
                mysqlbaglan.Close();
                MessageBox.Show("Bağlantı Kurulamadı - Yetki Sorgulanamadı. - Hata Kodu:M20zer : Bağlantı Kurulamadı. ", "LMR-Process Vortex - Sirtuex", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }




        }




            private void Anamenu_Yetkili_personeli_sorgulama()
            {
            try
            {
                string markacekkomutu = "select * from kullanicilar_yetki where y_id='" + adminadi + "'";
                MySqlCommand markacek = new MySqlCommand(markacekkomutu, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader listelememarka = markacek.ExecuteReader();
                if (listelememarka.Read())
                {
                    button1.Enabled = true;
                    garanti_ac.Enabled = true;
                    programAyarlarıToolStripMenuItem.Enabled = false;
                    button9.Enabled = false;
                    sifre_Degis_Ac.Enabled = true;
                    if (listelememarka["urun_stok_goruntuleme"].ToString() == "True") { button2.Enabled = true; cari_islemler_ac.Enabled = true; } //1
                    if (listelememarka["personel_ekle"].ToString() == "True") { button3.Enabled = true; kullanıcıAyarlarıToolStripMenuItem.Enabled = true; }
                    if (listelememarka["kullanici_loglari_goruntule"].ToString() == "True") { button4.Enabled = true; kullanıcıLoglarıToolStripMenuItem.Enabled = true; }
                    if (listelememarka["yazilim_giris"].ToString() == "True") { button8.Enabled = true; yazilimlari_ac.Enabled = true; }
                    if (listelememarka["dokumanlara_giris"].ToString() == "True") { button7.Enabled = true; Dokumanlar_ac.Enabled = true; }
                    if (listelememarka["hatali_giris_loglari"].ToString() == "True") { button5.Enabled = true; hatalıGirişLoglarıToolStripMenuItem.Enabled = true; }
                    if (listelememarka["veritabani_bilgisi"].ToString() == "True") { button6.Enabled = true; veri_tabani_bilgi.Enabled = true; }

                }
                else
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
               
                    this.Close();
                }
                mysqlbaglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
           
        }







        public string eG80LPJJCimP { get; set; }
        public string Id4SGF8YIcyg9y { get; set; }
        private void anamenu_Load(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            /// this.BackColor = Color.FromArgb(255, 102, 0);
            statusStrip1.BackColor = Color.WhiteSmoke;
            button1.BackColor = Color.Gainsboro;

            yenilemeaq();
            this.Focus();
            Anamenu_Yetki_sorgulama();
        }
        
        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            
        }
        void f3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            garanti_ac.Enabled = false;
            button1.Enabled=false;
            using (secim_form f2 = new secim_form())
            {
               
                contextMenuStrip1.Refresh();
                this.Hide();
                f2.gercek_yetki = gercek_yetki;
                f2.adminadi = adminadi;
                f2.mysqlbaglan = mysqlbaglan;
                f2.eG80LPJJCimP = eG80LPJJCimP;
                f2.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
                f2.Neof_Wotf = Neof_Wotf;
                f2.ekleyen_ismi_cek = ekleyen_ismi_cek;
                f2.ShowDialog();

                if (f2.cikisa_don_mizer == "Evet")
                {
                    DialogResult = DialogResult.OK;
                }
                f2.Dispose();
                this.Show();
               
                contextMenuStrip1.Refresh();
            }
            garanti_ac.Enabled = true;
            button1.Enabled = true;
            GC.Collect();
            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
         
            cari_islemler_ac.Enabled = false;
            button2.Enabled = false;
            try
            {
            pg_ayar_ck();
            felek_donsunmu();
            if (ci_gir == false)
            {
                string super_sifre_giris = Prompt.ShowDialog("Lütfen Süper Şifreyi giriniz...", "LMR - Mizer");

                  
                if (felek_donuyorr_agaaaa == super_sifre_giris)
                {
                    using (cari_islemler f3 = new cari_islemler())
                    {
                        this.Hide();
                        f3.ekleyen_adi = ekleyen_ismi_cek;
                        f3.gercek_yetki = gercek_yetki;
                        f3.mysqlbaglan = mysqlbaglan;
                        f3.kadi_getir = adminadi;
                        f3.ShowDialog();

                        if (f3.cikisa_don_mizer == "Evet")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        f3.Dispose();
                        this.Show();

                    }
                    GC.Collect();
                }
                else
                {
                    MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    }

                
            else if (ci_gir==true)
            {
                using (cari_islemler f3 = new cari_islemler())
                {
                    this.Hide();
                    f3.ekleyen_adi = ekleyen_ismi_cek;
                    f3.gercek_yetki = gercek_yetki;
                    f3.mysqlbaglan = mysqlbaglan;
                    f3.kadi_getir = adminadi;
                    f3.ShowDialog();

                    if (f3.cikisa_don_mizer == "Evet")
                    {
                        DialogResult = DialogResult.OK;
                    }
                    f3.Dispose();
                    this.Show();

                }
                GC.Collect();

            }
            else
            {


            }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }

            cari_islemler_ac.Enabled = true;
            button2.Enabled = true;
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            hatalıGirişLoglarıToolStripMenuItem.Enabled = false;
            button5.Enabled = false;
            try
            {
                pg_ayar_ck();
                felek_donsunmu();
                if (hgl_gir == false)
                {
                    string super_sifre_giris = Prompt.ShowDialog("Lütfen Süper Şifreyi giriniz...", "LMR - Mizer");


                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                    {
                        using (giris_loglari_form f5 = new giris_loglari_form())
                        {
                            f5.ekleyen_adi = ekleyen_ismi_cek;
                            f5.gercek_yetki = gercek_yetki;
                            f5.mysqlbaglan = mysqlbaglan;
                            f5.adminadi = adminadi;
                            f5.ShowDialog();
                            if (f5.cikisa_don_mizer == "Evet")
                            {
                                DialogResult = DialogResult.OK;
                            }

                            f5.Dispose();
                        }
                        GC.Collect();
                    }
                    else
                    {
                        MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (hgl_gir == true)
                {
                    using (giris_loglari_form f5 = new giris_loglari_form())
                    {
                        f5.ekleyen_adi = ekleyen_ismi_cek;
                        f5.gercek_yetki = gercek_yetki;
                        f5.mysqlbaglan = mysqlbaglan;
                        f5.adminadi = adminadi;
                        f5.ShowDialog();
                        if (f5.cikisa_don_mizer == "Evet")
                        {
                            DialogResult = DialogResult.OK;
                        }

                        f5.Dispose();
                    }
                    GC.Collect();

                }
                else
                {


                }
            }
            catch
            {

            }



            hatalıGirişLoglarıToolStripMenuItem.Enabled = true;
            button5.Enabled = true;





        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            kullanıcıLoglarıToolStripMenuItem.Enabled = false;
            button4.Enabled = false;
            try
            {
                pg_ayar_ck();
                felek_donsunmu();
                if (kl_gir == false)
                {
                    string super_sifre_giris = Prompt.ShowDialog("Lütfen Süper Şifreyi giriniz...", "LMR - Mizer");


                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                    {
                        using (kullanici_loglari f6 = new kullanici_loglari())
                        {
                            f6.ekleyen_adi = ekleyen_ismi_cek;
                            f6.gercek_yetki = gercek_yetki;
                            f6.mysqlbaglan = mysqlbaglan;
                            f6.adminadi = adminadi;
                            f6.ShowDialog();
                            if (f6.cikisa_don_mizer == "Evet")
                            {
                                DialogResult = DialogResult.OK;
                            }
                            f6.Dispose();

                        }
                        GC.Collect();
                    }
                    else
                    {
                        MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (kl_gir == true)
                {
                    using (kullanici_loglari f6 = new kullanici_loglari())
                    {
                        f6.ekleyen_adi = ekleyen_ismi_cek;
                        f6.gercek_yetki = gercek_yetki;
                        f6.mysqlbaglan = mysqlbaglan;
                        f6.adminadi = adminadi;
                        f6.ShowDialog();
                        if (f6.cikisa_don_mizer == "Evet")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        f6.Dispose();

                    }
                    GC.Collect();

                }
                else
                {


                }
            }
            catch
            {

            }

            kullanıcıLoglarıToolStripMenuItem.Enabled = true;
            button4.Enabled = true;








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
            mysqlbaglan.Close();
            }
            catch
            {

            }

        }
        private void programKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Ana Menü", "Çıkış Yapıldı", "Çıkış Yapıldı");
            Environment.Exit(1);
        }
        form_loading form_out;
        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Ana Menü", "Çıkış Yapıldı", "Çıkış Yapıldı");
           DialogResult= DialogResult.OK;
        }
        void form_out_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void anamenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Ana Menü", "Çıkış Yapıldı", "Çıkış Yapıldı");
            DialogResult = DialogResult.OK;

        }
        
        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkinda.Enabled = false;
            using (hakkinda hakkindaac = new hakkinda())
            {
                hakkindaac.ShowDialog();
            }
            hakkinda.Enabled = true;
               
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            kullanıcıAyarlarıToolStripMenuItem.Enabled = false;
            button3.Enabled = false;
            try
            {
                pg_ayar_ck();
                felek_donsunmu();
                if (k_gir == false)
                {
                    string super_sifre_giris = Prompt.ShowDialog("Lütfen Süper Şifreyi giriniz...", "LMR - Mizer");


                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                    {

                        using (kullanici_ayarlari f7 = new kullanici_ayarlari())
                        {
                            this.Hide();
                            f7.ekleyen_adi = ekleyen_ismi_cek;
                            f7.gercek_yetki = gercek_yetki;
                            f7.adminadi = adminadi;
                            f7.kadi_getir = adminadi;
                            f7.mysqlbaglan = mysqlbaglan;
                            f7.ShowDialog();
                            if (f7.cikisa_don_mizer == "Evet")
                            {
                                DialogResult = DialogResult.OK;
                            }
                            f7.Dispose();
                            this.Show();
                        }
                        GC.Collect();
                    }
                    else
                    {
                        MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else if (k_gir == true)
                {
                    using (kullanici_ayarlari f7 = new kullanici_ayarlari())
                    {
                        this.Hide();
                        f7.ekleyen_adi = ekleyen_ismi_cek;
                        f7.gercek_yetki = gercek_yetki;
                        f7.adminadi = adminadi;
                        f7.kadi_getir = adminadi;
                        f7.mysqlbaglan = mysqlbaglan;
                        f7.ShowDialog();
                        if (f7.cikisa_don_mizer == "Evet")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        f7.Dispose();
                        this.Show();
                    }
                    GC.Collect();

                }
                else
                {


                }
            }
            catch
            {

            }

            kullanıcıAyarlarıToolStripMenuItem.Enabled = true;
            button3.Enabled = true;


        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 102, 0);
            pictureBox2.Location = new Point(284,152);
            pictureBox2.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false ;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(255, 102, 0);
            pictureBox2.Location = new Point(422, 154);
            pictureBox2.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(255, 102, 0);

            pictureBox2.Location = new Point(422, 228);
            pictureBox2.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(255, 102, 0);

            pictureBox2.Location = new Point(422, 379);
            pictureBox2.Visible = true;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(255, 102, 0);

            pictureBox2.Location = new Point(284, 453);
            pictureBox2.Visible = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Gainsboro;

            pictureBox2.Visible = false ;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(255, 102, 0);

            pictureBox2.Location = new Point(422, 451);
            pictureBox2.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            veri_tabani_bilgi.Enabled = false;
            button6.Enabled = false;
            using (vt_bilgiler_Mizer f_bilgi = new vt_bilgiler_Mizer())
            { 
            f_bilgi.ekleyen_adi = ekleyen_ismi_cek;
            f_bilgi.gercek_yetki = gercek_yetki;
            f_bilgi.adminadi = adminadi;
            f_bilgi.kadi_getir = adminadi;
            f_bilgi.mysqlbaglan = mysqlbaglan;
            f_bilgi.ShowDialog();
               
                f_bilgi.Dispose();
            }
            GC.Collect();
            veri_tabani_bilgi.Enabled = true;
            button6.Enabled = true; 
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = Color.FromArgb(255, 102, 0);

            pictureBox2.Location = new Point(284, 376);
            pictureBox2.Visible = true;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false;
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            programAyarlarıToolStripMenuItem.Enabled = false;
            button9.Enabled = false;
            try
            {
                pg_ayar_ck();
                felek_donsunmu();
                
                   string super_sifre_giris = Prompt.ShowDialog("Lütfen Süper Şifreyi giriniz...", "LMR - Mizer");
                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                    {

                    using (ayarlar_Mizer_Sirtuex f_ayarlar = new ayarlar_Mizer_Sirtuex())
                    {
                        f_ayarlar.ekleyen_adi = ekleyen_ismi_cek;
                        f_ayarlar.gercek_yetki = gercek_yetki;
                        f_ayarlar.adminadi = adminadi;
                        f_ayarlar.eG80LPJJCimP = eG80LPJJCimP;
                        f_ayarlar.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
                        f_ayarlar.kadi_getir = adminadi;
                        f_ayarlar.mysqlbaglan = mysqlbaglan;
                        f_ayarlar.Neof_Wotf = Neof_Wotf;
                        f_ayarlar.ShowDialog();

                        f_ayarlar.Dispose();
                    }
                    GC.Collect();
                    }
                    else
                    {
                        MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
               
            }
            catch
            {

            }


            programAyarlarıToolStripMenuItem.Enabled = true;
            button9.Enabled = true;




        }

        private void anamenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            markaAyarlarıToolStripMenuItem.Enabled = false;
            button10.Enabled = false;
            try
            {
                pg_ayar_ck();
                felek_donsunmu();
                if (m_gir == false)
                {
                    string super_sifre_giris = Prompt.ShowDialog("Lütfen Süper Şifreyi giriniz...", "LMR - Mizer");


                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                    {

                        using (marka_ayarlari_Mizer f_marka = new marka_ayarlari_Mizer())
                        {
                            f_marka.ekleyen_adi = ekleyen_ismi_cek;
                            f_marka.ekleyen_ismi_cek = ekleyen_ismi_cek;
                            f_marka.gercek_yetki = gercek_yetki;
                            f_marka.mysqlbaglan = mysqlbaglan;
                            f_marka.adminadi = adminadi;
                            f_marka.ShowDialog();

                            f_marka.Dispose();

                        }
                        GC.Collect();
                    }
                    else
                    {
                        MessageBox.Show("Süper Şifre yanlış.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (m_gir == true)
                {
                    using (marka_ayarlari_Mizer f_marka = new marka_ayarlari_Mizer())
                    {
                        f_marka.ekleyen_adi = ekleyen_ismi_cek;
                        f_marka.ekleyen_ismi_cek = ekleyen_ismi_cek;
                        f_marka.gercek_yetki = gercek_yetki;
                        f_marka.mysqlbaglan = mysqlbaglan;
                        f_marka.adminadi = adminadi;
                        f_marka.ShowDialog();

                        f_marka.Dispose();

                    }
                    GC.Collect();

                }
                else
                {


                }
            }
            catch
            {

            }

            markaAyarlarıToolStripMenuItem.Enabled = true;
            button10.Enabled = true;



        }

        private void pg_ayar_ck()
        {
            try
            {
                string sql = "Select * from program_ayarlari where mizer=666";
                if (mysqlbaglan.State == ConnectionState.Closed) { mysqlbaglan.Open(); }
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    if (oku["m_girerken_ss"].ToString() == "Evet") { m_gir = false; } else { m_gir = true; }
                    if (oku["ci_girerken_ss"].ToString() == "Evet") { ci_gir = false; } else { ci_gir = true; }
                    if (oku["ya_girerken_ss"].ToString() == "Evet") { ya_gir = false; } else { ya_gir = true; }
                    if (oku["kl_girerken_ss"].ToString() == "Evet") { kl_gir = false; } else { kl_gir = true; }
                    if (oku["hgl_girerken_ss"].ToString() == "Evet") { hgl_gir = false; } else { hgl_gir = true; }
                    if (oku["k_girerken_ss"].ToString() == "Evet") { k_gir = false; } else { k_gir = true; }
                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -6", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }




        }
        public Boolean m_gir;
        public Boolean ci_gir;
        public Boolean ya_gir;
        public Boolean kl_gir;
        public Boolean hgl_gir;
        public Boolean k_gir;
        public string felek_donuyorr_agaaaa;
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

                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -7", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
             button10.BackColor = Color.FromArgb(255, 102, 0);
                pictureBox2.Location = new Point(422, 305);
                pictureBox2.Visible = true;
         

           
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.Gainsboro;
            pictureBox2.Visible = false;
        }

        private void anamenu_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.BalloonTipText = "Process Vortex - Arka Planda Çalışıyor.";
                notifyIcon.ShowBalloonTip(400);
               
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
 
               
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
                this.WindowState = FormWindowState.Normal;




        }

        private void programikapat_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Ana Menü", "Çıkış Yapıldı", "Çıkış Yapıldı");
            Environment.Exit(1);
        }

        private void hakkinda_Click(object sender, EventArgs e)
        {
            programHakkındaToolStripMenuItem_Click(null, null);
        }

        private void cikisyap_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Ana Menü", "Çıkış Yapıldı", "Çıkış Yapıldı");
            Environment.Exit(1);
        }

        private void goster_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Focus();
        }

        private void garanti_ac_Click(object sender, EventArgs e)
        {
            button1_Click(null,null);
        }
        private void cari_islemler_ac_Click(object sender, EventArgs e)
        {

            button2_Click(null,null);
           
            

        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void kullanıcıLoglarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

        private void hatalıGirişLoglarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(null, null);
        }

        private void kullanıcıAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void markaAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button10_Click(null, null);
        }

        private void programAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button9_Click(null, null);
        }

        private void veri_tabani_bilgi_Click(object sender, EventArgs e)
        {
            button6_Click(null,null);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
        }

        private void sifre_Degis_Ac_Click(object sender, EventArgs e)
        {
            sifre_Degis_Ac.Enabled = false;
            using (sifre_degistir s_degis_Ac = new sifre_degistir())
            {
                s_degis_Ac.aktarmaotobusu = adminadi;
                s_degis_Ac.mysqlbaglan = mysqlbaglan;
                s_degis_Ac.ShowDialog();

                sifre_Degis_Ac.Dispose();
            }
            GC.Collect();
            sifre_Degis_Ac.Enabled = true;
     
        }
    }
    
}

