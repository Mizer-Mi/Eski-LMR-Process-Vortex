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
namespace LMR_Process_Vortex
{
    

    public partial class secim_form_ziyaretci : Form
    {
        public string eG80LPJJCimP { get; set; }
        public string Id4SGF8YIcyg9y { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }
        /*Form hakkindaac = new hakkinda(); */
        public secim_form_ziyaretci()
        {
            InitializeComponent();
        }
        Form hakkindaac = new hakkinda();
        public string gercek_yetki { get; set; }
        public string Neof_Wotf { get; set; }
        private void secim_form_ziyaretci_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            yenilemeaq();
        }
        private void yenilemeaq()
        {
            try
            {
                toolStripStatusLabel2.Text =  "Ziyaretçi Girişi Yapıldı";
                toolStripStatusLabel2.Text = " | Tarih: " + DateTime.Today.ToShortDateString() + " | ";
                int say = 0;
                mysqlbaglan.Open();
                string kayitsayisi = "SELECT * FROM `anatablo` ";
                MySqlCommand cmd = new MySqlCommand(kayitsayisi, mysqlbaglan);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    say = say + 1;


                }
                toolStripStatusLabel3.Text = "     | Toplam Kayıtlı Cihaz Sayısı: " + say.ToString();
                mysqlbaglan.Close();
            }
            catch
            {

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                errorProvider1.SetError(textBox1, "Seri Numarası Boş Geçilemez,Lütfen Geçerli Bir Seri Numarası Giriniz.");
            }
            else
            {
                errorProvider1.Clear();

            }
        }
        private void programKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*  private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
          {
              hakkindaac.Show();
              hakkindaac.Visible = false;
              hakkindaac.ShowDialog();
          }
          */
        int resimsay;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox8.Text = "";
            richTextBox1.Text = "";
            resimsay = 0;
            try
            {
                mysqlbaglan.Open();
                string sql = "SELECT * FROM `anatablo` where `VT_serial_number`='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                {

                    MessageBox.Show("Seri Numarası buluanmadı.", "Hata");
                }
                else
                {


                    textBox2.Text = rdr["VT_serial_number"].ToString();
                    textBox3.Text = rdr["VT_garanti_disi_sebep"].ToString();
                    textBox4.Text = rdr["VT_model"].ToString();
                    textBox5.Text = rdr["VT_marka"].ToString();
                    textBox8.Text = rdr["VT_tarih"].ToString();
                    richTextBox1.Text = rdr["VT_aciklama"].ToString();
                    button3.Enabled = true;

                }
                rdr.Close();
                mysqlbaglan.Close();
              
            }
            catch
            {
                mysqlbaglan.Close();
                MessageBox.Show("İnternet bağlantısı yok.", "Hata");
            }

        }
        form_loading form_out;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            form_out = new form_loading();
            form_out.FormClosing += form_out_FormClosing;
            form_out.ShowDialog();
        }
        void form_out_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_out = new form_loading();
            form_out.FormClosing += form_out_FormClosing;
            form_out.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
           
        }

        private void secim_form_ziyaretci_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

            string seri_aktarim = textBox2.Text;
            resim_goster_duzenle form_resimgosterduzenle = new resim_goster_duzenle();
            form_resimgosterduzenle.goster_duz_kapa = "Tamam Tamam Kapan Kapan";
            form_resimgosterduzenle.veriyolu = seri_aktarim;
            form_resimgosterduzenle.mysqlbaglan = mysqlbaglan;
            form_resimgosterduzenle.eG80LPJJCimP = eG80LPJJCimP;
            form_resimgosterduzenle.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
            form_resimgosterduzenle.Neof_Wotf = Neof_Wotf;
            form_resimgosterduzenle.Visible = false;
            form_resimgosterduzenle.ShowDialog();
        }

        private void çıkışYapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
             DialogResult = DialogResult.OK;
        }

        private void programKapatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkindaac.Show();
            hakkindaac.Visible = false;
            hakkindaac.ShowDialog();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
