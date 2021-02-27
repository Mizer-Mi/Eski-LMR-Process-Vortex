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
using System.Threading;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using System.Collections;

namespace LMR_Process_Vortex
{

    public partial class secim_form : Form
    {
        public string eG80LPJJCimP { get; set; }
        public string Id4SGF8YIcyg9y { get; set; }
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


        private void populate(String id, String sebep, string marka, string tarih, string ead, string aciklama, string aciklama2, string aciklama3)
        {
            dataGridView1.Rows.Add(id, sebep, marka, tarih, ead, aciklama, aciklama2,aciklama3);
        }


        private void retrieve()
        {
            dataGridView1.Rows.Clear();
            string sql = "";
            
             


            try
            {
                

                
                int i = yetkilerin.Length -1;
                if(gercek_yetki=="Personel")
                { 
                    while (i >= 0)
                    {
                        
                        sql = "SELECT VT_serial_number,VT_garanti_disi_sebep,VT_marka,VT_model,VT_tarih,VT_aciklama,VT_referans,ekleyenin_adi FROM anatablo where VT_marka='"+yetkilerin[i]+"'";
                        dg_cmd = new MySqlCommand(sql, mysqlbaglan);
                        mysqlbaglan.Open();
                        adapter = new MySqlDataAdapter(dg_cmd);
                        adapter.Fill(dt);
                        
                       

                        i--;
                        if (mysqlbaglan.State == ConnectionState.Open)
                        {
                            mysqlbaglan.Close();
                        }

                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                    }

                }
                else
                {
                    sql = "SELECT VT_serial_number,VT_garanti_disi_sebep,VT_marka,VT_model,VT_tarih,VT_aciklama,VT_referans,ekleyenin_adi FROM anatablo";
                    dg_cmd = new MySqlCommand(sql, mysqlbaglan);
                    mysqlbaglan.Open();
                    adapter = new MySqlDataAdapter(dg_cmd);
                    adapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                    }
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                }
               
                


                    dt.Rows.Clear();
                this.dataGridView1.Sort(this.dataGridView1.Columns[4], ListSortDirection.Descending);
            }
            catch
            {

                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }

           

        }


        private void update(string id, string marka, string sebep2, string aciklama)
        {

            string sql = "update `anatablo` set VT_garanti_disi_sebep='"+sebep2+ "',VT_marka='" + marka + "',VT_model='" + model.Text + "',VT_aciklama='" + aciklama + "',VT_referans='" + referans.Text + "' where VT_serial_number='" + id + "'";
            dg_cmd = new MySqlCommand(sql, mysqlbaglan);
  

         try
          {
                mysqlbaglan.Open();
                adapter = new MySqlDataAdapter(dg_cmd);

                adapter.UpdateCommand = mysqlbaglan.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                    log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Listesi Güncelleme", "Güncellenen Seri No: " + seri_no.Text + " ");
                    clearTxts();
                    MessageBox.Show("Başarıyla Güncellendi");
                }

                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }

