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
    public partial class stok_ekle_SirtueX : Form
    {
       public MySqlConnection mysqlbaglan { get; set; }
        public string ekleyen_adi { get; set; }
        public string urun_kodu { get; set; }
        public stok_ekle_SirtueX()
        {
            InitializeComponent();
        }

        private void stok_ekle_SirtueX_Load(object sender, EventArgs e)
        {
            try
            {
                string komutsatiri = "SELECT * FROM urunler where urun_kodu='" + urun_kodu + "'";
                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();
                if (okuyucum.Read())
                {
                    marka.Text = okuyucum.GetString("urun_bagli_marka");
                    urun_kodu2.Text = okuyucum.GetString("urun_kodu");
                    urun_turu.Text = okuyucum.GetString("urun_tur");
                    urun_ismi.Text = okuyucum.GetString("urun_ismi");
                    stok_durumu.Text = okuyucum.GetString("urun_stok_durumu");
                    stok = Convert.ToInt32(stok_durumu.Text);


                }
                else
                {
                    MessageBox.Show("Veriler Çekilemedi. Bağlantı HATASI.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mysqlbaglan.Close();
            }
            catch
            {

            }
        }
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
            {

            }
        }
        int stok = 0;
        public string eklenilcek_stok_urun_listesine { get; set; }
        private void stok_ekle_Click(object sender, EventArgs e)
        {
           try
               { 
            stok = 0;
                    string guncelle = "insert into stok(urun_kodu,urun_ismi,degisen_stok,guncel_stok,urun_yer,stok_aciklamasi,satis_mi,stok_ekleyen_adi,stok_eklenen_tarih) values (@u_k,@u_b_m,@u_t,@u_i,@u_f,@u_s_d,@u_e_a,@u_e_t,@u_a)";
                    MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
                    guncel.Parameters.AddWithValue("@u_k", urun_kodu2.Text);
                    guncel.Parameters.AddWithValue("@u_b_m", urun_ismi.Text);
                    guncel.Parameters.AddWithValue("@u_t", "+"+stok_ekle_sayi.Value.ToString() );
                stok = stok + Convert.ToInt16(stok_durumu.Text);
            stok = stok + Convert.ToInt16(stok_ekle_sayi.Value);
                    guncel.Parameters.AddWithValue("@u_i", (stok).ToString());
                    guncel.Parameters.AddWithValue("@u_f", stok_yer.Text);
                    guncel.Parameters.AddWithValue("@u_s_d", aciklama.Text);
                    guncel.Parameters.AddWithValue("@u_e_a", "");
                    guncel.Parameters.AddWithValue("@u_e_t", ekleyen_adi);
                    guncel.Parameters.AddWithValue("@u_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                    mysqlbaglan.Open();
                    guncel.ExecuteNonQuery();
                    mysqlbaglan.Close();
                
                guncelle = "update urunler set urun_stok_durumu ='" + (stok).ToString() +"' where urun_kodu ='"+urun_kodu2.Text+"'";
                guncel = new MySqlCommand(guncelle, mysqlbaglan);
                mysqlbaglan.Open();
                guncel.ExecuteNonQuery();
                mysqlbaglan.Close();
                log_gonder(adminadi, ekleyen_adi, "Cari İşlemler", "Stok Eklendi", "Stok Eklenilen Ürün Kodu: " + urun_kodu2.Text + " Eklenen Adet sayısı: " + stok_ekle_sayi.Value.ToString());
                MessageBox.Show("Stok başarıyla Eklendi.");
                
                this.eklenilcek_stok_urun_listesine = stok.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();

                




         }
            catch
            {
                mysqlbaglan.Close();

                MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
