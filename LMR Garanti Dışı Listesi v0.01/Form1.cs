using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using System.Net;
using System.Management;
using System.Runtime.InteropServices;
using EncryptStringSample;
using System.Security.Cryptography;
using System.Net.Sockets;
using CrystalDecisions.CrystalReports.Engine;

namespace LMR_Process_Vortex
{



    public partial class form_loading : Form
    {

        public static string NeoWorf_Mizer_Sirtuex_Process_Vortex()
        {

            string Mücahit_Gökhan = StringCipher.Decrypt(God_mizer.System_Control_Process_Vortex_Label_Text, Decrypt("9pR8lgpGw6cOfg4meC5m8t+rhSNZijCDgGsawkS+QwQm9PW1TD5AFUgChEmq52eue05pLm1q3foLqUhDfAiYkP6C0XAeFuwcZ1G1o25051ZOlkbmI8RvYDM52l7qINxT"));
            string form2_loadiing = StringCipher.Decrypt(God_mizer.Button_1_Text_System_Control, Mücahit_Gökhan);

            return form2_loadiing;


        }
        public static string NeoWorf_Mizer_Process_Vortex()
        {


            string Mücahit_Gökhan2 = StringCipher.Decrypt(God_mizer.worfun_disi, Decrypt("aiOvZtUch6lx7Fs8 + imtsI + wbRGDdr3lLeh7WqMSAAWCxgildqjVFA2JDgWtjs1p8Bk4lNqJBfaN1bPe432Sqr1ioIoM1xx4DTV9P9bkGjk2oR / jWpxAnLJbui / HOhN9Hqq2y + c0kSJWagbtuoxhYh5njqwqS2xD"));
            string form2_loadiiing = StringCipher.Decrypt(God_mizer.System_Control_label3_text, Mücahit_Gökhan2);

            return form2_loadiiing;

        }

        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };


