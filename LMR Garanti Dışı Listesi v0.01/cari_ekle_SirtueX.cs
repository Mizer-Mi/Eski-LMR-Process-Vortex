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
    public partial class cari_ekle_SirtueX : Form
    {
        public cari_ekle_SirtueX()
        {
            InitializeComponent();
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
            { }
        }
        public string ekleyen_adi { get; set; }
       public MySqlConnection mysqlbaglan { get; set; }
        private void cari_eklediktensonra_temizle()
        {
            ekle_firma_adi.Text = "";
            ekle_y_i.Text = "";
            ekle_a_s1.Text = "";
            ekle_a_s2.Text = "";
            ekle_p_k.Text = "";
            ekle_t.Text = "";
            ekle_c_t.Text = "";
            ekle_f.Text = "";
            ekle_v.Text = "";
            ekle_v_2.Text = "";
            ekle_a.Text = "";

        }
        private void ekle_cariler_Click(object sender, EventArgs e)
        {
            if (ekle_firma_adi.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Cari Adını boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (ekle_firma_adi.Text == "")
            {
                MessageBox.Show("Cari Adını boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Random rastgele = new Random();
                int cari_No_uret = rastgele.Next(100000000,999999999);
                string guncelle = "insert into cariler(cari_no,firma_adi,firma_tipi,yetkili_isim,adres_satiri_1,adres_satiri_2,posta_kodu,telefon,cep_telefon,faks,vergidairesi,vergidairesi_2,aciklama,ekleyen,eklenmetarihi) values (@c_n,@f_a,@f_t,@y_i,@a_s1,@a_s2,@p_k,@t,@c_t,@f,@v,@v_2,@a,@e,@e_t)";
                MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
                guncel.Parameters.AddWithValue("@c_n", cari_No_uret);
                guncel.Parameters.AddWithValue("@f_a", ekle_firma_adi.Text);
                guncel.Parameters.AddWithValue("@f_t", cari_tipi_combo.Text);
                guncel.Parameters.AddWithValue("@y_i", ekle_y_i.Text);
                guncel.Parameters.AddWithValue("@a_s1", ekle_a_s1.Text);
                guncel.Parameters.AddWithValue("@a_s2", ekle_a_s2.Text);
                guncel.Parameters.AddWithValue("@p_k", ekle_p_k.Text);
                guncel.Parameters.AddWithValue("@t", ekle_t.Text);
                guncel.Parameters.AddWithValue("@c_t", ekle_c_t.Text);
                guncel.Parameters.AddWithValue("@f", ekle_f.Text);
                guncel.Parameters.AddWithValue("@v", ekle_v.Text);
                guncel.Parameters.AddWithValue("@v_2", ekle_v_2.Text);
                guncel.Parameters.AddWithValue("@a", ekle_a.Text);
                guncel.Parameters.AddWithValue("@e", ekleyen_adi);
                guncel.Parameters.AddWithValue("@e_t", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                mysqlbaglan.Open();
                guncel.ExecuteNonQuery();
                mysqlbaglan.Close();
             
                log_gonder(adminadi, ekleyen_adi, "Cari İşlemler", "Cari Ekleme", "Eklenen Cari No: " + cari_No_uret);
                cari_eklediktensonra_temizle();
                MessageBox.Show("Cari Başarıyla Eklendi.");
                this.Close();
            }
            catch
            {
                mysqlbaglan.Close();
                MessageBox.Show("İnternet bağlantısı yok veya Bu Firma adı daha önceden kayıtlı.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cari_ekle_SirtueX_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cari_tipi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cari_tipi_combo.SelectedIndex == 2)
            {
                label11.Text = "İsim Soyad:";
                label19.Visible = false;
                ekle_y_i.Visible = false;
                label12.Visible = false;
                ekle_v.Visible = false;

                label13.Text = "TC Kimlik Numarası:";
            }
            else
            {
                label11.Text = "Firma adı:";
                label19.Visible = true;
                ekle_y_i.Visible = true;
                label12.Visible = true;
                ekle_v.Visible = true;
                label13.Text = "Vergi Dairesi Numarası:";
            }
           
        }
    }
}
