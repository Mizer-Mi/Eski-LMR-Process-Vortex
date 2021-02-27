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
    public partial class urun_ekle_SirtueX : Form
    {
        public urun_ekle_SirtueX()
        {
            InitializeComponent();
        }
       public MySqlConnection mysqlbaglan { get; set; }
        public string ekleyen_adi { get; set; }
        public string adminadi { get; set; }
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
            { }
        }

            private void ekle_Click(object sender, EventArgs e)
        {
            if (ekle_urun_numarasi.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ürün Kodunu boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekle_urun_numarasi.Focus();
                return;
            }
            else if (ekle_urun_numarasi.Text == "")
            {
                MessageBox.Show("Ürün Kodunu boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ekle_urun_numarasi.Focus();
                return;
            }
            else
            {
                errorProvider2.Clear();
                try
                {
                    mysqlbaglan.Open();
                    string guncelle2 = "SELECT * FROM `urunler` where `urun_kodu`='" + ekle_urun_numarasi.Text + "'";
                    MySqlCommand guncel2 = new MySqlCommand(guncelle2, mysqlbaglan);
                    MySqlDataReader rdr = guncel2.ExecuteReader();
                    if (rdr.Read())
                    {
                        mysqlbaglan.Close();
                        MessageBox.Show("Ürün numarası zaten kayıtlı. Farklı bir ürün numarası girin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ekle_urun_numarasi.Focus();
                    }
                    else
                    {
                        mysqlbaglan.Close();
                        string guncelle = "insert into urunler(urun_kodu,urun_bagli_marka,urun_tur,urun_ismi,urun_fiyati,urun_stok_durumu,urun_ekleyen_adi,urun_eklenen_tarih,urun_aciklama) values (@u_k,@u_b_m,@u_t,@u_i,@u_f,@u_s_d,@u_e_a,@u_e_t,@u_a)";
                        MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
                        guncel.Parameters.AddWithValue("@u_k", ekle_urun_numarasi.Text);
                        guncel.Parameters.AddWithValue("@u_b_m", marka_eklerken_sec.Text);
                        guncel.Parameters.AddWithValue("@u_t", ekle_urun_turu.Text);
                        guncel.Parameters.AddWithValue("@u_i", ekle_urun_ismi.Text);
                        guncel.Parameters.AddWithValue("@u_f", neosFade_TL.Text);
                        guncel.Parameters.AddWithValue("@u_s_d", ekle_eldeki_stok.Value.ToString());
                        guncel.Parameters.AddWithValue("@u_e_a", ekleyen_adi);
                        guncel.Parameters.AddWithValue("@u_e_t", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                        guncel.Parameters.AddWithValue("@u_a", ekle_aciklama.Text);
                        mysqlbaglan.Open();
                        guncel.ExecuteNonQuery();
                        mysqlbaglan.Close();

                         guncelle = "insert into stok(urun_kodu,urun_ismi,guncel_stok,urun_yer,stok_aciklamasi,stok_ekleyen_adi,stok_eklenen_tarih) values (@u_k,@u_b_m,@u_i,@u_f,@u_s_d,@u_e_t,@u_a)";
                         guncel = new MySqlCommand(guncelle, mysqlbaglan);
                        guncel.Parameters.AddWithValue("@u_k", ekle_urun_numarasi.Text);
                        guncel.Parameters.AddWithValue("@u_b_m", ekle_urun_ismi.Text);
                        guncel.Parameters.AddWithValue("@u_i", ekle_eldeki_stok.Value.ToString());
                        guncel.Parameters.AddWithValue("@u_f", stok_yer.Text);
                        guncel.Parameters.AddWithValue("@u_s_d", "Başlangıç Stok. Ürün Eklerken Gelir.");
                        guncel.Parameters.AddWithValue("@u_e_t", ekleyen_adi);
                        guncel.Parameters.AddWithValue("@u_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                        mysqlbaglan.Open();
                        guncel.ExecuteNonQuery();
                        mysqlbaglan.Close();

                        
                        log_gonder(adminadi, ekleyen_adi, "Cari İşlemler", "Ürün Ekledi", "Eklenen Ürün Kodu: " + ekle_urun_numarasi.Text);
                        eklediktensonra_temizle();
                        MessageBox.Show("Ürün başarıyla Eklendi.");
                        this.Close();
                   
                    }

                   


                }
                catch 
                {
                    mysqlbaglan.Close();

                    MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }
        
        private void eklediktensonra_temizle()
        {
            ekle_urun_numarasi.Text = "";
            ekle_urun_turu.Text = "";
            ekle_urun_ismi.Text = "";
            ekle_eldeki_stok.Value = 1;
            neosFade_TL.Text = "000,00";
            ekle_aciklama.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void urun_ekle_SirtueX_Load(object sender, EventArgs e)
        {
            try
            {

                string komutsatiri = "SELECT marka_ad FROM markalar";

                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();

                while (okuyucum.Read())
                {
                    marka_eklerken_sec.Items.Add(okuyucum.GetString("marka_ad"));



                }

                marka_eklerken_sec.SelectedIndex = 1;
                marka_eklerken_sec.SelectedItem = 1;
               

                mysqlbaglan.Close();
            }
            catch 
            {
                mysqlbaglan.Close();
            }
        }
    }
    
}

