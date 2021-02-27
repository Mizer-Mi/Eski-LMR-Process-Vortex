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
    public partial class cari_duzenle_SirtueX : Form
    {
        public cari_duzenle_SirtueX()
        {
            InitializeComponent();
        }
        public string ekleyen_adi { get; set; }
        public string cari_no { get; set; }
       public MySqlConnection mysqlbaglan { get; set; }


        private void cari_sil_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cari_guncelle_Click(object sender, EventArgs e)
        {

            if (cari_duzenle_firma_adi.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Cari Adını boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cari_duzenle_firma_adi.Text == "")
            {
                MessageBox.Show("Cari Adını boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {



                mysqlbaglan.Open();
                try
                {
                    string guncelle = "update `cariler` set firma_adi=@f_a,firma_tipi=@f_t,yetkili_isim=@y_i,adres_satiri_1=@a_s1,adres_satiri_2=@a_s2,posta_kodu=@p_k,telefon=@tel,cep_telefon=@c_tel,faks=@faks,vergidairesi=@v_d,vergidairesi_2=@v_d_2,aciklama=@aciklama,duzenleyen=@duzenleyen,duzenlenmetarihi=@d_tarih where cari_no=" + cari_no + "";
                    MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                    guncel.Parameters.AddWithValue("@f_a", cari_duzenle_firma_adi.Text);
                    guncel.Parameters.AddWithValue("@f_t", cari_duzenle_tip.Text);

                    guncel.Parameters.AddWithValue("@y_i", cari_duzenle_yetkili.Text);
                    guncel.Parameters.AddWithValue("@a_s1", cari_duzenle_adres1.Text);
                    guncel.Parameters.AddWithValue("@a_s2", cari_duzenle_adres2.Text);
                    guncel.Parameters.AddWithValue("@p_k", cari_duzenle_postakodu.Text);
                    guncel.Parameters.AddWithValue("@tel", cari_duzenle_tel.Text);
                    guncel.Parameters.AddWithValue("@c_tel", cari_duzenle_ceptel.Text);
                    guncel.Parameters.AddWithValue("@faks", cari_duzenle_faks.Text);
                    guncel.Parameters.AddWithValue("@v_d", cari_duzenle_vergidairesi.Text);
                    guncel.Parameters.AddWithValue("@v_d_2", cari_duzenle_vergino.Text);
                    guncel.Parameters.AddWithValue("@aciklama", cari_duzenle_aciklama.Text);
                    guncel.Parameters.AddWithValue("@duzenleyen", ekleyen_adi);
                    guncel.Parameters.AddWithValue("@d_tarih", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                    guncel.ExecuteNonQuery();
                    mysqlbaglan.Close();
                    log_gonder(adminadi, ekleyen_adi, "Cari İşlemler", "Cari Düzenleme", "Düzenlenen Cari No: " + cari_no );
                    MessageBox.Show("Cari Bilgileri Güncellendi.");
                    panel2.Visible = true;
                    this.Close();
                }
                catch
                {
                    mysqlbaglan.Close();
                    MessageBox.Show("HATA ! Firma_adı aynı olamaz. veya Bağlantı sorunu.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }








            }
            catch
            {
                mysqlbaglan.Close();

                MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            { }
        }
        private void cari_duzenle_SirtueX_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            try
            {
              
                string komutsatiri = "SELECT * FROM cariler WHERE `cari_no`="+cari_no+"";
                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();
                if (okuyucum.Read())
                {
                    Cari_no_getir_copy.Text= okuyucum.GetString("cari_no");
                    cari_duzenle_tip.Text = okuyucum.GetString("firma_tipi");
                    cari_duzenle_firma_adi.Text = okuyucum.GetString("firma_adi");
                    cari_duzenle_yetkili.Text = okuyucum.GetString("yetkili_isim");
                    cari_duzenle_adres1.Text = okuyucum.GetString("adres_satiri_1");
                    cari_duzenle_adres2.Text = okuyucum.GetString("adres_satiri_2");
                    cari_duzenle_postakodu.Text = okuyucum.GetString("posta_kodu");
                    cari_duzenle_vergidairesi.Text = okuyucum.GetString("vergidairesi");
                    cari_duzenle_vergino.Text = okuyucum.GetString("vergidairesi_2");
                    cari_duzenle_aciklama.Text = okuyucum.GetString("aciklama");
                    cari_duzenle_tel.Text = okuyucum.GetString("telefon");
                    cari_duzenle_ceptel.Text = okuyucum.GetString("cep_telefon");
                    cari_duzenle_faks.Text = okuyucum.GetString("faks");

                    cari_ekleyen_label.Text = cari_ekleyen_label.Text + " " + okuyucum.GetString("ekleyen");
                    cari_ekleyen_tarih.Text = cari_ekleyen_tarih.Text + " " + okuyucum.GetString("eklenmetarihi");
                    cari_duzenleyen.Text = cari_duzenleyen.Text + " " + okuyucum.GetString("duzenleyen");
                    cari_duzenleyen_tarih.Text = cari_duzenleyen_tarih.Text + " " + okuyucum.GetString("duzenlenmetarihi");


                   


                }
                else
                {
                    panel2.Visible = false;
                   
                    MessageBox.Show("Cari seçtiğinize emin olun.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mysqlbaglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
