using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LMR_Process_Vortex
{

    public partial class ResimKirpmaMotoru : Form

    {

        public string resimyolu1 { get; set; }
        public string hocam_ben_gosterden_geldim { get; set; }

        public int sec
        {
            get;
            set;
        }


        secim_form wolfsfadedonus = new secim_form();
        Image<Bgr, byte> imgInput;
        Rectangle rect;
        Point StartLocation;
        Point EndLcation;
        bool IsMouseDown = false;
        OpenFileDialog ofd = new OpenFileDialog();


        public ResimKirpmaMotoru()
        {
            InitializeComponent();
        }

        private void ResimKirpmaMotoru_Load(object sender, EventArgs e)
        {
           /* Rectangle cozunurluk = new Rectangle();
            cozunurluk = Screen.GetBounds(cozunurluk);
            float YWidth = ((float)cozunurluk.Width / (float)1366);
            float YHeight = ((float)cozunurluk.Height / (float)768);
            SizeF scale = new SizeF(YWidth, YHeight);
            this.Scale(scale);
            foreach (Control control in this.Controls)//panel içindeyse this.Panel1.Controls
            {
                control.Font = new Font("Microsoft Sans Serif", control.Font.SizeInPoints * YHeight * YWidth);
            }
            foreach (Control control in this.panel2.Controls)//panel içindeyse this.Panel1.Controls
            {
                control.Font = new Font("Microsoft Sans Serif", control.Font.SizeInPoints * YHeight * YWidth);
            }
            
            */

            try
            { 
            ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
            if (resimyolu1 == null)
            {


            }
            else
            {
                    ofd.FileName = resimyolu1;
                    imgInput = new Image<Bgr, byte>(resimyolu1);
                pictureBox1.Image = imgInput.Bitmap;
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("AYRIŞTIRMA HATASI !. Yüklediğiniz resim geçerli değil. Resim bozuk olabilir,");
            }
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = imgInput.Bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                resimyolu1 = null;
                pictureBox2.Image = null;
            }



        }
        private Rectangle GetRectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(StartLocation.X, EndLcation.X);
            rect.Y = Math.Min(StartLocation.Y, EndLcation.Y);
            rect.Width = Math.Abs(StartLocation.X - EndLcation.X);
            rect.Height = Math.Abs(StartLocation.Y - EndLcation.Y);

            return rect;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (IsMouseDown == true)
                {
                    EndLcation = e.Location;
                    IsMouseDown = false;
                    if (rect != null)
                    {
                        imgInput.ROI = rect;
                        Image<Bgr, byte> temp = imgInput.CopyBlank();
                        imgInput.CopyTo(temp);
                        imgInput.ROI = Rectangle.Empty;
                        pictureBox2.Image = temp.Bitmap;
                    }
                }
            }
            catch
            {

            }

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                EndLcation = e.Location;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            StartLocation = e.Location;
        }

        private void kırpmaAracıHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mizer Crop Engine | Mizer Resim Kırpma aracı | Version 0.001 ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string imagePath2 = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" +"resim" + sec + ".jpg";
                pictureBox2.Image.Save(imagePath2);
                wolfsfadedonus.WolfsFade = sec.ToString();
                cikis_Click(sender, e);

            }
            catch 
            {
         
                MessageBox.Show("Kırpıp Kaydetmek istiyorsan ilk önce Resmi kırp.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmpKucuk = new Bitmap(pictureBox1.Image, 631, 768);
            pictureBox1.Image = bmpKucuk;
            pictureBox1.Width = 631;
            pictureBox1.Height = 768;
            string imagePath3 = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg";
            pictureBox1.Image.Save(imagePath3);
            imgInput = new Image<Bgr, byte>(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg");
            pictureBox1.Image = imgInput.Bitmap;

            if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg"))
            {
                System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click_1(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                string orjinalresimkaydet = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"resim" + sec + ".jpg";
                pictureBox1.Image.Save(orjinalresimkaydet);
                wolfsfadedonus.WolfsFade = sec.ToString();
                cikis_Click(sender, e);
               


            }
            catch 
            {

                MessageBox.Show("Resim Seç");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
              
               if (ofd.FileName == "")
                {

                }
                else
                {
                    imgInput = new Image<Bgr, byte>(ofd.FileName);
                    pictureBox1.Image = imgInput.Bitmap;
                }
               
                if (((Convert.ToInt32(textBox2.Text) > 100) && (Convert.ToInt32(textBox2.Text) < 2400)))
                {
                    if (((Convert.ToInt32(textBox1.Text) > 100) && (Convert.ToInt32(textBox1.Text) < 2400)))
                    {
                        int genisliksize, yuksekliksize;
                        genisliksize = Convert.ToInt32(textBox1.Text);
                        yuksekliksize = Convert.ToInt32(textBox2.Text);
                        Bitmap bmpKucuk = new Bitmap(pictureBox1.Image, genisliksize, yuksekliksize);
                        pictureBox1.Image = bmpKucuk;
                        pictureBox1.Width = genisliksize;
                        pictureBox1.Height = yuksekliksize;
                     
                        string imagePath3 = System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg";
                        pictureBox1.Image.Save(imagePath3);
                        imgInput = new Image<Bgr, byte>(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg");
                        pictureBox1.Image = imgInput.Bitmap;

                        if (System.IO.File.Exists(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\" + "geciciresimmizer.jpg"))
                        {
                            System.IO.File.Delete(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"geciciresimmizer.jpg");
                        }
                      


                        /*  Bitmap bmpKucuk = new Bitmap(pictureBox1.Image, genisliksize, yuksekliksize);
                          pictureBox1.Image = bmpKucuk;
                          pictureBox1.Width = genisliksize;
                          pictureBox1.Height = yuksekliksize;
                          string imagePath3 = @"resim\geciciresimmizer.jpg";
                          pictureBox1.Image.Save(imagePath3);
                          imgInput = new Image<Bgr, byte>(@"resim\geciciresimmizer.jpg");
                          pictureBox1.Image = imgInput.Bitmap;

                          if (System.IO.File.Exists(@"resim\geciciresimmizer.jpg"))
                          {
                              System.IO.File.Delete(@"resim\geciciresimmizer.jpg");
                          }
                          */
                    }
                    else
                    {
                        MessageBox.Show("Genişlik 100px ile 2400 arasında olmalı, Bu aralıkta bir değer girin");
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                }

                else
                {

                    MessageBox.Show("Yükseklik 100px ile 2400 arasında olmalı, Bu aralıkta bir değer girin");
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Girdiğiniz değerler geçerli değil. Lütfen geçerli değer giriniz. Piksel cinsinden.");
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {


        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

        }

        void setLabelInForm1()
        {
            if (hocam_ben_gosterden_geldim == null)
            {
                try
                {
                    secim_form frm13 = (secim_form)Application.OpenForms["secim_form"];
                    secim_form verigonderq = new secim_form();
                    switch (sec)
                    {
                        case 1:
                            if (wolfsfadedonus.WolfsFade == "1")
                            {

                                frm13.label15.Text = "Resim 1: (Seçildi)";


                            }
                            else { frm13.label15.Text = "Resim 1:"; }
                            break;
                        case 2:
                            if (wolfsfadedonus.WolfsFade == "2")
                            {

                                frm13.label9.Text = "Resim 2: (Seçildi)";


                            }
                            else { frm13.label9.Text = "Resim 2:"; }


                            break;
                        case 3:
                            if (wolfsfadedonus.WolfsFade == "3")
                            {

                                frm13.label10.Text = "Resim 3: (Seçildi)";


                            }
                            else { frm13.label10.Text = "Resim 3:"; }

                            break;
                    }





                }
                catch
                {
                    MessageBox.Show("Görsel Hata");
                }
            }
            else
            {
                hocam_ben_gosterden_geldim = null;
               
            }

        }

        private void cikis_Click(object sender, EventArgs e)
        {
           

            this.Close();


        }

        private void cikis_Click_1(object sender, EventArgs e)
        {
            

            this.Close();
        }

        private void ResimKirpmaMotoru_FormClosing(object sender, FormClosingEventArgs e)
        {
            setLabelInForm1();
            pictureBox2.Image = null;
            pictureBox1.Image = null;
            textBox1.Text = "631";
            textBox2.Text = "768";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kırpVeKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void orjinalKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(null,null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

