namespace vtys
{
    partial class hizmetler
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
            dataGridView1 = new DataGridView();
            btn_ekle = new Button();
            btn_guncelle = new Button();
            txtAd = new TextBox();
            txtFiyat = new TextBox();
            txtAciklama = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_sil = new Button();
            usd_cevir = new Button();
            try_cevir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 128, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 167);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1061, 415);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btn_ekle
            // 
            btn_ekle.BackColor = Color.FromArgb(255, 128, 255);
            btn_ekle.ForeColor = SystemColors.ButtonHighlight;
            btn_ekle.Location = new Point(1257, 430);
            btn_ekle.Margin = new Padding(4, 3, 4, 3);
            btn_ekle.Name = "btn_ekle";
            btn_ekle.Size = new Size(141, 42);
            btn_ekle.TabIndex = 1;
            btn_ekle.Text = "ekle";
            btn_ekle.UseVisualStyleBackColor = false;
            btn_ekle.Click += btn_ekle_Click;
            // 
            // btn_guncelle
            // 
            btn_guncelle.BackColor = Color.FromArgb(255, 128, 255);
            btn_guncelle.ForeColor = SystemColors.ButtonHighlight;
            btn_guncelle.Location = new Point(1257, 553);
            btn_guncelle.Margin = new Padding(4, 3, 4, 3);
            btn_guncelle.Name = "btn_guncelle";
            btn_guncelle.Size = new Size(141, 42);
            btn_guncelle.TabIndex = 3;
            btn_guncelle.Text = "güncelle";
            btn_guncelle.UseVisualStyleBackColor = false;
            btn_guncelle.Click += btn_guncelle_Click;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(1237, 202);
            txtAd.Margin = new Padding(4, 3, 4, 3);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(186, 28);
            txtAd.TabIndex = 4;
            // 
            // txtFiyat
            // 
            txtFiyat.Location = new Point(1237, 235);
            txtFiyat.Margin = new Padding(4, 3, 4, 3);
            txtFiyat.Name = "txtFiyat";
            txtFiyat.Size = new Size(186, 28);
            txtFiyat.TabIndex = 5;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(1237, 285);
            txtAciklama.Margin = new Padding(4, 3, 4, 3);
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(186, 120);
            txtAciklama.TabIndex = 6;
            txtAciklama.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1166, 205);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 7;
            label1.Text = "İşlem:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1169, 238);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 8;
            label2.Text = "Fiyat:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1129, 285);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 9;
            label3.Text = "Açıklama:";
            // 
            // btn_sil
            // 
            btn_sil.BackColor = Color.FromArgb(255, 128, 255);
            btn_sil.ForeColor = SystemColors.ButtonHighlight;
            btn_sil.Location = new Point(1257, 493);
            btn_sil.Margin = new Padding(4, 3, 4, 3);
            btn_sil.Name = "btn_sil";
            btn_sil.Size = new Size(141, 44);
            btn_sil.TabIndex = 2;
            btn_sil.Text = "sil";
            btn_sil.UseVisualStyleBackColor = false;
            btn_sil.Click += btn_sil_Click;
            // 
            // usd_cevir
            // 
            usd_cevir.Location = new Point(116, 102);
            usd_cevir.Margin = new Padding(4, 3, 4, 3);
            usd_cevir.Name = "usd_cevir";
            usd_cevir.Size = new Size(86, 29);
            usd_cevir.TabIndex = 10;
            usd_cevir.Text = "USD";
            usd_cevir.UseVisualStyleBackColor = true;
            usd_cevir.Click += cevir_Click;
            // 
            // try_cevir
            // 
            try_cevir.Location = new Point(210, 102);
            try_cevir.Margin = new Padding(4, 3, 4, 3);
            try_cevir.Name = "try_cevir";
            try_cevir.Size = new Size(86, 29);
            try_cevir.TabIndex = 11;
            try_cevir.Text = "TRY";
            try_cevir.UseVisualStyleBackColor = true;
            try_cevir.Click += button1_Click;
            // 
            // hizmetler
            // 
            AutoScaleDimensions = new SizeF(12F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(1476, 746);
            Controls.Add(try_cevir);
            Controls.Add(usd_cevir);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAciklama);
            Controls.Add(txtFiyat);
            Controls.Add(txtAd);
            Controls.Add(btn_guncelle);
            Controls.Add(btn_sil);
            Controls.Add(btn_ekle);
            Controls.Add(dataGridView1);
            Font = new Font("Orbitron", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlDarkDark;
            Margin = new Padding(4, 3, 4, 3);
            Name = "hizmetler";
            ShowIcon = false;
            Text = "HİZMETLER";
            Load += hizmetler_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_ekle;
        private Button btn_guncelle;
        private TextBox txtAd;
        private TextBox txtFiyat;
        private RichTextBox txtAciklama;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_sil;
        private Button usd_cevir;
        private Button try_cevir;
    }
}