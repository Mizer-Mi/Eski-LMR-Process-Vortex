using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMR_Process_Vortex
{
    public partial class parca_ekle_basarili : Form
    {
        public parca_ekle_basarili()
        {
            InitializeComponent();
        }

        private void parca_ekle_basarili_Load(object sender, EventArgs e)
        {
           /* parca_no.ReadOnly = true;
            parca_no.BorderStyle = 0;
            parca_no.BackColor = this.BackColor;
            Random rastgele = new Random();
            int barkod_numarasi = rastgele.Next(166666666, 966666666);
            parca_no.Text = barkod_numarasi.ToString();
            label1.Focus();


            StrokeScribeClass ss = new StrokeScribeClass();
            ss.Alphabet = enumAlphabet.CODE128;
            ss.Text = barkod_numarasi.ToString();
            ss.FontColor = 0x000000; //0xff0000=blue, 0x00ff00=green, 0x0000ff=red

            int width = ss.BitmapW;
            int rc = ss.SavePicture("muconun_barkodu.bmp", enumFormats.BMP, width * 2, width);
            if (rc != 0)
                System.Console.Write(ss.ErrorDescription);

            pictureBox2.ImageLocation = (@"muconun_barkodu.bmp");
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Set the printer name. 
              ///  pd.PrinterSettings.PrinterName = textBox1.Text;               
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            System.Drawing.Font printFont = new System.Drawing.Font("3 of 9 Barcode", 17);
            System.Drawing.Font printFont1 = new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold);

            SolidBrush br = new SolidBrush(Color.Black);
            if(checkBox1.Checked==true) 
            {
                ev.Graphics.DrawString("*"+parca_no.Text+"*", printFont, br, 10, 65);
                ev.Graphics.DrawString("*" + parca_no.Text + "*", printFont1, br, 10, 85);
            }
            else if ( checkBox2.Checked == true )
            {
                ev.Graphics.DrawString("" + parca_no.Text + "", printFont, br, 10, 65);
                ev.Graphics.DrawString("" + parca_no.Text + "", printFont1, br, 10, 85);
            }
            else 
            {
                ev.Graphics.DrawString("*AAAAAAFFF*", printFont, br, 10, 65);
                ev.Graphics.DrawString("*AAAAAAFFF*", printFont1, br, 10, 85);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(@"muconun_barkodu.bmp");
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }
    }
}
