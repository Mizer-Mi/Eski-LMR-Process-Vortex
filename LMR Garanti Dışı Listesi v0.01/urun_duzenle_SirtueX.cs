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
    public partial class urun_duzenle_SirtueX : Form
    {
        public string ekleyen_adi { get; set; }
    public string urun_kodu { get; set; }
   public MySqlConnection mysqlbaglan { get; set; }
   
        public urun_duzenle_SirtueX()
        {
            InitializeComponent();
        }
        public string adminadi { get; set; }
       
        private void urun_guncelle_buton_Click(object sender, EventArgs e)
        {
            if (guncelle_yeni_urun_numarasi.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ürün Kodunu boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guncelle_yeni_urun_numarasi.Focus();
                return;
            }
            else if (guncelle_yeni_urun_numarasi.Text == "")
            {
                MessageBox.Show("Ürün Kodunu boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guncelle_yeni_urun_numarasi.Focus();
                return;
            }
            else
            {
                errorProvider2.Clear();
                try
                {



                    mysqlbaglan.Open();
                    try
                    {
                        string guncelle = "update `urunler` set urun_kodu=@u_k,urun_bagli_marka=@u_b_m,urun_tur=@u_t,urun_ismi=@u_i,urun_aciklama=@u_a,urun_fiyati=@u_f,urun_stok_durumu=@u_s_d,urun_son_duzenleyen_adi=@u_s_d_a,urun_duzenlenen_tarih=@u_d_t where urun_kodu='" +urun_kodu + "'";
                        MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                        guncel.Parameters.AddWithValue("@u_k", guncelle_yeni_urun_numarasi.Text);
                        guncel.Parameters.AddWithValue("@u_b_m", marka_guncellerken_sec.Text);

                        guncel.Parameters.AddWithValue("@u_t", guncelle_urun_turu.Text);
                        guncel.Parameters.AddWithValue("@u_i", guncellerken_urun_ismi.Text);
                        guncel.Parameters.AddWithValue("@u_a", guncellerken_urun_aciklamasi.Text);
                        guncel.Parameters.AddWithValue("@u_f", guncelle_neosFade_TL.Text);
                        guncel.Parameters.AddWithValue("@u_s_d", guncelle_stok_durumu.Value.ToString());
                        guncel.Parameters.AddWithValue("@u_s_d_a", ekleyen_adi);
                        guncel.Parameters.AddWithValue("@u_d_t", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                        guncel.ExecuteNonQuery();
                        mysqlbaglan.Close();

                        guncelle = "insert into stok(urun_kodu,urun_ismi,guncel_stok,urun_yer,stok_aciklamasi,stok_ekleyen_adi,stok_eklenen_tarih) values (@u_k,@u_b_m,@u_i,@u_f,@u_s_d,@u_e_t,@u_a)";
                        guncel = new MySqlCommand(guncelle, mysqlbaglan);
                        guncel.Parameters.AddWithValue("@u_k", guncelle_yeni_urun_numarasi.Text);
                        guncel.Parameters.AddWithValue("@u_b_m", guncellerken_urun_ismi.Text);
                        guncel.Parameters.AddWithValue("@u_i", guncelle_stok_durumu.Value.ToString());
                        guncel.Parameters.AddWithValue("@u_f", "Bilgi Yok");
                        guncel.Parameters.AddWithValue("@u_s_d", "Düzenlenen Stok. Ürün Düzenlenirken Gelir.");
                        guncel.Parameters.AddWithValue("@u_e_t", ekleyen_adi);
                        guncel.Parameters.AddWithValue("@u_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                        mysqlbaglan.Open();
                        guncel.ExecuteNonQuery();
                        mysqlbaglan.Close();

                        if (checkBox1.Checked)
                        {
                            log_gonder(adminadi, ekleyen_adi, "Cari İşlemler", "Ürün Düzenlendi", "Eski Ürün Kodu: " + urun_kodu + " Yeni Ürün Kodu: " + guncelle_yeni_urun_numarasi.Text);
                        }
                        else
                        {
                            log_gonder(adminadi, ekleyen_adi, "Cari İşlemler", "Ürün Düzenlendi", "Düzenlenen Ürün Kodu: " + urun_kodu + " ");
                        }

                        MessageBox.Show("Ürün Bilgileri Güncellendi.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        mysqlbaglan.Close();
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("Ürün numarası zaten kayıtlı. Farklı bir ürün numarası girin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }








                }
                catch
                {
                    mysqlbaglan.Close();

                    MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                guncelle_yeni_urun_numarasi.ReadOnly = false;
                guncelle_yeni_urun_numarasi.BackColor = Color.White;
                guncelle_yeni_urun_numarasi.ForeColor = Color.Black;
            }
            else
            {
                guncelle_yeni_urun_numarasi.ReadOnly = true ;
                guncelle_yeni_urun_numarasi.BackColor = Color.Black;
                guncelle_yeni_urun_numarasi.ForeColor = Color.White;
            }
        }

        private void guncelle_urun_sil_Click(object sender, EventArgs e)
        {
            this.Close();
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
            { }
        }
            private void urun_duzenle_SirtueX_Load(object sender, EventArgs e)
        {
            guncelle_yeni_urun_numarasi.ReadOnly = true;
            guncelle_yeni_urun_numarasi.BackColor = Color.Black;
            guncelle_yeni_urun_numarasi.ForeColor = Color.White;
         
            try
            {
                comboboxlarin_saflarini_sikilastiralim();
                string komutsatiri = "SELECT * FROM urunler where urun_kodu='" + urun_kodu + "'";
                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();
                if (okuyucum.Read())
                {
                    marka_guncellerken_sec.Text = okuyucum.GetString("urun_bagli_marka");
                    guncelle_yeni_urun_numarasi.Text = okuyucum.GetString("urun_kodu");
                    guncellerken_urun_aciklamasi.Text = okuyucum.GetString("urun_aciklama");
                    guncellerken_urun_ismi.Text = okuyucum.GetString("urun_ismi");
                    guncelle_urun_turu.Text = okuyucum.GetString("urun_tur");
                    guncelle_neosFade_TL.Text = okuyucum.GetString("urun_fiyati");
                    guncelle_lbl_eklyn.Text = guncelle_lbl_eklyn.Text + " " + okuyucum.GetString("urun_ekleyen_adi");
                    guncelle_eklyn_tarih.Text = guncelle_eklyn_tarih.Text + " " + okuyucum.GetString("urun_eklenen_tarih");
                    guncelle_duzenleyen.Text = guncelle_duzenleyen.Text + " " + okuyucum.GetString("urun_son_duzenleyen_adi");
                    guncelle_duzenleyen_tarih.Text = guncelle_duzenleyen_tarih.Text + " " + okuyucum.GetString("urun_duzenlenen_tarih");
                    int sayidok = Convert.ToInt32(okuyucum["urun_stok_durumu"].ToString());
                    guncelle_stok_durumu.Value = sayidok;
                    panel1.Visible = true;


                }
                else
                {
                    panel1.Visible = false;
                    MessageBox.Show("Ürünü seçtiğinize emin olun.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mysqlbaglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }
        private void comboboxlarin_saflarini_sikilastiralim()
        {
            try
            {
                string komutsatiri = "SELECT marka_ad FROM markalar";

                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();

                while (okuyucum.Read())
                {
                    marka_guncellerken_sec.Items.Add(okuyucum.GetString("marka_ad"));


                }
                marka_guncellerken_sec.SelectedIndex = 1;
                marka_guncellerken_sec.SelectedItem = 1;

                mysqlbaglan.Close();
            }
            catch 
            {
                mysqlbaglan.Close();
            }
        }
    }
}