                retrieve();
            }
            catch 
              { 
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }


        }


        private void delete(string id)
        {

            try
            {
                string resim1_yoket = ""; string resim2_yoket = ""; string resim3_yoket = ""; string video_yoket = "";
                string sql = "SELECT * FROM `anatablo` where `VT_serial_number`='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    resim1_yoket = rdr["VT_resim1_url"].ToString();
                    resim2_yoket = rdr["VT_resim2_url"].ToString();
                    resim3_yoket = rdr["VT_resim3_url"].ToString();
                    video_yoket = rdr["VT_video_url"].ToString();
                }
                else
                {

                }
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }




                sql = "DELETE FROM anatablo WHERE VT_serial_number='" + id + "'";
                dg_cmd = new MySqlCommand(sql, mysqlbaglan);

                mysqlbaglan.Open();

                adapter = new MySqlDataAdapter(dg_cmd);

                adapter.DeleteCommand = mysqlbaglan.CreateCommand();

                adapter.DeleteCommand.CommandText = sql;


                if (MessageBox.Show("Kaydı Silmek istediğine Eminmisin ??", "Silme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (dg_cmd.ExecuteNonQuery() > 0)
                    {
                        if (mysqlbaglan.State == ConnectionState.Open)
                        {
                            mysqlbaglan.Close();
                        }
                        log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Listesi Silme", "Silinen Seri No: " + seri_no.Text + " ");
                        clearTxts();
                        MessageBox.Show("Başarıyla Silindi");

                    }
                    try
                    {

                        dosya_sil(resim1_yoket);
                        dosya_sil(resim2_yoket);
                        dosya_sil(resim3_yoket);
                        dosya_sil(video_yoket);

                    }
                    catch
                    {

                    }

                }
                else
                {
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }

                }
                retrieve();
            }
            catch 
            {
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }

        }


        private void clearTxts()
        {
            seri_no.Text = "";
            referans.Text = "";
            model.Text = "";
            sebep.Text = "";
            aciklama_dg.Text = "";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                seri_no.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sebep.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox7.Text= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                model.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                aciklama_dg.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                referans.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                kyd_gnclle.Enabled = true;
                kyd_sil.Enabled = true;
                aciklama_dg.Enabled = true;
                button8.Enabled = true;
                referans.Enabled = true;
                sebep.Enabled = true;
                model.Enabled = true;
                comboBox7.Enabled = true;
                button11.Enabled = true;

            }
            catch
            {

            }
        }





        private void kyd_gnclle_Click(object sender, EventArgs e)
        {
            try
            { 
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = selected.ToString();

            update(id, comboBox7.Text, sebep.Text, aciklama_dg.Text);
           
                kyd_gnclle.Enabled = false;
                kyd_sil.Enabled = false;
                aciklama_dg.Enabled = false;
                referans.Enabled = false;
                sebep.Enabled = false;
                model.Enabled = false;
                comboBox7.Enabled = false;
            }
            catch
            {

            }
        }

        private void kyd_sil_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = selected.ToString();

            delete(id);
            
            kyd_gnclle.Enabled = false;
            kyd_sil.Enabled = false;
            aciklama_dg.Enabled = false;
            referans.Enabled = false;
            sebep.Enabled = false;
            model.Enabled = false;
            comboBox7.Enabled = false;
        }








        /// //////////////////
        ///   /// //////////////////
        ///     /// //////////////////
        ///       /// //////////////////
        ///         /// //////////////////
        ///           /// ////DATAGRIDVIEW AYAR BITIŞI//////////////
        ///             /// //////////////////
        ///         /// //////////////////
        ///         /// //////////////////
        ///         /// //////////////////
        public string WolfsFade = "0-0-0";
        public MySqlConnection mysqlbaglan { get; set; }
        public string Neof_Wotf { get; set; }
        MySqlCommand dg_cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();

        public string res1, res2, res3, video1 = null;
        Form hakkindaac = new hakkinda();
        public string gercek_yetki { get; set; }
        public string adminadi { get; set; }
        public string ekleyen_ismi_cek { get; set; }
        public secim_form()
        {
           InitializeComponent();
           
                        //// 1 ci DATEGRIDVIEW AYARLARI
                        //DATAGRIDVIEW PROPERTIES
                        dataGridView1.ColumnCount = 8;
                        dataGridView1.Columns[0].Name = "Seri Numarası";
                        dataGridView1.Columns[1].Name = "Garanti Dışı Sebebi";
                        dataGridView1.Columns[2].Name = "Marka";
                        dataGridView1.Columns[3].Name = "Model";
                        dataGridView1.Columns[4].Name = "Tarih";
                        dataGridView1.Columns[5].Name = "Açıklama";
                        dataGridView1.Columns[6].Name = "RN-Referans";
                        dataGridView1.Columns[7].Name = "Ekleyenin Adı";
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.MultiSelect = false;
           
        }

        private void MySQL_ToDatagridview()
        {

        }
       
        /// //////////////////
        private void kullanici_ekle_combobox_1()
        {
            
            
            
                comboBox1.Items.Clear();
                
                comboBox7.Items.Clear();
                comboBox2.Items.Clear();
            // MÜCONUN ADMİN YETKİ ŞOVU BAŞLASIN 26.12.2018 GECE 2:20 AQ
            if (gercek_yetki == "Personel")
            {
                try
                { 
                string komutsatiri = "SELECT yetkili_markalar FROM kullanicilar where kadi='"+adminadi+"'";
                MySqlCommand muconun_yetki_sovu = new MySqlCommand(komutsatiri,mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader sovu_oku = muconun_yetki_sovu.ExecuteReader();
                if (sovu_oku.Read())
                {
                        string TempTr = sovu_oku["yetkili_markalar"].ToString();
                        string[] result = TempTr.Split(',');
                        foreach (string s in result)
                        {
                            if (s.Trim() != "")
                            comboBox1.Items.Add(s);
                            comboBox1.SelectedIndex = 0;
                            comboBox2.Items.Add(s);
                            comboBox2.SelectedIndex = 0;
                            comboBox7.Items.Add(s);
                            comboBox7.SelectedIndex = 0;
                        }
                      
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
           else
            {
                try
                {
                    string komutsatiri = "SELECT marka_ad FROM markalar";

                    MySqlCommand cmd_combobox_doldur = new MySqlCommand(komutsatiri, mysqlbaglan);
                    mysqlbaglan.Open();
                    MySqlDataReader okuyucum = cmd_combobox_doldur.ExecuteReader();

                    while (okuyucum.Read())
                    {
                        comboBox1.Items.Add(okuyucum.GetString("marka_ad"));
                        comboBox2.Items.Add(okuyucum.GetString("marka_ad"));
                        comboBox7.Items.Add(okuyucum.GetString("marka_ad"));

                    }
                  
                    comboBox1.SelectedIndex = 0;
                    comboBox1.SelectedItem = 0;

                    comboBox7.SelectedIndex = 0;
                    comboBox7.SelectedItem = 0;
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
           
        }
        private void seri_listesi_ayarlari_loading()
        {



            dataGridView1.DataSource = null;

            dataGridView1.ColumnCount = 8;
            try
            {
                dataGridView1.Columns[0].Name = "Seri Numarası";
                dataGridView1.Columns[1].Name = "Garanti Dışı Sebebi";
                dataGridView1.Columns[2].Name = "Marka";
                dataGridView1.Columns[3].Name = "Model";
                dataGridView1.Columns[4].Name = "Tarih";
                dataGridView1.Columns[5].Name = "Açıklama";
                dataGridView1.Columns[6].Name = "RN-Referans";
                dataGridView1.Columns[7].Name = "Ekleyenin Adı";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
            }
            catch
            {

            }




            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                int colw = dataGridView1.Columns[i].Width;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = colw;
            }

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        /// <summary>
        ///  garbage collector.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secim_form_Load(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Form form2 = new form_loading();
            form2.Close();
            KodumunFtpininProtokolunuDuzeltme();
            ///  dateTimePicker1.Text = DateTime.Today.ToShortDateString() + DateTime.Today.ToShortTimeString();

            Control.CheckForIllegalCrossThreadCalls = false;

            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10);
            seri_listesi_ayarlari_loading();


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            


            yenilemeaq();
            retrieve();
            kullanici_ekle_combobox_1();
        

            seri_no.ReadOnly = true;
            seri_no.BorderStyle = 0;
            seri_no.BackColor = this.BackColor;
            watermarkimiz.Alignment = ToolStripItemAlignment.Right;

        }
        string[] yetkilerin;
        private void yenilemeaq()
        {
            try
            {
                toolStripStatusLabel1.Text = gercek_yetki + " Girişi Yapıldı";

                toolStripStatusLabel2.Text = " | Tarih: " + DateTime.Today.ToShortDateString() + " | ";
                toolStripStatusLabel4.Text = "Hoşgeldin " + ekleyen_ismi_cek + " |";
                int say = 0;
                mysqlbaglan.Open();
                string kayitsayisi = "SELECT * FROM `anatablo` ";
                MySqlCommand cmd = new MySqlCommand(kayitsayisi, mysqlbaglan);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    say = say + 1;


                }
                toolStripStatusLabel3.Text = "     | Toplam Kayıtlı Cihaz Sayısı: " + say.ToString();
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                kayitsayisi = "select yetkili_markalar FROM kullanicilar where kadi='" + adminadi + "'";
                
               MySqlCommand cmd2 = new MySqlCommand(kayitsayisi, mysqlbaglan);
                mysqlbaglan.Open();
               MySqlDataReader rdr2 = cmd2.ExecuteReader();
                if (rdr2.Read())
                {
                    string gokhan = rdr2["yetkili_markalar"].ToString();
                    yetkilerin = gokhan.Split(',');
                 
                }
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
            }
            catch
            {
                
            }
            if (gercek_yetki == "Personel")
            {
                anaMenüDönToolStripMenuItem.Enabled = false;
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text == " " || textBox1.Text == "" || textBox1.Text == "  " || textBox1.Text == "   ")
            {
                errorProvider2.SetError(textBox1, "Seri Numarası Boş Geçilemez,Lütfen Geçerli Bir Seri Numarası Giriniz.");

                textBox1.Focus();
            }
            else
            {
                if (textBox1.Text.Length < 4)
                {
                    errorProvider2.SetError(textBox1, "Seri Numarası 4 haneden küçük olamaz,Lütfen Geçerli Bir Seri Numarası Giriniz.");
                }
                else
                {
                    textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            richTextBox1.Text = "";
            textBox10.Text = "";
                    try
                    {
                        if (mysqlbaglan.State == ConnectionState.Open)
                        {
                            mysqlbaglan.Close();
                        }
                        mysqlbaglan.Open();
                        string sql = "SELECT * FROM `anatablo` where `VT_serial_number`='" + textBox1.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        if (!rdr.Read())
                        {
                            if (mysqlbaglan.State == ConnectionState.Open)
                            {
                                mysqlbaglan.Close();
                            }
                            MessageBox.Show("Seri Numarası bulunamadı.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            comboBox2.Enabled = false;
                            textBox8.Enabled = false;
                            richTextBox1.Enabled = false;
                            button2.Enabled = false;
                            button4.Enabled = false;
                            button10.Enabled = false;
                            textBox10.Enabled = false;

                        }
                        else
                        {

                            if (gercek_yetki == "SüperAdmin" || gercek_yetki == "Yetkili Personel")
                            {
                                textBox2.Enabled = true;
                                textBox3.Enabled = true;
                                textBox4.Enabled = true;
                                textBox8.Enabled = true;
                                comboBox2.Enabled = true;
                                richTextBox1.Enabled = true;
                                button2.Enabled = true;
                                button4.Enabled = true;
                                button10.Enabled = true;
                                textBox10.Enabled = true;
                                textBox2.Text = rdr["VT_serial_number"].ToString();
                                textBox3.Text = rdr["VT_garanti_disi_sebep"].ToString();
                                comboBox2.Text = rdr["VT_marka"].ToString();
                                textBox4.Text = rdr["VT_model"].ToString();
                                textBox8.Text = rdr["VT_tarih"].ToString();
                                richTextBox1.Text = rdr["VT_aciklama"].ToString();
                                textBox10.Text = rdr["VT_referans"].ToString();
                                if (mysqlbaglan.State == ConnectionState.Open)
                                {
                                    mysqlbaglan.Close();
                                }
                                log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Sorgulama", "Sorgulanan Seri No: " + textBox2.Text + " ");
                            }
                            else if (yetkilerin.Contains(rdr["VT_marka"].ToString()))
                            {
                                textBox2.Enabled = true;
                                textBox3.Enabled = true;
                                textBox4.Enabled = true;
                                textBox8.Enabled = true;
                                comboBox2.Enabled = true;
                                richTextBox1.Enabled = true;
                                button2.Enabled = true;
                                button4.Enabled = true;
                                button10.Enabled = true;
                                textBox10.Enabled = true;
                                textBox2.Text = rdr["VT_serial_number"].ToString();
                                textBox3.Text = rdr["VT_garanti_disi_sebep"].ToString();
                                comboBox2.Text = rdr["VT_marka"].ToString();
                                textBox4.Text = rdr["VT_model"].ToString();
                                textBox8.Text = rdr["VT_tarih"].ToString();
                                richTextBox1.Text = rdr["VT_aciklama"].ToString();
                                textBox10.Text = rdr["VT_referans"].ToString();
                                if (mysqlbaglan.State == ConnectionState.Open)
                                {
                                    mysqlbaglan.Close();
                                }
                                log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Sorgulama", "Sorgulanan Seri No: " + textBox2.Text + " ");
                            }
                            else
                            {
                                if (mysqlbaglan.State == ConnectionState.Open)
                                {
                                    mysqlbaglan.Close();
                                }
                                MessageBox.Show("Girdiğiniz seri numarası yetkiniz dışında bir markaya ait.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Yetkisiz Sorgulama", "Yetkisiz Sorgulanan Seri No: " + textBox1.Text + " ");
                            }


                        }
                        rdr.Close();
                      
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
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                mysqlbaglan.Open();
                string guncelle = "update `anatablo` set VT_serial_number=@sn,VT_garanti_disi_sebep=@sebep,VT_marka=@marka,VT_model=@model,VT_tarih=@tarih,VT_aciklama=@aciklama,VT_referans=@referans where VT_serial_number=@serinomain";
                MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                guncel.Parameters.AddWithValue("@sn", textBox2.Text);
                guncel.Parameters.AddWithValue("@sebep", textBox3.Text);
                guncel.Parameters.AddWithValue("@marka", comboBox2.Text);
                guncel.Parameters.AddWithValue("@model", textBox4.Text);
                guncel.Parameters.AddWithValue("@tarih", textBox8.Text);
                guncel.Parameters.AddWithValue("@aciklama", richTextBox1.Text);
                guncel.Parameters.AddWithValue("@referans", textBox10.Text);
                guncel.Parameters.AddWithValue("@serinomain", textBox2.Text);
                guncel.ExecuteNonQuery();
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Kayıt Güncelleme", "Güncelllenen Seri No: " + textBox2.Text + " ");
                MessageBox.Show("Bilgiler Güncellendi.");
                
            }
            catch
            {
                MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                if (textBox7.Text == "" || textBox7.Text == " " || textBox7.Text == "  "|| textBox7.Text == "   " || textBox7.Text == "    ")
            {
                errorProvider2.SetError(textBox7, "Seri Numarası Boş Geçilemez,Lütfen Geçerli Bir Seri Numarası Giriniz.");

                textBox7.Focus();
            }
            else
            {
                if (textBox7.Text.Length < 4)
                {
                    errorProvider2.SetError(textBox7, "Seri Numarası 4 haneden küçük olamaz,Lütfen Geçerli Bir Seri Numarası Giriniz.");
                }
                else
                {
                    errorProvider2.Clear();
              try
              {
                    mysqlbaglan.Open();
                    string guncelle = "SELECT * FROM `anatablo` where `VT_serial_number`='" + textBox7.Text + "'";
                    MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
                    MySqlDataReader rdr = guncel.ExecuteReader();
                    if (rdr.Read())
                    {
                            if (mysqlbaglan.State == ConnectionState.Open)
                            {
                                mysqlbaglan.Close();
                            }
                            MessageBox.Show("Seri numarası zaten kayıtlı. Farklı bir seri numarası girin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox7.Focus();
                    }
                    else
                    {
                        progressBar1.Visible = true;
                        label19.Visible = true;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                            if (mysqlbaglan.State == ConnectionState.Open)
                            {
                                mysqlbaglan.Close();
                            }
                            Task.Run(() => Upload());




                    }




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
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                textBox9.Enabled = true;
            }
            else
            {
                textBox9.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ResimKirpmaMotoru form_resimekle = new ResimKirpmaMotoru();
                form_resimekle.resimyolu1 = ofd.FileName;
                form_resimekle.sec = 1;
                form_resimekle.Show();
                form_resimekle.Visible = false;
                form_resimekle.ShowDialog();

            }

        }


        OpenFileDialog ofd;


        private void button6_Click(object sender, EventArgs e)
        {

            ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;||*.jpeg;*.gif;*.png;*.bmp;*.tiff";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ResimKirpmaMotoru form_resimekle = new ResimKirpmaMotoru();
                form_resimekle.resimyolu1 = ofd.FileName;
                form_resimekle.sec = 2;

                form_resimekle.Show();
                form_resimekle.Visible = false;
                form_resimekle.ShowDialog();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpeg;*.jpg;*.gif;*.png;*.bmp;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ResimKirpmaMotoru form_resimekle = new ResimKirpmaMotoru();
                form_resimekle.resimyolu1 = ofd.FileName;
                form_resimekle.sec = 3;
                form_resimekle.Show();
                form_resimekle.Visible = false;
                form_resimekle.ShowDialog();
            }

        }
        private void Upload(/*string seri_no_eklemesi_ftp*/ )
        {
            
            try
          {




                string n;
                //// Resim 1
                progressBar1.Value = 0;
                res1 = Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + "1" + ".jpg";
                if (this.label15.Text == "Resim 1: (Seçildi)")
                {
                    n = "1";

                    this.label19.Text = "Seçtiğiniz " + n + ". Resim Yükleniyor...";

                 try
                    {

              



                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + n + ".jpg");
                        request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.ServicePoint.Expect100Continue = false;
                        request.KeepAlive = true;
                        request.EnableSsl = false;
                        res1 = Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + n + ".jpg";

                        using (Stream fileStream = File.OpenRead(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"resim" + n + ".jpg"))

                        using (Stream ftpStream = request.GetRequestStream())
                        {

                            progressBar1.Invoke(
                                            (MethodInvoker)delegate { progressBar1.Maximum = (int)fileStream.Length; });

                            byte[] buffer = new byte[10240];
                            int read;
                            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ftpStream.Write(buffer, 0, read);
                                progressBar1.Invoke(
                                    (MethodInvoker)delegate
                                    {
                                        progressBar1.Value = (int)fileStream.Position;
                                        progressBar1.Refresh();
                                        label19.Refresh();

                                    });

                            }
                           ftpStream.Close();
                        fileStream.Close();
                        

                    }
                }

                    catch
                    {




                    }
                    
                }
                //// 1 bitiş 
                progressBar1.Value = 0;

                /////// Resim 2
                res2 = Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + "2" + ".jpg";
                if (this.label9.Text == "Resim 2: (Seçildi)")
                {

                    n = "2";
                    this.label19.Text = "Seçtiğiniz " + n + ". Resim Yükleniyor...";

                  try
                    {
                    




                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + n + ".jpg");
                        request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.ServicePoint.Expect100Continue = false;
                        request.KeepAlive = true;
                        request.EnableSsl = false;
                        res2 = Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + n + ".jpg";
                        using (Stream fileStream = File.OpenRead(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"resim" + n + ".jpg"))

                        using (Stream ftpStream = request.GetRequestStream())
                        {

                            progressBar1.Invoke(
                                            (MethodInvoker)delegate { progressBar1.Maximum = (int)fileStream.Length; });

                            byte[] buffer = new byte[10240];
                            int read;
                            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ftpStream.Write(buffer, 0, read);
                                progressBar1.Invoke(
                                    (MethodInvoker)delegate
                                    {
                                        progressBar1.Value = (int)fileStream.Position;
                                        progressBar1.Refresh();
                                        label19.Refresh();
                                    });

                            }
                             ftpStream.Close();
                        fileStream.Close();
                       
                    }
                   }

                    catch
                    {



                    } 

                }
                //// 2 bitiş 
                progressBar1.Value = 0;
                /////// Resim 3
                res3 = Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + "3" + ".jpg";
                if (this.label10.Text == "Resim 3: (Seçildi)")
                {
                    n = "3";
                    this.label19.Text = "Seçtiğiniz " + n + ". Resim Yükleniyor...";

                   try
                   {





                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + n + ".jpg");
                        request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.ServicePoint.Expect100Continue = false;
                        request.KeepAlive = true;
                        request.EnableSsl = false;
                        res3 = Neof_Wotf + "/resimler/" + textBox7.Text + "_" + "resim" + n + ".jpg";

                    using (Stream fileStream = File.OpenRead(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\"+"resim" + n + ".jpg"))

                    using (Stream ftpStream = request.GetRequestStream())
                    {

                        progressBar1.Invoke(
                                        (MethodInvoker)delegate { progressBar1.Maximum = (int)fileStream.Length; });

                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ftpStream.Write(buffer, 0, read);
                            progressBar1.Invoke(
                                (MethodInvoker)delegate
                                {
                                    progressBar1.Value = (int)fileStream.Position;
                                    label19.Refresh();
                                });

                        }



                    ftpStream.Close();
                    fileStream.Close();
                   
                }
                 
                   }catch
                    {



                    }
                    
                }
                //// 3 bitiş 
                /// video başlangıç
                progressBar1.Value = 0;
                this.label19.Text = "Seçtiğiniz Resimler Yüklendi Sırada video var.";
                if (this.label20.Text == "Video: (Seçildi)")
                {
                    n = "3";
                    this.label19.Text = "Seçtiğiniz Video Yükleniyor...";

                    try
                    {





                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Neof_Wotf + "/videolar/" + textBox7.Text + "_" + "video" + Path.GetExtension(videodeneme) + "");
                        request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.ServicePoint.Expect100Continue = false;
                        request.EnableSsl = false;
                        request.KeepAlive = true;
                        video1 = Neof_Wotf + "/videolar/" + textBox7.Text + "_" + "video" + Path.GetExtension(videodeneme) + "";
                        using (Stream fileStream = File.OpenRead(videodeneme))

                        using (Stream ftpStream = request.GetRequestStream())
                        {

                            progressBar1.Invoke(
                                            (MethodInvoker)delegate { progressBar1.Maximum = (int)fileStream.Length; });

                            byte[] buffer = new byte[10240];
                            int read;
                            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ftpStream.Write(buffer, 0, read);
                                progressBar1.Invoke(
                                    (MethodInvoker)delegate
                                    {
                                        progressBar1.Value = (int)fileStream.Position;
                                        label19.Refresh();
                                    });

                            }


                        }
                    }

                    catch
                    {




                    }



                }
                progressBar1.Value = 0;
                this.label19.Text = "Dosyalar Sunucuya yüklendi - Şimdi Veritabanına kaydediliyor.";
                //// VERİ TABANINA Kayıt GİRİŞi
                try
                {
                    mysqlbaglan.Open();
                    string guncelle = "insert into anatablo(VT_serial_number,VT_garanti_disi_sebep,VT_marka,VT_model,VT_tarih,VT_aciklama,VT_referans,ekleyenin_adi,VT_resim1_url,VT_resim2_url,VT_resim3_url,VT_video_url) values (@sn,@sebep,@marka,@model,@tarih,@aciklama,@referans,@ekleyen,@res1,@res2,@res3,@video1)";
                    MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);

                    guncel.Parameters.AddWithValue("@sn", textBox7.Text);
                    if (radioButton1.Checked == true)
                    {
                        guncel.Parameters.AddWithValue("@sebep", radioButton1.Text.ToString());
                    }
                    else if (radioButton2.Checked == true)
                    {
                        guncel.Parameters.AddWithValue("@sebep", radioButton2.Text.ToString());
                    }
                    else if (radioButton3.Checked == true)
                    {
                        guncel.Parameters.AddWithValue("@sebep", radioButton3.Text.ToString());
                    }
                    else if (radioButton4.Checked == true)
                    {
                        guncel.Parameters.AddWithValue("@sebep", radioButton4.Text.ToString());
                    }
                    else if (radioButton5.Checked == true)
                    {
                        guncel.Parameters.AddWithValue("@sebep", textBox9.Text.ToString());
                    }
                    else
                    {
                        guncel.Parameters.AddWithValue("@sebep", textBox9.Text.ToString());
                    }
                    guncel.Parameters.AddWithValue("@marka", comboBox1.Text);
                    guncel.Parameters.AddWithValue("@model", textBox6.Text);
                    guncel.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
                    guncel.Parameters.AddWithValue("@aciklama", richTextBox2.Text);
                    guncel.Parameters.AddWithValue("@referans", textBox5.Text);
                    guncel.Parameters.AddWithValue("@ekleyen", ekleyen_ismi_cek);
                    guncel.Parameters.AddWithValue("@res1", res1);
                    guncel.Parameters.AddWithValue("@res2", res2);
                    guncel.Parameters.AddWithValue("@res3", res3);
                    guncel.Parameters.AddWithValue("@video1", video1);
                    guncel.ExecuteNonQuery();
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                    this.label19.Text = "Dosyalarınız Yüklendi ve Veriler Veritabanına işlendi.";
                    log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Yeni Cihaz Kaydı Eklendi", "Eklenen Seri No: " + textBox7.Text + " ");
                    textBox7.Clear();
                    textBox6.Clear();
                    textBox5.Clear();
                    ////  dateTimePicker1.Text = DateTime.Today.ToShortDateString() + DateTime.Today.ToShortTimeString();
                    richTextBox2.Clear();
                    radioButton5.Checked = true;
                    textBox9.Text = "Belirtilmemiş";
                    textBox1.Clear();
                    res1 = null; res2 = null; res3 = null; video1 = null;
                    WolfsFade = "0-0-0";
                    video_temizle();
                    label15.Text = "Resim 1:";
                    label9.Text = "Resim 2:";
                    label10.Text = "Resim 3:";
                    errorProvider2.Clear();
                    yenilemeaq();
                    MessageBox.Show("Başarılı... Seri Numarası Veritabanına Eklendi.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox8.Text = "";
                    comboBox2.Text = "";
                    richTextBox1.Text = "";
                    textBox10.Text = "";
                    button2.Enabled = false;
                    button4.Enabled = false;
                    button10.Enabled = false;
                }
                catch
                {
                    if (mysqlbaglan.State == ConnectionState.Open)
                    {
                        mysqlbaglan.Close();
                    }
                    MessageBox.Show("HATA ! Seri numarası zaten kayıtlı. Farklı bir seri numarası girin.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           }
            catch
            {
                MessageBox.Show("İnternet bağlantınızı kontrol ediniz.", "LmR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                progressBar1.Visible = false; ;
                label19.Visible = false; ;
            }
            finally
            {

            }
            
            progressBar1.Value = 0;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            progressBar1.Visible = false; ;
            label19.Visible = false; ;
            try { retrieve(); }
            catch { }

        }


        public string videodeneme = null;
        public string cikisa_don_mizer;
        private void secim_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Sorgulama", "Anamenü Dönüş");
            System.IO.DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath().ToString() + @"\gecicibellek\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }


             DialogResult = DialogResult.OK;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Resim/Göster/Ekle/Düzenle/Sil", "Girilen Seri No: " + textBox2.Text + " ");
            string seri_aktarim = textBox2.Text;
            resim_goster_duzenle form_resimgosterduzenle = new resim_goster_duzenle();
            form_resimgosterduzenle.mysqlbaglan = mysqlbaglan;
            form_resimgosterduzenle.veriyolu = seri_aktarim;
            form_resimgosterduzenle.eG80LPJJCimP = eG80LPJJCimP;
            form_resimgosterduzenle.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
            form_resimgosterduzenle.Neof_Wotf = Neof_Wotf;
            form_resimgosterduzenle.Visible = false;
            form_resimgosterduzenle.ShowDialog();
           
        }

        private void programKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Çıkış Yapıldı.", "Çıkış Yapıldı.");
            Environment.Exit(1);
        }



        private void programAyarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkindaac.Show();
            hakkindaac.Visible = false;
            hakkindaac.ShowDialog();
        }

        public string videodenemepart = null;
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Video Dosyaları|*.mp4;*.m4v;*.mov;*.mpg;*.mpeg;*.avi;*.asf;*.flv;*.swi;*.swf;*.amv;*.mkv;*.webm;*.3gpp;*.3gp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    videodeneme = ofd.FileName;

                    this.label20.Text = "Video: (Seçildi)";

                }
            }
            catch
            {

            }
        }
        private void video_temizle()
        {
            videodeneme = null; ;
            videodenemepart = null; ;
            this.label20.Text = "Video:";
        }
        private static void KodumunFtpininProtokolunuDuzeltme()
        {
            Type requestType = typeof(FtpWebRequest);
            FieldInfo methodInfoField = requestType.GetField("m_MethodInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            Type methodInfoType = methodInfoField.FieldType;


            FieldInfo knownMethodsField = methodInfoType.GetField("KnownMethodInfo", BindingFlags.Static | BindingFlags.NonPublic);
            Array knownMethodsArray = (Array)knownMethodsField.GetValue(null);

            FieldInfo flagsField = methodInfoType.GetField("Flags", BindingFlags.NonPublic | BindingFlags.Instance);

            int MustChangeWorkingDirectoryToPath = 0x100;
            foreach (object knownMethod in knownMethodsArray)
            {
                int flags = (int)flagsField.GetValue(knownMethod);
                flags |= MustChangeWorkingDirectoryToPath;
                flagsField.SetValue(knownMethod, flags);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                errorProvider1.SetError(textBox1, "Seri Numarası Boş Geçilemez,Lütfen Geçerli Bir Seri Numarası Giriniz.");
            }
            else
            {
                errorProvider1.Clear();

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox1.Text == " ")
            {
                errorProvider2.SetError(textBox7, "Seri Numarası Boş Geçilemez,Lütfen Geçerli Bir Seri Numarası Giriniz.");
                textBox7.Focus();
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox1.Text == " ")
            {
                errorProvider2.SetError(textBox7, "Seri Numarası Boş Geçilemez,Lütfen Geçerli Bir Seri Numarası Giriniz.");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string resim1_yoket = ""; string resim2_yoket = ""; string resim3_yoket = ""; string video_yoket = "";
            try
            {
                string sql = "SELECT * FROM `anatablo` where `VT_serial_number`='" + textBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    resim1_yoket = rdr["VT_resim1_url"].ToString();
                    resim2_yoket = rdr["VT_resim2_url"].ToString();
                    resim3_yoket = rdr["VT_resim3_url"].ToString();
                    video_yoket = rdr["VT_video_url"].ToString();
                }
                else
                {

                }
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                mysqlbaglan.Open();
                string guncelle = "delete from `anatablo` where VT_serial_number=@sn";
                MySqlCommand guncel = new MySqlCommand(guncelle, mysqlbaglan);
                guncel.Parameters.AddWithValue("@sn", textBox2.Text);
                guncel.ExecuteNonQuery();
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    mysqlbaglan.Close();
                }
                try
                {
                    dosya_sil(resim1_yoket);
                    dosya_sil(resim2_yoket);
                    dosya_sil(resim3_yoket);
                    dosya_sil(video_yoket);
                    yenilemeaq();
                }
                catch
                {

                }
                log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Seri Kayıt Silme", "Silinen Seri No: " + textBox2.Text + " ");
                MessageBox.Show("Seri no veritabanından Silindi.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox2.Text = "";
                textBox8.Text = "";
                richTextBox1.Text = "";
                button10.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
     
               

            }
            catch
            {
                MessageBox.Show("İnternet bağlantısı yok.", "LMR - Mizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dosya_sil(string url)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(eG80LPJJCimP, Id4SGF8YIcyg9y);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.ServicePoint.Expect100Continue = false;
                request.KeepAlive = true;
                request.EnableSsl = false;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
               
                response.Close();
            }



            catch
            {


            }
        }


        private void yenile_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

      
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

       
      

    

       

       
      
        private void watermarkimiz_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.letmerepair.com/");
        }

    

        private void tabControl1_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            parca_ekle_basarili yeniformparcaeklebasarili = new parca_ekle_basarili();
            yeniformparcaeklebasarili.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void stok_ekle_Click(object sender, EventArgs e)
        {
            parca_ekle_basarili parca_ekle_basarili_ac = new parca_ekle_basarili();
            parca_ekle_basarili_ac.ShowDialog();
        }

        private void programAyarlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
        private void anaMenüDönToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;




        }
        private void sa_s_marka_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = string.Concat(textBox1.Text.Where(char.IsLetterOrDigit));
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(textBox7.Text.Where(char.IsLetterOrDigit));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Resim/Göster/Ekle/Düzenle/Sil", "Girilen Seri No: " + seri_no.Text + " ");
            string seri_aktarim = seri_no.Text;
            resim_goster_duzenle form_resimgosterduzenle = new resim_goster_duzenle();
            form_resimgosterduzenle.mysqlbaglan = mysqlbaglan;
            form_resimgosterduzenle.veriyolu = seri_aktarim;
            form_resimgosterduzenle.eG80LPJJCimP = eG80LPJJCimP;
            form_resimgosterduzenle.Id4SGF8YIcyg9y = Id4SGF8YIcyg9y;
            form_resimgosterduzenle.Neof_Wotf = Neof_Wotf;
            form_resimgosterduzenle.Visible = false;
            form_resimgosterduzenle.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = seri_no.Text;
            tabControl1.SelectedTab = tabPage1;
            textBox1.Focus();
           
            button1_Click(null,null);
        }

        private void secim_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

      

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_gonder(adminadi, ekleyen_ismi_cek, "Garanti Dışı", "Çıkış Yapıldı.", "Çıkış Yapıldı.");
        cikisa_don_mizer = "Evet";
             DialogResult = DialogResult.OK;
        }

        private void şifreDeğişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifre_degistir sifredegistir = new sifre_degistir();
            sifredegistir.mysqlbaglan = mysqlbaglan;
            sifredegistir.aktarmaotobusu = adminadi; 
            sifredegistir.ShowDialog();



        }

    }
}
