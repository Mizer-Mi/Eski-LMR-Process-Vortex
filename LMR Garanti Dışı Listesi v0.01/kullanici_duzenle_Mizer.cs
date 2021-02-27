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
    public partial class kullanici_duzenle_Mizer : Form
    {
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string adminadi { get; set; }
        public string kadi { get; set; }
        Boolean zaten_yetki;
        public MySqlConnection mysqlbaglan { get; set; }

        public kullanici_duzenle_Mizer()
        {
            InitializeComponent();
        }

        private void kullanici_duzenle_Mizer_Load(object sender, EventArgs e)
        {
            yenilemeaq();
            markacekaq();
            kullaniciadicekaq();
        }
        private void kullaniciadicekaq()
        {
            if(gercek_yetki =="Yetkili Personel")
            {
                radioButton2.Enabled = false;
                yetkili_personel_radio.Enabled = false;
            }
            try
            {
                string markacekkomutu = "select * from kullanicilar where kadi='"+kadi+"'";
                MySqlCommand markacek = new MySqlCommand(markacekkomutu, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader listelememarka = markacek.ExecuteReader();
                if (listelememarka.Read())
                {
                    kadi_ekle.Text = listelememarka["kadi"].ToString();
                    isim_soyisim_ekle.Text = listelememarka["isim"].ToString();
                    ekle_sifre1.Text = listelememarka["sifre"].ToString();
                    ekle_sifre2.Text = listelememarka["sifre"].ToString();
                    if (listelememarka["yetki"].ToString() == "SüperAdmin")
                    {
                        lord.Visible = false;
                        groupBox3.Visible = false;
                        radioButton2.Checked = true;
                    }
                   else if (listelememarka["yetki"].ToString() == "personel")
                    {
                        radioButton3.Checked = true;
                    }
                    if (listelememarka["yetki"].ToString() == "Yetkili Personel")
                    {
                        zaten_yetki = true;
                        yetkili_personel_radio.Checked = true;
                        yetkili_personel_radio_CheckedChanged(null,null);
                        if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                        yetkicekaq();
                    }
                }
                else
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    MessageBox.Show("Çekme Başarısız. Birşeyler yanlış. :/ ");
                    this.Close();
                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
        }

        private void yetkicekaq()
        {
            try
            {
                string markacekkomutu = "select * from kullanicilar_yetki where y_id='" + kadi + "'";
                MySqlCommand markacek = new MySqlCommand(markacekkomutu, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader listelememarka = markacek.ExecuteReader();
                if (listelememarka.Read())
                {
                    if (listelememarka["urun_stok_goruntuleme"].ToString() == "True") { urun_stok_ana.Checked = true; } else { urun_ekle.Enabled = false;urun_duz_sil.Enabled = false; stok_eksilt_dus.Enabled = false;stok_rapor.Enabled = false; } //1
                    if (listelememarka["urun_ekle"].ToString() == "True") { urun_ekle.Checked = true; } 
                    if (listelememarka["urun_duzenle_sil"].ToString() == "True") { urun_duz_sil.Checked = true; }
                    if (listelememarka["stok_ekle_dus"].ToString() == "True") { stok_eksilt_dus.Checked = true; }
                    if (listelememarka["urun_raporla"].ToString() == "True") { stok_rapor.Checked = true; }
                    if (listelememarka["cari_goruntule"].ToString() == "True") { cari_goruntule.Checked = true; }
                    if (listelememarka["cari_ekle"].ToString() == "True") { cari_ekle.Checked = true; }
                    if (listelememarka["cari_duzenle"].ToString() == "True") { cari_duzenle.Checked = true; }
                    if (listelememarka["satis_yetkisi"].ToString() == "True") { satis_yetki.Checked = true; }
                    if (listelememarka["fatura_goruntule"].ToString() == "True") { fatura_goruntuleme.Checked = true; }
                    if (listelememarka["cari_hesaplari_goruntule"].ToString() == "True") { cari_hesap_goruntuleme.Checked = true; }
                    if (listelememarka["odeme_al"].ToString() == "True") { odeme_al.Checked = true; }
                    if (listelememarka["borclandir"].ToString() == "True") { borclandir.Checked = true; }
                    if (listelememarka["odeme_yap"].ToString() == "True") { odeme_yap.Checked = true; }
                    if (listelememarka["borclan"].ToString() == "True") { borclan.Checked = true; }
                    if (listelememarka["islem_fatura_sil"].ToString() == "True") { islem_fatura_silme.Checked = true; }
                    if (listelememarka["cari_raporu_goruntule"].ToString() == "True") { cari_raporu_goruntuleme.Checked = true; }
                    if (listelememarka["kasa_yetkisi"].ToString() == "True") { kasa_yetkisi.Checked = true; }
                    if (listelememarka["personel_ekle"].ToString() == "True") { personel_ekle.Checked = true; }
                    if (listelememarka["kullanici_loglari_goruntule"].ToString() == "True") { log_goruntule.Checked = true; }
                    if (listelememarka["yazilim_giris"].ToString() == "True") { yazılımlara_giris.Checked = true; }
                    if (listelememarka["dokumanlara_giris"].ToString() == "True") { dokuman_gir.Checked = true;  }
                    if (listelememarka["dokuman_ekle"].ToString() == "True") { dokuman_ekle.Checked = true; }
                    if (listelememarka["dokuman_duz_sil"].ToString() == "True") { dokuman_duz_sil.Checked = true; }
                    if (listelememarka["hatali_giris_loglari"].ToString() == "True") { hatali_giris_loglari.Checked = true; }
                    if (listelememarka["veritabani_bilgisi"].ToString() == "True") { veritabani_bilgisi.Checked = true; }

                }
                else
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    MessageBox.Show("Çekme Başarısız. Birşeyler yanlış. :/ ");
                    this.Close();
                }
                mysqlbaglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            genel_Getir_gotur();
        }



        private void genel_Getir_gotur()
        {
            tum_stok_yetkileri_kitle();
            cari_hesap_goruntuleme_CheckedChanged(null, null);
            dokuman_gir_CheckedChanged(null, null);
            if (urun_stok_ana.Checked == false)
            {
                stok_rapor.Enabled = false;
                stok_eksilt_dus.Enabled = false;
                urun_ekle.Enabled = false;
                urun_duz_sil.Enabled = false;
            }
            kasa_yetkisi_CheckedChanged(null,null);
        }






        private void markacekaq()
        {
            try
            { 
            string markacekkomutu = "select * from markalar";
            MySqlCommand markacek = new MySqlCommand(markacekkomutu, mysqlbaglan);
            mysqlbaglan.Open();
            MySqlDataReader listelememarka = markacek.ExecuteReader();
            while (listelememarka.Read())
            {
                listBox1.Items.Add(listelememarka["marka_ad"]);
            }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Çekme Başarısız. Birşeyler yanlış. :/ ");
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }

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
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {

            }

        }
        private void kadi_ekle_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ekle_cariler_Click(object sender, EventArgs e)
        {
            kullanici_ekle(kadi_ekle.Text, ekle_sifre1.Text, isim_soyisim_ekle.Text);
        }


        private void kullanici_ekle(string kadi, string sifre, string isim)
        {
            if (kadi == "" && sifre == "")
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Boş Olamaz...", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kadi_ekle.Focus();
                return;
            }
            else if (ekle_sifre1.Text != ekle_sifre2.Text)
            {
                MessageBox.Show("Şifreler uyuşmamaktadır...", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kadi_ekle.Focus();
                return;
            }
            else if (radioButton3.Checked == true)
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
                sql2 = "UPDATE kullanicilar set sifre=@sifre,isim=@isim,yetki='SüperAdmin',yetkili_markalar='' where kadi='" + kadi + "'";
            }
            else if (radioButton3.Checked==true)
            {
                sql2 = "UPDATE kullanicilar set sifre=@sifre,isim=@isim,yetki='Personel',yetkili_markalar=@sorumlu1 where kadi='" + kadi + "'";
            }
            else if (yetkili_personel_radio.Checked==true)
            {
                sql2 = "UPDATE kullanicilar set sifre=@sifre,isim=@isim,yetki='Yetkili Personel',yetkili_markalar='' where kadi='" + kadi + "'";
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
                    log_gonder(adminadi, ekleyen_adi, "Kullanıcı Ayarları", "Kullanıcı Düzenleme", "Kullanıcı Adı: " + kadi + " -- Şifre" + sifre + " -- İsim: " + isim + " -- Sorumlu Olduğu Markalar: " + neow);
                    if (yetkili_personel_radio.Checked == true)
                    {
                        if (zaten_yetki == true)
                        {
                            yetkili_personel_giris();
                        }
                        else
                        {
                            yetkili_personel_giris2();
                        }
                    }
                    else
                    {
                        try { eski_Yetkili_sil(); } catch { }
                    }
                    MessageBox.Show("Kullanıcı Düzenlendi.");
                    this.Close();
                }
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Kullanıcı adını farklı girin ve ya bağlantınızı kotnrol edin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mysqlbaglan.Close();
            }
        }
        private void eski_Yetkili_sil ()
        {
            try
            { 
            string sql_urun_sil = "delete from kullanicilar_yetki where y_id='" +kadi_ekle.Text+  "'";
            mysqlbaglan.Open();


            MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
            silmekomutu_urunler_icin.ExecuteNonQuery();
            mysqlbaglan.Close();
            }

            catch
            { }
        }
        private void yetkili_personel_giris()
        {
            try
            {
                string guncelle = "UPDATE kullanicilar_yetki set y_id=@1,urun_stok_goruntuleme=@2,urun_ekle=@3,urun_duzenle_sil=@4,stok_ekle_dus=@5,urun_raporla=@6,cari_goruntule=@7,cari_ekle=@8,cari_duzenle=@9,satis_yetkisi=@10,fatura_goruntule=@11,cari_hesaplari_goruntule=@12,odeme_al=@13,borclandir=@14,odeme_yap=@15,borclan=@16,islem_fatura_sil=@17,cari_raporu_goruntule=@18,kasa_yetkisi=@19,personel_ekle=@20,kullanici_loglari_goruntule=@21,yazilim_giris=@22,dokumanlara_giris=@23,dokuman_ekle=@24,dokuman_duz_sil=@25,hatali_giris_loglari=@26,veritabani_bilgisi=@27   where y_id='" + kadi_ekle.Text+"'";
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
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Personel Yetkileri Veritabanına geçirilemedi.");
            }

        }
        private void yetkili_personel_giris2()
        {
            eski_Yetkili_sil();
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
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
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
            if (dokuman_gir.Checked == true)
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
            if (cari_hesap_goruntuleme.Checked == true)
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
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
    }
}
