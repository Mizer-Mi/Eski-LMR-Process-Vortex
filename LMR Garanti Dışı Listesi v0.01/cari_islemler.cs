using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using Spire.Xls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace LMR_Process_Vortex
{


    public partial class cari_islemler : Form
    {

        public cari_islemler()
        {
            InitializeComponent();


        }
        string neo_tl, guncelle_neo_tl;
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string baglanti_getir_mizer { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }

        /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        private void populate(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2, string aciklama3, string aciklama4, string aciklama5, string aciklama6, string aciklama7, string aciklama8)
        {
            cari_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2, aciklama3, aciklama4, aciklama5, aciklama6, aciklama7, aciklama8);
        }

        string sql = "";
        MySqlCommand dg_cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        private void retrieve()
        {

            cari_ayarlari_loading();
            cari_listesi.Rows.Clear();
            cari_listesi.Refresh();



            sql = "SELECT cari_no,firma_tipi,firma_adi,yetkili_isim,adres_satiri_1,adres_satiri_2,posta_kodu,telefon,cep_telefon,faks,vergidairesi,vergidairesi_2,aciklama from cariler";


            dg_cmd = new MySqlCommand(sql, mysqlbaglan);


            try
            {

                mysqlbaglan.Open();

                adapter = new MySqlDataAdapter(dg_cmd);

                dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString());
                }





                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




                //// dt.Rows.Clear();
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            label38.Text = cari_listesi.RowCount.ToString();
            textBox1.Text = "";
            cari_listesi.Refresh();

            cariye_ait_fatura_retrieve_yap();
        }
        /// Cari Listesi Kodları Bitiş
        ///  /// Cari Listesi Kodları Bitiş
        ///   /// Cari Listesi Kodları Bitiş
        ///  /// Cari Listesi Kodları Bitiş
        ///   ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        ///URUN LİSTESİ KODLARI BAŞLANGIÇ,
        //////URUN LİSTESİ KODLARI BAŞLANGIÇ
        //////URUN LİSTESİ KODLARI BAŞLANGIÇ
        //////URUN LİSTESİ KODLARI BAŞLANGIÇ
        private void urun_listesini_cogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2)
        {
            urun_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2);
        }

        string sql2 = "";
        MySqlCommand dg_cmd2;
        MySqlDataAdapter adapter2;
        DataTable dt2 = new DataTable();
        private void urun_listesini_retrieve_yap()
        {

            urun_ayarlari_loading();
            urun_listesi.Rows.Clear();
            urun_listesi.Refresh();



            sql2 = "SELECT urun_kodu,urun_bagli_marka,urun_tur,urun_ismi,urun_fiyati,urun_stok_durumu,urun_aciklama from urunler";


            dg_cmd2 = new MySqlCommand(sql2, mysqlbaglan);


            try
            {
                mysqlbaglan.Open();

                adapter2 = new MySqlDataAdapter(dg_cmd2);

                dt2 = new DataTable();
                adapter2.Fill(dt2);

                foreach (DataRow row in dt2.Rows)
                {
                    urun_listesini_cogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }





                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




                //// dt.Rows.Clear();
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            label40.Text = urun_listesi.RowCount.ToString();
            textBox1.Text = "";
            urun_listesi_SelectionChanged(null, null);
        }
        ///URUN LİSTESİ KODLARI BİTİŞ,
        //////URUN LİSTESİ KODLARI BİTİŞ
        //////URUN LİSTESİ KODLARI BİTİŞ
        //////URUN LİSTESİ KODLARI BİTİŞ
        ///   ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        private void stok_listesi_cogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2, string aciklama3, string aciklama4, string aciklama5, string aciklama6)
        {
            stok_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2, aciklama3, aciklama4, aciklama5, aciklama6);
        }

        string sql3 = "";
        MySqlCommand dg_cmd3;
        MySqlDataAdapter adapter3;
        DataTable dt3 = new DataTable();
        private void stok_listesini_retrieve_yap()
        {

            stok_ayarlari_loading();
            stok_listesi.Rows.Clear();

            stok_listesi.Refresh();
            try
            {
                if (urun_listesi.RowCount == 1)
                {
                    sql3 = "SELECT kayit_no,urun_kodu,urun_ismi,degisen_stok,guncel_stok,urun_yer,satis_mi,fatura_no,stok_ekleyen_adi,stok_eklenen_tarih,stok_aciklamasi from stok where urun_kodu ='" + urun_listesi.Rows[0].Cells[0].Value.ToString() + "'";
                }
                else
                {
                    sql3 = "SELECT kayit_no,urun_kodu,urun_ismi,degisen_stok,guncel_stok,urun_yer,satis_mi,fatura_no,stok_ekleyen_adi,stok_eklenen_tarih,stok_aciklamasi from stok where urun_kodu ='" + urun_listesi.SelectedRows[0].Cells[0].Value.ToString() + "'";
                }

                dg_cmd3 = new MySqlCommand(sql3, mysqlbaglan);


                try
                {
                    mysqlbaglan.Open();

                    adapter3 = new MySqlDataAdapter(dg_cmd3);

                    dt3 = new DataTable();
                    adapter3.Fill(dt3);

                    foreach (DataRow row in dt3.Rows)
                    {
                        stok_listesi_cogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString());
                    }





                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




                    //// dt3.Rows.Clear();
                }
                catch
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                }
                label43.Text = stok_listesi.RowCount.ToString();
                this.stok_listesi.Sort(this.stok_listesi.Columns["No"], ListSortDirection.Descending);
            }
            catch
            { }
            this.stok_listesi.Columns[10].Width = 200;
        }
        /// Stok Listesi Kodları Bitiş
        ///  /// Stok Listesi Kodları Bitiş
        ///   /// Stok Listesi Kodları Bitiş
        ///  /// Stok Listesi Kodları Bitiş
        ///   ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------

        ///   ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        /// /// Stok Listesi Kodları
        private void cari_ait_fatura_cogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2, string aciklama3)
        {
            cariye_ait_fatura_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2, aciklama3);
        }

        string sql4 = "";
        MySqlCommand dg_cmd4;
        MySqlDataAdapter adapter4;
        DataTable dt4 = new DataTable();
        private void cariye_ait_fatura_retrieve_yap()
        {

            fatura_ait_ayarlari_loading();
            cariye_ait_fatura_listesi.Rows.Clear();

            cariye_ait_fatura_listesi.Refresh();
            try
            {


                sql4 = "SELECT islem_no,DATE_FORMAT(islem_tarihi, '%Y-%m-%d %H:%i'),evrak_no,islem_turu,odeme_tipi,aciklama,tutar,odenen from cari_hesaplar where cari_no=" + cari_listesi.SelectedRows[0].Cells[0].Value.ToString() + "";


                dg_cmd4 = new MySqlCommand(sql4, mysqlbaglan);


                try
                {
                    mysqlbaglan.Open();

                    adapter4 = new MySqlDataAdapter(dg_cmd4);

                    dt4 = new DataTable();
                    adapter4.Fill(dt4);

                    foreach (DataRow row in dt4.Rows)
                    {
                        cari_ait_fatura_cogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                    }





                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




                    //// dt3.Rows.Clear();
                }
                catch
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                }
                label39.Text = cariye_ait_fatura_listesi.RowCount.ToString();
                if (label39.Text == "0")
                {
                    button19.Enabled = false;
                }
                else
                {
                    button19.Enabled = true;
                }
                this.cariye_ait_fatura_listesi.Sort(this.cariye_ait_fatura_listesi.Columns[1], ListSortDirection.Descending);
                dikkatli_olma_zamani();
                cariye_ait_fatura_listesi.Columns[0].Visible = false;
            }
            catch
            { }
        }
        private void dikkatli_olma_zamani()
        {

            borc_fiyat.Text = "";
            try
            {
                double verecek = 0;
                for (int i = 0; i < cariye_ait_fatura_listesi.Rows.Count; ++i)
                {

                    if (cariye_ait_fatura_listesi.Rows[i].Cells[3].Value.ToString() == "Cariye Borçlanıldı.")
                    {
                        verecek = verecek + Convert.ToDouble(cariye_ait_fatura_listesi.Rows[i].Cells[6].Value);

                    }

                }
                for (int i = 0; i < cariye_ait_fatura_listesi.Rows.Count; ++i)
                {

                    if (cariye_ait_fatura_listesi.Rows[i].Cells[3].Value.ToString() == "Ödeme Yapıldı.")
                    {
                        verecek = verecek - Convert.ToDouble(cariye_ait_fatura_listesi.Rows[i].Cells[7].Value);

                    }

                }


                double alacak = 0;

                for (int i = 0; i < cariye_ait_fatura_listesi.Rows.Count; ++i)
                {

                    if (cariye_ait_fatura_listesi.Rows[i].Cells[3].Value.ToString() == "Cari Borçlandırıldı.")
                    {
                        verecek = verecek - Convert.ToDouble(cariye_ait_fatura_listesi.Rows[i].Cells[6].Value);

                    }

                }
                for (int i = 0; i < cariye_ait_fatura_listesi.Rows.Count; ++i)
                {

                    if (cariye_ait_fatura_listesi.Rows[i].Cells[3].Value.ToString() == "Satış" && cariye_ait_fatura_listesi.Rows[i].Cells[4].Value.ToString() == "Açık Hesap")
                    {
                        verecek = verecek - Convert.ToDouble(cariye_ait_fatura_listesi.Rows[i].Cells[6].Value);

                    }

                }
                for (int i = 0; i < cariye_ait_fatura_listesi.Rows.Count; ++i)
                {

                    if (cariye_ait_fatura_listesi.Rows[i].Cells[3].Value.ToString() == "Ödeme Alındı.")
                    {
                        verecek = verecek + Convert.ToDouble(cariye_ait_fatura_listesi.Rows[i].Cells[7].Value);

                    }

                }

                double sonuc2 = verecek;
                borc_fiyat.Text = sonuc2.ToString("N2").Replace("-", "") + " ₺";
                if (sonuc2 < 0)
                {
                    sonuc.Text = "Cari Borçlu!";
                    sonuc.ForeColor = Color.Red;
                }
                else if (sonuc2 > 0)
                {
                    sonuc.Text = "Cari Alacaklı!";
                    sonuc.ForeColor = Color.Green;
                }
                else
                {
                    sonuc.Text = "";
                }


            }
            catch (Exception ex)
            { ex.ToString(); ; }





        }
        /// Stok Listesi Kodları Bitiş
        ///  /// Stok Listesi Kodları Bitiş
        ///   /// Stok Listesi Kodları Bitiş
        ///  /// Stok Listesi Kodları Bitiş
        ///   ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------
        /// ------------------------------------------ ------------------------------------------ ------------------------------------------ ------------------------------------------



        DataTable cari_dt = new DataTable("cariler");
        private void cari_ayarlari_loading()
        {

            //// CARİ LİSTESİ AYARLAR //////////

            cari_listesi.DataSource = null;

            cari_listesi.ColumnCount = 13;
            try
            {
                cari_listesi.Columns[0].Name = "No";
                cari_listesi.Columns[1].Name = "Tip";
                cari_listesi.Columns[2].Name = "Adı";
                cari_listesi.Columns[3].Name = "Yetkili İsim";
                cari_listesi.Columns[4].Name = "Adres 1";
                cari_listesi.Columns[5].Name = "Adres 2";
                cari_listesi.Columns[6].Name = "Posta Kodu";
                cari_listesi.Columns[7].Name = "Telefon";
                cari_listesi.Columns[8].Name = "Cep_Telefon";
                cari_listesi.Columns[9].Name = "Faks";
                cari_listesi.Columns[10].Name = "Vergi Dairesi";
                cari_listesi.Columns[11].Name = "Vergi Dairesi No";
                cari_listesi.Columns[12].Name = "Açıklama";
                cari_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                cari_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < cari_listesi.Columns.Count - 1; i++)
            {
                cari_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            cari_listesi.Columns[cari_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < cari_listesi.Columns.Count; i++)
            {
                int colw = cari_listesi.Columns[i].Width;
                cari_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                cari_listesi.Columns[i].Width = colw;
            }

            cari_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            cari_listesi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cari_listesi.Columns[12].Width = 400;


            //// CARİ LİSTESİ AYARLARI BİTİŞ //////////
        }
        //// Ürün LİSTESİ AYARLAR //////////
        private void urun_ayarlari_loading()
        {



            urun_listesi.DataSource = null;

            urun_listesi.ColumnCount = 7;
            try
            {
                urun_listesi.Columns[0].Name = "Ürün Kodu";
                urun_listesi.Columns[1].Name = "Marka";
                urun_listesi.Columns[2].Name = "Ürün Türü";
                urun_listesi.Columns[3].Name = "Ürün İsmi";
                urun_listesi.Columns[4].Name = "Ürün Fiyatı";
                urun_listesi.Columns[5].Name = "Stok Sayısı";
                urun_listesi.Columns[6].Name = "Ürün Açıklaması";
                urun_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                urun_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < urun_listesi.Columns.Count - 1; i++)
            {
                urun_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            urun_listesi.Columns[urun_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < urun_listesi.Columns.Count; i++)
            {
                int colw = urun_listesi.Columns[i].Width;
                urun_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                urun_listesi.Columns[i].Width = colw;
            }

            urun_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }
        //// Ürün LİSTESİ AYARLARI BİTİŞ //////////

        //// Stok LİSTESİ AYARLARI BAŞLANGIÇ //////////
        private void stok_ayarlari_loading()
        {



            stok_listesi.DataSource = null;

            stok_listesi.ColumnCount = 11;
            try
            {
                stok_listesi.Columns[0].Name = "No";
                stok_listesi.Columns[1].Name = "Urun Kodu";
                stok_listesi.Columns[2].Name = "Urun İsmi";
                stok_listesi.Columns[3].Name = "Değişen Stok";
                stok_listesi.Columns[4].Name = "Güncel Stok";
                stok_listesi.Columns[5].Name = "Stok Yeri";
                stok_listesi.Columns[6].Name = "Satış mı?";
                stok_listesi.Columns[7].Name = "Fatura No";
                stok_listesi.Columns[8].Name = "Ekleyen";
                stok_listesi.Columns[9].Name = "Eklenme Tarihi";
                stok_listesi.Columns[10].Name = "Açıklama";
                stok_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                stok_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < stok_listesi.Columns.Count - 1; i++)
            {
                stok_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            stok_listesi.Columns[stok_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < stok_listesi.Columns.Count; i++)
            {
                int colw = stok_listesi.Columns[i].Width;
                stok_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                stok_listesi.Columns[i].Width = colw;
            }

            stok_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stok_listesi.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }
        //// Stok LİSTESİ AYARLARI BİTİŞ //////////
        ///
        ///

        //// AİT FATURA LİSTESİ AYARLARI BAŞLANGIÇ //////////
        private void fatura_ait_ayarlari_loading()
        {



            cariye_ait_fatura_listesi.DataSource = null;

            cariye_ait_fatura_listesi.ColumnCount = 8;
            try
            {
                cariye_ait_fatura_listesi.Columns[0].Name = "İşlem No";
                cariye_ait_fatura_listesi.Columns[1].Name = "İşlem Tarihi";
                cariye_ait_fatura_listesi.Columns[2].Name = "Evrak No";
                cariye_ait_fatura_listesi.Columns[3].Name = "İşlem Türü";
                cariye_ait_fatura_listesi.Columns[4].Name = "Ödeme Tipi";
                cariye_ait_fatura_listesi.Columns[5].Name = "Açıklama";
                cariye_ait_fatura_listesi.Columns[6].Name = "Tutar";
                cariye_ait_fatura_listesi.Columns[7].Name = "Ödenen";
                cariye_ait_fatura_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                cariye_ait_fatura_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < cariye_ait_fatura_listesi.Columns.Count - 1; i++)
            {
                cariye_ait_fatura_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            cariye_ait_fatura_listesi.Columns[cariye_ait_fatura_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < cariye_ait_fatura_listesi.Columns.Count; i++)
            {
                int colw = cariye_ait_fatura_listesi.Columns[i].Width;
                cariye_ait_fatura_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                cariye_ait_fatura_listesi.Columns[i].Width = colw;
            }
            cariye_ait_fatura_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cariye_ait_fatura_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cariye_ait_fatura_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cariye_ait_fatura_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cariye_ait_fatura_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cariye_ait_fatura_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cariye_ait_fatura_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cariye_ait_fatura_listesi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }
        //// AİT FATURA LİSTESİ AYARLARI BİTİŞ //////////
        ///
        ///

        /// SATIŞ YAP LİSTESİ
        /// SATIŞ YAP LİSTESİ
        /// SATIŞ YAP LİSTESİ
        private void satis_yap_ayarlari_loading()
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;

            satis_yap_listesi.DataSource = null;

            satis_yap_listesi.ColumnCount = 11;
            try
            {
                satis_yap_listesi.Columns[0].Name = "Ürun Kodu";
                satis_yap_listesi.Columns[1].Name = "Ürün Tür";
                satis_yap_listesi.Columns[2].Name = "Ürun İsmi";
                satis_yap_listesi.Columns[3].Name = "Miktar";
                satis_yap_listesi.Columns[4].Name = "BR Fiyatı";
                satis_yap_listesi.Columns[5].Name = "Toplam";
                satis_yap_listesi.Columns[6].Name = "-İndirim";
                satis_yap_listesi.Columns[7].Name = "+KDV";
                satis_yap_listesi.Columns[8].Name = "Genel Toplam";
                satis_yap_listesi.Columns[9].Name = "Seri Numarası";
                satis_yap_listesi.Columns[10].Name = "Stokdan Düş";
                satis_yap_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                satis_yap_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < satis_yap_listesi.Columns.Count - 1; i++)
            {
                satis_yap_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            satis_yap_listesi.Columns[satis_yap_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < satis_yap_listesi.Columns.Count; i++)
            {
                int colw = satis_yap_listesi.Columns[i].Width;
                satis_yap_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                satis_yap_listesi.Columns[i].Width = colw;
            }

            satis_yap_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            satis_yap_listesi.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }

        /// SATIŞ YAP LİSTESİ BİTİŞ
        /// SATIŞ YAP LİSTESİ BİTİŞ
        /// SATIŞ YAP LİSTESİ BİTİŞ
        /// Tüm faturalar Listesi * Mizer Son
        /// Tüm faturalar Listesi * Mizer Son
        /// Tüm faturalar Listesi * Mizer Son
        /// 
        private void tum_faturalar_ayarlar_loading()
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;

            tum_faturalar_listesi.DataSource = null;

            tum_faturalar_listesi.ColumnCount = 11;
            try
            {
                tum_faturalar_listesi.Columns[0].Name = "Fatura No";
                tum_faturalar_listesi.Columns[1].Name = "Cari adı";
                tum_faturalar_listesi.Columns[2].Name = "Toplam";
                tum_faturalar_listesi.Columns[3].Name = "KDV";
                tum_faturalar_listesi.Columns[4].Name = "Genel Toplam";
                tum_faturalar_listesi.Columns[5].Name = "Ödeme Tipi";
                tum_faturalar_listesi.Columns[6].Name = "Satış Tarihi";
                tum_faturalar_listesi.Columns[7].Name = "Fatura Üst Bilgisi";
                tum_faturalar_listesi.Columns[8].Name = "Fatura Açıklaması";
                tum_faturalar_listesi.Columns[9].Name = "Faturalandıran";
                tum_faturalar_listesi.Columns[10].Name = "Fatura Oluşturulma Tarihi";
                tum_faturalar_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                tum_faturalar_listesi.MultiSelect = false;



            }
            catch
            {

            }




            for (int i = 0; i < tum_faturalar_listesi.Columns.Count - 1; i++)
            {
                tum_faturalar_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            tum_faturalar_listesi.Columns[tum_faturalar_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < tum_faturalar_listesi.Columns.Count; i++)
            {
                int colw = tum_faturalar_listesi.Columns[i].Width;
                tum_faturalar_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                tum_faturalar_listesi.Columns[i].Width = colw;
            }

            tum_faturalar_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_faturalar_listesi.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        /// /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        /// /// Cari Listesi Kodları
        private void tum_faturacogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2, string aciklama3, string aciklama4, string aciklama5, string aciklama6)
        {
            tum_faturalar_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2, aciklama3, aciklama4, aciklama5, aciklama6);
        }

        string sql_tum = "";
        MySqlCommand dg_cmd_tum;
        MySqlDataAdapter adapter_tum;
        DataTable dt_tum = new DataTable();
        private void tum_fatura_retrieve()
        {

            tum_faturalar_ayarlar_loading();
            tum_faturalar_listesi.Rows.Clear();
            tum_faturalar_listesi.Refresh();



            sql_tum = "Select fatura.fatura_no, cariler.firma_adi,fatura.toplam,fatura.kdv,fatura.genel_toplam,fatura.Odeme_tipi,fatura.satis_tarih,fatura.fatura_ust_bilgi,fatura.fatura_aciklamasi,fatura.fatura_kesen,fatura.fatura_kesen_tarih FROM fatura INNER JOIN cariler ON fatura.cari_no = cariler.cari_no  ";


            dg_cmd_tum = new MySqlCommand(sql_tum, mysqlbaglan);


            try
            {
                mysqlbaglan.Open();

                adapter_tum = new MySqlDataAdapter(dg_cmd_tum);

                dt_tum = new DataTable();
                adapter_tum.Fill(dt_tum);

                foreach (DataRow row in dt_tum.Rows)
                {
                    tum_faturacogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString());
                }





                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




                //// dt.Rows.Clear();
                this.tum_faturalar_listesi.Sort(this.tum_faturalar_listesi.Columns[7], ListSortDirection.Descending);
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            label12.Text = cari_listesi.RowCount.ToString();
            fatura_ara.Text = "";
        }

        ///

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

        private void pg_ayar_ck()
        {
            try
            {
                string sql = "Select * from program_ayarlari where mizer=666";
                if (mysqlbaglan.State == ConnectionState.Closed) { mysqlbaglan.Open(); }
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    if (oku["f_silerken_ss"].ToString() == "Evet") { f_sil = false; } else { f_sil = true; }
                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -2", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }




        }
        public Boolean f_sil;

        public string felek_donuyorr_agaaaa;
        private void felek_donsunmu()
        {
            try
            {
                string sql = "Select * from version_guvenlik_Mizer";
                if (mysqlbaglan.State == ConnectionState.Closed) { mysqlbaglan.Open(); }
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    felek_donuyorr_agaaaa = oku["Super_Sifre"].ToString();

                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                MessageBox.Show("Bağlantı Sağlanamadı Hata... -3", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                DialogResult = DialogResult.OK;
            }
        }



        private void fatura_no_ekle_bir()
        {

            try
            {
                string sql = "Select MAX(fatura_no) from fatura ";
                mysqlbaglan.Open();

                MySqlCommand sorgula = new MySqlCommand(sql, mysqlbaglan);
                int maxId = (Convert.ToInt32(sorgula.ExecuteScalar())) + 1;
                fatura_no_gir.Value = maxId;
                mysqlbaglan.Close();
            }
            catch
            {
                mysqlbaglan.Close();
            }

        }





        private void cari_islemler_Load(object sender, EventArgs e)
        {
            yetki_sorgulama_XI();
            this.tum_faturalar_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.tum_faturalar_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            this.satis_yap_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.satis_yap_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            this.cari_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.cari_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            this.cariye_ait_fatura_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.cariye_ait_fatura_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            this.urun_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.urun_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            this.stok_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.stok_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            this.kasa_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.kasa_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            ilk_tarih_kasa.Value = DateTime.Now.AddMonths(-1);
            son_tarih_kasa.Value = DateTime.Now;
            fatura_tarihi_gir.CustomFormat = "dd/MM/yyyy HH:mm";
            fatura_tarihi_gir.Value = DateTime.Now;
            fatura_tarihi_gir.Refresh();
            tarih_yenile_Click(null, null);


            log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Giriş Yapıldı", "Görüntülendi.");


            fatura_no_ekle_bir();




            yenilemeaq();
            fatura_tipi_combosu.SelectedIndex = 0;
            fatura_tarihi_gir.Text = DateTime.Now.ToShortDateString().Replace(".", "/");
            hizli_urun_ekle_combosu();
            cari_ayarlari_loading();
            urun_ayarlari_loading();
            satis_yap_ayarlari_loading();
            cari_ayarlari_loading();
            tum_faturalar_ayarlar_loading();

            retrieve();
            urun_listesini_retrieve_yap();
            stok_listesini_retrieve_yap();
            tum_fatura_retrieve();
            



        }
        private void listelere_retrieve_duzenle()
        {
            hizli_urun_ekle_combosu();
            cari_ayarlari_loading();
            urun_ayarlari_loading();
            satis_yap_ayarlari_loading();
            cari_ayarlari_loading();
            tum_faturalar_ayarlar_loading();

            retrieve();
            urun_listesini_retrieve_yap();
            stok_listesini_retrieve_yap();
            tum_fatura_retrieve();
        }





        private void neosFade_TL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != ','))
            {
                e.Handled = true;
            }


        }


        private void guncelle_neosFade_TL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != ','))
            {
                e.Handled = true;
            }


        }




        DataTable AllNames = new DataTable();

        private void urun_duzenle_liste_Click(object sender, EventArgs e)
        {

        }








        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


        }



        private void urun_duzenle_liste_KeyPress(object sender, KeyPressEventArgs e)
        {

        }






        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cari_ekle_SirtueX cari_ekle_ac = new cari_ekle_SirtueX();
            cari_ekle_ac.adminadi = kadi_getir;
            cari_ekle_ac.ekleyen_adi = ekleyen_adi;
            cari_ekle_ac.mysqlbaglan = mysqlbaglan;
            cari_ekle_ac.ShowDialog();
            retrieve();
            cari_listesi.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cari_duzenle_SirtueX cari_duzenle_ac = new cari_duzenle_SirtueX();
                cari_duzenle_ac.ekleyen_adi = ekleyen_adi;
                cari_duzenle_ac.adminadi = kadi_getir;
                cari_duzenle_ac.mysqlbaglan = mysqlbaglan;
                cari_duzenle_ac.cari_no = cari_listesi.SelectedRows[0].Cells[0].Value.ToString();
                cari_duzenle_ac.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Seçili Cari yok.");
            }
            retrieve();
            cari_listesi.Refresh();
        }
        DataTable cariarama = new DataTable("cariler");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cari_listesi.Columns.Clear();
            DataView dv = dt.DefaultView;
            try
            {
                dt.Columns["cari_no"].ColumnName = "No";
                dt.Columns["firma_tipi"].ColumnName = "Tip";
                dt.Columns["firma_adi"].ColumnName = "Adı";
                dt.Columns["yetkili_isim"].ColumnName = "Yetkili";
                dt.Columns["adres_satiri_1"].ColumnName = "Adres1";
                dt.Columns["adres_satiri_2"].ColumnName = "Adres2";
                dt.Columns["posta_kodu"].ColumnName = "Posta Kodu";
                dt.Columns["telefon"].ColumnName = "Telefon";
                dt.Columns["cep_telefon"].ColumnName = "Cep_Telefon";
                dt.Columns["faks"].ColumnName = "Faks";
                dt.Columns["vergidairesi"].ColumnName = "Vergi Dairesi";
                dt.Columns["vergidairesi_2"].ColumnName = "Vergi No";
                dt.Columns["aciklama"].ColumnName = "Açıklama";
            }
            catch/*Exception ex*/
            {
                /* MessageBox.Show(ex.ToString()); */
            }
            try
            {
                dv.RowFilter = string.Format("Adı like '%{0}%' or Tip like '%{0}%' or Açıklama like '%{0}%'", textBox1.Text);
                cari_listesi.DataSource = dv.ToTable();
            }
            catch
            { }


        }
        DataTable urunarama = new DataTable("cariler");
        private void textBox3_TextChanged(object sender, EventArgs e)

        {
            urun_listesi.Columns.Clear();
            DataView dv2 = dt2.DefaultView;
            try
            {
                ////  dv2.RowFilter = string.Format("urun_kodu like '%{0}%' or urun_ismi like '%{0}%' or urun_aciklama like '%{0}%' or urun_tur like '%{0}%' or urun_bagli_marka like '%{0}%'", textBox3.Text);
                dt2.Columns["urun_kodu"].ColumnName = "Ürün Kodu";
                dt2.Columns["urun_bagli_marka"].ColumnName = "Marka";
                dt2.Columns["urun_tur"].ColumnName = "Ürün Türü";
                dt2.Columns["urun_ismi"].ColumnName = "Ürün İsmi";
                dt2.Columns["urun_fiyati"].ColumnName = "Ürün Fiyatı";
                dt2.Columns["urun_stok_durumu"].ColumnName = "Stok Sayısı";
                dt2.Columns["urun_aciklama"].ColumnName = "Ürün Açıklaması";
            }
            catch/*Exception ex*/
            {
                /* MessageBox.Show(ex.ToString()); */
            }
            try
            {
                dv2.RowFilter = string.Format(" `Ürün Kodu` like '%{0}%' or `Ürün İsmi` like '%{0}%' or `Ürün Açıklaması` like '%{0}%' or `Ürün Türü` like '%{0}%' or `Marka` like '%{0}%'", textBox3.Text);

                urun_listesi.DataSource = dv2.ToTable();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(cari_listesi.SelectedRows[0].Cells[2].Value + " isimli cariyi silmek istediğine emin misin ??", "Silmek için emin misin? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from cariler where cari_no=" + cari_listesi.SelectedRows[0].Cells[0].Value + "";
                    textBox1.Text = "";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Cari Sil", "Silinen Cari No: " + cari_listesi.SelectedRows[0].Cells[0].Value.ToString());
                    retrieve();

                    cari_listesi.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Birşeyler ters sende biliyorsun bunu mesela internet bağlantısı olmayabilir ", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            urun_ekle_SirtueX urun_ekle_ac_main = new urun_ekle_SirtueX();
            urun_ekle_ac_main.ekleyen_adi = ekleyen_adi;
            urun_ekle_ac_main.adminadi = kadi_getir;
            urun_ekle_ac_main.mysqlbaglan = mysqlbaglan;
            urun_ekle_ac_main.ShowDialog();
            urun_listesini_retrieve_yap();
            urun_listesi.Refresh();
            hizli_urun_ekle_combosu();

        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                urun_duzenle_SirtueX urun_duzenle_main = new urun_duzenle_SirtueX();
                urun_duzenle_main.ekleyen_adi = ekleyen_adi;
                urun_duzenle_main.mysqlbaglan = mysqlbaglan;
                urun_duzenle_main.adminadi = kadi_getir;
                urun_duzenle_main.urun_kodu = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
                urun_duzenle_main.ShowDialog();
                urun_listesini_retrieve_yap();
                urun_listesi.Refresh();
                hizli_urun_ekle_combosu();
            }
            catch
            {
                MessageBox.Show("Seçili ürün yok.");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(urun_listesi.SelectedRows[0].Cells[3].Value + " isimli ürünü silmek istediğine emin misin ??", "Silmek için emin misin? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from urunler where urun_kodu='" + urun_listesi.SelectedRows[0].Cells[0].Value + "'";
                    textBox1.Text = "";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Ürün Silindi.", "Silinen Ürün Stok Kodu: " + urun_listesi.SelectedRows[0].Cells[0].Value + " ");
                    urun_listesini_retrieve_yap();
                    urun_listesi.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Birşeyler ters sende biliyorsun bunu mesela internet bağlantısı olmayabilir.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hizli_urun_ekle_combosu();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int select = urun_listesi.SelectedRows[0].Index;


                stok_ekle_SirtueX stok_ekle_ac = new stok_ekle_SirtueX();
                stok_ekle_ac.ekleyen_adi = ekleyen_adi;
                stok_ekle_ac.adminadi = kadi_getir;
                stok_ekle_ac.mysqlbaglan = mysqlbaglan;
                stok_ekle_ac.urun_kodu = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();

                var result = stok_ekle_ac.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = stok_ekle_ac.eklenilcek_stok_urun_listesine;
                    MessageBox.Show(stok_ekle_ac.eklenilcek_stok_urun_listesine);
                    urun_listesi.SelectedRows[0].Cells[5].Value = stok_ekle_ac.eklenilcek_stok_urun_listesine;
                    urun_listesi.UpdateCellValue(5, select);
                    stok_listesini_retrieve_yap();
                    stok_listesi.Refresh();
                }
                label46.Text = urun_listesi.SelectedRows[0].Cells[5].Value.ToString();
                label49.Text = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void urun_listesi_Click(object sender, EventArgs e)
        {

        }

        private void urun_listesi_SelectionChanged(object sender, EventArgs e)
        {
            stok_listesini_retrieve_yap();
            try
            {
                label46.Text = urun_listesi.SelectedRows[0].Cells[5].Value.ToString();
                label49.Text = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {

            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                int select = urun_listesi.SelectedRows[0].Index;


                stok_dus_SirtueX stok_dus_ac = new stok_dus_SirtueX();
                stok_dus_ac.ekleyen_adi = ekleyen_adi;
                stok_dus_ac.adminadi = kadi_getir;
                stok_dus_ac.mysqlbaglan = mysqlbaglan;
                stok_dus_ac.urun_kodu = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
                var result = stok_dus_ac.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = stok_dus_ac.eklenilcek_stok_urun_listesine;
                    urun_listesi.SelectedRows[0].Cells[5].Value = stok_dus_ac.eklenilcek_stok_urun_listesine;
                    urun_listesi.UpdateCellValue(5, select);
                    stok_listesini_retrieve_yap();
                    stok_listesi.Refresh();
                }
                label46.Text = urun_listesi.SelectedRows[0].Cells[5].Value.ToString();
                label49.Text = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            { }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            satis_urun_ekle_SirtueX satis_urun_ekle_ac = new satis_urun_ekle_SirtueX();
            satis_urun_ekle_ac.mysqlbaglan = mysqlbaglan;
            var result = satis_urun_ekle_ac.ShowDialog();
            if (result == DialogResult.OK)
            {
                string seri_asil_donus = "";
                if (fatura_tipi_combosu.SelectedIndex == 0)
                {
                    for (int i = 0; i <= (Convert.ToInt16(satis_urun_ekle_ac.geri_urun_adet) - 1); i++)
                    {
                        string seri_donus = Prompt.ShowDialog("Parçası değişilecek dihazın Seri Numarasını Girin", "LMR - Cari - Mizer");
                        seri_asil_donus = seri_asil_donus + ("|" + seri_donus);
                    }
                }
                else
                {
                    string seri_donus = "";
                    seri_asil_donus = "|" + seri_donus;
                }
                satis_yap_listesi.Rows.Add(satis_urun_ekle_ac.geri_urun_kodu, satis_urun_ekle_ac.geri_urun_turu, satis_urun_ekle_ac.geri_urun_ismi, satis_urun_ekle_ac.geri_urun_adet, satis_urun_ekle_ac.geri_urun_fiyat, satis_urun_ekle_ac.geri_urun_toplam, satis_urun_ekle_ac.geri_urun_indirim, satis_urun_ekle_ac.geri_urun_kdv, satis_urun_ekle_ac.geri_urun_genel_toplam, seri_asil_donus, satis_urun_ekle_ac.stok_duscenmi);
            }
            fiyatlari_satistan_guncelleme_vakti();
        }

        private void neosFade_TL_TextChanged(object sender, EventArgs e)
        {

        }



        private void button9_Click(object sender, EventArgs e)
        {
            if (satis_yap_listesi.RowCount == 0)
            {
                MessageBox.Show("Düzeltilecek ürün Seçili değil..", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                satis_urun_ekle_SirtueX satis_urun_ekle_ac = new satis_urun_ekle_SirtueX();
                satis_urun_ekle_ac.duzenle_boolen = true;
                satis_urun_ekle_ac.geri_urun_kodu = satis_yap_listesi.SelectedRows[0].Cells[0].Value.ToString();
                satis_urun_ekle_ac.geri_urun_turu = satis_yap_listesi.SelectedRows[0].Cells[1].Value.ToString();
                satis_urun_ekle_ac.geri_urun_ismi = satis_yap_listesi.SelectedRows[0].Cells[2].Value.ToString();
                satis_urun_ekle_ac.geri_urun_adet = satis_yap_listesi.SelectedRows[0].Cells[3].Value.ToString();
                satis_urun_ekle_ac.geri_urun_fiyat = satis_yap_listesi.SelectedRows[0].Cells[4].Value.ToString();
                satis_urun_ekle_ac.mysqlbaglan = mysqlbaglan;
                satis_urun_ekle_ac.geri_urun_toplam = satis_yap_listesi.SelectedRows[0].Cells[5].Value.ToString();
                satis_urun_ekle_ac.geri_urun_indirim = satis_yap_listesi.SelectedRows[0].Cells[6].Value.ToString();
                satis_urun_ekle_ac.geri_urun_kdv = satis_yap_listesi.SelectedRows[0].Cells[7].Value.ToString();
                satis_urun_ekle_ac.geri_urun_genel_toplam = satis_yap_listesi.SelectedRows[0].Cells[8].Value.ToString();

                var result = satis_urun_ekle_ac.ShowDialog();
                if (result == DialogResult.OK)
                {
                    satis_yap_listesi.Rows.RemoveAt(satis_yap_listesi.SelectedRows[0].Index);
                    satis_yap_listesi.Rows.Add(satis_urun_ekle_ac.geri_urun_kodu, satis_urun_ekle_ac.geri_urun_turu, satis_urun_ekle_ac.geri_urun_ismi, satis_urun_ekle_ac.geri_urun_adet, satis_urun_ekle_ac.geri_urun_fiyat, satis_urun_ekle_ac.geri_urun_toplam, satis_urun_ekle_ac.geri_urun_indirim, satis_urun_ekle_ac.geri_urun_kdv, satis_urun_ekle_ac.geri_urun_genel_toplam, satis_urun_ekle_ac.stok_duscenmi);
                }
            }
            fiyatlari_satistan_guncelleme_vakti();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (satis_yap_listesi.RowCount == 0)
            {
                MessageBox.Show("Silinecek ürün yok.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                satis_yap_listesi.Rows.RemoveAt(satis_yap_listesi.SelectedRows[0].Index);
            }
            fiyatlari_satistan_guncelleme_vakti();
        }

        private void fiyatlari_satistan_guncelleme_vakti()
        {
            double toplam = 0;
            double kdv = 0;
            double genel_toplam = 0;
            double indirim = 0;
            if (satis_yap_listesi.RowCount == 0)
            {
                toplam_cikis.Text = "0,00";
                kdv_cikis.Text = "0,00";
                geneltopla_cikis.Text = "0,00";
                indirim_cikis.Text = "0,00";
            }
            else
            {
                ///
                for (int i = 0; (i <= (satis_yap_listesi.RowCount - 1)); i++)
                {
                    toplam = toplam + Convert.ToDouble(satis_yap_listesi.Rows[i].Cells[5].Value);

                    toplam_cikis.Text = toplam.ToString(".00");
                }
                toplam_cikis.Text = toplam.ToString(".00");

                ///

                for (int i = 0; (i <= (satis_yap_listesi.RowCount - 1)); i++)
                {
                    indirim = indirim + Convert.ToDouble(satis_yap_listesi.Rows[i].Cells[6].Value);

                    indirim_cikis.Text = indirim.ToString(".00");
                }
                indirim_cikis.Text = indirim.ToString(".00");

                ///
                for (int i = 0; (i <= (satis_yap_listesi.RowCount - 1)); i++)
                {
                    kdv = kdv + Convert.ToDouble(satis_yap_listesi.Rows[i].Cells[7].Value);

                    kdv_cikis.Text = kdv.ToString(".00");
                }
                kdv_cikis.Text = kdv.ToString(".00");
                ///
                for (int i = 0; (i <= (satis_yap_listesi.RowCount - 1)); i++)
                {
                    genel_toplam = genel_toplam + Convert.ToDouble(satis_yap_listesi.Rows[i].Cells[8].Value);

                    geneltopla_cikis.Text = genel_toplam.ToString(".00");
                }
                geneltopla_cikis.Text = genel_toplam.ToString(".00");
                /// 

            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                double toplam = 0;
                double kdv2 = 0;
                double genel_toplam = 0;
                string sql = "select * from urunler where urun_kodu='" + hizli_ekle_combosu.Text + "'";
                MySqlCommand sqloynat = new MySqlCommand(sql, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader dr = sqloynat.ExecuteReader();
                if (dr.Read())
                {
                    string seri_asil_donus = "";
                    if (fatura_tipi_combosu.SelectedIndex == 0)
                    {
                        string seri_donus = Prompt.ShowDialog("Parçası değişilecek dihazın Seri Numarasını Girin", "LMR - Cari - Mizer");
                        seri_asil_donus = "|" + seri_donus;
                    }
                    else
                    {
                        string seri_donus = "";
                        seri_asil_donus = "|" + seri_donus;
                    }
                    toplam = Convert.ToDouble(dr["urun_fiyati"].ToString());
                    kdv2 = Convert.ToDouble(toplam * 0.18);
                    genel_toplam = toplam + kdv2;
                    string stokdan_du23 = "";
                    if (stokdan_dus2.Checked == true)
                    {
                        stokdan_du23 = "Evet";
                    }
                    else
                    {
                        stokdan_du23 = "Hayır";
                    }


                    satis_yap_listesi.Rows.Add(dr["urun_kodu"].ToString(), dr["urun_tur"].ToString(), dr["urun_ismi"].ToString(), "1", dr["urun_fiyati"].ToString(), Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00"), "0,00", Math.Round(kdv2, 2, MidpointRounding.AwayFromZero).ToString(".00"), Math.Round(genel_toplam, 2, MidpointRounding.AwayFromZero).ToString(".00"), seri_asil_donus, stokdan_du23);


                }
                else
                {
                    MessageBox.Show("Girdiğiniz ürün kodu veritabanında bulunamadı.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




            }
            fiyatlari_satistan_guncelleme_vakti();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cari_sec_listesi_SirtueX cari_sec_ac_s = new cari_sec_listesi_SirtueX();
            cari_sec_ac_s.mysqlbaglan = mysqlbaglan;
            var result = cari_sec_ac_s.ShowDialog();
            if (result == DialogResult.OK)
            {
                cari_tipi_satis.Text = cari_sec_ac_s.cari_tipi;
                cari_adi_satis.Text = cari_sec_ac_s.cari_adi;
                cari_adres1_satis.Text = cari_sec_ac_s.cari_adres1;
                cari_adres2_satis.Text = cari_sec_ac_s.cari_adres2;
                cari_vd_satis.Text = cari_sec_ac_s.cari_vd;
                cari_vdno_satis.Text = cari_sec_ac_s.cari_vd2;
                cari_no_satis.Text = cari_sec_ac_s.cari_no;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cari_satis_temizle();

        }
        private void komple_temizle()
        {
            cari_satis_temizle();
            satis_yap_listesi.Rows.Clear();
            fiyatlari_satistan_guncelleme_vakti();
            ust_bilgi_fatura.SelectedIndex = 0;
            fatura_aciklamasi.Text = "Açıklama Girilmedi...";

        }
        private void ekli_urunleri_temizle()
        {
            satis_yap_listesi.Rows.Clear();
        }


        private void cari_satis_temizle()
        {
            cari_no_satis.Text = "";
            cari_adres1_satis.Text = "";
            cari_adres2_satis.Text = "";
            cari_adi_satis.Text = "";
            cari_tipi_satis.Text = "";
            cari_vdno_satis.Text = "";
            cari_vd_satis.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            komple_temizle();
            fatura_tarihi_gir.Text = DateTime.Now.ToShortDateString().Replace(".", "/");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            satis_yap_listesi.Rows.Clear();
            fiyatlari_satistan_guncelleme_vakti();
        }
        Excel.Application excelApp = new Excel.Application();
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                string seri_nolar = "";
                string workbookPath = "" + Application.StartupPath.ToString() + @"\excel_ana\kemik.xlsx";
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Excel.Sheets excelSheets = excelWorkbook.Worksheets;
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item("Sheet1");
                Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range("A1", "G53");
                excelWorksheet.Cells[12, 2] = cari_adi_satis.Text;

                excelWorksheet.Cells[5, 7] = fatura_tarihi_gir.Text;
                excelWorksheet.Cells[13, 2] = cari_adres1_satis.Text;
                excelWorksheet.Cells[15, 2] = cari_adres2_satis.Text;
                excelWorksheet.Cells[13, 6] = ust_bilgi_fatura.Text;
                int k = 0;
                for (int i = 0; i <= (satis_yap_listesi.RowCount - 1); i++)
                {
                    seri_nolar = satis_yap_listesi.Rows[i].Cells[9].Value.ToString();
                    List<string> seri_no_tek = seri_nolar.Split('|').ToList();
                    excelWorksheet.Cells[27 + k, 2].Value = satis_yap_listesi.Rows[i].Cells[1].Value.ToString();
                    excelWorksheet.Cells[27 + k, 5].Value = satis_yap_listesi.Rows[i].Cells[3].Value.ToString();
                    excelWorksheet.Cells[27 + k, 6].Value = satis_yap_listesi.Rows[i].Cells[4].Value.ToString() + " TL";
                    excelWorksheet.Cells[27 + k, 7].Value = satis_yap_listesi.Rows[i].Cells[5].Value.ToString() + " TL";
                    excelWorksheet.Cells[27 + k, 2].Font.Bold = true;
                    excelWorksheet.Cells[27 + k, 5].Font.Bold = true;
                    excelWorksheet.Cells[27 + k, 6].Font.Bold = true;
                    excelWorksheet.Cells[27 + k, 7].Font.Bold = true;
                    seri_no_tek.RemoveAt(0);
                    foreach (string seriler in seri_no_tek)
                    {
                        excelWorksheet.Cells[27 + k + 1, 2].Value = seriler;
                        excelWorksheet.Cells[27 + k + 1, 2].Font.Bold = false;
                        k = k + 1;
                    }


                    k = k + 1;
                    //// 27 yazdın  | 28 yazdın ---- 29yazdın ---- 30 yazdın ---- 31 yazdın
                }

                excelWorksheet.Cells[18, 5] = cari_vd_satis.Text + " / " + cari_vdno_satis.Text;
                excelWorksheet.Cells[44, 7] = toplam_cikis.Text + " TL";
                excelWorksheet.Cells[46, 7] = kdv_cikis.Text + " TL";
                excelWorksheet.Cells[48, 7] = geneltopla_cikis.Text + " TL";
                excelWorksheet.Cells[52, 5] = "YALNIZ " + yaziyaCevir(Convert.ToDecimal(geneltopla_cikis.Text));


                string workbookPath2 = "" + Application.StartupPath.ToString() + @"\excel_ana\onizleme.xlsx";
                excelApp.DisplayAlerts = false;

                excelWorkbook.SaveAs(workbookPath2, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                Workbook workbook = new Workbook();
                excelWorkbook.Close();
                workbook.LoadFromFile(workbookPath2);

                //If you want to make the excel content fit to pdf page
                //workbook.ConverterSetting.SheetFitToPage = true;
                workbookPath2 = "" + Application.StartupPath.ToString() + @"\excel_ana\onizleme.pdf";
                workbook.SaveToFile(workbookPath2, Spire.Xls.FileFormat.PDF);
                System.Diagnostics.Process.Start(workbookPath2);
            }
            catch
            {

                MessageBox.Show("Hata İnternet bağlantısı olmayabilir..", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static int harfsay(string seriler, char ayrac)
        {
            int count = 0;
            foreach (char c in seriler)
            {
                if (ayrac == c)
                    count++;
            }
            return count;
        }
        private void hizli_urun_ekle_combosu()
        {
            hizli_ekle_combosu.Items.Clear();
            try
            {
                string carikomut = "select * FROM urunler";
                MySqlCommand cmd_combobox_cari_doldur = new MySqlCommand(carikomut, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum_cari = cmd_combobox_cari_doldur.ExecuteReader();
                while (okuyucum_cari.Read())
                {
                    hizli_ekle_combosu.Items.Add(okuyucum_cari.GetString("urun_kodu"));
                }
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }
        }
        ////////////////
        ///////////////////
        ///          PDF MOTOR
        ///////////
        ///

        ////////////////
        ///////////////////
        ///          PDF MOTOR
        ///////////
        ///
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };

                Button confirmation = new Button() { Text = "Kaydet", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;
                textBox.TextChanged += new System.EventHandler(textbox_TextChanged);
                void textbox_TextChanged(object sender, EventArgs e)
                {
                    textBox.Text = string.Concat(textBox.Text.Where(char.IsLetterOrDigit));
                }


                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }


        }
        public static class Prompt2
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt2 = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
                ComboBox textBox = new ComboBox() { Left = 50, Top = 50, Width = 400 };
                textBox.DropDownStyle = ComboBoxStyle.DropDownList;
                textBox.Items.Clear();
                textBox.Items.Add("Peşin");
                textBox.Items.Add("Kredi Kartı");
                textBox.Items.Add("Açık Hesap");
                textBox.SelectedIndex = 0;
                Button confirmation = new Button() { Text = "Kaydet", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt2.Close(); };
                prompt2.Controls.Add(textBox);
                prompt2.Controls.Add(confirmation);
                prompt2.Controls.Add(textLabel);
                prompt2.AcceptButton = confirmation;
                prompt2.MaximizeBox = false;
                prompt2.MinimizeBox = false;
                textBox.TextChanged += new System.EventHandler(textbox_TextChanged);
                void textbox_TextChanged(object sender, EventArgs e)
                {
                    textBox.Text = string.Concat(textBox.Text.Where(char.IsLetterOrDigit));
                }


                return prompt2.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }


        }

        private string fatura_no_kontrol()
        {
            try
            {


                string sql = "Select fatura_no from fatura where fatura_no=" + fatura_no_gir.Value.ToString();
                mysqlbaglan.Open();
                MySqlCommand sorgula = new MySqlCommand(sql, mysqlbaglan);
                MySqlDataReader oku = sorgula.ExecuteReader();
                if (oku.Read())
                {
                    mysqlbaglan.Close();
                    return "Kullanılmakta";
                }
                else
                {
                    mysqlbaglan.Close();
                    return "Devam";
                }
            }
            catch
            {
                mysqlbaglan.Close();
                return "Sorgu Hatası";

            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (cari_adi_satis.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Cari İsmini boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cari_adi_satis.Text == "")
            {
                MessageBox.Show("Cari İsmini boş bırakamazsınız.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fatura_no_gir.Value > 999999)
            {
                MessageBox.Show("Fatura No 999999'dan fazla olamaz.");

                fatura_no_gir.Focus();
                return;
            }
            else if (fatura_no_gir.Value < 0)
            {
                MessageBox.Show("Fatura No 1'den az olamaz.");

                fatura_no_gir.Focus();
                return;
            }

            string devam_tanrisi = fatura_no_kontrol();
            if (devam_tanrisi == "Kullanılmakta")
            { MessageBox.Show("Fatura No Kullanılıyor Lütfen Kullanılmayan Fatura No giriniz.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else if (devam_tanrisi == "Devam")
            {
            }
            else
            { MessageBox.Show("Bağlantı hatası, İnternet Bağlantınızı Kontrol ediniz. Fatura_No Sorgulanırken!.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }




            string odeme_yontemi = Prompt2.ShowDialog("Lütfen Ödeme yöntemini seçiniz.", "LMR - Cari - Mizer");
            if (odeme_yontemi == "Peşin")
            {



            }
            else if (odeme_yontemi == "Kredi Kartı")
            {

            }
            else if (odeme_yontemi == "Açık Hesap")
            {

            }
            else
            {
                MessageBox.Show("Ödeme yöntemini Seçmediniz. Tekrar deneyin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                string guncelle = "";
                string guncelle2 = "";
                string guncelle3 = "";
                MySqlCommand guncel;
                MySqlCommand guncel2;
                MySqlCommand guncel3;
                Random rnd = new Random();

                int cari_no_uret = rnd.Next(100000000, 999999999);
                int cari_no_uretilmis = cari_no_uret;
                if (cari_no_satis.Text == "")
                {
                    try
                    {
                        guncelle = "insert into cariler(cari_no,firma_adi,firma_tipi,adres_satiri_1,adres_satiri_2,vergidairesi,vergidairesi_2,aciklama,ekleyen,eklenmetarihi) values (@1_a,@2_a,@3_a,@4_a,@5_a,@6_a,@7_a,@8,@9,@10)";
                        guncel = new MySqlCommand(guncelle, mysqlbaglan);
                        guncel.Parameters.AddWithValue("@1_a", cari_no_uretilmis.ToString());
                        guncel.Parameters.AddWithValue("@2_a", cari_adi_satis.Text);
                        guncel.Parameters.AddWithValue("@3_a", cari_tipi_satis.Text);
                        guncel.Parameters.AddWithValue("@4_a", cari_adres1_satis.Text);
                        guncel.Parameters.AddWithValue("@5_a", cari_adres2_satis.Text);
                        guncel.Parameters.AddWithValue("@6_a", cari_vd_satis.Text);
                        guncel.Parameters.AddWithValue("@7_a", cari_vdno_satis.Text);
                        guncel.Parameters.AddWithValue("@8", "Satış yaparken cari olarak eklendi.");
                        guncel.Parameters.AddWithValue("@9", ekleyen_adi);
                        guncel.Parameters.AddWithValue("@10", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                        mysqlbaglan.Open();
                        guncel.ExecuteNonQuery();
                        cari_no_satis.Text = cari_no_uretilmis.ToString();
                        if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                        log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Cari Ekleme", "Fatura Kesilirken Cari eklendi.. Fatura No" + fatura_no_gir.Value.ToString() + " Eklenen Cari No: " + cari_no_uretilmis.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Firma Adı aynı veya boş olmamalı.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                        goto a;

                    }


                }
                else
                {

                }

                for (int i = 0; i <= (satis_yap_listesi.RowCount - 1); i++)
                {
                    guncelle = "insert into satis(fatura_no,Urun_Kodu,Urun_Tur,Urun_ismi,Miktar,BR_Fiyati,Toplam,indirim,kdv,geneltoplam,Seri_nolar,`fatura_ust_bilgi`,`satis_tarih`) values (@f_a,@f_t,@y_i,@a_s1,@a_s2,@p_k,@t,@c_t,@f,@v,@v_2,@8,@9)";
                    guncel = new MySqlCommand(guncelle, mysqlbaglan);
                    guncel.Parameters.AddWithValue("@f_a", fatura_no_gir.Value.ToString());
                    guncel.Parameters.AddWithValue("@f_t", satis_yap_listesi.Rows[i].Cells[0].Value.ToString());
                    guncel.Parameters.AddWithValue("@y_i", satis_yap_listesi.Rows[i].Cells[1].Value.ToString());
                    guncel.Parameters.AddWithValue("@a_s1", satis_yap_listesi.Rows[i].Cells[2].Value.ToString());
                    guncel.Parameters.AddWithValue("@a_s2", satis_yap_listesi.Rows[i].Cells[3].Value.ToString());
                    guncel.Parameters.AddWithValue("@p_k", satis_yap_listesi.Rows[i].Cells[4].Value.ToString());
                    guncel.Parameters.AddWithValue("@t", satis_yap_listesi.Rows[i].Cells[5].Value.ToString());
                    guncel.Parameters.AddWithValue("@c_t", satis_yap_listesi.Rows[i].Cells[6].Value.ToString());
                    guncel.Parameters.AddWithValue("@f", satis_yap_listesi.Rows[i].Cells[7].Value.ToString());
                    guncel.Parameters.AddWithValue("@v", satis_yap_listesi.Rows[i].Cells[8].Value.ToString());
                    guncel.Parameters.AddWithValue("@v_2", satis_yap_listesi.Rows[i].Cells[9].Value.ToString());
                    if (ust_bilgi_fatura.Text == "Cari ID") { guncel.Parameters.AddWithValue("@8", cari_no_satis.Text.ToString()); }
                    else { guncel.Parameters.AddWithValue("@8", ust_bilgi_fatura.Text); }
                    guncel.Parameters.AddWithValue("@9", fatura_tarihi_gir.Text);
                    mysqlbaglan.Open();
                    guncel.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    if (satis_yap_listesi.Rows[i].Cells[10].Value.ToString() == "Evet")
                    {
                        ///Stokdan Düş
                        string guncelle8 = "";

                        guncelle8 = "insert into stok(urun_kodu,urun_ismi,degisen_stok,guncel_stok,urun_yer,stok_aciklamasi,satis_mi,fatura_no,stok_ekleyen_adi,stok_eklenen_tarih) values (@u_k,@u_b_m,@u_t,@u_i,@u_f,@u_s_d,@u_e_a,@neo,@u_e_t,@u_a)";
                        MySqlCommand guncel8 = new MySqlCommand(guncelle8, mysqlbaglan);
                        guncel8.Parameters.AddWithValue("@u_k", satis_yap_listesi.Rows[i].Cells[0].Value.ToString());
                        guncel8.Parameters.AddWithValue("@u_b_m", satis_yap_listesi.Rows[i].Cells[2].Value.ToString());
                        guncel8.Parameters.AddWithValue("@u_t", "-" + satis_yap_listesi.Rows[i].Cells[3].Value.ToString());
                        ///
                        int stok = 0;
                        string stok_bilgisi_cek_duserken = "select urun_stok_durumu from urunler where urun_kodu='" + satis_yap_listesi.Rows[i].Cells[0].Value.ToString() + "'";
                        MySqlCommand guncelle28 = new MySqlCommand(stok_bilgisi_cek_duserken, mysqlbaglan);
                        mysqlbaglan.Open();
                        MySqlDataReader stok_bilgisi_okuma = guncelle28.ExecuteReader();
                        if (stok_bilgisi_okuma.Read())
                        {
                            stok = Convert.ToInt32(stok_bilgisi_okuma["urun_stok_durumu"].ToString());
                        }
                        if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                        ////


                        stok = stok - Convert.ToInt32(satis_yap_listesi.Rows[i].Cells[3].Value.ToString());

                        guncel8.Parameters.AddWithValue("@u_i", (stok).ToString());
                        guncel8.Parameters.AddWithValue("@u_f", "");
                        guncel8.Parameters.AddWithValue("@u_s_d", "Stokdaki Ürün faturalandırılmış ve satılmıştır.");
                        guncel8.Parameters.AddWithValue("@u_e_a", "Evet");
                        guncel8.Parameters.AddWithValue("@neo", fatura_no_gir.Value.ToString());
                        guncel8.Parameters.AddWithValue("@u_e_t", ekleyen_adi);
                        guncel8.Parameters.AddWithValue("@u_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());


                        mysqlbaglan.Open();
                        guncel8.ExecuteNonQuery();
                        if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

                        guncelle8 = "update urunler set urun_stok_durumu ='" + (stok).ToString() + "' where urun_kodu ='" + satis_yap_listesi.Rows[i].Cells[0].Value.ToString() + "'";
                        guncel8 = new MySqlCommand(guncelle8, mysqlbaglan);
                        mysqlbaglan.Open();
                        guncel8.ExecuteNonQuery();
                        if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                        log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Stok Düşüldü", "Fatura Kesilirken Stok Düşüldü.. Fatura No: " + fatura_no_gir.Value.ToString() + " Düşülen Ürün Kodu: " + satis_yap_listesi.Rows[i].Cells[0].Value.ToString() + " Düşülen Adet: " + satis_yap_listesi.Rows[i].Cells[3].Value.ToString());


                        /////
                    }
                }
                ///Stokdan Düş


                /////


                /// guncelle2 = "INSERT INTO `fatura` (`cari_no`, `satis_urunler_no`, `toplam`, `kdv`, `genel_toplam`, `fatura_kesen`, `fatura_kesen_tarih`) VALUES ('"+ cari_no_satis.Text + "','"+toplam_cikis.Text+"','"+ kdv_cikis.Text + "','"+ geneltopla_cikis.Text + "','"+ ekleyen_adi + "','"+ DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString() + "')";
                guncelle2 = "INSERT INTO `fatura` (`fatura_no`, `cari_no`, `toplam`, `kdv`, `genel_toplam`, `fatura_kesen`, `fatura_kesen_tarih`,`fatura_ust_bilgi`,`fatura_aciklamasi`,`satis_tarih`,`Odeme_Tipi`) VALUES(@0_a, @1_a, @3_a, @4_a, @5_a, @6_a, @7_a, @8_a,@9_a,@10_a,@11_a)";

                guncel2 = new MySqlCommand(guncelle2, mysqlbaglan);
                guncel2.Parameters.AddWithValue("@0_a", fatura_no_gir.Value.ToString());
                guncel2.Parameters.AddWithValue("@1_a", cari_no_satis.Text);
                guncel2.Parameters.AddWithValue("@3_a", toplam_cikis.Text);
                guncel2.Parameters.AddWithValue("@4_a", kdv_cikis.Text);
                guncel2.Parameters.AddWithValue("@5_a", geneltopla_cikis.Text);
                guncel2.Parameters.AddWithValue("@6_a", ekleyen_adi);
                guncel2.Parameters.AddWithValue("@7_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                if (ust_bilgi_fatura.Text == "Cari ID") { guncel2.Parameters.AddWithValue("@8_a", cari_no_satis.Text.ToString()); }
                else { guncel2.Parameters.AddWithValue("@8_a", ust_bilgi_fatura.Text); }

                guncel2.Parameters.AddWithValue("@9_a", fatura_aciklamasi.Text);
                guncel2.Parameters.AddWithValue("10_a", fatura_tarihi_gir.Text);
                guncel2.Parameters.AddWithValue("11_a", odeme_yontemi);
                mysqlbaglan.Open();
                guncel2.ExecuteNonQuery();
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Kesildi", "Fatura Kesildi. Fatura No: " + fatura_no_gir.Value.ToString());



                guncelle3 = "INSERT INTO `cari_hesaplar` (`cari_no`, `islem_Tarihi`, `evrak_no`, `islem_turu`, `odeme_tipi`,`aciklama`,`tutar`, `odenen`, `islem_yapan_adi`,`eklendigi_tarih`) VALUES(@1_a, @3_a, @4_a, @5_a, @6_a, @6_b, @6_c, @6_d,@10_a,@11_a)";
                guncel3 = new MySqlCommand(guncelle3, mysqlbaglan);
                guncel3.Parameters.AddWithValue("@1_a", cari_no_satis.Text);
                DateTime lolo = Convert.ToDateTime(fatura_tarihi_gir.Text);
                guncel3.Parameters.AddWithValue("@3_a", lolo.ToString("yyyy-MM-dd HH:mm:ss"));
                guncel3.Parameters.AddWithValue("@4_a", fatura_no_gir.Value.ToString());
                guncel3.Parameters.AddWithValue("@5_a", "Satış");
                guncel3.Parameters.AddWithValue("@6_a", odeme_yontemi);
                guncel3.Parameters.AddWithValue("@6_b", "Cariye Satış yapıldı. Fatura No: " + fatura_no_gir.Value.ToString() + " - Ödeme Tipi: " + odeme_yontemi);
                guncel3.Parameters.AddWithValue("@6_c", geneltopla_cikis.Text);
                if (odeme_yontemi == "Açık Hesap") { guncel3.Parameters.AddWithValue("@6_d", "0"); } else { guncel3.Parameters.AddWithValue("@6_d", geneltopla_cikis.Text); }
                guncel3.Parameters.AddWithValue("@10_a", ekleyen_adi);
                guncel3.Parameters.AddWithValue("@11_a", DateTime.Today.ToShortDateString() + " | " + DateTime.Now.ToShortTimeString());
                mysqlbaglan.Open();
                guncel3.ExecuteNonQuery();
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Cari Hesap", "Satış Yapıldı. Fatura No: " + fatura_no_gir.Value.ToString());



                MessageBox.Show("Fatura başarıyla oluşturuldu.");

                if (checkBox2.Checked == true)
                {
                    try {
                        string mizer_urun_raport_saati = "Fatura No " + fatura_no_gir.Value.ToString() + " --- Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
                        ReportDocument rd;
                        rd = new ReportDocument();
                        rd.Load(Application.StartupPath + @"\fatura_goster.rpt");
                        rd.SetParameterValue("cari_no", Convert.ToInt32(cari_no_satis.Text));
                        rd.SetParameterValue("fatura_no", Convert.ToInt32(fatura_no_gir.Value.ToString()));
                        string yaziya = yaziyaCevir(Convert.ToDecimal(geneltopla_cikis.Text));
                        rd.SetParameterValue("alt_text", yaziya);


                        rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                        System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                    }
                    catch
                    { MessageBox.Show("Fatura Görüntülenirken hata oluştu.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                }

                komple_temizle();
                retrieve();
                cariye_ait_fatura_retrieve_yap();
                urun_listesini_retrieve_yap();
                stok_listesini_retrieve_yap();
                tum_fatura_retrieve();
                fatura_no_ekle_bir();
            a:;
            }
            catch (Exception ex)
            { if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); } MessageBox.Show(ex.ToString()); MessageBox.Show("Hata Birşeyler TERS GİTTİ !! İnternet bağlantısı olmayabilir.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cari_listesi_SelectionChanged(object sender, EventArgs e)
        {
            cariye_ait_fatura_retrieve_yap();
            try
            {
                cari_no_copy.Text = cari_listesi.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {

            }

        }

        private void yenile_Click(object sender, EventArgs e)
        {
            urun_listesini_retrieve_yap();
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            retrieve();
            cariye_ait_fatura_retrieve_yap();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            try
            {
                string mizer_urun_raport_saati = "Fatura No " + cariye_ait_fatura_listesi.SelectedRows[0].Cells[1].Value.ToString() + " --- Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
                ReportDocument rd;
                rd = new ReportDocument();
                rd.Load(Application.StartupPath + @"\fatura_goster.rpt");
                rd.SetParameterValue("cari_no", Convert.ToInt32(cari_no_copy.Text));
                rd.SetParameterValue("fatura_no", Convert.ToInt32(cariye_ait_fatura_listesi.SelectedRows[0].Cells[1].Value.ToString()));
                string yaziya = yaziyaCevir(Convert.ToDecimal(cariye_ait_fatura_listesi.SelectedRows[0].Cells[5].Value.ToString()));
                rd.SetParameterValue("alt_text", yaziya);


                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Görüntüleme", "Görüntülenen Fatura_No: " + cariye_ait_fatura_listesi.SelectedRows[0].Cells[1].Value);

                komple_temizle();
                /*
               komple_temizle();
               string komutsatiri = "SELECT * FROM satis where satis_urunler_no='" + cariye_ait_fatura_listesi.SelectedRows[0].Cells[2].Value + "'";
               MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
               mysqlbaglan.Open();
               MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();
               while (okuyucum.Read())
               {

                   satis_yap_listesi.Rows.Add(okuyucum["Urun_Kodu"].ToString(), okuyucum["Urun_Tur"].ToString(), okuyucum["Urun_ismi"].ToString(), okuyucum["Miktar"].ToString(), okuyucum["BR_Fiyati"].ToString(), okuyucum["Toplam"].ToString(), okuyucum["indirim"].ToString(), okuyucum["kdv"].ToString(), okuyucum["geneltoplam"].ToString(), okuyucum["Seri_nolar"].ToString());
                   ust_bilgi_fatura.Text = okuyucum["fatura_ust_bilgi"].ToString();
                   fatura_tarihi_gir.Text = okuyucum["satis_tarih"].ToString();

               }
               ust_bilgi_fatura.Text = okuyucum["fatura_ust_bilgi"].ToString();
               if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
               fiyatlari_satistan_guncelleme_vakti();
               komutsatiri = "SELECT * FROM cariler where cari_no=" + cariye_ait_fatura_listesi.SelectedRows[0].Cells[1].Value + "";
               cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
               mysqlbaglan.Open();
               MySqlDataReader okuyucum2 = cmd_combobox_doldur.ExecuteReader();
               if (okuyucum2.Read())
               {
                   cari_no_satis.Text = okuyucum2["cari_no"].ToString();
                   cari_adi_satis.Text = okuyucum2["firma_adi"].ToString();
                   cari_tipi_satis.Text = okuyucum2["firma_tipi"].ToString();
                   cari_adres1_satis.Text = okuyucum2["adres_satiri_1"].ToString();
                   cari_adres2_satis.Text = okuyucum2["adres_satiri_2"].ToString();
                   cari_vdno_satis.Text = okuyucum2["vergidairesi_2"].ToString();
                   cari_vd_satis.Text = okuyucum2["vergidairesi"].ToString();
               }

               if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
               fiyatlari_satistan_guncelleme_vakti();





               string seri_nolar = "";
               string workbookPath = "" + Application.StartupPath.ToString() + @"\excel_ana\kemik.xlsx";
               Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
               Excel.Sheets excelSheets = excelWorkbook.Worksheets;
               Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item("Sheet1");
               Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range("A1", "G53");
               excelWorksheet.Cells[12, 2] = cari_adi_satis.Text;

               excelWorksheet.Cells[5, 7] = fatura_tarihi_gir.Text;
               excelWorksheet.Cells[13, 2] = cari_adres1_satis.Text;
               excelWorksheet.Cells[15, 2] = cari_adres2_satis.Text;
               int k = 0;
               for (int i = 0; i <= (satis_yap_listesi.RowCount - 1); i++)
               {


                   seri_nolar = satis_yap_listesi.Rows[i].Cells[9].Value.ToString();
                   List<string> seri_no_tek = seri_nolar.Split('|').ToList();
                   excelWorksheet.Cells[27 + k, 2].Value = satis_yap_listesi.Rows[i].Cells[1].Value.ToString();
                   excelWorksheet.Cells[27 + k, 5].Value = satis_yap_listesi.Rows[i].Cells[3].Value.ToString();
                   excelWorksheet.Cells[27 + k, 6].Value = satis_yap_listesi.Rows[i].Cells[4].Value.ToString() + " TL";
                   excelWorksheet.Cells[27 + k, 7].Value = satis_yap_listesi.Rows[i].Cells[5].Value.ToString() + " TL";
                   excelWorksheet.Cells[27 + k, 2].Font.Bold = true;
                   excelWorksheet.Cells[27 + k, 5].Font.Bold = true;
                   excelWorksheet.Cells[27 + k, 6].Font.Bold = true;
                   excelWorksheet.Cells[27 + k, 7].Font.Bold = true;
                   seri_no_tek.RemoveAt(0);
                   foreach (string seriler in seri_no_tek)
                   {
                       excelWorksheet.Cells[27 + k + 1, 2].Value = seriler;
                       excelWorksheet.Cells[27 + k + 1, 2].Font.Bold = false;
                       k = k + 1;
                   }


                   k = k + 1;
                   //// 27 yazdın  | 28 yazdın ---- 29yazdın ---- 30 yazdın ---- 31 yazdın
               }

               excelWorksheet.Cells[18, 5] = cari_vd_satis.Text + " / " + cari_vdno_satis.Text;
               excelWorksheet.Cells[44, 7] = toplam_cikis.Text + " TL";
               excelWorksheet.Cells[46, 7] = kdv_cikis.Text + " TL";
               excelWorksheet.Cells[48, 7] = geneltopla_cikis.Text + " TL";
               excelWorksheet.Cells[52, 5] = "YALNIZ " + yaziyaCevir(Convert.ToDecimal(geneltopla_cikis.Text));
               excelWorksheet.Cells[13, 6] = ust_bilgi_fatura.Text;

               string workbookPath2 = "" + Application.StartupPath.ToString() + @"\excel_ana\onizleme.xlsx";
               excelApp.DisplayAlerts = false;

               excelWorkbook.SaveAs(workbookPath2, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
               Workbook workbook = new Workbook();
               excelWorkbook.Close();
               workbook.LoadFromFile(workbookPath2);

               //If you want to make the excel content fit to pdf page
               //workbook.ConverterSetting.SheetFitToPage = true;
               workbookPath2 = "" + Application.StartupPath.ToString() + @"\excel_ana\onizleme.pdf";
               workbook.SaveToFile(workbookPath2, Spire.Xls.FileFormat.PDF);
               System.Diagnostics.Process.Start(workbookPath2);
               log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Görüntüleme", "Görüntülenen Satış_Fatura_No: " + cariye_ait_fatura_listesi.SelectedRows[0].Cells[2].Value);
               komple_temizle();
               */
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                MessageBox.Show("Seçtiğiniz işleme dahil fatura bulunamadı.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private string cari_FNO_CNO(string f_no)
        {

            string wolf = "SELECT cari_no FROM `fatura` WHERE `fatura_no`=" + f_no;
            MySqlCommand wolfcmd = new MySqlCommand(wolf, mysqlbaglan);
            mysqlbaglan.Open();
            MySqlDataReader dr = wolfcmd.ExecuteReader();
            if (dr.Read())
            {
                f_no = dr.GetString("cari_no").ToString();
            }
            if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            return f_no;




        }
        private void fatura_goster_Click(object sender, EventArgs e)
        {
            try
            {
                string cari_no_getir = cari_FNO_CNO(tum_faturalar_listesi.SelectedRows[0].Cells[0].Value.ToString());
                string mizer_urun_raport_saati = "Fatura No " + tum_faturalar_listesi.SelectedRows[0].Cells[0].Value.ToString() + " --- Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
                ReportDocument rd;
                rd = new ReportDocument();
                rd.Load(Application.StartupPath + @"\fatura_goster.rpt");
                rd.SetParameterValue("cari_no", Convert.ToInt32(cari_no_getir));
                rd.SetParameterValue("fatura_no", Convert.ToInt32(tum_faturalar_listesi.SelectedRows[0].Cells[0].Value.ToString()));
                string yaziya = yaziyaCevir(Convert.ToDecimal(tum_faturalar_listesi.SelectedRows[0].Cells[4].Value.ToString()));
                rd.SetParameterValue("alt_text", yaziya);


                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Görüntüleme", "Görüntülenen Fatura_No: " + tum_faturalar_listesi.SelectedRows[0].Cells[0].Value);

                komple_temizle();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); MessageBox.Show("Hata ! Bağlantı sağlanamadı.. -4", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); } }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tum_fatura_retrieve();
        }
        DataTable faturaarama = new DataTable("faturalar");
        private void faturaara_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;

            if (!double.TryParse(fatura_ara.Text, out parsedValue))
            {



                if (fatura_ara.Text == "")
                {
                    tum_fatura_retrieve();
                }
                else
                {
                    tum_faturalar_listesi.Columns.Clear();
                    DataView dv2 = dt_tum.DefaultView;
                    try
                    {
                        dt_tum.Columns["fatura_no"].ColumnName = "Fatura No";
                        dt_tum.Columns["firma_adi"].ColumnName = "Cari Adı";
                        dt_tum.Columns["toplam"].ColumnName = "Toplam";
                        dt_tum.Columns["kdv"].ColumnName = "KDV";
                        dt_tum.Columns["genel_toplam"].ColumnName = "Genel Toplam";
                        dt_tum.Columns["Odeme_Tipi"].ColumnName = "Ödeme Tipi";
                        dt_tum.Columns["satis_tarih"].ColumnName = "Satış Tarihi";
                        dt_tum.Columns["fatura_ust_bilgi"].ColumnName = "Fatura Üst Bilgisi";
                        dt_tum.Columns["fatura_aciklamasi"].ColumnName = "Fatura Açıklaması";
                        dt_tum.Columns["fatura_kesen"].ColumnName = "Faturalandıran";
                        dt_tum.Columns["fatura_kesen_tarih"].ColumnName = "Fatura Oluşturulma Tarihi";

                    }
                    catch
                    { }
                    try
                    {
                        ///   dv2.RowFilter = string.Format("where cari_no= {0} or fatura_kesen_tarih like '%{0}%' or fatura_aciklamasi like '%{0}%' or fatura_ust_bilgi like '%{0}%'", fatura_ara.Text);
                        ///   dv2.RowFilter = string.Format("`Fatura Üst Bilgisi` like '%{0}%'", fatura_ara.Text);
                        dv2.RowFilter = string.Format(" `Fatura Açıklaması` like '%{0}%' or `Cari Adı` like '%{0}%' or `Ödeme Tipi` like '%{0}%' or `Satış Tarihi` like '%{0}%' or `Fatura Oluşturulma Tarihi` like '%{0}%' or `Faturalandıran` like '%{0}%' or `Fatura Üst Bilgisi` like '%{0}%'", fatura_ara.Text);
                        tum_faturalar_listesi.DataSource = dv2.ToTable();

                    }
                    catch
                    { }
                }
            }
            else
            {

                if (fatura_ara.Text == "")
                {
                    tum_fatura_retrieve();
                }
                else
                {
                    tum_faturalar_listesi.Columns.Clear();
                    DataView dv2 = dt_tum.DefaultView;
                    try
                    {
                        dt_tum.Columns["fatura_no"].ColumnName = "Fatura No";
                        dt_tum.Columns["firma_adi"].ColumnName = "Cari Adı";
                        dt_tum.Columns["toplam"].ColumnName = "Toplam";
                        dt_tum.Columns["kdv"].ColumnName = "KDV";
                        dt_tum.Columns["genel_toplam"].ColumnName = "Genel Toplam";
                        dt_tum.Columns["Odeme_Tipi"].ColumnName = "Ödeme Tipi";
                        dt_tum.Columns["satis_tarih"].ColumnName = "Satış Tarihi";
                        dt_tum.Columns["fatura_ust_bilgi"].ColumnName = "Fatura Üst Bilgisi";
                        dt_tum.Columns["fatura_aciklamasi"].ColumnName = "Fatura Açıklaması";
                        dt_tum.Columns["fatura_kesen"].ColumnName = "Faturalandıran";
                        dt_tum.Columns["fatura_kesen_tarih"].ColumnName = "Fatura Oluşturulma Tarihi";

                    }
                    catch
                    {

                    }
                    try
                    {
                        ///   dv2.RowFilter = string.Format("where cari_no= {0} or fatura_kesen_tarih like '%{0}%' or fatura_aciklamasi like '%{0}%' or fatura_ust_bilgi like '%{0}%'", fatura_ara.Text);
                        ///   dv2.RowFilter = string.Format("`Fatura Üst Bilgisi` like '%{0}%'", fatura_ara.Text);
                        dv2.RowFilter = string.Format("`Fatura No`='{0}' ", fatura_ara.Text);
                        tum_faturalar_listesi.DataSource = dv2.ToTable();

                    }
                    catch
                    { }
                }

            }

        }

        private void fatura_silme_eylemine_giristen_5yil()
        {
            if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            try
            {
                if (MessageBox.Show(tum_faturalar_listesi.SelectedRows[0].Cells[0].Value + " No'lu Faturayı silmek istediğine emin misin ??", "Silmek için emin misin? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from fatura where fatura_no='" + tum_faturalar_listesi.SelectedRows[0].Cells[0].Value + "'";

                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

                    sql_urun_sil = "delete from satis where fatura_no='" + tum_faturalar_listesi.SelectedRows[0].Cells[0].Value + "'";
                    mysqlbaglan.Open();


                    silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }


                    sql_urun_sil = "delete from cari_hesaplar where evrak_no='" + tum_faturalar_listesi.SelectedRows[0].Cells[0].Value + "' and islem_turu='Satış'";
                    mysqlbaglan.Open();


                    silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Silindi", "Silinen Fatura No: " + tum_faturalar_listesi.SelectedRows[0].Cells[0].Value);

                    fatura_tarihi_gir.Text = "";
                    textBox1.Text = "";
                    retrieve();
                    cariye_ait_fatura_retrieve_yap();
                    tum_fatura_retrieve();
                    tum_faturalar_listesi.Refresh();
                    MessageBox.Show("Fatura Silinmiştir.", "Bilginiz olsun - Mizer");

                }
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

            }
        }
        private void fatura_silme_eylemine_giristen_10yil(string evrak_no_silerken)
        {
            if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            try
            {
                if (MessageBox.Show(evrak_no_silerken + " No'lu Faturayı silmek istediğine emin misin ??", "Silmek için emin misin? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from fatura where fatura_no='" + evrak_no_silerken + "'";

                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

                    sql_urun_sil = "delete from satis where fatura_no='" + evrak_no_silerken + "'";
                    mysqlbaglan.Open();


                    silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }


                    sql_urun_sil = "delete from cari_hesaplar where evrak_no='" + evrak_no_silerken + "' and islem_turu='Satış'";
                    mysqlbaglan.Open();


                    silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Silindi", "Silinen Fatura No: " + evrak_no_silerken);

                    fatura_tarihi_gir.Text = "";
                    textBox1.Text = "";

                    MessageBox.Show("Fatura Silinmiştir.", "Bilginiz olsun - Mizer");

                }
            }
            catch (Exception ex)
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                MessageBox.Show(ex.ToString());
            }
        }




        private void fatura_sil_Click(object sender, EventArgs e)
        {



            try
            {
                pg_ayar_ck();
                felek_donsunmu();
                if (f_sil == false)
                {
                    string super_sifre_giris = Prompt.ShowDialog("Lütfen Faturayı Silmek için Süper Şifreyi giriniz...", "LMR - Cari - Mizer");
                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                    {
                        ///
                        fatura_silme_eylemine_giristen_5yil();
                        ///
                    }
                    else
                    {
                        MessageBox.Show("Süper Şifre yanlış. Faturayı Silemediniz.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (f_sil == true)
                {
                    ///
                    fatura_silme_eylemine_giristen_5yil();
                    ///
                }
                else
                {

                    MessageBox.Show("Bağlantı Sağlanamadı.. -1", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            try
            {
                string yedek_tarihi = DateTime.Today.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString().Replace(":", ".");
                fatura_ara.Text = "";
                tum_fatura_retrieve();
                for (int sayac = 0; sayac <= (tum_faturalar_listesi.RowCount - 1); sayac++)
                {

                    try
                    {
                        string cari_no_getir = cari_FNO_CNO(tum_faturalar_listesi.SelectedRows[0].Cells[0].Value.ToString());
                        string mizer_urun_raport_saati = "Fatura No " + tum_faturalar_listesi.Rows[sayac].Cells[0].Value.ToString() + " --- Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
                        ReportDocument rd;
                        rd = new ReportDocument();
                        rd.Load(Application.StartupPath + @"\fatura_goster.rpt");
                        rd.SetParameterValue("cari_no", Convert.ToInt32(cari_no_getir));
                        rd.SetParameterValue("fatura_no", Convert.ToInt32(tum_faturalar_listesi.Rows[sayac].Cells[0].Value.ToString()));
                        string yaziya = yaziyaCevir(Convert.ToDecimal(tum_faturalar_listesi.Rows[sayac].Cells[4].Value.ToString()));
                        rd.SetParameterValue("alt_text", yaziya);


                        rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Faturalar\" + mizer_urun_raport_saati);

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); MessageBox.Show("Hata ! Bağlantı sağlanamadı.. -4", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error); if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); } }
                }
                log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Fatura Yedekleme", "Tüm Faturalar Yedeklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string komutsatiri = "SELECT * FROM cariler where cari_no=" + cari_listesi.SelectedRows[0].Cells[0].Value + "";
                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum2 = cmd_combobox_doldur.ExecuteReader();
                if (okuyucum2.Read())
                {
                    cari_no_satis.Text = okuyucum2["cari_no"].ToString();
                    cari_adi_satis.Text = okuyucum2["firma_adi"].ToString();
                    cari_tipi_satis.Text = okuyucum2["firma_tipi"].ToString();
                    cari_adres1_satis.Text = okuyucum2["adres_satiri_1"].ToString();
                    cari_adres2_satis.Text = okuyucum2["adres_satiri_2"].ToString();
                    cari_vdno_satis.Text = okuyucum2["vergidairesi_2"].ToString();
                    cari_vd_satis.Text = okuyucum2["vergidairesi"].ToString();
                }

                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                tabControl1.SelectedIndex = 2;
            }
            catch
            {

            }
        }

        private void programKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Çıkış Yapıldı", "Çıkış Yapıldı");
            Environment.Exit(1);

        }
        hakkinda hakkindaac = new hakkinda();
        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkindaac.Show();
            hakkindaac.Visible = false;
            hakkindaac.ShowDialog();
        }
        public string cikisa_don_mizer;
        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Çıkış Yapıldı", "Çıkış Yapıldı");
            cikisa_don_mizer = "Evet";
            DialogResult = DialogResult.OK;

        }


        private void cari_islemler_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Ana Menüye Dönüldü", "Ana Menüye Dönüldü");
            DialogResult = DialogResult.OK;
        }
        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            /*this.Hide();
            anadonus = new anamenu();
            anadonus.gercek_yetki = gercek_yetki;
            anadonus.ekleyen_ismi_cek = ekleyen_adi;
            anadonus.mysqlbaglan = mysqlbaglan;
            anadonus.adminadi = kadi_getir;
            anadonus.ShowDialog();
            */

        }
        void form_ana_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void cari_tipi_satis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cari_tipi_satis.SelectedIndex == 2)
            {
                label54.Visible = false;
                cari_vd_satis.Visible = false;
                label55.Text = "T.C No:";
            }
            else
            {
                label54.Visible = true;
                cari_vd_satis.Visible = true;
                label55.Text = "V.D No:";
            }
        }



        ///  Ürün Raporu


        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                using (secim_raportlama_Mizer_Sirtuex asd = new secim_raportlama_Mizer_Sirtuex())
                {
                    asd.nereden_geldin_hocam_gulucuk = "Ürünler";
                    asd.ekleyen_adi = ekleyen_adi;
                    asd.adminadi = kadi_getir;
                    asd.mysqlbaglan = mysqlbaglan;
                    asd.ShowDialog();
                }

            }
            catch
            {

            }


        }

        private void cari_listesi_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip2.Show(this.cari_listesi, e.Location);
                this.contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button18_Click_1(null, null);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void tarih_yenile_Click(object sender, EventArgs e)
        {
            fatura_tarihi_gir.Value = DateTime.Now;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 2)
            {
                tarih_yenile_Click(null, null);
            }
            if (tabControl1.SelectedIndex == 4)
            {
                button31_Click(null, null);
            }
        }

        private void fatura_no_gir_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            using (odeme_al_Mizer lol = new odeme_al_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            using (odeme_yap_Mizer lol = new odeme_yap_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            using (borclandir_Mizer lol = new borclandir_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            using (borclan_Mizer lol = new borclan_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
            }
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void carininFaturalarınıRaporlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cari_raporu_uret();
        }
        private void cari_raporu_uret()
        {
            try
            {
                string mizer_urun_raport_saati = "Cari_Raporu Cari No " + cari_listesi.SelectedRows[0].Cells[0].Value.ToString() + " Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
                ReportDocument rd;
                rd = new ReportDocument();
                rd.Load(Application.StartupPath + @"\cariyeait.rpt");
                rd.SetParameterValue("carino", Convert.ToUInt32(cari_listesi.SelectedRows[0].Cells[0].Value.ToString()));

                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            cari_raporu_uret();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cariyeSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(null, null);
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button22_Click(null, null);
        }

        private void borçlandırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button24_Click(null, null);
        }

        private void ödemeYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button23_Click(null, null);
        }

        private void borçlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button25_Click(null, null);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            kasa_verileri_retrieve_yap();
            kasa_toplam_hesapla();
        }

        private void kasa_toplam_hesapla()
        {
            double giris = 0;
            double cikis = 0;
            for (int i = 0; i < kasa_listesi.Rows.Count - 1; i++)
            {
                if (kasa_listesi.Rows[i].Cells[2].Value.ToString() == "Giriş +")
                {
                    giris = giris + Convert.ToDouble(kasa_listesi.Rows[i].Cells[3].Value);
                }
                else if (kasa_listesi.Rows[i].Cells[2].Value.ToString() == "Çıkış -")
                {
                    cikis = cikis + Convert.ToDouble(kasa_listesi.Rows[i].Cells[3].Value);
                }
                t_para_girisi.Text = giris.ToString("N2") + " ₺";

                t_para_cikisi.Text = cikis.ToString("N2") + " ₺";

                t_para.Text = (giris - cikis).ToString("N2") + " ₺";

            }
        }

        /// /// kasa
        private void kasa_cogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2)
        {
            switch (marka)
            {
                case "Satış":
                    marka = "Giriş +";
                    break;
                case "KASA GİRİŞİ":
                    marka = "Giriş +";
                    break;
                case "KASA ÇIKIŞI":
                    marka = "Çıkış -";
                    break;
                case "Ödeme Alındı.":
                    marka = "Giriş +";
                    break;
                case "Ödeme Yapıldı.":
                    marka = "Çıkış -";
                    break;
                case "Cariye Borçlanıldı.":
                    return;

                case "Cari Borçlandırıldı.":
                    return;


            }
            kasa_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2);


        }

        string sql99 = "";
        MySqlCommand dg_cmd99;
        MySqlDataAdapter adapter99;
        DataTable dt99 = new DataTable();
        private void kasa_verileri_retrieve_yap()
        {

            kasa_ayarlar_loading();
            kasa_listesi.Rows.Clear();

            kasa_listesi.Refresh();
            try
            {
                /// tarih ayarları innerdan önce oalcak.
                DateTime lolo1 = Convert.ToDateTime(ilk_tarih_kasa.Text);
                DateTime lolo2 = Convert.ToDateTime(son_tarih_kasa.Text).AddDays(1);

                sql99 = "(Select cari_hesaplar.islem_no, cari_hesaplar.islem_tarihi,cari_hesaplar.islem_turu,cari_hesaplar.odenen,cari_hesaplar.evrak_no,cari_hesaplar.aciklama,cariler.firma_adi FROM cari_hesaplar INNER JOIN cariler ON cari_hesaplar.cari_no = cariler.cari_no  where cari_hesaplar.islem_tarihi BETWEEN ' " + lolo1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + lolo2.ToString("yyyy-MM-dd HH:mm:ss") + "') UNION (Select cari_hesaplar.islem_no, cari_hesaplar.islem_tarihi,cari_hesaplar.islem_turu,cari_hesaplar.odenen,cari_hesaplar.evrak_no,cari_hesaplar.aciklama,null FROM cari_hesaplar where cari_hesaplar.cari_no=0 and cari_hesaplar.islem_tarihi BETWEEN ' " + lolo1.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + lolo2.ToString("yyyy-MM-dd HH:mm:ss") + "') ";



                dg_cmd99 = new MySqlCommand(sql99, mysqlbaglan);


                try
                {
                    mysqlbaglan.Open();

                    adapter99 = new MySqlDataAdapter(dg_cmd99);

                    dt99 = new DataTable();
                    adapter99.Fill(dt99);

                    foreach (DataRow row in dt99.Rows)
                    {
                        kasa_cogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                    }





                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }




                    //// dt3.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                }
                islem_kasa_toplam.Text = kasa_listesi.RowCount.ToString();
                if (islem_kasa_toplam.Text == "0")
                {
                    button19.Enabled = false;
                }
                else
                {
                    button19.Enabled = true;
                }
                this.kasa_listesi.Sort(this.kasa_listesi.Columns[0], ListSortDirection.Descending);
                kasa_verileri_cek();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            kasa_listesi.Columns[0].Visible = false;

        }










        private void kasa_verileri_cek()
        {

        }

        private void kasa_ayarlar_loading()
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;

            kasa_listesi.DataSource = null;

            kasa_listesi.ColumnCount = 7;
            try
            {
                kasa_listesi.Columns[0].Name = "İşlem No";
                kasa_listesi.Columns[1].Name = "Tarih";
                kasa_listesi.Columns[2].Name = "Tip";
                kasa_listesi.Columns[3].Name = "Tutar";
                kasa_listesi.Columns[4].Name = "Evrak No";
                kasa_listesi.Columns[5].Name = "Açıklama";
                kasa_listesi.Columns[6].Name = "Cari Adı";

                kasa_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                kasa_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < kasa_listesi.Columns.Count - 1; i++)
            {
                kasa_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            kasa_listesi.Columns[kasa_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < kasa_listesi.Columns.Count; i++)
            {
                int colw = kasa_listesi.Columns[i].Width;
                kasa_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                kasa_listesi.Columns[i].Width = colw;
            }

            kasa_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            kasa_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            kasa_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            kasa_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            kasa_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            kasa_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            kasa_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void button29_Click(object sender, EventArgs e)
        {

            using (kasa_giris_mizer lol = new kasa_giris_mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
                button31_Click(null, null);
            }

        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (kasa_cikis_Mizer lol = new kasa_cikis_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
                button31_Click(null, null);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {

            try
            {
                string fatura_no_cek = kasa_listesi.SelectedRows[0].Cells[4].Value.ToString();
                if (MessageBox.Show(kasa_listesi.SelectedRows[0].Cells[1].Value.ToString() + " Tarihindeki " + kasa_listesi.SelectedRows[0].Cells[2].Value.ToString() + " işlemini silmek istediğine emin misin? ", "Silmek için emin misin?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from cari_hesaplar where islem_no='" + kasa_listesi.SelectedRows[0].Cells[0].Value + "'";
                    textBox1.Text = "";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler", "Kasa " + kasa_listesi.SelectedRows[0].Cells[2].Value.ToString() + " İşlemi Silindi.", "Silinen İşlem No: " + kasa_listesi.SelectedRows[0].Cells[0].Value + " Evrak No: " + kasa_listesi.SelectedRows[0].Cells[3].Value.ToString() + "");
                    button31_Click(null, null);
                    if (MessageBox.Show("Kasa İşlemi Silindi İşleme ait varsa faturayı silmek ister misiniz?", "Silmek için emin misin?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        try
                        {
                            pg_ayar_ck();
                            felek_donsunmu();
                            if (f_sil == false)
                            {
                                string super_sifre_giris = Prompt.ShowDialog("Lütfen Faturayı Silmek için Süper Şifreyi giriniz...", "LMR - Cari - Mizer");
                                if (felek_donuyorr_agaaaa == super_sifre_giris)
                                {
                                    ///
                                    fatura_silme_eylemine_giristen_10yil(fatura_no_cek);
                                    ///
                                }
                                else
                                {
                                    MessageBox.Show("Süper Şifre yanlış. Faturayı Silemediniz.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (f_sil == true)
                            {
                                ///
                                fatura_silme_eylemine_giristen_10yil(fatura_no_cek);
                                ///
                            }
                            else
                            {

                                MessageBox.Show("Bağlantı Sağlanamadı.. -1", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                        }

                    }
                    button31_Click(null, null);
                    retrieve();
                    tum_fatura_retrieve();
                }


            }
            catch
            {
                MessageBox.Show("Birşeyler ters sende biliyorsun bunu mesela internet bağlantısı olmayabilir.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button31_Click(null, null);

        }

        private void button30_Click(object sender, EventArgs e)
        {
            using (kasa_duzenle_Mizer lol = new kasa_duzenle_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.norm_royal = kasa_listesi.SelectedRows[0].Cells[0].Value.ToString();
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
                button31_Click(null, null);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            using (kasa_duzenle_Mizer lol = new kasa_duzenle_Mizer())
            {
                lol.mysqlbaglan = mysqlbaglan;
                lol.kadi_getir = kadi_getir;
                lol.cari_no = cari_no_copy.Text;
                lol.norm_royal = cariye_ait_fatura_listesi.SelectedRows[0].Cells[0].Value.ToString();
                lol.ekleyen_adi = ekleyen_adi;
                lol.ShowDialog();
                cariye_ait_fatura_retrieve_yap();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {

            try
            {
                string fatura_no_cek = cariye_ait_fatura_listesi.SelectedRows[0].Cells[2].Value.ToString();
                if (MessageBox.Show(cariye_ait_fatura_listesi.SelectedRows[0].Cells[1].Value.ToString() + " Tarihindeki " + cariye_ait_fatura_listesi.SelectedRows[0].Cells[3].Value.ToString() + " işlemini silmek istediğine emin misin? ", "Silmek için emin misin?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from cari_hesaplar where islem_no='" + cariye_ait_fatura_listesi.SelectedRows[0].Cells[0].Value + "'";
                    textBox1.Text = "";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                    log_gonder(kadi_getir, ekleyen_adi, "Cari İşlemler ", cari_listesi.SelectedRows[0].Cells[0].Value.ToString() + " nolu Carinin hesabından " + tum_faturalar_listesi.SelectedRows[0].Cells[3].Value.ToString() + " İşlemi Silindi.", "Silinen İşlem No: " + cariye_ait_fatura_listesi.SelectedRows[0].Cells[0].Value + " Evrak No: " + cariye_ait_fatura_listesi.SelectedRows[0].Cells[2].Value.ToString() + "");
                    if (cariye_ait_fatura_listesi.SelectedRows[0].Cells[2].Value.ToString() == "Satış")
                    {
                        if (MessageBox.Show("Kasa İşlemi Silindi İşleme ait varsa faturayı silmek ister misiniz?", "Silmek için emin misin?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            try
                            {
                                pg_ayar_ck();
                                felek_donsunmu();
                                if (f_sil == false)
                                {
                                    string super_sifre_giris = Prompt.ShowDialog("Lütfen Faturayı Silmek için Süper Şifreyi giriniz...", "LMR - Cari - Mizer");
                                    if (felek_donuyorr_agaaaa == super_sifre_giris)
                                    {
                                        ///
                                        fatura_silme_eylemine_giristen_10yil(fatura_no_cek);
                                        ///
                                    }
                                    else
                                    {
                                        MessageBox.Show("Süper Şifre yanlış. Faturayı Silemediniz.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else if (f_sil == true)
                                {
                                    ///
                                    fatura_silme_eylemine_giristen_10yil(fatura_no_cek);
                                    ///
                                }
                                else
                                {

                                    MessageBox.Show("Bağlantı Sağlanamadı.. -1", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch
                            {
                                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
                            }

                        }
                        cariye_ait_fatura_retrieve_yap();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Birşeyler ters sende biliyorsun bunu mesela internet bağlantısı olmayabilir.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cariye_ait_fatura_retrieve_yap();
        }
        DataTable kasaarama = new DataTable("cari_Hesaplar");

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                button31_Click(null, null);
                return;
            }
            kasa_listesi.Columns.Clear();
            DataView dv = dt99.DefaultView;
            try
            {
                dt99.Columns["islem_no"].ColumnName = "İşlem No";
                dt99.Columns["islem_tarihi"].ColumnName = "Tarih";
                dt99.Columns["islem_turu"].ColumnName = "Tip";
                dt99.Columns["odenen"].ColumnName = "Tutar";
                dt99.Columns["evrak_no"].ColumnName = "Evrak No";
                dt99.Columns["aciklama"].ColumnName = "Açıklama";
                dt99.Columns["firma_adi"].ColumnName = "Cari Adı";

                for (int i = 0; i < dt99.Rows.Count; i++)
                {
                    var marka = dt99.Rows[i][2];

                    switch (marka)
                    {
                        case "Satış":
                            marka = "Giriş +";
                            dt99.Rows[i][2] = marka;
                            break;
                        case "KASA GİRİŞİ":
                            marka = "Giriş +";
                            dt99.Rows[i][2] = marka;
                            break;
                        case "KASA ÇIKIŞI":
                            marka = "Çıkış -";
                            dt99.Rows[i][2] = marka;
                            break;
                        case "Ödeme Alındı.":
                            marka = "Giriş +";
                            dt99.Rows[i][2] = marka;
                            break;
                        case "Ödeme Yapıldı.":
                            marka = "Çıkış -";
                            dt99.Rows[i][2] = marka;
                            break;
                        case "Cariye Borçlanıldı.":
                            dt99.Rows[i].Delete();
                            break;

                        case "Cari Borçlandırıldı.":
                            dt99.Rows[i].Delete();
                            break;


                    }

                }
            }
            catch
            {

            }
            try
            {
                dv.RowFilter = string.Format("`Cari Adı` like '%{0}%' or `Açıklama` like '%{0}%' or `Evrak No` like '%{0}%' or `Tip` like '%{0}%'", textBox2.Text); /// Tip like '%{0}%' or A
                kasa_listesi.DataSource = dv.ToTable();
                kasa_listesi.Columns[0].Visible = false;
                kasa_listesi.Refresh();

            }
            catch
            {

            }


        }
        private void orasmus()
        {
            for (int i = 0; i < kasa_listesi.RowCount - 1; i++)
            {
                string marka = kasa_listesi.Rows[i].Cells[2].Value.ToString();

                switch (marka)
                {
                    case "Satış":
                        marka = "Giriş +";
                        kasa_listesi.Rows[i].Cells[2].Value = marka;
                        break;
                    case "KASA GİRİŞİ":
                        marka = "Giriş +";
                        kasa_listesi.Rows[i].Cells[2].Value = marka;
                        break;
                    case "KASA ÇIKIŞI":
                        marka = "Çıkış -";
                        kasa_listesi.Rows[i].Cells[2].Value = marka;
                        break;
                    case "Ödeme Alındı.":
                        marka = "Giriş +";
                        kasa_listesi.Rows[i].Cells[2].Value = marka;
                        break;
                    case "Ödeme Yapıldı.":
                        marka = "Çıkış -";
                        kasa_listesi.Rows[i].Cells[2].Value = marka;
                        break;
                    case "Cariye Borçlanıldı.":
                        kasa_listesi.Rows.RemoveAt(i);
                        break;

                    case "Cari Borçlandırıldı.":
                        kasa_listesi.Rows.RemoveAt(i);
                        break;


                }
                kasa_listesi.Refresh();
            }
        }

        private void kasa_raporlamasi_Click(object sender, EventArgs e)
        {
            try
            {
                string mizer_urun_raport_saati = "Kasa_Raporu --- Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
                ReportDocument rd;
                rd = new ReportDocument();
                rd.Load(Application.StartupPath + @"\kasa_raporu_mizer.rpt");
                rd.SetParameterValue("ilk_tarih", Convert.ToDateTime(ilk_tarih_kasa.Text));
                rd.SetParameterValue("Son_Tarih", Convert.ToDateTime(son_tarih_kasa.Text));

                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
                System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }















        /// ürün raporu





        private string yaziyaCevir(decimal tutar)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                                //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " LIRA ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " KURUŞ";
            else
                yazi += "SIFIR KURUŞ.";

            return yazi;
        }

        private void yetki_sorgulama_XI()
        {
           if(gercek_yetki == "SüperAdmin")
            {

            }
           else if (gercek_yetki=="Yetkili Personel")
            {
                Anamenu_Yetkili_personeli_sorgulama();
            }
           else
            {
                mysqlbaglan.Close();
                MessageBox.Show("Yetkisiz Personel! - Hata Kodu:M22zer : Yetkisiz Personel ", "LMR-Process Vortex - Sirtuex", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void Anamenu_Yetkili_personeli_sorgulama()
        {
            try
            {
                string markacekkomutu = "select * from kullanicilar_yetki where y_id='" + kadi_getir + "'";
                MySqlCommand markacek = new MySqlCommand(markacekkomutu, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader listelememarka = markacek.ExecuteReader();
                if (listelememarka.Read())
                {
                    
                    if (listelememarka["urun_ekle"].ToString() == "False") { button4.Dispose(); } //1
                    if (listelememarka["urun_duzenle_sil"].ToString() == "False") { button3.Dispose(); button2.Dispose(); } //1
                    if (listelememarka["stok_ekle_dus"].ToString() == "False") { button1.Dispose(); button5.Dispose(); } //1
                    if (listelememarka["urun_raporla"].ToString() == "False") { button21.Dispose(); } //1
                    if (listelememarka["cari_goruntule"].ToString() == "False") { tabPage2.Dispose();tabPage3.Dispose();tabPage4.Dispose();tabPage5.Dispose(); }
                    if (listelememarka["cari_ekle"].ToString() == "False") { cari_ekle.Dispose(); } //1
                    if (listelememarka["cari_duzenle"].ToString() == "False") { düzenleToolStripMenuItem.Dispose(); cari_duzenle.Dispose(); } //1
                    if (listelememarka["satis_yetkisi"].ToString() == "False") { tabPage3.Dispose();button6.Dispose(); } //1
                    if (listelememarka["fatura_goruntule"].ToString() == "False") { button19.Dispose(); tabPage4.Dispose(); } //1
                    if (listelememarka["cari_hesaplari_goruntule"].ToString() == "False") { groupBox8.Dispose();panel1.Dispose();cariye_ait_fatura_listesi.Dispose(); } //1
                    if (listelememarka["odeme_al"].ToString() == "False") { button22.Dispose(); ödemeAlToolStripMenuItem.Dispose(); } //1
                    if (listelememarka["borclandir"].ToString() == "False") { button24.Dispose(); borçlandırToolStripMenuItem.Dispose(); } //1
                    if (listelememarka["odeme_yap"].ToString() == "False") { button23.Dispose(); ödemeYapToolStripMenuItem.Dispose(); } //1
                    if (listelememarka["borclan"].ToString() == "False") { button25.Dispose(); borçlanToolStripMenuItem.Dispose(); } //1
                    if (listelememarka["islem_fatura_sil"].ToString() == "False") { cari_silme.Dispose(); button33.Dispose(); silToolStripMenuItem.Dispose(); fatura_sil.Dispose(); } //1
                    if (listelememarka["cari_raporu_goruntule"].ToString() == "False") { button26.Dispose(); carininFaturalarınıRaporlaToolStripMenuItem.Dispose(); } //1
                    if (listelememarka["kasa_yetkisi"].ToString() == "False") { tabPage5.Dispose(); } //1


                }
                else
                {
                    if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }

                    this.Close();
                }
                mysqlbaglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (mysqlbaglan.State == ConnectionState.Open) { mysqlbaglan.Close(); }
            }

        }

    }
}
