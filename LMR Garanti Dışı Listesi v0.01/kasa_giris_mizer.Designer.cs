namespace LMR_Process_Vortex
{
    partial class kasa_giris_mizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kasa_giris_mizer));
            this.panel5 = new System.Windows.Forms.Panel();
            this.evrak_no = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fiyat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.aciklama = new System.Windows.Forms.RichTextBox();
            this.iptal = new System.Windows.Forms.Button();
            this.stok_ekle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tarih_yenile = new System.Windows.Forms.Button();
            this.fatura_tarihi_gir = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.odeme_tipi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.evrak_no);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(12, 187);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(195, 86);
            this.panel5.TabIndex = 32;
            // 
            // evrak_no
            // 
            this.evrak_no.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.evrak_no.Location = new System.Drawing.Point(43, 34);
            this.evrak_no.Name = "evrak_no";
            this.evrak_no.Size = new System.Drawing.Size(100, 23);
            this.evrak_no.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(54, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Evrak No";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.fiyat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 84);
            this.panel1.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TL";
            // 
            // fiyat
            // 
            this.fiyat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fiyat.Location = new System.Drawing.Point(43, 46);
            this.fiyat.Name = "fiyat";
            this.fiyat.Size = new System.Drawing.Size(98, 26);
            this.fiyat.TabIndex = 6;
            this.fiyat.Text = "0,00";
            this.fiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fiyat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fiyat_KeyPress);
            this.fiyat.Leave += new System.EventHandler(this.fiyat_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(78, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tutar";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.aciklama);
            this.panel4.Location = new System.Drawing.Point(15, 352);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(195, 88);
            this.panel4.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(68, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Açıklama";
            // 
            // aciklama
            // 
            this.aciklama.Location = new System.Drawing.Point(34, 25);
            this.aciklama.Name = "aciklama";
            this.aciklama.Size = new System.Drawing.Size(123, 51);
            this.aciklama.TabIndex = 3;
            this.aciklama.Text = "Kasaya Giriş Yapıldı.";
            // 
            // iptal
            // 
            this.iptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptal.Location = new System.Drawing.Point(135, 446);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(72, 36);
            this.iptal.TabIndex = 29;
            this.iptal.Text = "İptal";
            this.iptal.UseVisualStyleBackColor = true;
            this.iptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // stok_ekle
            // 
            this.stok_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.stok_ekle.Location = new System.Drawing.Point(11, 446);
            this.stok_ekle.Name = "stok_ekle";
            this.stok_ekle.Size = new System.Drawing.Size(102, 36);
            this.stok_ekle.TabIndex = 27;
            this.stok_ekle.Text = "Kasa Girişi";
            this.stok_ekle.UseVisualStyleBackColor = true;
            this.stok_ekle.Click += new System.EventHandler(this.stok_ekle_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tarih_yenile);
            this.panel3.Controls.Add(this.fatura_tarihi_gir);
            this.panel3.Location = new System.Drawing.Point(11, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 57);
            this.panel3.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(79, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 221;
            this.label3.Text = "Tarih";
            // 
            // tarih_yenile
            // 
            this.tarih_yenile.Image = ((System.Drawing.Image)(resources.GetObject("tarih_yenile.Image")));
            this.tarih_yenile.Location = new System.Drawing.Point(168, 28);
            this.tarih_yenile.Name = "tarih_yenile";
            this.tarih_yenile.Size = new System.Drawing.Size(22, 22);
            this.tarih_yenile.TabIndex = 220;
            this.tarih_yenile.UseVisualStyleBackColor = true;
            this.tarih_yenile.Click += new System.EventHandler(this.tarih_yenile_Click);
            // 
            // fatura_tarihi_gir
            // 
            this.fatura_tarihi_gir.CustomFormat = "dd/MM/yyyy HH:mm";
            this.fatura_tarihi_gir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fatura_tarihi_gir.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fatura_tarihi_gir.Location = new System.Drawing.Point(3, 29);
            this.fatura_tarihi_gir.Name = "fatura_tarihi_gir";
            this.fatura_tarihi_gir.Size = new System.Drawing.Size(159, 21);
            this.fatura_tarihi_gir.TabIndex = 219;
            this.fatura_tarihi_gir.Value = new System.DateTime(2019, 2, 24, 11, 57, 6, 0);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.odeme_tipi);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(11, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 84);
            this.panel2.TabIndex = 26;
            // 
            // odeme_tipi
            // 
            this.odeme_tipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.odeme_tipi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.odeme_tipi.FormattingEnabled = true;
            this.odeme_tipi.Items.AddRange(new object[] {
            "Peşin",
            "Kredi Kartı",
            "Havale"});
            this.odeme_tipi.Location = new System.Drawing.Point(36, 48);
            this.odeme_tipi.Name = "odeme_tipi";
            this.odeme_tipi.Size = new System.Drawing.Size(121, 22);
            this.odeme_tipi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(55, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ödeme Tipi";
            // 
            // kasa_giris_mizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(221, 504);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.iptal);
            this.Controls.Add(this.stok_ekle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kasa_giris_mizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kasa Girişi - Process Vortex";
            this.Load += new System.EventHandler(this.kasa_giris_mizer_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox evrak_no;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fiyat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox aciklama;
        private System.Windows.Forms.Button iptal;
        private System.Windows.Forms.Button stok_ekle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tarih_yenile;
        private System.Windows.Forms.DateTimePicker fatura_tarihi_gir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox odeme_tipi;
        private System.Windows.Forms.Label label1;
    }
}