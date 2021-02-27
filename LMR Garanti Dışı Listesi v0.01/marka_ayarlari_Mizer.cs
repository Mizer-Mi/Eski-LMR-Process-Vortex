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
    public partial class marka_ayarlari_Mizer : Form
    {
        public marka_ayarlari_Mizer()
        {
            InitializeComponent();
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
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
            catch
            {

            }

        }
        public MySqlConnection mysqlbaglan { get; set; }
        public string gercek_yetki { get; set; }
        public string adminadi { get; set; }
        public string ekleyen_ismi_cek { get; set; }
        public string  ekleyen_adi { get; set; }
        MySqlCommand marka_cmd;
        private void marka_ayarlari_Mizer_Load(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Marka Ayarları", "Marka Ayarları Görüntülendi.", "Görüntülendi.");
            yenilemeaq();
            markalari_doldur_yenile();
        }
        private void yenilemeaq()
        {
            try
            {
                toolStripStatusLabel1.Text = gercek_yetki + " Girişi Yapıldı";

                toolStripStatusLabel2.Text = " | Tarih: " + DateTime.Today.ToShortDateString() + " | ";
                toolStripStatusLabel4.Text = "Hoşgeldin " + ekleyen_ismi_cek + " |";
         
            
               
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
             

            
               
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
            catch
            {

            }
           
        }
        private void marka_box_sil()
        {
            marka_ad.Text = "";
            marka_acik.Text = "";
        }
        private void markalari_doldur_yenile()
        {
           
            marka_listesi.Items.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            panel6.Visible = false;
            try
            {
                marka_listesi.Text = "";
                string markasqlsorgu = "SELECT * FROM `markalar`";
                marka_cmd = new MySqlCommand(markasqlsorgu, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader rdr = marka_cmd.ExecuteReader();
                while (rdr.Read())
                {
                    marka_listesi.Items.Add(rdr["marka_ad"].ToString());
                    comboBox1.Items.Add(rdr["marka_ad"].ToString());

                }
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
      
            }
            catch
            {
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }


            }


        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (mysqlbaglan.State == ConnectionState.Open)
            {
                mysqlbaglan.Close();
            }
            if (marka_ad.Text != "")
            {
                string markasqlsorgu = "INSERT INTO markalar(marka_ad,marka_aciklamasi,ekleyenin_adi) VALUES(@marka_ad,@marka_aciklama,@ekleyen)";
                marka_cmd = new MySqlCommand(markasqlsorgu, mysqlbaglan);


                marka_cmd.Parameters.AddWithValue("@marka_ad", marka_ad.Text);
                marka_cmd.Parameters.AddWithValue("@marka_aciklama", marka_acik.Text);
                marka_cmd.Parameters.AddWithValue("@ekleyen", ekleyen_adi);

                try
                {
                    mysqlbaglan.Open();

                    if (marka_cmd.ExecuteNonQuery() > 0)
                    {
                        if (mysqlbaglan.State == ConnectionState.Open)
                        {
                            mysqlbaglan.Close();
                        }
                        log_gonder(adminadi, ekleyen_ismi_cek, "Marka Ayarları", "Marka Eklendi", "Eklenen Marka Adı: "+marka_ad.Text);
                        MessageBox.Show("Marka Eklendi Eklendi");
                    }

                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                    marka_box_sil();
                    markalari_doldur_yenile();


                }
                catch 
                {
                    MessageBox.Show("Marka adını farklı girin yada bağlantınızı kontrol edin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Marka adı boş geçilemez.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string sorgu_tut = "";
        
        private void marka_isim_combo_ararken()
        {
            if (comboBox1.Text != "")
            {

                panel6.Visible = true;
                string markasqlsorgu = "SELECT * FROM `markalar` where marka_ad='" + comboBox1.Text + "'";
                marka_cmd = new MySqlCommand(markasqlsorgu, mysqlbaglan);
                try
                {
                    mysqlbaglan.Open();
                    MySqlDataReader rdr = marka_cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        sorgu_tut = comboBox1.Text;
                        richTextBox5.Text = rdr["marka_aciklamasi"].ToString();
                        label1.Text = "";
                        textBox1.Text = comboBox1.Text;
                        label3.Text = comboBox1.Text;
                    }
                    else
                    {
                        panel6.Visible = false;
                        richTextBox5.Text = "";
                        label1.Text = "Marka adı bulunamadı..";
                    }
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                }
                catch
                {
                    panel6.Visible = false;
                    label1.Text = "Bağlantı sağlanamıyor.";
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                }
            }
            else
            {
                richTextBox5.Text = "";
                label1.Text = "Marka adı boş geçilemez..";
                panel6.Visible = false;
            }
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            marka_isim_combo_ararken();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            marka_isim_combo_ararken();
        }
        

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                marka_isim_combo_ararken();

            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            marka_isim_combo_ararken();
        }

        private void marka_listesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = marka_listesi.SelectedItem.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            if (comboBox1.Text != "")
            {
                try
                {
                    mysqlbaglan.Open();
                    string guncelle = "UPDATE markalar set marka_aciklamasi=@markaaciklamasi ,  marka_ad=@markaadi WHERE marka_ad='" + label3.Text + "'";
                    MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
                    guncel.Parameters.AddWithValue("@markaadi", textBox1.Text);
                    guncel.Parameters.AddWithValue("@markaaciklamasi", richTextBox5.Text);
                    guncel.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                    markalari_doldur_yenile();
                    log_gonder(adminadi, ekleyen_ismi_cek, "Marka Ayarları", "Marka Güncellendi", "Güncellenen Marka Adı: " + label3.Text + "  --- Yeni Marka Adı: "+textBox1.Text);
                    MessageBox.Show("Marka Bilgileri Güncellendi.");
                    richTextBox5.Text = "";

                }
                catch
                {
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                    MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Marka adı boş geçilemez.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panel6.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string markasqlsorgu = "DELETE FROM markalar WHERE marka_ad='" + label3.Text + "'";
                marka_cmd = new MySqlCommand(markasqlsorgu, mysqlbaglan);

                try
                {
                    mysqlbaglan.Open();





                    if (MessageBox.Show(label3.Text + " Adlı markayı silmek istediğine Emin misin ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        marka_cmd.ExecuteNonQuery();
                        if (mysqlbaglan.State == ConnectionState.Open)
                        {
                            mysqlbaglan.Close();
                        }
                        log_gonder(adminadi, ekleyen_ismi_cek, "Marka Ayarları", "Marka Silindi", "Silinen Marka Adı: " + label3.Text);
                    }

                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }

                    markalari_doldur_yenile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Marka adı boş geçilemez.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            panel6.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            markalari_doldur_yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
        }

        private void marka_ayarlari_Mizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Marka Ayarları", "AnaMenüye Dönüldü.", "AnaMenüye Dönüldü.");
        }
    }
}
