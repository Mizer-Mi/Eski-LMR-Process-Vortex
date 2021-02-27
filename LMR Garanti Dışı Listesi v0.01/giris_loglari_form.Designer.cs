namespace LMR_Process_Vortex
{
    partial class giris_loglari_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(giris_loglari_form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.watermarkimiz = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anaMenüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programHakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giris_loglari_listesi = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giris_loglari_listesi)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.watermarkimiz});
            this.statusStrip1.Location = new System.Drawing.Point(0, 598);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(602, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel4.Text = "Hoşgeldin |";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel1.Text = "Admin Girişi Yapıldı";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel2.Text = " | Tarih: |";
            // 
            // watermarkimiz
            // 
            this.watermarkimiz.IsLink = true;
            this.watermarkimiz.Name = "watermarkimiz";
            this.watermarkimiz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.watermarkimiz.Size = new System.Drawing.Size(359, 17);
            this.watermarkimiz.Spring = true;
            this.watermarkimiz.Text = "LMR - Process Vortex - Giriş Logları";
            this.watermarkimiz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(227, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Tarih Seç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(486, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Temizle/Yenile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(353, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "İlk 500 Kayıt Listele";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(602, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaMenüToolStripMenuItem,
            this.çıkışYapToolStripMenuItem,
            this.programKapatToolStripMenuItem});
            this.dosyaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dosyaToolStripMenuItem.Image")));
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.dosyaToolStripMenuItem.Text = "Genel";
            // 
            // anaMenüToolStripMenuItem
            // 
            this.anaMenüToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("anaMenüToolStripMenuItem.Image")));
            this.anaMenüToolStripMenuItem.Name = "anaMenüToolStripMenuItem";
            this.anaMenüToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.anaMenüToolStripMenuItem.Text = "Ana Menü";
            this.anaMenüToolStripMenuItem.Click += new System.EventHandler(this.anaMenüyeDönToolStripMenuItem_Click);
            // 
            // çıkışYapToolStripMenuItem
            // 
            this.çıkışYapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("çıkışYapToolStripMenuItem.Image")));
            this.çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
            this.çıkışYapToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.çıkışYapToolStripMenuItem.Text = "Çıkış Yap";
            this.çıkışYapToolStripMenuItem.Click += new System.EventHandler(this.çıkışYapToolStripMenuItem_Click);
            // 
            // programKapatToolStripMenuItem
            // 
            this.programKapatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("programKapatToolStripMenuItem.Image")));
            this.programKapatToolStripMenuItem.Name = "programKapatToolStripMenuItem";
            this.programKapatToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.programKapatToolStripMenuItem.Text = "Program Kapat";
            this.programKapatToolStripMenuItem.Click += new System.EventHandler(this.programKapatToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programHakkındaToolStripMenuItem});
            this.hakkındaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hakkındaToolStripMenuItem.Image")));
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            // 
            // programHakkındaToolStripMenuItem
            // 
            this.programHakkındaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("programHakkındaToolStripMenuItem.Image")));
            this.programHakkındaToolStripMenuItem.Name = "programHakkındaToolStripMenuItem";
            this.programHakkındaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.programHakkındaToolStripMenuItem.Text = "Program Hakkında";
            this.programHakkındaToolStripMenuItem.Click += new System.EventHandler(this.programHakkındaToolStripMenuItem_Click);
            // 
            // giris_loglari_listesi
            // 
            this.giris_loglari_listesi.AllowUserToAddRows = false;
            this.giris_loglari_listesi.AllowUserToDeleteRows = false;
            this.giris_loglari_listesi.AllowUserToResizeColumns = false;
            this.giris_loglari_listesi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.giris_loglari_listesi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.giris_loglari_listesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.giris_loglari_listesi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.giris_loglari_listesi.BackgroundColor = System.Drawing.Color.White;
            this.giris_loglari_listesi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.giris_loglari_listesi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.giris_loglari_listesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.giris_loglari_listesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.giris_loglari_listesi.DefaultCellStyle = dataGridViewCellStyle3;
            this.giris_loglari_listesi.EnableHeadersVisualStyles = false;
            this.giris_loglari_listesi.Location = new System.Drawing.Point(12, 65);
            this.giris_loglari_listesi.Name = "giris_loglari_listesi";
            this.giris_loglari_listesi.ReadOnly = true;
            this.giris_loglari_listesi.RowTemplate.ReadOnly = true;
            this.giris_loglari_listesi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.giris_loglari_listesi.Size = new System.Drawing.Size(578, 530);
            this.giris_loglari_listesi.TabIndex = 31;
            // 
            // giris_loglari_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(602, 620);
            this.Controls.Add(this.giris_loglari_listesi);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "giris_loglari_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hatalı Giriş Logları - Process Vortex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.giris_loglari_form_FormClosing);
            this.Load += new System.EventHandler(this.giris_loglari_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giris_loglari_listesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel watermarkimiz;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anaMenüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programHakkındaToolStripMenuItem;
        public System.Windows.Forms.DataGridView giris_loglari_listesi;
    }
}