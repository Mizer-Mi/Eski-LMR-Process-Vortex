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
using System.Net;

namespace LMR_Process_Vortex
{
    public partial class kullanici_loglari : Form
    {
        public kullanici_loglari()
        {
            InitializeComponent();
        }
        
        private void giris_loglari_Load(object sender, EventArgs e)
        {
            this.giris_loglari_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.giris_loglari_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            log_gonder(adminadi, ekleyen_adi, "Kullanıcı Logları", "Kullanıcı Logları Görüntüledi.", "Kullanıcı Loglarını Görüntüledi.");
            yenilemeaq();
            kullanici_adlarini_cek_metedu();
            tum_fatura_retrieve();
          
            
        }

        private void kullanici_adlarini_cek_metedu()
        {
          
          

          
            try
            { 
            comboBox1.Items.Clear();
                if (gercek_yetki == "SüperAdmin") { comboBox1.Items.Add("Hepsi"); }
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
                if (gercek_yetki == "SüperAdmin")
                { sql_tum = "SELECT kadi from kullanicilar"; }
                else if (gercek_yetki=="Yetkili Personel")
                {
                    sql_tum = "SELECT kadi from kullanicilar where yetki='Personel'";
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            mysqlbaglan.Open();
            MySqlCommand kullanici_cek = new MySqlCommand(sql_tum, mysqlbaglan);
            MySqlDataReader kadi_oku = kullanici_cek.ExecuteReader();
            while(kadi_oku.Read())
            {
                comboBox1.Items.Add(kadi_oku["kadi"]);
            }
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
            comboBox1.SelectedIndex = 0;
            try
            { 
            int index = comboBox1.Items.IndexOf("");
            comboBox1.Items.RemoveAt(index);
            }
            catch
            {
               
            }
            }
            catch
            { }

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
        DataTable faturaarama = new DataTable("giris_loglari");
        private void tarih_ara()
        {
            giris_loglari_listesi.Columns.Clear();
            DataView dv2 = dt_tum.DefaultView;
            try
            {
                dt_tum.Columns["no"].ColumnName = "No";
                dt_tum.Columns["kullanici_adi"].ColumnName = "Kullanıcı Adı";
                dt_tum.Columns["isim"].ColumnName = "İsim";
                dt_tum.Columns["bolum"].ColumnName = "Bölüm";
                dt_tum.Columns["islem"].ColumnName = "İşlem";
                dt_tum.Columns["aciklama"].ColumnName = "Açıklama";
                dt_tum.Columns["tarih"].ColumnName = "Tarih";

            }
            catch/*Exception ex*/
            {
                /* MessageBox.Show(ex.ToString()); */
            }
           /// burda kaldık
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
        private void tum_faturacogalt(String id, String sebep, string marka, string tarih, string ead,string aciklama,string aciklama2)
        {
            giris_loglari_listesi.Rows.Add(id, sebep, marka, tarih, ead,aciklama,aciklama2);
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
            if (comboBox1.SelectedItem.ToString() == "Hepsi")
            { 
            sql_tum = "SELECT * from kullanici_islemleri ORDER BY no DESC LIMIT 500 ";
            }
            else
            {
                sql_tum = "SELECT * from kullanici_islemleri where kullanici_adi='"+comboBox1.Text+ "' ORDER BY no DESC LIMIT 500 ";
            }
            }
            else
            {
                if (comboBox1.SelectedItem.ToString()== "Hepsi")
                {
                    sql_tum = "SELECT * from kullanici_islemleri ORDER BY no DESC ";
                }
                else
                {
                    sql_tum = "SELECT * from kullanici_islemleri where kullanici_adi='" + comboBox1.Text + "' ORDER BY no DESC";
                }
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
                giris_loglari_listesi.Columns[0].Name = "No";
                giris_loglari_listesi.Columns[1].Name = "Kullanıcı Adı";
                giris_loglari_listesi.Columns[2].Name = "İsim";
                giris_loglari_listesi.Columns[3].Name = "Bölüm";
                giris_loglari_listesi.Columns[4].Name = "İşlemler";
                giris_loglari_listesi.Columns[5].Name = "Açıklama";
                giris_loglari_listesi.Columns[6].Name = "Tarih";
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
       
        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (hakkinda hakkindaac = new hakkinda())
            { 
            hakkindaac.ShowDialog();
            }
        }

        private void programKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Kullanıcı Logları", "Çıkış Yapıldı", "Çıkış Yapıldı");
            Environment.Exit(1);
        }

        public string cikisa_don_mizer;
        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Kullanıcı Logları", "Çıkış Yapıldı", "Çıkış Yapıldı");
           
        cikisa_don_mizer = "Evet";
             DialogResult = DialogResult.OK;
        }
      
        /// anamenü
      
        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;


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

        private void kullanici_loglari_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Kullanıcı Logları", "Ana Menüye Dönüldü", "Ana Menüye Dönüldü");
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tum_fatura_retrieve();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tum_fatura_retrieve();
        }
    }
}
