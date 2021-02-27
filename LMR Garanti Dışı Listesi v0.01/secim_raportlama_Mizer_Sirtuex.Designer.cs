namespace LMR_Process_Vortex
{
    partial class secim_raportlama_Mizer_Sirtuex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(secim_raportlama_Mizer_Sirtuex));
            this.button21 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.marka_eklerken_sec = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Image = ((System.Drawing.Image)(resources.GetObject("button21.Image")));
            this.button21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button21.Location = new System.Drawing.Point(4, 110);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(146, 43);
            this.button21.TabIndex = 107;
            this.button21.Text = "Excel Raporla";
            this.button21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(239, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 43);
            this.button1.TabIndex = 108;
            this.button1.Text = "PDF Raporla";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(6, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 35);
            this.label1.TabIndex = 109;
            this.label1.Text = "Rapor dosyası ek olarak C:\\Mizer_LMR_Raporlar konumuna kaydedildi.";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(110, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 23);
            this.label2.TabIndex = 110;
            this.label2.Text = "N/A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(4, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(381, 23);
            this.button2.TabIndex = 111;
            this.button2.Text = "K a p a t";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // marka_eklerken_sec
            // 
            this.marka_eklerken_sec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marka_eklerken_sec.FormattingEnabled = true;
            this.marka_eklerken_sec.Location = new System.Drawing.Point(138, 73);
            this.marka_eklerken_sec.Name = "marka_eklerken_sec";
            this.marka_eklerken_sec.Size = new System.Drawing.Size(121, 21);
            this.marka_eklerken_sec.TabIndex = 112;
            // 
            // secim_raportlama_Mizer_Sirtuex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(397, 242);
            this.Controls.Add(this.marka_eklerken_sec);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "secim_raportlama_Mizer_Sirtuex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Raporlama Mizer - Process Vortex";
            this.Load += new System.EventHandler(this.secim_raportlama_Mizer_Sirtuex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox marka_eklerken_sec;
    }
}