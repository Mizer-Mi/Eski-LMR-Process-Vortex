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

namespace LMR_Process_Vortex
{
    public partial class giris_loglari_form : Form
    {
        public giris_loglari_form()
        {
            InitializeComponent();
        }
        
        private void giris_loglari_Load(object sender, EventArgs e)
        {

            this.giris_loglari_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.giris_loglari_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            log_gonder(adminadi, ekleyen_adi, "Hatalı Giriş Logları", "Hatalı Giriş Logları Görüntüledi.", "Hatalı Giriş Logları Görüntüledi.");
            yenilemeaq();
            tum_fatura_retrieve();
        }
        public string adminadi { get; set; }
        private void log_gonder(string kadi, string isim, string bolum, string islem, string aciklama)
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
        DataTable faturaarama = new DataTable("giris_loglari");
        private void tarih_ara()
        {
            giris_loglari_listesi.Columns.Clear();
            DataView dv2 = dt_tum.DefaultView;
            try
            {
                dt_tum.Columns["no"].ColumnName = "No";
                dt_tum.Columns["mac_adresi"].ColumnName = "Mac Adresi";
                dt_tum.Columns["tarih"].ColumnName = "Tarih";
                dt_tum.Columns["denenen_id"].ColumnName = "Girilen Kadi";
                dt_tum.Columns["denenen_sifre"].ColumnName = "Girilen Şifre";
                dt_tum.Columns[""].ColumnName = "cikis_ip_adresi";
                dt_tum.Columns["denenen_sifre"].ColumnName = "yerel_ip_adresi";



            }
            catch/*Exception ex*/
            {
                /* MessageBox.Show(ex.ToString()); */
            }
            try
            { 
            dv2.RowFilter = "Convert(Tarih, 'System.String') LIKE '" + dateTimePicker1.Text + "%'";
            giris_loglari_listesi.DataSource = dv2.ToTable();
            this.giris_loglari_listesi.Sort(this.giris_loglari_listesi.Columns[0], ListSortDirection.Descending);

            }
            catch
            { }







        }

        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
       public MySqlConnection mysqlbaglan { get; set; }
        private void tum_faturacogalt(String id, String sebep, string marka, string tarih, string ead, string ac1, string ac2)
        {
            giris_loglari_listesi.Rows.Add(id, sebep, marka, tarih, ead,ac1,ac2);
        }

        string sql_tum = "";
        MySqlCommand dg_cmd_tum;
        MySqlDataAdapter adapter_tum;
        DataTable dt_tum = new DataTable();
        private void tum_fatura_retrieve()
        {

            tum_faturalar_ayarlar_loading();
            giris_loglari_listesi.Rows.Clear();
            giris_loglari_listesi.Refresh();

            if (checkBox1.Checked==true)
            {
                sql_tum = "SELECT * from hatali_giris_loglari LIMIT 500";
            }
            else
            { 
            sql_tum = "SELECT * from hatali_giris_loglari";
            }

            dg_cmd_tum = new MySqlCommand(sql_tum, mysqlbaglan);


            try
            {
                mysqlbaglan.Open();

                adapter_tum = new MySqlDataAdapter(dg_cmd_tum);

                dt_tum = new DataTable();
                adapter_tum.Fill(dt_tum);

                foreach (DataRow row in dt_tum.Rows)
                {
                    tum_faturacogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }





                mysqlbaglan.Close();




                //// dt.Rows.Clear();
                this.giris_loglari_listesi.Sort(this.giris_loglari_listesi.Columns[0], ListSortDirection.Descending);
            }
            catch
            {
                mysqlbaglan.Close();
            }
           
            /// buraya datetime
        }

        private void tum_faturalar_ayarlar_loading()
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;

            giris_loglari_listesi.DataSource = null;

            giris_loglari_listesi.ColumnCount = 7;
            try
            {
                giris_loglari_listesi.Columns[0].Name = "No:";
                giris_loglari_listesi.Columns[1].Name = "Mac Adresi:";
                giris_loglari_listesi.Columns[2].Name = "Tarih:";
                giris_loglari_listesi.Columns[3].Name = "Girilen Kadi";
                giris_loglari_listesi.Columns[4].Name = "Girilen Şifre";
                giris_loglari_listesi.Columns[5].Name = "Dış IP Adresi";
                giris_loglari_listesi.Columns[6].Name = "Yerel IP Adresi";
                giris_loglari_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                giris_loglari_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < giris_loglari_listesi.Columns.Count - 1; i++)
            {
                giris_loglari_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            giris_loglari_listesi.Columns[giris_loglari_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < giris_loglari_listesi.Columns.Count; i++)
            {
                int colw = giris_loglari_listesi.Columns[i].Width;
                giris_loglari_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                giris_loglari_listesi.Columns[i].Width = colw;
            }

            giris_loglari_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            giris_loglari_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            giris_loglari_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 

            giris_loglari_listesi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            giris_loglari_listesi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            giris_loglari_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            giris_loglari_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            giris_loglari_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            giris_loglari_listesi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            tum_fatura_retrieve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tarih_ara();
        }
        hakkinda hakkindaac;
        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkindaac = new hakkinda();
            hakkindaac.Show();
            hakkindaac.Visible = false;
            hakkindaac.ShowDialog();
        }

        private void programKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Hatalı Giriş Logları", "Çıkış Yapıldı", "Çıkış Yapıldı");
            Environment.Exit(1);
        }

         public string cikisa_don_mizer;

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Hatalı Giriş Logları", "Çıkış Yapıldı", "Çıkış Yapıldı");
          
        cikisa_don_mizer = "Evet";
             DialogResult = DialogResult.OK;
            
           
         ///   form_out.FormClosing += form_out_FormClosing;

            
        }
        void form_out_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
        /// anamenü
        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
          DialogResult=  DialogResult.OK;
            
            
        }
        void form_ana_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Close();
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

        private void giris_loglari_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Hatalı Giriş Logları", "Ana Menüye Dönüldü", "Ana Menüye Dönüldü");
            DialogResult = DialogResult.OK;
        }

        private void giris_loglari_listesi_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {

            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tum_fatura_retrieve();
        }
    }
}
