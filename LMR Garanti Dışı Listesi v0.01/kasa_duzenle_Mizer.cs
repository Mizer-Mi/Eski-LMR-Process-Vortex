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
    public partial class kasa_duzenle_Mizer : Form
    {
        public kasa_duzenle_Mizer()
        {
            InitializeComponent();
        }
        public string ekleyen_adi { get; set; }
        public string cari_no { get; set; }
        public string kadi_getir { get; set; }
        public string norm_royal { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }
        private void kasa_duzenle_Mizer_Load(object sender, EventArgs e)
        {
            odeme_tipi.SelectedIndex = 0;
            fatura_tarihi_gir.Value = DateTime.Now;
            duzenle_cek();
        }
        private void duzenle_cek()
        {
            string sql_sorgusu_31 = "select * from cari_hesaplar where islem_no="+norm_royal+"";
            MySqlCommand command = new MySqlCommand(sql_sorgusu_31,mysqlbaglan);
            mysqlbaglan.Open();
            MySqlDataReader dr = command.ExecuteReader();
           if (dr.Read())
            {
                if (dr.GetString("islem_turu") == "Satış")
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    MessageBox.Show("Faturalar Düzenlenemez.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.OK;
                    return;
                    
                }
               else if (dr.GetString("islem_turu") == "Ödeme Yapıldı.")
                {
                    fiyat.Text = dr.GetString("odenen").Replace(".", "");

                }
                else if (dr.GetString("islem_turu") == "Cari Borçlandırıldı.")
                {
                    fiyat.Text = dr.GetString("tutar").Replace(".", "");

                }
                else if (dr.GetString("islem_turu") == "Cariye Borçlanıldı.")
                {
                    fiyat.Text = dr.GetString("tutar").Replace(".", "");

                }
                else if (dr.GetString("islem_turu") == "Ödeme Alındı.")
                {
                    fiyat.Text = dr.GetString("odenen").Replace(".","");

                }
                else if (dr.GetString("islem_turu") == "KASA GİRİŞİ")
                {
                    fiyat.Text = dr.GetString("odenen").Replace(".", "");

                }
                else if (dr.GetString("islem_turu") == "KASA ÇIKIŞI")
                {
                    fiyat.Text = dr.GetString("odenen").Replace(".", "");

                }
                aciklama.Text = dr.GetString("aciklama");
                fatura_tarihi_gir.Text = dr.GetString("islem_tarihi");
                evrak_no.Text = dr.GetString("evrak_no");
                label8.Text = dr.GetString("cari_no");
                label9.Text = dr.GetString("islem_turu");
                label13.Text = dr.GetString("islem_yapan_adi");
                label15.Text = dr.GetString("eklendigi_tarih");
                odeme_tipi.SelectedItem = dr.GetString("odeme_tipi");
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

            }
           else
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                MessageBox.Show("İşlem Bulunamaadı.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.OK;
               
              
            }
        }
        private void tarih_yenile_Click(object sender, EventArgs e)
        {
            fatura_tarihi_gir.Value = DateTime.Now;
        }

        private void fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        string neo_tl;
        private void fiyat_Leave(object sender, EventArgs e)
        {
            try
            {
                neo_tl = fiyat.Text.Replace("R₺", "");
                fiyat.Text = string.Format("{0:N}", Convert.ToDouble(neo_tl));
            }
            catch { }
        }

        private void stok_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                string guncelle3;
                MySqlCommand guncel3;
                guncelle3 = "INSERT INTO `cari_hesaplar` (`cari_no`, `islem_Tarihi`, `evrak_no`, `islem_turu`, `odeme_tipi`,`aciklama`,`tutar`, `odenen`, `islem_yapan_adi`,`eklendigi_tarih`) VALUES(@1_a, @3_a, @4_a, @5_a, @6_a, @6_b, @6_c, @6_d,@10_a,@11_a)";
                guncel3 = new MySqlCommand(guncelle3, mysqlbaglan);
                guncel3.Parameters.AddWithValue("@1_a", cari_no);
                DateTime lolo = Convert.ToDateTime(fatura_tarihi_gir.Text);
                guncel3.Parameters.AddWithValue("@3_a", lolo.ToString("yyyy-MM-dd HH:mm:ss"));
                guncel3.Parameters.AddWithValue("@4_a", evrak_no.Text);
                guncel3.Parameters.AddWithValue("@5_a", "Ödeme Alındı.");
                guncel3.Parameters.AddWithValue("@6_a", odeme_tipi.Text);
                guncel3.Parameters.AddWithValue("@6_b", aciklama.Text);
                guncel3.Parameters.AddWithValue("@6_c", "0,00");
                guncel3.Parameters.AddWithValue("@6_d", fiyat.Text);
                guncel3.Parameters.AddWithValue("@10_a", ekleyen_adi);
                guncel3.Parameters.AddWithValue("@11_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                mysqlbaglan.Open();
                guncel3.ExecuteNonQuery();
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Cari Hesap", "Ödeme Alındı Evrak No: " + evrak_no.Text);
                DialogResult = DialogResult.OK;
            }

            catch (Exception ex)
            { if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); } MessageBox.Show(ex.ToString()); }
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
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {

            }

        }

        private void iptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
