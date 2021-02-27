using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using TagLib;


namespace LMR_Process_Vortex
{
    public partial class resim_goster_duzenle : Form
    {
        private MyWaitForm _waitForm;

        protected void ShowWaitForm(string message)
          {
              // don't display more than one wait form at a time
              if (_waitForm != null && !_waitForm.IsDisposed)
              {
                  return;
              }

              _waitForm = new MyWaitForm();
              ////  _waitForm.SetMessage(message); // "Loading data. Please wait..."
              _waitForm.TopMost = true;
              _waitForm.StartPosition = FormStartPosition.CenterScreen;
              _waitForm.label1.Text = "Resimler Yükleniyor Lütfen bekleyin...";
              _waitForm.Show();
              _waitForm.Refresh();

             


          }

          




        public resim_goster_duzenle()
        {
            InitializeComponent();
        }
        public string eG80LPJJCimP { get; set; }
        public string Id4SGF8YIcyg9y { get; set; }
        string res1_url, res2_url, res3_url, video_url, sec_seri_mizer;
        private string _address;
        private string _userName;
        private string _password;
        private string _logfile;
        private string _localPath;
        public string  Neof_Wotf { get; set; }
        public string veriyolu { get; set; }
        public string goster_duz_kapa { get; set; }
       public MySqlConnection mysqlbaglan { get; set; }
        private void resim_goster_duzenle_Load(object sender, EventArgs e)
        {
            try
            {
              if (goster_duz_kapa == "Tamam Tamam Kapan Kapan")
                {
                    button16.Dispose();
                    button15.Dispose();
                    button8.Dispose();
                    button9.Dispose();
                    button4.Dispose();
                    button5.Dispose();
                    button3.Dispose();
                    button10.Dispose();
                }
              
            }
            catch
            { }
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                sec_seri_mizer = veriyolu;
              ShowWaitForm("sie");
                mysqlbaglan.Open();
                string sql = "SELECT * FROM `anatablo` where `VT_serial_number`='" + veriyolu + "'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                {

                }
                else
                {




                    res1_url = rdr["VT_resim1_url"].ToString();
                    res2_url = rdr["VT_resim2_url"].ToString();
                    res3_url = rdr["VT_resim3_url"].ToString();
                    video_url = rdr["VT_video_url"].ToString();
                    ////  res1_url = rdr["VT_aciklama"].ToString();
                    ///

                }
                rdr.Close();
                mysqlbaglan.Close();
                KodumunFtpininProtokolunuDuzeltme();
                ////
                ///


                /* 


                 */
                verileri_yukle_1(res1_url);
                verileri_yukle_2(res2_url);
                verileri_yukle_3(res3_url);
                video_hakkinda(video_url);


              _waitForm.Close();
             
