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
    public partial class satis_urun_ekle_SirtueX : Form
    {
        public satis_urun_ekle_SirtueX()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            satis_urun_ekle_liste_SirtueX satis_urun_ekle_liste_ac = new satis_urun_ekle_liste_SirtueX();
            satis_urun_ekle_liste_ac.mysqlbaglan = mysqlbaglan;
            var result = satis_urun_ekle_liste_ac.ShowDialog();
            if (result == DialogResult.OK)
            {
                urun_adi_gir.Text = satis_urun_ekle_liste_ac.urun_adi;
                urun_listesi_combosu.Text = satis_urun_ekle_liste_ac.urun_kodu;
                urun_tipi_gir.Text = satis_urun_ekle_liste_ac.urun_tipi;
                stok_gir.Text = satis_urun_ekle_liste_ac.urun_stok;
                birim_fiyati_gir.Text = satis_urun_ekle_liste_ac.urun_fiyat;
            }
        }

        private void satis_urun_ekle_SirtueX_Load(object sender, EventArgs e)
        {
            duzenle_den_mi();
            urun_listesi_combosu.Items.Clear();
            var culture = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            try
            {
                string carikomut = "select * FROM urunler";
                MySqlCommand cmd_combobox_cari_doldur = new MySqlCommand(carikomut, mysqlbaglan);
                mysqlbaglan.Open();
                MySqlDataReader okuyucum_cari = cmd_combobox_cari_doldur.ExecuteReader();
                while (okuyucum_cari.Read())
                {
                    urun_listesi_combosu.Items.Add(okuyucum_cari.GetString("urun_kodu"));
                }
                mysqlbaglan.Close();

            }
            catch
            {
                mysqlbaglan.Close();
            }
        }

        private void birim_fiyati_gir_TextChanged(object sender, EventArgs e)
        {
            fiyat_degis();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fiyat_degis();
        }
        private void fiyat_degis()
        {
            try
            {
                double birim = Convert.ToDouble(adet_gir.Value);
                double fiyat = Convert.ToDouble(birim_fiyati_gir.Text);
                double kdv = Convert.ToDouble(kdv_gir.Value);
                double indirim = Convert.ToDouble(indirim_gir.Value);
                double toplam = 0;
                double kdv_toplam = 0;
                double indirim_toplam = 0;
                if (checkBox3.Checked == false)
                {
                    if (checkBox2.Checked == true)
                    {
                        toplam = ((fiyat * birim));
                        urun_ekle_toplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        urun_ekle_toplam2.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        kdv_toplam = toplam * (kdv / 100);
                        urun_ekle_kdv.Text = Math.Round(kdv_toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        toplam = toplam + kdv_toplam;
                        indirim_yansit.Text = "0,00";
                        urun_ekle_Gtoplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");


                    }
                    else
                    {
                        toplam = ((fiyat * birim));
                        urun_ekle_toplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        urun_ekle_toplam2.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        urun_ekle_Gtoplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        indirim_yansit.Text = "0,00";
                        urun_ekle_kdv.Text = "0,00";
                    }
                }
                else
                {
                    if (checkBox2.Checked == true)
                    {
                        toplam = ((fiyat * birim));
                        urun_ekle_toplam2.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        indirim_toplam = toplam * (indirim / 100);
                        toplam = toplam - indirim_toplam;
                        indirim_yansit.Text = Math.Round(indirim_toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        urun_ekle_toplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        kdv_toplam = toplam * (kdv / 100);
                        urun_ekle_kdv.Text = Math.Round(kdv_toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        toplam = toplam + kdv_toplam;

                        urun_ekle_Gtoplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");


                    }
                    else
                    {
                        toplam = ((fiyat * birim));
                        urun_ekle_toplam2.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        indirim_toplam = toplam * (indirim / 100);
                        toplam = toplam - indirim_toplam;
                        urun_ekle_toplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        indirim_yansit.Text = Math.Round(indirim_toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        urun_ekle_Gtoplam.Text = Math.Round(toplam, 2, MidpointRounding.AwayFromZero).ToString(".00");
                        urun_ekle_kdv.Text = "0,00";
                    }
                }
            }
            catch
            {

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            fiyat_degis();
        }
        string neo_tl;
        private void birim_fiyati_gir_Leave(object sender, EventArgs e)
        {
            try
            {
                neo_tl = birim_fiyati_gir.Text.Replace("R₺", "");
                birim_fiyati_gir.Text = string.Format("{0:N}", Convert.ToDouble(neo_tl));
            }
            catch { }
        }

        private void birim_fiyati_gir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
       public MySqlConnection mysqlbaglan { get; set; }
        private void urun_kodu_gir_Leave(object sender, EventArgs e)
        {
            try
            { 
            string sql = "select * from urunler where urun_kodu='" + urun_listesi_combosu.Text + "'";
            MySqlCommand sqloynat = new MySqlCommand(sql, mysqlbaglan);
            mysqlbaglan.Open();
            MySqlDataReader dr = sqloynat.ExecuteReader();
            if (dr.Read())
            {
                urun_tipi_gir.Text = dr["urun_tur"].ToString();
                urun_adi_gir.Text = dr["urun_ismi"].ToString();
                stok_gir.Text = dr["urun_stok_durumu"].ToString();
                birim_fiyati_gir.Text = dr["urun_fiyati"].ToString();
                bildiri_urun.Text = "";
                stokdan_dus_cenmi.Checked = true;
                stokdan_dus_cenmi.Enabled = true;

            }
            else
            {
                urun_tipi_gir.Text = "";
                urun_adi_gir.Text = "";
                stok_gir.Text = "";
                birim_fiyati_gir.Text = "";
                bildiri_urun.Text = "Ürün Kodu bulunamadı. Yeni Oluşturulcak";
                stok_gir.Text = "N/A";
                birim_fiyati_gir.Text = "0,00";
                stokdan_dus_cenmi.Checked = false;
                stokdan_dus_cenmi.Enabled = false;

            }
            mysqlbaglan.Close();
            }
            catch
            {
                mysqlbaglan.Close();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label14.Visible = true;
                indirim_gir.Enabled = true;
                fiyat_degis();
            }
            else
            {
                label14.Visible = false;
                indirim_gir.Enabled = false; ;
                fiyat_degis();
                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                kdv_gir.Enabled = true;
                fiyat_degis();
            }
            else
            {
                kdv_gir.Enabled = false;
                fiyat_degis();
            }
        }

        private void kdv_gir_ValueChanged(object sender, EventArgs e)
        {
            fiyat_degis();
        }

        private void indirim_gir_ValueChanged(object sender, EventArgs e)
        {
            fiyat_degis();
        }

        private void urun_listesi_combosu_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void urun_listesi_combosu_SelectedValueChanged(object sender, EventArgs e)
        {
            urun_kodu_gir_Leave(null, null);
        }

        public string geri_urun_kodu { get; set; }
        public string geri_urun_ismi { get; set; }
        public string geri_urun_turu { get; set; }
        public string geri_urun_adet { get; set; }
        public string geri_urun_fiyat { get; set; }
        public string geri_urun_toplam { get; set; }
        public string geri_urun_kdv { get; set; }
        public string geri_urun_indirim { get; set; }
        public string geri_urun_genel_toplam { get; set; }
        public string stok_duscenmi { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                if(indirim_gir.Value == 0)
                {
                    this.geri_urun_fiyat = birim_fiyati_gir.Text;
                }
                else
                {
                    double yuzde_mizde = Convert.ToDouble(birim_fiyati_gir.Text);
                    yuzde_mizde =yuzde_mizde - ((yuzde_mizde * Convert.ToDouble(indirim_gir.Value)) / 100);
                    this.geri_urun_fiyat = Math.Round(yuzde_mizde, 2, MidpointRounding.AwayFromZero).ToString(".00");
                }
            }
            else
            {
                this.geri_urun_fiyat = birim_fiyati_gir.Text;
            }
            this.geri_urun_kodu = urun_listesi_combosu.Text;
            this.geri_urun_ismi = urun_adi_gir.Text;
            this.geri_urun_turu = urun_tipi_gir.Text;
            this.geri_urun_adet = adet_gir.Value.ToString();
         /// birim fiyatı burdan aldık alında olsun unutim deme sakın :DDD iyice şizofren olduk aq
            this.geri_urun_toplam = urun_ekle_toplam.Text;
            this.geri_urun_kdv = urun_ekle_kdv.Text;
            this.geri_urun_indirim = indirim_yansit.Text;
            this.geri_urun_genel_toplam = urun_ekle_Gtoplam.Text;
            if (stokdan_dus_cenmi.Checked==true)
            {
                this.stok_duscenmi = "Evet";
            }
            else
            {
                this.stok_duscenmi = "Hayır";
            }

            this.DialogResult = DialogResult.OK;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Boolean duzenle_boolen {get;set; }
        private void duzenle_den_mi()
        {
           if (duzenle_boolen)
            {
                urun_listesi_combosu.Text = this.geri_urun_kodu;
                 urun_adi_gir.Text = this.geri_urun_ismi;
                urun_tipi_gir.Text = this.geri_urun_turu;
                adet_gir.Value = Convert.ToInt16(this.geri_urun_adet);
                birim_fiyati_gir.Text = this.geri_urun_fiyat;
                urun_ekle_toplam.Text = this.geri_urun_toplam;
                urun_ekle_kdv.Text = this.geri_urun_kdv;
                indirim_yansit.Text = this.geri_urun_indirim;
                urun_ekle_Gtoplam.Text = this.geri_urun_genel_toplam;
            }
        }

        private void indirim_gir_KeyPress(object sender, KeyPressEventArgs e)
        {
            fiyat_degis();
        }

        private void kdv_gir_KeyPress(object sender, KeyPressEventArgs e)
        {
            fiyat_degis();
        }

        private void indirim_gir_KeyUp(object sender, KeyEventArgs e)
        {
            fiyat_degis();
        }

        private void kdv_gir_KeyUp(object sender, KeyEventArgs e)
        {
            fiyat_degis();
        }

        private void adet_gir_KeyPress(object sender, KeyPressEventArgs e)
        {
            fiyat_degis();
        }

        private void adet_gir_KeyUp(object sender, KeyEventArgs e)
        {
            fiyat_degis();
        }
    }
}
