using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LMR_Process_Vortex
{
    public partial class kullanici_ekle_SirtueX : Form
    {
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string adminadi { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }

        public kullanici_ekle_SirtueX()
        {
            InitializeComponent();
        }

        private void kullanici_ekle_SirtueX_Load(object sender, EventArgs e)
        {
            if (gercek_yetki == "Yetkili Personel")
            {
                radioButton2.Enabled = false;
                yetkili_personel_radio.Enabled = false;
            }
            yenilemeaq();
            markacekaq();
        }
        private void markacekaq()
        {
            string markacekkomutu = "select * from markalar";
            MySqlCommand markacek = new MySqlCommand(markacekkomutu,mysqlbaglan);
            mysqlbaglan.Open();
            MySqlDataReader listelememarka = markacek.ExecuteReader();
            while(listelememarka.Read())
            {
                listBox1.Items.Add(listelememarka["marka_ad"]);
            }
            mysqlbaglan.Close();

        }

        private void yenilemeaq()
        {
            try
            {
                toolStripStatusLabel1.Text = gercek_yetki + " Girişi Yapıldı";

                toolStripStatusLabel2.Text = " | Tarih: " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " | ";
                toolStripStatusLabel4.Text = "Hoşgeldin " + ekleyen_adi + " |";

            }
            catch
            {

            }
            
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
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
           
        }

        private void ekle_cariler_Click(object sender, EventArgs e)
        {
            kullanici_ekle(kadi_ekle.Text, ekle_sifre1.Text, isim_soyisim_ekle.Text);
        }


        private void kullanici_ekle(string kadi, string sifre, string isim)
        {
            if (kadi == "")
            {
                MessageBox.Show("Kullanıcı Adı Boş Olamaz...", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kadi_ekle.Focus();
                return;
            }
            else if (ekle_sifre1.Text != ekle_sifre2.Text)
            {
                MessageBox.Show("Şifreler uyuşmamaktadır...", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kadi_ekle.Focus();
                return;
            }
            else if (radioButton3.Checked==true)
            {
                if (listBox1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("En azından Personele ait bir yetki girmeniz gerekir. Eğer yetki girilmez ise personel hiç birşeye müdahale edemez. Ziyaretçi Girişi yapması daha muhtemeldir.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string neow = "";
            int i = 0;
            foreach (var item in listBox1.SelectedItems)
            {

                if (i == 0)
                {
                    neow += item.ToString();
                }
                else if (i == (listBox1.Items.Count))
                {
                    neow += item.ToString();
                }
                else
                {
                    neow += "," + item.ToString();
                }
                i++;
            }
            string sql2 = "";
            if (radioButton2.Checked == true)
            {
                sql2 = "INSERT INTO kullanicilar(kadi,sifre,isim,yetki) VALUES(@kadi,@sifre,@isim,'SüperAdmin')";
            }
            else if (radioButton3.Checked == true)
            {
                sql2 = "INSERT INTO kullanicilar(kadi,sifre,isim,yetki,yetkili_markalar) VALUES(@kadi,@sifre,@isim,'Personel',@sorumlu1)";
            }
            else if (yetkili_personel_radio.Checked == true)
            {
                sql2 = "INSERT INTO kullanicilar(kadi,sifre,isim,yetki) VALUES(@kadi,@sifre,@isim,'Yetkili Personel')";
            }
            else
            {
                MessageBox.Show("Yetki seçili gözükmüyor.");
                return;
            }

            MySqlCommand dg_cmd2 = new MySqlCommand(sql2, mysqlbaglan);


            dg_cmd2.Parameters.AddWithValue("@kadi", kadi);
            dg_cmd2.Parameters.AddWithValue("@sifre", sifre);
            dg_cmd2.Parameters.AddWithValue("@isim", isim);
            dg_cmd2.Parameters.AddWithValue("@sorumlu1", neow);
          

            try
            {
                mysqlbaglan.Open();

                if (dg_cmd2.ExecuteNonQuery() > 0)
                {
                    mysqlbaglan.Close();
                    log_gonder(adminadi, ekleyen_adi, "Kullanıcı Ayarları", "Kullanıcı Eklendi", "Kullanıcı Adı: "+kadi+" -- Şifre" +sifre+ " -- İsim: "+isim+" -- Sorumlu Olduğu Markalar: "+neow);
                    if (yetkili_personel_radio.Checked == true)
                    {
                        yetkili_personel_giris();
                    }
                    MessageBox.Show("Kullanıcı Eklendi");
                    this.Close();
                }   
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
             
            }
            catch
            {
                MessageBox.Show("Kullanıcı adını farklı girin ve ya bağlantınızı kotnrol edin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mysqlbaglan.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked ==true)
            {
               
                groupBox3.Enabled = true;
                groupBox3.Visible = true;
                lord.Enabled = false;
                lord.Visible = false;
            }
            else
            {
               
                lord.Enabled = false;
                lord.Visible = false;
                groupBox3.Enabled = false;
                groupBox3.Visible = false;
            }
          
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
               
                groupBox3.Enabled = false;
                groupBox3.Visible = false;
                lord.Enabled = false;
                lord.Visible = false;
            }
            else
            {
               
                groupBox3.Enabled = true;
                groupBox3.Visible = true;
                lord.Enabled = false;
                lord.Visible = false;
            }

          
        }

        private void kadi_ekle_TextChanged(object sender, EventArgs e)
        {
            kadi_ekle.Text = string.Concat(kadi_ekle.Text.Where(char.IsLetterOrDigit));
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void yetkili_personel_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (yetkili_personel_radio.Checked == true)
            {
                
                groupBox3.Enabled = false;
                groupBox3.Visible = false;
                lord.Enabled = true;
                lord.Visible = true;
            }
            else
            {
               
                groupBox3.Enabled = true;
                groupBox3.Visible = true;
                lord.Enabled = false;
                lord.Visible = false;
            }
        }
        private void yetkili_personel_giris()
        {
            try
            { 
            string guncelle = "insert into kullanicilar_yetki(y_id,urun_stok_goruntuleme,urun_ekle,urun_duzenle_sil,stok_ekle_dus,urun_raporla,cari_goruntule,cari_ekle,cari_duzenle,satis_yetkisi,fatura_goruntule,cari_hesaplari_goruntule,odeme_al,borclandir,odeme_yap,borclan,islem_fatura_sil,cari_raporu_goruntule,kasa_yetkisi,personel_ekle,kullanici_loglari_goruntule,yazilim_giris,dokumanlara_giris,dokuman_ekle,dokuman_duz_sil,hatali_giris_loglari,veritabani_bilgisi) values (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27)";
            MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
            guncel.Parameters.AddWithValue("@1", kadi_ekle.Text);
            guncel.Parameters.AddWithValue("@2", urun_stok_ana.Checked.ToString());
            guncel.Parameters.AddWithValue("@3", urun_ekle.Checked.ToString());
            guncel.Parameters.AddWithValue("@4", urun_duz_sil.Checked.ToString());
            guncel.Parameters.AddWithValue("@5", stok_eksilt_dus.Checked.ToString());
            guncel.Parameters.AddWithValue("@6", stok_rapor.Checked.ToString());
            guncel.Parameters.AddWithValue("@7", cari_goruntule.Checked.ToString());
            guncel.Parameters.AddWithValue("@8", cari_ekle.Checked.ToString());
            guncel.Parameters.AddWithValue("@9", cari_duzenle.Checked.ToString());
            guncel.Parameters.AddWithValue("@10", satis_yetki.Checked.ToString());
            guncel.Parameters.AddWithValue("@11", fatura_goruntuleme.Checked.ToString());
            guncel.Parameters.AddWithValue("@12", cari_hesap_goruntuleme.Checked.ToString());
            guncel.Parameters.AddWithValue("@13", odeme_al.Checked.ToString());
            guncel.Parameters.AddWithValue("@14", borclandir.Checked.ToString());
            guncel.Parameters.AddWithValue("@15", odeme_yap.Checked.ToString());
            guncel.Parameters.AddWithValue("@16", borclan.Checked.ToString());
            guncel.Parameters.AddWithValue("@17", islem_fatura_silme.Checked.ToString());
            guncel.Parameters.AddWithValue("@18", cari_raporu_goruntuleme.Checked.ToString());
            guncel.Parameters.AddWithValue("@19", kasa_yetkisi.Checked.ToString());
            guncel.Parameters.AddWithValue("@20", personel_ekle.Checked.ToString());
            guncel.Parameters.AddWithValue("@21", log_goruntule.Checked.ToString());
            guncel.Parameters.AddWithValue("@22", yazılımlara_giris.Checked.ToString());
            guncel.Parameters.AddWithValue("@23", dokuman_gir.Checked.ToString());
            guncel.Parameters.AddWithValue("@24", dokuman_ekle.Checked.ToString());
            guncel.Parameters.AddWithValue("@25", dokuman_duz_sil.Checked.ToString());
            guncel.Parameters.AddWithValue("@26", hatali_giris_loglari.Checked.ToString());
            guncel.Parameters.AddWithValue("@27", veritabani_bilgisi.Checked.ToString());
                mysqlbaglan.Open();
            guncel.ExecuteNonQuery();
            mysqlbaglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Personel Yetkileri Veritabanına geçirilemedi.");
            }

        }

        private void cari_goruntule_CheckedChanged(object sender, EventArgs e)
        {
            tum_stok_yetkileri_kitle();
            tum_cari_yetkileri_kitle();
        }

        private void tum_stok_yetkileri_kitle()
        {
            if (cari_goruntule.Checked == true)
            {
                urun_stok_ana.Checked = true;
                stok_rapor.Checked = true;
                urun_ekle.Checked = true;
                urun_duz_sil.Checked = true;
                stok_eksilt_dus.Checked = true;

                urun_stok_ana.Enabled = false;
                stok_rapor.Enabled = false;
                urun_ekle.Enabled = false;
                urun_duz_sil.Enabled = false;
                stok_eksilt_dus.Enabled = false;
            }
            else
            {
                urun_stok_ana.Enabled = true;
                stok_rapor.Enabled = true;
                urun_ekle.Enabled = true;
                urun_duz_sil.Enabled = true;
                stok_eksilt_dus.Enabled = true;
            }
        }
        private void tum_cari_yetkileri_kitle()
        {
            if (cari_goruntule.Checked == true)
            {
                kasa_yetkisi.Enabled = true;
                kasa_yetkisi.Checked = false;
                cari_ekle.Enabled = true;
                cari_duzenle.Enabled = true;
                satis_yetki.Enabled = true;
                fatura_goruntuleme.Enabled = true;
               
                cari_hesap_goruntuleme.Enabled = true;
                /*
                odeme_al.Enabled = true;
                odeme_yap.Enabled = true;
                borclan.Enabled = true;
                borclandir.Enabled = true;
                islem_fatura_silme.Enabled = true;
                cari_raporu_goruntuleme.Enabled = true;
                */

                cari_ekle.Checked = false;
                cari_duzenle.Checked = false;
                satis_yetki.Checked = false;
                fatura_goruntuleme.Checked = false;
            
                cari_hesap_goruntuleme.Checked = false;
                /*
                odeme_al.Checked = false;
                odeme_yap.Checked = false;
                borclan.Checked = false;
                borclandir.Checked = false;
                islem_fatura_silme.Checked = false;
                cari_raporu_goruntuleme.Checked = false;
                */

            }
            else
            {
                kasa_yetkisi.Enabled = false;
                kasa_yetkisi.Checked = false;
                cari_ekle.Enabled = false;
                cari_duzenle.Enabled = false;
                satis_yetki.Enabled = false;
                fatura_goruntuleme.Enabled = false;
                
                cari_hesap_goruntuleme.Enabled = false;
                odeme_al.Enabled = false;
                odeme_yap.Enabled = false;
                borclan.Enabled = false;
                borclandir.Enabled = false;
                islem_fatura_silme.Enabled = false;
                cari_raporu_goruntuleme.Enabled = false;

                cari_ekle.Checked = false;
                cari_duzenle.Checked = false;
                satis_yetki.Checked = false;
                fatura_goruntuleme.Checked = false;
              
                cari_hesap_goruntuleme.Checked = false;
                odeme_al.Checked = false;
                odeme_yap.Checked = false;
                borclan.Checked = false;
                borclandir.Checked = false;
                islem_fatura_silme.Checked = false;
                cari_raporu_goruntuleme.Checked = false;
            }
        }

        private void urun_stok_ana_CheckedChanged(object sender, EventArgs e)
        {
            if (urun_stok_ana.Checked == true)
            {
                
                stok_rapor.Enabled = true;
                urun_ekle.Enabled = true;
                urun_duz_sil.Enabled = true;
                stok_eksilt_dus.Enabled = true;
            }
            else
            {
              
                stok_rapor.Enabled = false;
                urun_ekle.Enabled = false;
                urun_duz_sil.Enabled = false;
                stok_eksilt_dus.Enabled = false;

                stok_rapor.Checked = false;
                urun_ekle.Checked = false;
                urun_duz_sil.Checked = false;
                stok_eksilt_dus.Checked = false;

            }
        }

        private void kasa_yetkisi_CheckedChanged(object sender, EventArgs e)
        {
            if (kasa_yetkisi.Checked == true)
            {
                cari_ekle.Checked = true;
                cari_duzenle.Checked = true;
                satis_yetki.Checked = true;
                fatura_goruntuleme.Checked = true;
                kasa_yetkisi.Checked = true;
                cari_hesap_goruntuleme.Checked = true;
                odeme_al.Checked = true;
                odeme_yap.Checked = true;
                borclan.Checked = true;
                borclandir.Checked = true;
                islem_fatura_silme.Checked = true;
                cari_raporu_goruntuleme.Checked = true;


                cari_ekle.Enabled = false;
                cari_duzenle.Enabled = false;
                satis_yetki.Enabled = false;
                fatura_goruntuleme.Enabled = false;           
                cari_hesap_goruntuleme.Enabled = false;
                odeme_al.Enabled = false;
                odeme_yap.Enabled = false;
                borclan.Enabled = false;
                borclandir.Enabled = false;
                islem_fatura_silme.Enabled = false;
                cari_raporu_goruntuleme.Enabled = false;

            }
            else
            {
                cari_ekle.Enabled = true;
                cari_duzenle.Enabled = true;
                satis_yetki.Enabled = true;
                fatura_goruntuleme.Enabled = true;
                cari_hesap_goruntuleme.Enabled = true;
                odeme_al.Enabled = true;
                odeme_yap.Enabled = true;
                borclan.Enabled = true;
                borclandir.Enabled = true;
                islem_fatura_silme.Enabled = true;
                cari_raporu_goruntuleme.Enabled = true;
            }




        }

        private void dokuman_gir_CheckedChanged(object sender, EventArgs e)
        {
            if (dokuman_gir.Checked==true)
            {
                dokuman_duz_sil.Enabled = true;
                dokuman_ekle.Enabled = true;
            }
            else
            {
                dokuman_duz_sil.Enabled = false;
                dokuman_ekle.Enabled = false;
                dokuman_duz_sil.Checked = false;
                dokuman_ekle.Checked = false;
            }
        }

        private void cari_hesap_goruntuleme_CheckedChanged(object sender, EventArgs e)
        {
            if (cari_hesap_goruntuleme.Checked==true)
            {
                odeme_al.Enabled = true;
                odeme_yap.Enabled = true;
                borclan.Enabled = true;
                borclandir.Enabled = true;
                islem_fatura_silme.Enabled = true;
                cari_raporu_goruntuleme.Enabled = true;

            }
            else
            {
                odeme_al.Enabled = false;
                odeme_yap.Enabled = false;
                borclan.Enabled = false;
                borclandir.Enabled = false;
                islem_fatura_silme.Enabled = false;
                cari_raporu_goruntuleme.Enabled = false;

                odeme_al.Checked = false;
                odeme_yap.Checked = false;
                borclan.Checked = false;
                borclandir.Checked = false;
                islem_fatura_silme.Checked = false;
                cari_raporu_goruntuleme.Checked = false;
            }
        }
    }
}
