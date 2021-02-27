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
    public partial class cari_sec_listesi_SirtueX : Form
    {
        public cari_sec_listesi_SirtueX()
        {
            InitializeComponent();
        }
       public MySqlConnection mysqlbaglan { get; set; }
        private void urun_ayarlari_loading()
        {



            urun_listesi.DataSource = null;

            urun_listesi.ColumnCount = 13;
            try
            {
                urun_listesi.Columns[0].Name = "No";
                urun_listesi.Columns[1].Name = "Tip";
                urun_listesi.Columns[2].Name = "Adı";
                urun_listesi.Columns[3].Name = "Yetkili İsim";
                urun_listesi.Columns[4].Name = "Adres 1";
                urun_listesi.Columns[5].Name = "Adres 2";
                urun_listesi.Columns[6].Name = "Posta Kodu";
                urun_listesi.Columns[7].Name = "Telefon";
                urun_listesi.Columns[8].Name = "Cep_Telefon";
                urun_listesi.Columns[9].Name = "Faks";
                urun_listesi.Columns[10].Name = "Vergi Dairesi";
                urun_listesi.Columns[11].Name = "Vergi Dairesi No";
                urun_listesi.Columns[12].Name = "Açıklama";
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
            urun_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            urun_listesi.Columns[12].Width = 400;

        }

        ///URUN LİSTESİ KODLARI BAŞLANGIÇ,
        //////URUN LİSTESİ KODLARI BAŞLANGIÇ
        //////URUN LİSTESİ KODLARI BAŞLANGIÇ
        //////URUN LİSTESİ KODLARI BAŞLANGIÇ
        private void urun_listesini_cogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2, string aciklama3, string aciklama4, string aciklama5, string aciklama6, string aciklama7, string aciklama8)
        {
            urun_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2, aciklama3, aciklama4, aciklama5, aciklama6, aciklama7, aciklama8);
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



            sql2 = "SELECT cari_no,firma_tipi,firma_adi,yetkili_isim,adres_satiri_1,adres_satiri_2,posta_kodu,telefon,cep_telefon,faks,vergidairesi,vergidairesi_2,aciklama from cariler";


            dg_cmd2 = new MySqlCommand(sql2, mysqlbaglan);


            try
            {
                mysqlbaglan.Open();

                adapter2 = new MySqlDataAdapter(dg_cmd2);

                dt2 = new DataTable();
                adapter2.Fill(dt2);

                foreach (DataRow row in dt2.Rows)
                {
                    urun_listesini_cogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString());
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            this.cari_tipi = urun_listesi.SelectedRows[0].Cells[1].Value.ToString();
            this.cari_adi = urun_listesi.SelectedRows[0].Cells[2].Value.ToString();
            this.cari_adres1 = urun_listesi.SelectedRows[0].Cells[4].Value.ToString();
            this.cari_adres2 = urun_listesi.SelectedRows[0].Cells[5].Value.ToString();
            this.cari_vd = urun_listesi.SelectedRows[0].Cells[10].Value.ToString();
            this.cari_vd2 = urun_listesi.SelectedRows[0].Cells[11].Value.ToString();
            this.cari_no = urun_listesi.SelectedRows[0].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        public string cari_tipi { get; set; }
        public string cari_adi { get; set; }
        public string cari_adres1 { get; set; }
        public string cari_adres2 { get; set; }
        public string cari_vd { get; set; }
        public string cari_vd2 { get; set; }
        public string cari_no { get; set; }
        private void cari_sec_listesi_SirtueX_Load(object sender, EventArgs e)
        {
            urun_ayarlari_loading();
            urun_listesini_retrieve_yap();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            urun_listesi.Columns.Clear();
            DataView dv = dt2.DefaultView;
            try
            {
                dt2.Columns["cari_no"].ColumnName = "No";
                dt2.Columns["firma_tipi"].ColumnName = "Tip";
                dt2.Columns["firma_adi"].ColumnName = "Adı";
                dt2.Columns["yetkili_isim"].ColumnName = "Yetkili";
                dt2.Columns["adres_satiri_1"].ColumnName = "Adres1";
                dt2.Columns["adres_satiri_2"].ColumnName = "Adres2";
                dt2.Columns["posta_kodu"].ColumnName = "Posta Kodu";
                dt2.Columns["telefon"].ColumnName = "Telefon";
                dt2.Columns["cep_telefon"].ColumnName = "Cep_Telefon";
                dt2.Columns["faks"].ColumnName = "Faks";
                dt2.Columns["vergidairesi"].ColumnName = "Vergi Dairesi";
                dt2.Columns["vergidairesi_2"].ColumnName = "Vergi No";
                dt2.Columns["aciklama"].ColumnName = "Açıklama";
            }
            catch/*Exception ex*/
            {
                /* MessageBox.Show(ex.ToString()); */
            }
            try { 
            dv.RowFilter = string.Format("Adı like '%{0}%' or Tip like '%{0}%' or Açıklama like '%{0}%'", textBox1.Text);
            urun_listesi.DataSource = dv.ToTable();
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