                this._address = video_url;
                this._userName = eG80LPJJCimP;
                this._password = Id4SGF8YIcyg9y;
                this._logfile = @"\logdosyasi.txt";
                this._localPath = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\";
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Value = 0;

            }
            catch
            {
                MessageBox.Show("İnternet bağlantınızı kontrol ediniz.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void verileri_yukle_1(string url)
        {
            pictureBox1.Image = (ResizeImage(LoadPicture(url,eG80LPJJCimP,Id4SGF8YIcyg9y), pictureBox1, true));
            if (pictureBox1.Image == null)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button10.Enabled = false;
                button3.Text = "Resim Ekle";
                pictureBox1.ImageLocation = @"sistem_dosyalari\resimbulunamadi.png";
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button10.Enabled = true;
                button3.Text = "Resim Değiştir";
            }
        }
        private void verileri_yukle_2(string url)
        {
            pictureBox2.Image = (ResizeImage(LoadPicture(url, eG80LPJJCimP, Id4SGF8YIcyg9y), pictureBox2, true));
            if (pictureBox2.Image == null)
            {
                button7.Enabled = false;
                button6.Enabled = false;
                button4.Enabled = false;
                button5.Text = "Resim Ekle";
                pictureBox2.ImageLocation = @"sistem_dosyalari\resimbulunamadi.png";
            }
            else
            {
                button7.Enabled = true;
                button6.Enabled = true;
                button4.Enabled = true;
                button5.Text = "Resim Değiştir";
            }
        }
        private void verileri_yukle_3(string url)
        {
            pictureBox3.Image = (ResizeImage(LoadPicture(url, eG80LPJJCimP, Id4SGF8YIcyg9y), pictureBox3, true));
            if (pictureBox3.Image == null)
            {
                button12.Enabled = false;
                button11.Enabled = false;
                button8.Enabled = false;
                button9.Text = "Resim Ekle";
                pictureBox3.ImageLocation = @"sistem_dosyalari\resimbulunamadi.png";


            }
            else
            {
                button12.Enabled = true;
                button11.Enabled = true;
                button8.Enabled = true;
                button9.Text = "Resim Değiştir";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPG Resmi (.jpg)|*.jpg|Bitmap Resmi (.bmp)|*.bmp|JPEG Resmi (.jpeg)|*.jpeg|Png Resmi (.png)|*.png |Tiff Resmi (.tiff)|*.tiff |Wmf Resmi (.wmf)|*.wmf";
                saveFileDialog1.Title = "Resmi Kaydet";
                saveFileDialog1.FileName = "*";
                saveFileDialog1.DefaultExt = "jpg";
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.ShowDialog();


                if (saveFileDialog1.FileName != "")
                {

                    System.IO.File.Copy((System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(res1_url)), saveFileDialog1.FileName, true);



                }
            }
            catch
            {

            }



            this.Focus();

        }
        public static Bitmap terale(Bitmap bmp)
        {

            Bitmap pussyt = bmp;

            return pussyt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPG Resmi (.jpg)|*.jpg|Bitmap Resmi (.bmp)|*.bmp|JPEG Resmi (.jpeg)|*.jpeg|Png Resmi (.png)|*.png |Tiff Resmi (.tiff)|*.tiff |Wmf Resmi (.wmf)|*.wmf";
                saveFileDialog1.Title = "Resmi Kaydet";
                saveFileDialog1.FileName = "*";
                saveFileDialog1.DefaultExt = "jpg";
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.ShowDialog();


                if (saveFileDialog1.FileName != "")
                {

                    System.IO.File.Copy((System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(res2_url)), saveFileDialog1.FileName, true);



                }
            }
            catch
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPG Resmi (.jpg)|*.jpg|Bitmap Resmi (.bmp)|*.bmp|JPEG Resmi (.jpeg)|*.jpeg|Png Resmi (.png)|*.png |Tiff Resmi (.tiff)|*.tiff |Wmf Resmi (.wmf)|*.wmf";
                saveFileDialog1.Title = "Resmi Kaydet";
                saveFileDialog1.FileName = "*";
                saveFileDialog1.DefaultExt = "jpg";
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.ShowDialog();


                if (saveFileDialog1.FileName != "")
                {

                    System.IO.File.Copy((System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(res3_url)), saveFileDialog1.FileName, true);



                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath;
                Process.Start(@"" + (fullPath = Path.GetFullPath(System.IO.Path.GetTempPath().ToString()+@"\gecicibellek\" + System.IO.Path.GetFileName(res1_url))) + "");
            }
            catch
            {

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath;
                Process.Start(@"" + (fullPath = Path.GetFullPath(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(res2_url))) + "");
              
            }
            catch
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath;
                Process.Start(@"" + (fullPath = Path.GetFullPath(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(res3_url))) + "");
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button6_Click(null, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button11_Click(null, null);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Default;
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Cursor = Cursors.Default;
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Cursor = Cursors.Hand;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult secenek = MessageBox.Show("Resmi değiştirmek istiyor musunuz? Eski resim silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        ResimKirpmaMotoru form_resimekle = new ResimKirpmaMotoru();
                        form_resimekle.resimyolu1 = ofd.FileName;
                        form_resimekle.sec = 1;
                        form_resimekle.Show();
                        form_resimekle.Visible = false;
                        form_resimekle.hocam_ben_gosterden_geldim = "goster";
                        form_resimekle.ShowDialog();
                        if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim1.jpg"))
                        {

                            this.label7.Visible = true;
                            resimdegistir("1");

                            /*   using (var resim = new Bitmap((@"gecicibellek/resim1.jpg"))
                                  {
                                      pictureBox1.Image = resim;
                                  }
                              File.Delete(@"gecicibellek/resim1.jpg");
                              */
                            using (var image = new Bitmap(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim1.jpg"))
                            {
                                image.Save(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim1_1.jpg");
                            }
                            System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim1.jpg");

                            verileri_yukle_1(res1_url);

                        }

                    }
                    else if (secenek == DialogResult.No)
                    {

                    }
                }
                else
                {

                }
            }
            catch
            {

            }



        }






        ///  BURALARDA KALDIK REİS ÜŞÜYORUZ YA 19.12.2018 GECE 2 GRAPHİKS FALAN YAPARIZ ARTIK YARİN. AMK DOSYASINI BİTMAPE ÇEVİRSEN BİLE KULLANILIYOR DİYOR ŞAKA GİBİ :ddd
        private void resim_yenile(object sender, PaintEventArgs e)
        {


        }

        private void Ftpbuttonyukle(string ofd)
        {





        }
        private void resimdegistir(string Musinin_Hangi_Resmi)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            progressBar1.Visible = true;
            this.label7.Visible = true;
            try
            {
                label7.Text = "Dosya Yükleniyor... Lütfen Bekleyin...";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/resimler/" + veriyolu + "_" + "resim" + Musinin_Hangi_Resmi + ".jpg");
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.ServicePoint.Expect100Continue = false;
                request.KeepAlive = true;
                request.EnableSsl = false;
                string resyukle = Neof_Wotf + "/resimler/" + veriyolu + "_" + "resim" + Musinin_Hangi_Resmi + ".jpg";

                using (Stream fileStream = System.IO.File.OpenRead(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim" + Musinin_Hangi_Resmi + ".jpg"))

                using (Stream ftpStream = request.GetRequestStream())
                {

                    progressBar1.Invoke(
                                                (MethodInvoker)delegate { progressBar1.Maximum = (int)fileStream.Length; });

                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        progressBar1.Invoke(
                            (MethodInvoker)delegate
                            {
                                label7.Text = (((int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100))).ToString() + "% - Dosya Yükleniyor... Lütfen Bekleyin...";
                                label7.Refresh();

                                progressBar1.Value = (int)fileStream.Position;



                            });


                    }

                }

               

            }
            catch
            {

                MessageBox.Show("Hatalı yükleme.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                progressBar1.Visible = false;
                this.label7.Visible = false;

            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Resmi Silmek istiyor musunuz? Resim tamamen silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                pictureBox1.Image = null;
                resim_sil("1");
                if (pictureBox1.Image == null)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button10.Enabled = false;
                    button3.Text = "Resim Ekle";
                    pictureBox1.ImageLocation = @"sistem_dosyalari\resimbulunamadi.png";
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button10.Enabled = true;
                    button3.Text = "Resim Değiştir";

                }
            }
            else if (secenek == DialogResult.No)
            {

            }
        }
        private void resim_sil(string Musinin_Hangi_Resmi)
        {
            try
            {


                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/resimler/" + veriyolu + "_" + "resim" + Musinin_Hangi_Resmi + ".jpg");
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.ServicePoint.Expect100Continue = false;
                request.KeepAlive = true;
                request.EnableSsl = false;
                string resyukle = Neof_Wotf + "/resimler/" + veriyolu + "_" + "resim" + Musinin_Hangi_Resmi + ".jpg";

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();


                MessageBox.Show("Resim Başarıyla Silindi ");

                System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + veriyolu + "_resim" + Musinin_Hangi_Resmi + ".jpg");
                response.Close();
            }



            catch
            {

                MessageBox.Show("Resim silinirken bir sorun oluştu.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult secenek = MessageBox.Show("Resmi değiştirmek istiyor musunuz? Eski resim silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        ResimKirpmaMotoru form_resimekle = new ResimKirpmaMotoru();
                        form_resimekle.resimyolu1 = ofd.FileName;
                        form_resimekle.sec = 2;
                       
                        form_resimekle.Show();
                        form_resimekle.Visible = false;
                        form_resimekle.hocam_ben_gosterden_geldim = "goster";
                        form_resimekle.ShowDialog();
                        if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim2.jpg"))
                        {


                            resimdegistir("2");
                            /*   using (var resim = new Bitmap((@"gecicibellek/resim1.jpg"))
                                  {
                                      pictureBox1.Image = resim;
                                  }
                              File.Delete(@"gecicibellek/resim1.jpg");
                              */
                            using (var image = new Bitmap(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim2.jpg"))
                            {
                                image.Save(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim2_1.jpg");
                            }
                            System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim2.jpg");
                            verileri_yukle_2(res2_url);

                        }

                    }
                    else if (secenek == DialogResult.No)
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult secenek = MessageBox.Show("Resmi değiştirmek istiyor musunuz? Eski resim silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        ResimKirpmaMotoru form_resimekle = new ResimKirpmaMotoru();
                        form_resimekle.resimyolu1 = ofd.FileName;
                        form_resimekle.sec = 3;
                        form_resimekle.Show();
                        form_resimekle.Visible = false;
                        form_resimekle.hocam_ben_gosterden_geldim = "goster";
                        form_resimekle.ShowDialog();
                        if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim3.jpg"))
                        {


                            resimdegistir("3");
                            /*   using (var resim = new Bitmap((@"gecicibellek/resim1.jpg"))
                                  {
                                      pictureBox1.Image = resim;
                                  }
                              File.Delete(@"gecicibellek/resim1.jpg");
                              */
                            using (var image = new Bitmap(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim3.jpg"))
                            {
                                image.Save(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim3_1.jpg");
                            }
                            System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\resim3.jpg");
                            verileri_yukle_3(res3_url);

                        }

                    }
                    else if (secenek == DialogResult.No)
                    {

                    }
                }
                else
                {

                }
            }
            catch
            {

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Resmi Silmek istiyor musunuz? Resim tamamen silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                pictureBox2.Image = null;
                resim_sil("2");
                if (pictureBox2.Image == null)
                {
                    button7.Enabled = false;
                    button6.Enabled = false;
                    button4.Enabled = false;
                    button5.Text = "Resim Ekle";
                    pictureBox2.ImageLocation = @"sistem_dosyalari\resimbulunamadi.png";
                }
                else
                {
                    button7.Enabled = true;
                    button6.Enabled = true;
                    button4.Enabled = true;
                    button5.Text = "Resim Değiştir";
                }
            }
            else if (secenek == DialogResult.No)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Resmi Silmek istiyor musunuz? Resim tamamen silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                pictureBox3.Image = null;
                resim_sil("3");
                if (pictureBox3.Image == null)
                {
                    button12.Enabled = false;
                    button11.Enabled = false;
                    button8.Enabled = false;
                    button9.Text = "Resim Ekle";
                    pictureBox3.ImageLocation = @"sistem_dosyalari\resimbulunamadi.png";
                }
                else
                {
                    button12.Enabled = true;
                    button11.Enabled = true;
                    button8.Enabled = true;
                    button9.Text = "Resim Değiştir";
                }
            }
            else if (secenek == DialogResult.No)
            {

            }
        }

        private void resim_goster_duzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath;
                Process.Start(@"" + (fullPath = Path.GetFullPath(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(video_url))) + "");
            }
            catch
            {

            }

        }

        public static Bitmap LoadPicture(string url,string id2, string sifre)
        {
            System.Net.FtpWebRequest wreq;
            System.Net.FtpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;


            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(url);
                wreq.Credentials = new NetworkCredential(id2, sifre);
                wreq.Timeout = 120000;


                wresp = (System.Net.FtpWebResponse)wreq.GetResponse();

                if ((mystream = wresp.GetResponseStream()) != null)
                    bmp = new Bitmap(mystream);
                bmp.Save(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(url) + "");
            }
            catch
            {

            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }

            return (bmp);
        }
        private string video_cek(string url, string seri)
        {

            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            progressBar1.Visible = true;
            label7.Visible = true;

             try
             {
            backgroundWorker1_DoWork(null, null);


                }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 finally
                 {
               
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                progressBar1.Visible = false;
                label7.Visible = false;



              
         }
            return (System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + Path.GetFileName(url));            /*   System.Net.FtpWebRequest request;
               System.Net.FtpWebResponse request;
               request = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(url);
               request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
               request.Timeout = 120000;
               request.Method = WebRequestMethods.Ftp.GetFileSize;




               */












        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine(e.ProgressPercentage * (int)e.UserState / 100 + " bytes / " + e.UserState + " bytes" + " % = " + e.ProgressPercentage);
              progressBar1.Value = e.ProgressPercentage;
            label7.Text = e.ProgressPercentage + " %  - Video İndiriliyor...Lütfen Bekleyin...";
            label7.Refresh();

          
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

          private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 0;
            string fileName = Path.GetFileName(video_url);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this._address );
            request.Credentials = new NetworkCredential(this._userName, this._password);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Proxy = null;

            long fileSize; // this is the key for ReportProgress
            using (WebResponse resp = request.GetResponse())
                fileSize = resp.ContentLength;

            request = (FtpWebRequest)WebRequest.Create(this._address);
            request.Credentials = new NetworkCredential(this._userName, this._password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            using (FtpWebResponse responseFileDownload = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = responseFileDownload.GetResponseStream())
            using (FileStream writeStream = new FileStream(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + Path.GetFileName(video_url), FileMode.Create))
            {

                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                int bytes = 0;

                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                    bytes += bytesRead;// don't forget to increment bytesRead !
                    int totalSize = (int)(fileSize) / 1000; // Kbytes
                    backgroundWorker1.ReportProgress((bytes / 1000) * 100 / totalSize, totalSize);
                }
            }
           


        }





        public static Image ResizeImage(Image image, PictureBox canvas, bool centerImage)
        {
            if (image == null || canvas == null)
            {
                return null;
            }

            int canvasWidth = canvas.Size.Width;
            int canvasHeight = canvas.Size.Height;
            int originalWidth = image.Size.Width;
            int originalHeight = image.Size.Height;

            System.Drawing.Image thumbnail =
                new Bitmap(canvasWidth, canvasHeight); // changed parm names
            System.Drawing.Graphics graphic =
                         System.Drawing.Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;


            double ratioX = (double)canvasWidth / (double)originalWidth;
            double ratioY = (double)canvasHeight / (double)originalHeight;
            double ratio = ratioX < ratioY ? ratioX : ratioY;


            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);


            int posX = Convert.ToInt32((canvasWidth - (image.Width * ratio)) / 2);
            int posY = Convert.ToInt32((canvasHeight - (image.Height * ratio)) / 2);

            if (!centerImage)
            {
                posX = 0;
                posY = 0;
            }
            graphic.Clear(Color.White);
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);



            System.Drawing.Imaging.ImageCodecInfo[] info =
                             ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,
                             100L);

            Stream s = new System.IO.MemoryStream();
            thumbnail.Save(s, info[1],
                              encoderParameters);

            return Image.FromStream(s);
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click_1(object sender, EventArgs e)
        {


            try
            {  
            video_cek(video_url, veriyolu);
                button17.Enabled = false;
                button17.Visible = false;
                button13.Enabled = true;
                button13.Visible = true;
                button14.Enabled = true;
                button14.Visible = true;
                button16.Enabled = true;
                button16.Visible = true;
                button15.Enabled = true;
                button15.Visible = true;

            }
            catch
            {

            }
            label7.Visible = false;

            try
            {
                if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + veriyolu + "_" + Path.GetFileName(video_url)))
                {

                  
                    label12.Text = " Video Süresi: " + video_suresini_bul(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + Path.GetFileName(video_url));
                }
                else
                {
                    this.label7.Visible = true;

                    label12.Text = " Video Süresi: " + video_suresini_bul(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + Path.GetFileName(video_url));


                }
            }
            catch
            {
                label7.Visible = false;
            }
            finally
            {
                label7.Visible = false;
            }



            this.Focus();


        }

