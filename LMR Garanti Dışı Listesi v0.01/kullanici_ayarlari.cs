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
    public partial class kullanici_ayarlari : Form
    {
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string adminadi { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }
        public kullanici_ayarlari()
        {
            InitializeComponent();
        }

        hakkinda hakkindaac;
        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkindaac = new hakkinda();
            hakkindaac.Show();
            hakkindaac.Visible = false;
            hakkindaac.ShowDialog();
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
       




        /// Kullanıcı listesi başlangıç

        private void tum_faturacogalt(String id, String sebep, string marka, string tarih, string ead, string aciklama)
        {
            tum_kullanici_listesi.Rows.Add(id, sebep, marka, tarih, ead, aciklama);
        }

        string sql_tum = "";
        MySqlCommand dg_cmd_tum;
        MySqlDataAdapter adapter_tum;
        DataTable dt_tum = new DataTable();
        private void kullancilar_retrieve()
        {

           kullancilar_ayarlar_loading();
            tum_kullanici_listesi.Rows.Clear();
            tum_kullanici_listesi.Refresh();

            if (gercek_yetki == "SüperAdmin")
            {
                sql_tum = "SELECT * from kullanicilar";
            }
            else if (gercek_yetki == "Yetkili Personel")
            {
                sql_tum = "SELECT * from kullanicilar where yetki='Personel' ";
            }
            else
            {
                DialogResult = DialogResult.OK;
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
                    if (row[4].ToString() == "Ziyaretçi")
                    {
                    }
                    else
                    { 
                    tum_faturacogalt(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }

                }





                mysqlbaglan.Close();




                //// dt.Rows.Clear();
                this.tum_kullanici_listesi.Sort(this.tum_kullanici_listesi.Columns[0], ListSortDirection.Descending);
            }
            catch
            {
                mysqlbaglan.Close();
            }
           
            /// buraya datetime
            label12.Text = tum_kullanici_listesi.RowCount.ToString();
        }

        private void kullancilar_ayarlar_loading()
        {
            var culture2 = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture2;
            CultureInfo.DefaultThreadCurrentUICulture = culture2;

            tum_kullanici_listesi.DataSource = null;

            tum_kullanici_listesi.ColumnCount = 6;
            try
            {
                tum_kullanici_listesi.Columns[0].Name = "No";
                tum_kullanici_listesi.Columns[1].Name = "Kullanıcı Adı";
                tum_kullanici_listesi.Columns[2].Name = "Şifre";
                tum_kullanici_listesi.Columns[3].Name = "İsim";
                tum_kullanici_listesi.Columns[4].Name = "Yetki";
                tum_kullanici_listesi.Columns[5].Name = "Yetkili Olduğu Markalar";
                tum_kullanici_listesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                tum_kullanici_listesi.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < tum_kullanici_listesi.Columns.Count - 1; i++)
            {
                tum_kullanici_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            tum_kullanici_listesi.Columns[tum_kullanici_listesi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < tum_kullanici_listesi.Columns.Count; i++)
            {
                int colw = tum_kullanici_listesi.Columns[i].Width;
                tum_kullanici_listesi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                tum_kullanici_listesi.Columns[i].Width = colw;
            }

            tum_kullanici_listesi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_kullanici_listesi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tum_kullanici_listesi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            tum_kullanici_listesi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_kullanici_listesi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tum_kullanici_listesi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
  
        }





        /// Kullanıcı Listesi Bitiş






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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// anamenü
        anamenu anadonus;
        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;


        }
        void form_ana_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
        private void kullanici_ayarlari_Load(object sender, EventArgs e)
        {
            this.tum_kullanici_listesi.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.tum_kullanici_listesi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            yenilemeaq();
            kullancilar_retrieve();
          
          
        }

        private void kullanici_ayarlari_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(adminadi, ekleyen_adi, "Kullanıcı Logları", "Ana Menüye Dönüldü", "Ana Menüye Dönüldü");
        }

        private void fatura_goster_Click(object sender, EventArgs e)
        {

        }

        private void kullanici_ekle_ac_btn_Click(object sender, EventArgs e)
        {
            using (kullanici_ekle_SirtueX kullanici_ekle_ac_main = new kullanici_ekle_SirtueX())
            { 
            kullanici_ekle_ac_main.ekleyen_adi = ekleyen_adi;
            kullanici_ekle_ac_main.adminadi = kadi_getir;
            kullanici_ekle_ac_main.mysqlbaglan = mysqlbaglan;
                kullanici_ekle_ac_main.gercek_yetki = gercek_yetki;
            kullanici_ekle_ac_main.ShowDialog();
                kullanici_ekle_ac_main.Dispose();
            }
            GC.Collect();
            kullancilar_retrieve();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (kullanici_duzenle_Mizer kullanici_duzenle_ac_main = new kullanici_duzenle_Mizer())
            { 
                kullanici_duzenle_ac_main.ekleyen_adi = ekleyen_adi;
            kullanici_duzenle_ac_main.adminadi = kadi_getir;
            kullanici_duzenle_ac_main.mysqlbaglan = mysqlbaglan;
                kullanici_duzenle_ac_main.gercek_yetki = gercek_yetki;
            kullanici_duzenle_ac_main.kadi = tum_kullanici_listesi.SelectedRows[0].Cells[1].Value.ToString();
            kullanici_duzenle_ac_main.ShowDialog();
                kullanici_duzenle_ac_main.Dispose();
            }
            GC.Collect();
            kullancilar_retrieve();
        }

        private void fatura_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(tum_kullanici_listesi.SelectedRows[0].Cells[3].Value + " isimli kullanıcıyı silmek istediğine emin misin ??", "Silmek için emin misin? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string sql_urun_sil = "delete from kullanicilar where no='" + tum_kullanici_listesi.SelectedRows[0].Cells[0].Value + "'";
                    mysqlbaglan.Open();


                    MySqlCommand silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    mysqlbaglan.Close();
                   sql_urun_sil = "delete from kullanicilar_yetki where y_id='" + tum_kullanici_listesi.SelectedRows[0].Cells[1].Value + "'";
                    mysqlbaglan.Open();


                    silmekomutu_urunler_icin = new MySqlCommand(sql_urun_sil, mysqlbaglan);
                    silmekomutu_urunler_icin.ExecuteNonQuery();
                    mysqlbaglan.Close();

                    log_gonder(kadi_getir, ekleyen_adi, "Kullanıcı Ayarları", "Kullanıcı Sil", "Silinen Kullanıcı Adı: " + tum_kullanici_listesi.SelectedRows[0].Cells[1].Value.ToString() + " --- Silinen Kullanıcı No: " + tum_kullanici_listesi.SelectedRows[0].Cells[0].Value.ToString());

                    kullancilar_retrieve();
                }
            }
            catch
            {
                MessageBox.Show("Birşeyler ters sende biliyorsun bunu mesela İnternet bağlantısı olmayabilir  ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullancilar_retrieve();
        }
    }
}
