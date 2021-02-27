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

namespace LMR_Process_Vortex
{
    public partial class satis_urun_ekle_liste_SirtueX : Form
    {
        public satis_urun_ekle_liste_SirtueX()
        {
            InitializeComponent();
        }
       public MySqlConnection mysqlbaglan { get; set; }
        private void urun_ayarlari_loading()
        {



            urun_listesi.DataSource = null;

            urun_listesi.ColumnCount = 7;
            try
            {
                urun_listesi.Columns[0].Name = "Ürün_Kodu";
                urun_listesi.Columns[1].Name = "Marka";
                urun_listesi.Columns[2].Name = "Ürün_Türü";
                urun_listesi.Columns[3].Name = "Ürün_İsmi";
                urun_listesi.Columns[4].Name = "Ürün_Fiyatı";
                urun_listesi.Columns[5].Name = "Stok_Sayısı";
                urun_listesi.Columns[6].Name = "Ürün_Açıklaması";
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





                mysqlbaglan.Close();




                //// dt.Rows.Clear();
            }
            catch
            {
                mysqlbaglan.Close();
            }
            urun_sayisi_toplam.Text = urun_listesi.RowCount.ToString();
            textBox1.Text = "";
        }
        ///URUN LİSTESİ KODLARI BİTİŞ,
        //////URUN LİSTESİ KODLARI BİTİŞ
        //////URUN LİSTESİ KODLARI BİTİŞ
        //////URUN LİSTESİ KODLARI BİTİŞ
       
        private void satis_urun_ekle_liste_SirtueX_Load(object sender, EventArgs e)
        {
            urun_ayarlari_loading();
            urun_listesini_retrieve_yap();
        }
        DataTable urunarama = new DataTable("cariler");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            urun_listesi.Columns.Clear();
            DataView dv2 = dt2.DefaultView;
            try
            {
                ////  dv2.RowFilter = string.Format("urun_kodu like '%{0}%' or urun_ismi like '%{0}%' or urun_aciklama like '%{0}%' or urun_tur like '%{0}%' or urun_bagli_marka like '%{0}%'", textBox3.Text);
                dt2.Columns["urun_kodu"].ColumnName = "Ürün_Kodu";
                dt2.Columns["urun_bagli_marka"].ColumnName = "Marka";
                dt2.Columns["urun_tur"].ColumnName = "Ürün_Türü";
                dt2.Columns["urun_ismi"].ColumnName = "Ürün_İsmi";
                dt2.Columns["urun_fiyati"].ColumnName = "Ürün_Fiyatı";
                dt2.Columns["urun_stok_durumu"].ColumnName = "Stok_Sayısı";
                dt2.Columns["urun_aciklama"].ColumnName = "Ürün_Açıklaması";
            }
            catch/*Exception ex*/
            {
                /* MessageBox.Show(ex.ToString()); */
            }
            try
            { 
            dv2.RowFilter = string.Format("Ürün_Kodu like '%{0}%' or Ürün_İsmi like '%{0}%' or Ürün_Açıklaması like '%{0}%' or Ürün_Türü like '%{0}%' or Marka like '%{0}%'", textBox1.Text);
            urun_listesi.DataSource = dv2.ToTable();
            }
            catch
            { }


        }
        public string urun_kodu { get; set; }
        public string urun_tipi{ get; set; }
        public string urun_adi { get; set; }
        public string urun_stok { get; set; }
        public string urun_fiyat { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            this.urun_kodu = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
            this.urun_tipi = urun_listesi.SelectedRows[0].Cells[2].Value.ToString();
            this.urun_adi = urun_listesi.SelectedRows[0].Cells[3].Value.ToString();
            this.urun_fiyat = urun_listesi.SelectedRows[0].Cells[4].Value.ToString();
            this.urun_stok = urun_listesi.SelectedRows[0].Cells[5].Value.ToString();
            this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
