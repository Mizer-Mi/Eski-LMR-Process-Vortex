using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class secim_raportlama_Mizer_Sirtuex : Form
    {
        public secim_raportlama_Mizer_Sirtuex()
        {
            InitializeComponent();
        }
        public MySqlConnection mysqlbaglan { get; set; }
        public string ekleyen_adi { get; set; }
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
        public string nereden_geldin_hocam_gulucuk { get; set; }
        private void secim_raportlama_Mizer_Sirtuex_Load(object sender, EventArgs e)
        {

            label2.Text = nereden_geldin_hocam_gulucuk;
            if (nereden_geldin_hocam_gulucuk == "Ürünler")
            {


                urun_ekle_comboya();



            }

        }
            private void urun_ekle_comboya()
        {
            try
                {

                string komutsatiri = "SELECT marka_ad FROM markalar";

                MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();
                marka_eklerken_sec.Items.Add("Hepsi");
                while (okuyucum.Read())
                {
                    marka_eklerken_sec.Items.Add(okuyucum.GetString("marka_ad"));



                }

                marka_eklerken_sec.SelectedIndex = 0;
                marka_eklerken_sec.SelectedItem = 0;


                mysqlbaglan.Close();
            }
                catch
                {
                mysqlbaglan.Close();
            }

        }
            
        private void button21_Click(object sender, EventArgs e)
        {
            if (nereden_geldin_hocam_gulucuk == "Ürünler")
            {
               
                urun_raport_excel();
                label1.Visible = true;
               
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nereden_geldin_hocam_gulucuk == "Ürünler")
            {
              
                urun_raport_pdf();
                label1.Visible = true;
            }
        }

        private void urun_raport_excel()
        {
            try
            {
            string mizer_urun_raport_saati2 = "Urun_Raporu Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".xls";
            ReportDocument rd;
            rd = new ReportDocument();
            rd.Load(Application.StartupPath + @"\urunler.rpt");
                if (marka_eklerken_sec.Text == "Hepsi")
                {
                    rd.SetParameterValue("markasec", "Hepsi");
                }
                else
                {
                    rd.SetParameterValue("markasec", marka_eklerken_sec.Text);
                }
                ExportOptions exportOptions;

            DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
            ExcelFormatOptions formatTypeOptions = new ExcelFormatOptions();
            diskFileDestinationOptions.DiskFileName = @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati2;
                
            exportOptions = rd.ExportOptions;
            exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            exportOptions.ExportFormatType = ExportFormatType.Excel;
            exportOptions.DestinationOptions = diskFileDestinationOptions;
            exportOptions.FormatOptions = formatTypeOptions;
            rd.Export();
                System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati2);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


        }
        private void urun_raport_pdf()
        {
            try
            {
            string mizer_urun_raport_saati = "Urun_Raporu Tarih " + DateTime.Now.ToShortDateString().Replace(':', '.') + " Saat " + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".pdf";
            ReportDocument rd;
            rd = new ReportDocument();
            rd.Load(Application.StartupPath + @"\urunler.rpt");
                if (marka_eklerken_sec.Text == "Hepsi")
                {
                    rd.SetParameterValue("markasec", "Hepsi");
                }
                else
                {
                    rd.SetParameterValue("markasec", marka_eklerken_sec.Text);
                }
                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
            System.Diagnostics.Process.Start(@"C:\Mizer_LMR_Raporlar\" + mizer_urun_raport_saati);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
