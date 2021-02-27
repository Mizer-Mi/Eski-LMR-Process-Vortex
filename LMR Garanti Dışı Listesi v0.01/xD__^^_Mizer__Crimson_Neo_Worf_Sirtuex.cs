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
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using System.Collections;
using System.Globalization;

namespace LMR_Process_Vortex
{

    public partial class xD_____Mizer__Crimson_Neo_Worf_Sirtuex : Form
    {
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string adminadi { get; set; }
        public string eG80LPJJCimP { get; set; }
        public string Id4SGF8YIcyg9y { get; set; }
        public string Neof_Wotf { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }
        public xD_____Mizer__Crimson_Neo_Worf_Sirtuex()
        {
            InitializeComponent();
        }
        public static string zaman;
        private void zamanhesapla()
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;
          /*  try
            {
                var client = new System.Net.Sockets.TcpClient("time.nist.gov", 13);
                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();
                    var utcDateTimeString = response.Substring(7, 17);
                    var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                    zaman = localDateTime.ToString().Replace(':', '.');

                }

            }
            catch
            {
                MessageBox.Show("ŞİFRE DOĞRU ama Güvenlik Bağlantısı Sağlanamadı Tekrar Deneyin.", "Mizer - LmR ");
                DialogResult = DialogResult.OK;
            }
            */
            try
            {
                using (var response =
                  WebRequest.Create("http://www.google.com").GetResponse())
                    //string todaysDates =  response.Headers["date"];
                    zaman= DateTime.ParseExact(response.Headers["date"],
                        "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        CultureInfo.InvariantCulture.DateTimeFormat,
                        DateTimeStyles.AssumeUniversal).ToString();
              zaman =  zaman.Replace(" ", "-");
               zaman = zaman.Replace(":", ".");
               
            }
            catch (WebException)
            {
                zaman= DateTime.Now.ToString(); //In case something goes wrong. 
                zaman = zaman.Replace(" ", "-");
                zaman = zaman.Replace(":",".");
             
            }

        }

        private void xD_____Mizer__Crimson_Neo_Worf_Sirtuex_Load(object sender, EventArgs e)
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;
            zamanhesapla();
        
            KodumunFtpininProtokolunuDuzeltme();
            getFileList();
            

        }

        public void getFileList()

        {
            listBox1.Items.Clear();
            List<string> files = new List<string>();

            try
            {
                FtpWebRequest request = FtpWebRequest.Create(Neof_Wotf + "/vt_yedek/") as FtpWebRequest;
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;





                FtpWebResponse response = request.GetResponse() as FtpWebResponse;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)

                {

                    files.Add(reader.ReadLine());


                }

                foreach (string file in files)
                {
                    listBox1.Items.Add(file);
                }



                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                listBox1.Items.RemoveAt(0);
                listBox1.Items.RemoveAt(0);
            }
            catch
            {

            }

        }
        private void Backup()
        {

            string file = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "resim3.jpg";
            using (mysqlbaglan)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = mysqlbaglan;
                        mysqlbaglan.Open();
                        mb.ExportToFile(file);
                        mysqlbaglan.Close();
                    }
                }
            }
        }
        private void Restore()
        {
            string file = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "resim2.jpg";
            string file_mizer = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "resim2.sql";
            System.IO.File.Move(file, file_mizer);
            using (mysqlbaglan)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = mysqlbaglan;
                        mysqlbaglan.Open();
                        mb.ImportFromFile(file_mizer);
                        mysqlbaglan.Close();
                    }
                }
            }
        }
        private void dir(string neos)
        {
            KodumunFtpininProtokolunuDuzeltme();
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(neos + zaman);
            ftp.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
            ftp.UsePassive = true;
            ftp.UseBinary = true;
            ftp.KeepAlive = true;
            ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
            FtpWebResponse CreateForderResponse = (FtpWebResponse)ftp.GetResponse();
            CreateForderResponse.Close();




        }

        private void kir(string neowo)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                    client.UploadFile(neowo, WebRequestMethods.Ftp.UploadFile, System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"resim3.jpg");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Backup();
            KodumunFtpininProtokolunuDuzeltme();
            zamanhesapla();
            MessageBox.Show(zaman);
            try
            {

                string olum = Neof_Wotf + "/vt_yedek/"+zaman+ "/resim3.jpg";
                string olum2_m_k = Neof_Wotf + "/vt_yedek/";
                dir(olum2_m_k);
                kir(olum);

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }

            System.IO.DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            getFileList();


        }


        private void ftp_cek()
        {
            
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                    client.DownloadFile(Neof_Wotf + "/vt_yedek/" + listBox1.SelectedItem.ToString()+ "/resim3.jpg", System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"resim2.jpg");

                }
            
          


        }























        /// 

        public static void KodumunFtpininProtokolunuDuzeltme()
        {
            Type requestType = typeof(FtpWebRequest);
            FieldInfo methodInfoField = requestType.GetField("m_MethodInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            Type methodInfoType = methodInfoField.FieldType;


            FieldInfo knownMethodsField = methodInfoType.GetField("KnownMethodInfo", BindingFlags.Static | BindingFlags.NonPublic);
            Array knownMethodsArray = (Array)knownMethodsField.GetValue(null);

            FieldInfo flagsField = methodInfoType.GetField("Flags", BindingFlags.NonPublic | BindingFlags.Instance);

            int MustChangeWorkingDirectoryToPath = 0x100;
            foreach (object knownMethod in knownMethodsArray)
            {
                int flags = (int)flagsField.GetValue(knownMethod);
                flags |= MustChangeWorkingDirectoryToPath;
                flagsField.SetValue(knownMethod, flags);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Backup();
            KodumunFtpininProtokolunuDuzeltme();
            zamanhesapla();
            try
            {

                string olum = Neof_Wotf + "/neolurneolmaz/" + zaman + "/resim3.jpg";
                string olum2_m_k = Neof_Wotf + "/neolurneolmaz/";
                dir(olum2_m_k);
                kir(olum);
                ftp_cek();
                Restore();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }

            System.IO.DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
              

                if (MessageBox.Show(" Kullanıcı Loglarını silmek istediğine Emin misin ??", "Siliyorum Bak Üzülme Sonra :D", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from kullanici_islemleri";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    MessageBox.Show(" TÜM Kullanıcı Loglarını SİLDİNİZ.", "Process Vortex :( Silindi..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (MessageBox.Show(" Hatalı Giriş Loglarını silmek istediğine Emin misin ??", "Siliyorum Bak Üzülme Sonra :D", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from hatali_giris_loglari";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    MessageBox.Show(" TÜM Hatalı Giriş Loglarını SİLDİNİZ.", " Process Vortex :( Silindi..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}