        public static string Crypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);

        }
        public static string Decrypt(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }


        public MySqlConnection mysqlbaglan = new MySqlConnection(NeoWorf_Mizer_Sirtuex_Process_Vortex());
        public string Neof_Wotf = NeoWorf_Mizer_Process_Vortex();
        public string mysgbaglan1 = Decrypt("BvvZ6dET7v2VJnCXHkVT0A==");
        public string IntializeComponemt = Decrypt("dDCeUZpOFfn0+XXIWwiRq+4kAr7Qi2RH");
        string adminadi2 = "";

        string yetki = "";
        string isim = "";
        public form_loading()
        {
            InitializeComponent();
        }


        /// Ipleri Alma Kodları MIZER
        /// 
        /// 
        /// 

        string cikis_ip_adresi_sorgula_mizer; // cikis ip adresi
        public static string ip4_adresini_getir_aga_mizer()
        {

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("IP4 Yerel adres bulunamadı. - Mizer");
        }


        /// 
        /// 
        /// 
        /// İpleri alma Kodları MIZER


        private void pg_ayar_ck()
        {
            try
            {
                string sql = "Select * from program_ayarlari where mizer=666";
                mysqlbaglan.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    if (oku["z_girisi_kapat"].ToString() == "Evet") { z_gir = false; } else { z_gir = true; }
                    if (oku["p_girisi_kapat"].ToString() == "Evet") { p_gir = false; } else { p_gir = true; }

                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -5", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }




        }
        public Boolean z_gir;
        public Boolean p_gir;



        private void form_loading_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.resimlinki = @"/resimlinki/letmerepair.png";
            label3.Text = "Lütfen Giriş Yapınız.";
            label4.Visible = true;
         
            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            timer1.Enabled = false;
            progressBar1.Visible = false;
            label2.Visible = false;
            label6.Visible = true;
            kadilabel.Visible = true;
            sifrelabel.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            kadilabel.Visible = true;
            sifrelabel.Visible = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            textBox1.Focus();
            progressBar1.Value = 0;
            pg_ayar_ck();
            try
            {
                cikis_ip_adresi_sorgula_mizer = new WebClient().DownloadString("http://icanhazip.com");
            }
            catch
            { }
            System.IO.Directory.CreateDirectory(@"C:\\Mizer_LMR_Faturalar\");
            System.IO.Directory.CreateDirectory(@"C:\\Mizer_LMR_Raporlar\");
            System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\");
            System.IO.DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            progressBar1.Maximum = 1000;
            progressBar1.Step = 200;
            textBox1.Focus();
            Neof_Wotf = "ftp://85.105.76.42/Veri/Mizer_software/LmR_garantidisi";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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


        private double seconds = 100;


        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value == 1000)
            {
                if (yetki == "Personel")
                {
                    pg_ayar_ck();
                    if (p_gir == true)
                    {
                        log_gonder(textBox1.Text, "Personel", "Personel Girişi", "Personel Giriş Yaptı.", "Şifre: " + textBox2.Text + " --- Dış Ip adresi: " + cikis_ip_adresi_sorgula_mizer + " --- Yerel Ip Adresi: " + ip4_adresini_getir_aga_mizer());
                        timer1.Enabled = false;

                        using (secim_form f2 = new secim_form())
                        {
                            this.Hide();
                            f2.gercek_yetki = yetki;
                            f2.adminadi = adminadi2;
                            f2.mysqlbaglan = mysqlbaglan;
                            f2.Neof_Wotf = Neof_Wotf;
                            f2.eG80LPJJCimP = mysgbaglan1;
                            f2.Id4SGF8YIcyg9y = IntializeComponemt;
                            f2.ekleyen_ismi_cek = isim;
                            f2.ShowDialog();
                            f2.Dispose();
                            form_loading_Load(null, null);
                            this.Show();
                            this.Refresh();


                        }
                        GC.Collect();
                    }
                    else
                    {

                        log_gonder(textBox1.Text, "Personel", "Personel Giriş Denemesi-KAPALI-", "Personel Giriş yapmaya ÇALIŞTI.", "Şifre: " + textBox2.Text + " --- Dış Ip adresi: " + cikis_ip_adresi_sorgula_mizer + " --- Yerel Ip Adresi: " + ip4_adresini_getir_aga_mizer());
                        timer1.Enabled = false;
                        MessageBox.Show("Personel girişleri yönetici tarafından kapatılmıştır. Program Kapatılıyor..", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        this.Close();
                    }

                }
                else if (yetki == "SüperAdmin")
                {

                    log_gonder(textBox1.Text, "Süper Admin", "Admin Girişi", "Admin Giriş Yaptı.", "Şifre: " + textBox2.Text + " --- Dış Ip adresi: " + cikis_ip_adresi_sorgula_mizer + " --- Yerel Ip Adresi: " + ip4_adresini_getir_aga_mizer());
                    timer1.Enabled = false;
                    using (anamenu f5 = new anamenu())
                    {
                        this.Hide();
                        f5.gercek_yetki = yetki;
                        f5.adminadi = adminadi2;
                        f5.ekleyen_ismi_cek = isim;
                        f5.mysqlbaglan = mysqlbaglan;
                        f5.eG80LPJJCimP = mysgbaglan1;
                        f5.Id4SGF8YIcyg9y = IntializeComponemt;
                        f5.Neof_Wotf = Neof_Wotf;
                        f5.ShowDialog();
                        f5.Dispose();
                        form_loading_Load(null, null);
                        this.Show();
                        this.Refresh();


                    }
                    GC.Collect();
                }
                else if (yetki == "Yetkili Personel")
                {

                    log_gonder(textBox1.Text, "Yetkili Personel", "Y.Personel Girişi", "Y.Personel Giriş Yaptı.", "Şifre: " + textBox2.Text + " --- Dış Ip adresi: " + cikis_ip_adresi_sorgula_mizer + " --- Yerel Ip Adresi: " + ip4_adresini_getir_aga_mizer());
                    timer1.Enabled = false;
                    using (anamenu f5 = new anamenu())
                    {
                        this.Hide();
                        f5.gercek_yetki = yetki;
                        f5.adminadi = adminadi2;
                        f5.ekleyen_ismi_cek = isim;
                        f5.mysqlbaglan = mysqlbaglan;
                        f5.eG80LPJJCimP = mysgbaglan1;
                        f5.Id4SGF8YIcyg9y = IntializeComponemt;
                        f5.Neof_Wotf = Neof_Wotf;
                        f5.ShowDialog();
                        f5.Dispose();
                        form_loading_Load(null, null);
                        this.Show();
                        this.Refresh();


                    }
                    GC.Collect();
                }
                else
                {
                    pg_ayar_ck();
                    if (z_gir == true)
                    {
                        log_gonder(textBox1.Text, "Ziyaretçi ", "Ziyaretçi Girişi", "Ziyaretçi Giriş Yaptı.", "Şifre: " + textBox2.Text + " --- Dış Ip adresi: " + cikis_ip_adresi_sorgula_mizer + " --- Yerel Ip Adresi: " + ip4_adresini_getir_aga_mizer());
                        timer1.Enabled = false;
                        using (secim_form_ziyaretci f4 = new secim_form_ziyaretci())
                        {
                            this.Hide();
                            f4.gercek_yetki = "Ziyaretçi";
                            f4.mysqlbaglan = mysqlbaglan;
                            f4.Neof_Wotf = Neof_Wotf;
                            f4.eG80LPJJCimP = mysgbaglan1;
                            f4.Id4SGF8YIcyg9y = IntializeComponemt;
                            f4.ShowDialog();
                            f4.Dispose();
                            form_loading_Load(null, null);
                            this.Show();
                            this.Refresh();


                        }
                        GC.Collect();
                    }
                    else { timer1.Enabled = false; MessageBox.Show("Ziyaretçi girişleri yönetici tarafından kapatılmıştır. Program Kapatılıyor..", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); this.Close(); }


                }


            }
            if (progressBar1.Value == 100)
            {

                label2.Text = "Arayüz Ayarlanıyor";
            }
            if (progressBar1.Value == 400)
            {
                timer1.Interval = 400;
                label2.Text = "Veritabanı bağlantısı kuruluyor";
            }
            if (progressBar1.Value == 700)
            {
                timer1.Interval = 100;
                label2.Text = "Ayarlar Yapılıyor";
            }
            if (progressBar1.Value == 900)
            {
                timer1.Interval = 700;
                label2.Text = "Program Açılıyor";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
        void f4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
        void f5_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Yanlış Girme Sayısı
        /// </summary>
        public int ErrorTimes { get; set; }
        /// <summary>
        /// Kilit
        /// </summary>
        public DateTime LockTime { get; set; }

        public bool CheckUserInfo(string userName, string password)
        {
            try
            {
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                mysqlbaglan.Open();
                string sql = "SELECT * FROM `kullanicilar` where kadi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                {

                    MessageBox.Show("Kullanıcı adı ve ya Şifre yanlış.", "Hata");
                    rdr.Close();
                    mysqlbaglan.Close();
                    return false;
                }
                else
                {


                    label3.Text = "Hoşgeldin " + rdr["isim"].ToString();
                    yetki = rdr["yetki"].ToString();
                    adminadi2 = rdr["kadi"].ToString();
                    isim = rdr["isim"].ToString();

                    rdr.Close();
                    mysqlbaglan.Close();
                    return true;

                }
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                return false;
            }


        }
        public void InsertLoginErrorInfo(string macAddress)
        {
            try
            {
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                string sql = string.Format("insert hatali_giris(mac_adresi,hatali_giris_sayisi,kilit_suresi,olusturma_suresi,guncelleme_suresi,denenen_id,denenen_sifre,cikis_ip_adresi,yerel_ip_adresi) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", macAddress, 1, DateTime.Now, DateTime.Now, DateTime.Now, textBox1.Text, textBox2.Text, cikis_ip_adresi_sorgula_mizer, ip4_adresini_getir_aga_mizer());
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                mysqlbaglan.Open();
                cmd.ExecuteNonQuery();
                mysqlbaglan.Close();
                sql = string.Format("insert hatali_giris_loglari(mac_adresi,tarih,denenen_id,denenen_sifre,cikis_ip_adresi,yerel_ip_adresi) values('{0}','{1}','{2}','{3}','{4}','{5}')", macAddress, DateTime.Now, textBox1.Text, textBox2.Text, cikis_ip_adresi_sorgula_mizer, ip4_adresini_getir_aga_mizer());
                cmd = new MySqlCommand(sql, mysqlbaglan);
                mysqlbaglan.Open();
                cmd.ExecuteNonQuery();
                mysqlbaglan.Close();
            }
            catch
            {

                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }

        }
        public void DeleteLoginErrorInfo(string macAddress)
        {
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
            string deleteSql = "delete from hatali_giris where mac_adresi='" + macAddress + "'";
            MySqlCommand cmd = new MySqlCommand(deleteSql, mysqlbaglan);
            mysqlbaglan.Open();
            cmd.ExecuteNonQuery();
            mysqlbaglan.Close();


        }
        public void UpdateLoginErrorInfo(string macAddress)
        {
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
            string updateSql = "update hatali_giris set hatali_giris_sayisi = hatali_giris_sayisi+1 where mac_adresi='" + macAddress + "'";
            MySqlCommand cmd = new MySqlCommand(updateSql, mysqlbaglan);
            mysqlbaglan.Open();
            cmd.ExecuteNonQuery();
            mysqlbaglan.Close();
            string sql = string.Format("insert hatali_giris_loglari(mac_adresi,tarih,denenen_id,denenen_sifre,cikis_ip_adresi,yerel_ip_adresi) values('{0}','{1}','{2}','{3}','{4}','{5}')", macAddress, DateTime.Now, textBox1.Text, textBox2.Text, cikis_ip_adresi_sorgula_mizer, ip4_adresini_getir_aga_mizer());
            cmd = new MySqlCommand(sql, mysqlbaglan);
            mysqlbaglan.Open();
            cmd.ExecuteNonQuery();
            mysqlbaglan.Close();

        }

        public LoginErrorInfo GetLoginErrorInfo(string macAddress)
        {
            try {
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }

                string sql = "Select hatali_giris_sayisi,kilit_suresi from hatali_giris where mac_adresi='" + macAddress + "'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okumayap = cmd.ExecuteReader();

                if (okumayap.Read())
                {
                    return new LoginErrorInfo() { ErrorTimes = Convert.ToInt32(okumayap["hatali_giris_sayisi"].ToString()), LockTime = Convert.ToDateTime(okumayap["kilit_suresi"].ToString()) };


                }
                else
                {
                    mysqlbaglan.Close();
                    return null;
                }
            }
            catch
            {
                mysqlbaglan.Close();
                return null;
            }
        }
        public string GetLocalMac()
        {
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
            string mac = null;
            System.Management.ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return (mac);
        }
        public class LoginErrorInfo
        {
            public int ErrorTimes { get; set; }
            public DateTime LockTime { get; set; }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }

            string version = version_sorgu();
            string mac = GetLocalMac();
            LoginErrorInfo loginErrorInfo = GetLoginErrorInfo(mac);
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
            if (loginErrorInfo == null)
            {
                bool flag = CheckUserInfo(textBox1.Text, textBox2.Text);
                if (flag)
                {
                    label3.Visible = true;
                    label4.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button1.Visible = false;
                    timer1.Enabled = true;
                    progressBar1.Visible = true;
                    label2.Visible = true;
                    label6.Visible = false;
                    kadilabel.Visible = false;
                    sifrelabel.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = true;
                }
                else
                {
                    InsertLoginErrorInfo(mac);
                }
            }

            else
            {
                if (loginErrorInfo.ErrorTimes >= 3)
                {
                    double totalSeconds = (DateTime.Now - loginErrorInfo.LockTime).TotalSeconds;
                    if (totalSeconds >= seconds)
                    {
                        DeleteLoginErrorInfo(mac);
                        bool flag = CheckUserInfo(textBox1.Text, textBox2.Text);
                        if (flag)
                        {
                            label3.Visible = true;
                            label4.Visible = false;
                            textBox1.Visible = false;
                            textBox2.Visible = false;
                            button1.Visible = false;
                            timer1.Enabled = true;
                            progressBar1.Visible = true;
                            label2.Visible = true;
                            label6.Visible = false;
                            kadilabel.Visible = false;
                            sifrelabel.Visible = false;
                            pictureBox2.Visible = false;
                            pictureBox3.Visible = false;
                            pictureBox4.Visible = true;
                        }
                        else
                        {
                            InsertLoginErrorInfo(mac);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Process Vortex'e 3 Kez yanlış girdiniz. Tekrar denemek için " + (100 - Convert.ToInt32(totalSeconds)).ToString() + " saniye bekleyin..");
                    }
                }
                else
                {
                    bool flag = CheckUserInfo(textBox1.Text, textBox2.Text);
                    if (flag)
                    {
                        label3.Visible = true;
                        label4.Visible = false;
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        button1.Visible = false;
                        timer1.Enabled = true;
                        progressBar1.Visible = true;
                        label2.Visible = true;
                        label6.Visible = false;
                        kadilabel.Visible = false;
                        sifrelabel.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                        pictureBox4.Visible = true;
                    }
                    else
                    {
                        UpdateLoginErrorInfo(mac);
                    }
                }
            }










        }
        private string version_sorgu()
        {
            String version = "";
            try
            {
                mysqlbaglan.Open();
                string sql = "SELECT * FROM `version_guvenlik_Mizer` ";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                {

                    MessageBox.Show("Version Bilgisi sağlanamadı Program kapatılıyor...", "Hata");
                    this.Close();
                    return ("Eski Sürüm");

                }
                else
                {


                    if (rdr["version"].ToString() == "0.14" || rdr["version2"].ToString() == "0.14")
                    {
                        version = (rdr["version"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Programı Güncelleştirin. Version: 0.13 . Olması gereken " + rdr["version"].ToString() + " Program kapatılıyor...", "Hata");
                        this.Close();
                        return ("Eski Sürüm");
                    }



                }
                rdr.Close();
                mysqlbaglan.Close();
                return version;

            }
            catch
            {

                mysqlbaglan.Close();
                MessageBox.Show("İnternet bağlantısı yok.", "Hata");
                return (version);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Concat(textBox1.Text.Where(char.IsLetterOrDigit));
            kadilabel.Visible = false;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            if (textBox1.Text.Length < 4)
            {
                errorProvider1.SetError(textBox1, "Kullanıcı Adınız En Az 4 Karakterden Oluşmalıdır.");
            }
            else
            {
                errorProvider1.Clear();
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sifrelabel.Visible = false;
            errorProvider2.BlinkRate = 500;
            errorProvider2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            if (textBox2.Text.Length < 4)
            {
                errorProvider2.SetError(textBox2, "Şifreniz En Az 4 Karakterden Oluşmalıdır.");

            }
            else
            {
                errorProvider2.Clear();
            }

        }





        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.ActiveControl = textBox2;

            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.ActiveControl = button1;

                SendKeys.Send("{ENTER}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void form_loading_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void form_loading_Shown(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        


        /* private void button2_Click_1(object sender, EventArgs e)
         {
             string mizer_urun_raport_saati = "Cari_Raporu Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
             ReportDocument rd;
             rd = new ReportDocument();
             rd.Load(Application.StartupPath + @"\cariyeait.rpt");
             rd.SetParameterValue("carino",295714467);

             rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
             System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
         }

         private void button3_Click(object sender, EventArgs e)
         {
             string mizer_urun_raport_saati = "Cari_Raporu Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
             ReportDocument rd;
             rd = new ReportDocument();
             rd.Load(Application.StartupPath + @"\fatura_goster.rpt");
             rd.SetParameterValue("cari_no", 295714467);
             rd.SetParameterValue("fatura_no", 100009);
             rd.SetParameterValue("alt_text", "asdasdasd");


             rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
             System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
         }
         */
    }
}
