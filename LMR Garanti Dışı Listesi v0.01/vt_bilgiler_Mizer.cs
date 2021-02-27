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
    public partial class vt_bilgiler_Mizer : Form
    {
        public vt_bilgiler_Mizer()
        {
            InitializeComponent();
        }
        public string ekleyen_adi { get; set; }
        public string gercek_yetki { get; set; }
        public string kadi_getir { get; set; }
        public string adminadi { get; set; }
        public MySqlConnection mysqlbaglan { get; set; }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            log_gonder(kadi_getir, ekleyen_adi, "Veri Tabanı Bilgileri", "Anamenüye Dönüldü", "Anamenüye Dönüldü.");
            DialogResult =   DialogResult.OK;
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

        private void vt_bilgiler_Mizer_Load(object sender, EventArgs e)
        {
            log_gonder(kadi_getir, ekleyen_adi, "Veri Tabanı Bilgileri", "Veri Tabanı Bilgileri", "Görüntülendi.");
        }

        private void vt_bilgiler_Mizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(kadi_getir, ekleyen_adi, "Veri Tabanı Bilgileri", "Anamenüye Dönüldü", "Anamenüye Dönüldü.");
            DialogResult = DialogResult.OK;
        }
    }
}