        private void GetFilesList(string address, string fileName, string userName, string password)
        {

          


        }

            private void button14_Click(object sender, EventArgs e)
            {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Video Dosyaları|*.mp4;*.m4v;*.mov;*.mpg;*.mpeg;*.avi;*.asf;*.flv;*.swi;*.swf;*.amv;*.mkv;*.3gp;*.webm;*.3gpp";
                saveFileDialog1.Title = "Resmi Kaydet";
                saveFileDialog1.FileName = "*";
                saveFileDialog1.DefaultExt = System.IO.Path.GetExtension(video_url);
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.ShowDialog();


                if (saveFileDialog1.FileName != "")
                {

                    System.IO.File.Copy((System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + System.IO.Path.GetFileName(video_url)), saveFileDialog1.FileName, true);



                }
            }
            catch
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
           try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Video Dosyaları|*.mp4;*.m4v;*.mov;*.mpg;*.mpeg;*.avi;*.asf;*.flv;*.swi;*.swf;*.amv;*.mkv;*.3gp;*.webm;*.3gpp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string videodeneme = ofd.FileName;
                    try
                    {
                        
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/videolar/" + Path.GetFileName(video_url));
                        request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                        request.Method = WebRequestMethods.Ftp.DeleteFile;
                        request.ServicePoint.Expect100Continue = false;
                        request.KeepAlive = true;
                        request.EnableSsl = false;
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        response.Close();
                    }
                    catch
                    {

                    }
                    label6.Text = "Kayıtlı Video yok.";
                    label11.Text = "Video Uzantısı: N/A ";
                    label11.Text = " Video Süresi: N/A";
                    video_yukle(videodeneme);
                    video_vt_ext();
                 video_hakkinda(video_url);
                    groupBox1.Visible = true;
                    groupBox2.Visible = true;
                    groupBox3.Visible = true;
                    panel1.Visible = true;
                    panel2.Visible = true;
                    panel3.Visible = true;
                    progressBar1.Visible = false;
                    this.label7.Visible = false;

                }
           }
           catch
            {

            }
            
        }

        private void video_yukle(string videodeneme)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            progressBar1.Visible = true;
            this.label7.Visible = true;
            
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/videolar/" + veriyolu + "_" + "video" + Path.GetExtension(videodeneme) + "");
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.ServicePoint.Expect100Continue = false;
                request.EnableSsl = false;
                request.KeepAlive = true;
                video_url = Neof_Wotf + "/videolar/" + veriyolu + "_" + "video" + Path.GetExtension(videodeneme) + "";
                _address = video_url;
                using (Stream fileStream = System.IO.File.OpenRead(videodeneme))

                using (Stream ftpStream = request.GetRequestStream())
                {

                    progressBar1.Invoke(
                                    (MethodInvoker)delegate { progressBar1.Maximum = (int)fileStream.Length; });

                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        progressBar1.Invoke(
                            (MethodInvoker)delegate
                            {
                                label7.Text = (((int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100))).ToString() + "% - Dosya Yükleniyor... Lütfen Bekleyin...";
                                label7.Refresh();
                                progressBar1.Value = (int)fileStream.Position;

                            });

                    }
                    fileStream.Close();
                    ftpStream.Close();
                    label7.Visible = false;

                }
               
            }
            catch
            {
                label7.Visible = false;


            }
            finally
            {
                label7.Visible = false;
            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult secenek = MessageBox.Show("Video'yu Silmek istiyor musunuz? Video tamamen silinecek.", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    video_sil();
                    if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + Path.GetFileName(video_url)) == false)
                    {
                        button17.Enabled = false;
                        button17.Visible = false;
                        button13.Enabled = false;
                        button14.Enabled = false;
                        button15.Enabled = false;
                        button16.Enabled = true;
                        button16.Visible = true;
                        button16.Text = "Video Ekle";
                    }
                    else
                    {
                        button17.Enabled = false;
                        button17.Visible = false;
                        button13.Enabled = true;
                        button13.Visible = true;
                        button14.Enabled = true;
                        button14.Visible = true;
                        button15.Enabled = true;
                        button15.Visible = true;
                        button16.Enabled = true;
                        button16.Visible = true;
                        button16.Text = "Video Değiştir";
                    }
                    video_hakkinda(video_url);
                }
                else if (secenek == DialogResult.No)
                {


                }
            }
            catch
            { }
        }

        private void video_sil()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/videolar/" + Path.GetFileName(video_url));
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.ServicePoint.Expect100Continue = false;
                request.KeepAlive = true;
                request.EnableSsl = false;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();


                MessageBox.Show("Video Başarıyla Silindi ");

                System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + Path.GetFileName(video_url));
                response.Close();
            }



            catch
            {

                MessageBox.Show("Video silinirken bir sorun oluştu.", "LMR - Mizer",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void video_vt_ext()
        {
            try
            {
                mysqlbaglan.Open();
                string guncelle = "update `anatablo` set VT_video_url=@url where VT_serial_number=@sn";
                MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                guncel.Parameters.AddWithValue("@sn", veriyolu);
                guncel.Parameters.AddWithValue("@url", video_url);
                guncel.ExecuteNonQuery();
                mysqlbaglan.Close();
            }
            catch
            {
                MessageBox.Show("Bağlantı sorunu", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


























        /// <summary>
        /// / 22.12.2018 video boyutunda kaldık. üşüyorum aq gece 3 oldu yarin sabah 9da iş var. Nas kapanmasa daha çok uğraşcamda :d
        /// yarin geldiğimde bir yemek söyler 2-3 bira alırım sonra devam videoyu halledip secim formuna entegre edeceğim
        /// seçim formundan sonra grafik işlerini halledicem.
        /// yarin print işini halledersek süper olur. pazar günüde süperwizor olaylarına bakarız datagridview kullanıcı ekleme flaan.
        /// </summary>
        /// <param name="url"></param>
        private void video_hakkinda(string url)
        {
             try
             {


                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(url);
                request.Proxy = null;
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.ServicePoint.Expect100Continue = false;
                request.KeepAlive = true;
                request.EnableSsl = false;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                double size = response.ContentLength;
           

                if (size != 0)
                {
                    label6.Text = "Video Boyutu: " + dosyanın_boyutunu_al(size);
                    string dosya_uzantisi = Path.GetExtension(url);
                    label11.Text = "Video Uzantısı: " + dosya_uzantisi;
                 
                    button17.Enabled = true;
                    button17.Visible = true;
                    button13.Enabled = false;
                    button13.Visible = false;
                    button16.Enabled = false;
                    button16.Visible = false;
                    button16.Text = "Video Değiş";
                    button15.Enabled = false;
                    button15.Visible = false;
                    button14.Enabled = false;
                    button14.Visible = false;

                }
                else
                {
                    button17.Enabled = false;
                    button17.Visible = false;
                    button13.Enabled = false;
                    button13.Visible = false;
                    button16.Enabled = true;
                    button16.Visible = true;
                    button16.Text = "Video Ekle";
                    button15.Enabled = false;
                    button15.Visible = false;
                    button14.Enabled = false;
                    button14.Visible = false;
                    label6.Text = "Kayıtlı Video yok.";
                    label11.Text = "Video Uzantısı: N/A ";
                    label11.Text = " Video Süresi: N/A";
                   
                }
            response.Close();
            
            }
             catch
                {
                    button17.Enabled = false;
                button17.Visible = false;
                button13.Enabled = false;
                button13.Visible = false;
                button16.Enabled = true;
                button16.Visible = true;
                button16.Text = "Video Ekle";
                    button15.Enabled = false;
                button15.Visible = false;
                button14.Enabled = false;
                button14.Visible = false;
                label6.Text = "Kayıtlı Video yok.";
                label11.Text = "Video Uzantısı: N/A ";
                label11.Text = " Video Süresi: N/A";

            }
               

        }

        protected string video_suresini_bul(string FilePath)
        {
            string VideoDuration = "";
            try
            {

                using (TagLib.File file = TagLib.File.Create(FilePath))

                {

                    string Hour = file.Properties.Duration.Hours.ToString();

                    string Minute = file.Properties.Duration.Minutes.ToString();

                    string Second = file.Properties.Duration.Seconds.ToString();

                    VideoDuration = Hour + ":" + Minute + ":" + Second;

                }


                return VideoDuration;
            }
            catch
            {
                return VideoDuration;
            }
            finally
            {
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
                button16.Enabled = true;
                button16.Text = "Video Değiştir";

            }


        }

        private static string dosyanın_boyutunu_al(double efsaneyi_al)
        {
            string[] byte_cinsi = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int index = 0;
            do { efsaneyi_al /= 1024; index++; }
            while (efsaneyi_al >= 1024);
            return String.Format("{0:0.00} {1}", efsaneyi_al, byte_cinsi[index]);
        }







        private static void KodumunFtpininProtokolunuDuzeltme()
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
    }
}