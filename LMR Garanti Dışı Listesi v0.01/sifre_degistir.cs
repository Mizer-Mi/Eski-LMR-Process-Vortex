using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LMR_Process_Vortex
{
    public partial class sifre_degistir : Form
    {
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
       public MySqlConnection mysqlbaglan { get; set; }
        form_loading form_out = new form_loading();

        public sifre_degistir()
        {
            InitializeComponent();
        }
        public string aktarmaotobusu { get; set; }
        string isim = "";
        private void sifre_degistir_Load(object sender, EventArgs e)
        {
            
            mysqlbaglan.Open();
            string sql = "SELECT * FROM `kullanicilar` where kadi='"+aktarmaotobusu+"'";
            MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            { 
            label4.Text = "Merhaba, "+ rdr["isim"].ToString() + ". Şifre değiştirme menüsüne hoşgeldin." ;

                isim = rdr["isim"].ToString();
                label5.Text = ""+  rdr["kadi"].ToString() + "";

            }
            mysqlbaglan.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 

            if(textBox2.Text==textBox3.Text)
            { 
            mysqlbaglan.Open();
            string sql = "SELECT sifre FROM `kullanicilar` where kadi='"+aktarmaotobusu+"'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
            MySqlDataReader rdr = cmd.ExecuteReader();
                    

                    if (rdr.Read())
                {
                if(rdr["sifre"].ToString() == textBox1.Text )
                {
                    mysqlbaglan.Close();
                    mysqlbaglan.Open();

                    string guncelle = "update `kullanicilar` set sifre=@sifre where kadi='"+aktarmaotobusu+"'";
                    MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                    guncel.Parameters.AddWithValue("@sifre", textBox2.Text);
                    guncel.ExecuteNonQuery();
                            log_gonder(aktarmaotobusu, isim, "Şifre Değiştirme", "Şifre Değiştirildi", "Eski Şifre: " + textBox1.Text + " Yeni Şifre: " + textBox2.Text);
                            MessageBox.Show("Şifreniz Başarıyla Güncellendi.");
                    mysqlbaglan.Close();
                            DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Eski Şifre Doğru Değil.");
                }
                mysqlbaglan.Close();

                }
            }
            else
            {
                MessageBox.Show("Şifreleriniz Uyuşmamaktadır.");
            }
            }
            catch
            {
                MessageBox.Show("Kritik Hata , Bağlantı Sağlanamadı.");
            }
           
            
        }

        private void sifre_degistir_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
