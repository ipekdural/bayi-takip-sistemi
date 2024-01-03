namespace vtys
{
    partial class musteriler
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
            label2 = new Label();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            btn_guncelle = new Button();
            btn_sil = new Button();
            btn_ekle = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            txtTelefon = new TextBox();
            label4 = new Label();
            txtAdres = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            label7 = new Label();
            txtaramusteri = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(1076, 372);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(132, 18);
            label2.TabIndex = 18;
            label2.Text = "Müşteri Soyadı:";
            // 
            // txtSoyad
            // 
            txtSoyad.ForeColor = SystemColors.ControlDarkDark;
            txtSoyad.Location = new Point(1235, 370);
            txtSoyad.Margin = new Padding(4, 3, 4, 3);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(215, 25);
            txtSoyad.TabIndex = 15;
            // 
            // txtAd
            // 
            txtAd.ForeColor = SystemColors.ControlDarkDark;
            txtAd.Location = new Point(1235, 324);
            txtAd.Margin = new Padding(4, 3, 4, 3);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(215, 25);
            txtAd.TabIndex = 14;
            // 
            // btn_guncelle
            // 
            btn_guncelle.BackColor = Color.FromArgb(255, 128, 255);
            btn_guncelle.ForeColor = SystemColors.ButtonFace;
            btn_guncelle.Location = new Point(604, 616);
            btn_guncelle.Margin = new Padding(4, 3, 4, 3);
            btn_guncelle.Name = "btn_guncelle";
            btn_guncelle.Size = new Size(150, 40);
            btn_guncelle.TabIndex = 13;
            btn_guncelle.Text = "güncelle";
            btn_guncelle.UseVisualStyleBackColor = false;
            btn_guncelle.Click += btn_guncelle_Click;
            // 
            // btn_sil
            // 
            btn_sil.BackColor = Color.FromArgb(255, 128, 255);
            btn_sil.ForeColor = SystemColors.ButtonFace;
            btn_sil.Location = new Point(214, 616);
            btn_sil.Margin = new Padding(4, 3, 4, 3);
            btn_sil.Name = "btn_sil";
            btn_sil.Size = new Size(146, 40);
            btn_sil.TabIndex = 12;
            btn_sil.Text = "sil";
            btn_sil.UseVisualStyleBackColor = false;
            btn_sil.Click += btn_sil_Click;
            // 
            // btn_ekle
            // 
            btn_ekle.BackColor = Color.FromArgb(255, 128, 255);
            btn_ekle.ForeColor = SystemColors.ButtonFace;
            btn_ekle.Location = new Point(1278, 498);
            btn_ekle.Margin = new Padding(4, 3, 4, 3);
            btn_ekle.Name = "btn_ekle";
            btn_ekle.Size = new Size(139, 41);
            btn_ekle.TabIndex = 11;
            btn_ekle.Text = "ekle";
            btn_ekle.UseVisualStyleBackColor = false;
            btn_ekle.Click += btn_ekle_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 128, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(45, 248);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(982, 344);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(1052, 414);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(149, 18);
            label3.TabIndex = 22;
            label3.Text = "İletişim Numarası:";
            // 
            // txtTelefon
            // 
            txtTelefon.ForeColor = SystemColors.ControlDarkDark;
            txtTelefon.Location = new Point(1235, 412);
            txtTelefon.Margin = new Padding(4, 3, 4, 3);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(215, 25);
            txtTelefon.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(1159, 459);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 18);
            label4.TabIndex = 24;
            label4.Text = "Adres:";
            // 
            // txtAdres
            // 
            txtAdres.ForeColor = SystemColors.ControlDarkDark;
            txtAdres.Location = new Point(1235, 456);
            txtAdres.Margin = new Padding(4, 3, 4, 3);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(215, 25);
            txtAdres.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Russo One", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(1222, 21);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(160, 22);
            label5.TabIndex = 25;
            label5.Text = "Müşteri Sayısı:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Russo One", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(1408, 21);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(0, 22);
            label6.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(1106, 331);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 18);
            label1.TabIndex = 17;
            label1.Text = "Müşteri Adı:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(84, 54);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(166, 18);
            label7.TabIndex = 28;
            label7.Text = "Müşteri Adı-Soyadı:";
            // 
            // txtaramusteri
            // 
            txtaramusteri.ForeColor = SystemColors.ControlDarkDark;
            txtaramusteri.Location = new Point(258, 51);
            txtaramusteri.Margin = new Padding(4, 3, 4, 3);
            txtaramusteri.Name = "txtaramusteri";
            txtaramusteri.Size = new Size(215, 25);
            txtaramusteri.TabIndex = 29;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(215, 82);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(116, 35);
            button1.TabIndex = 31;
            button1.Text = "ara";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtaramusteri);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(264, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(517, 149);
            panel1.TabIndex = 32;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Font = new Font("Russo One", 11.999999F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(0, 15);
            label8.Name = "label8";
            label8.Size = new Size(254, 27);
            label8.TabIndex = 0;
            label8.Text = "Müşteri Arama Paneli";
            // 
            // musteriler
            // 
            AutoScaleDimensions = new SizeF(11F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(1476, 746);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtAdres);
            Controls.Add(label3);
            Controls.Add(txtTelefon);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(btn_guncelle);
            Controls.Add(btn_sil);
            Controls.Add(btn_ekle);
            Controls.Add(panel1);
            Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlDarkDark;
            Margin = new Padding(4, 3, 4, 3);
            Name = "musteriler";
            ShowIcon = false;
            Text = "MÜŞTERİLER";
            Load += musteriler_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Button btn_guncelle;
        private Button btn_sil;
        private Button btn_ekle;
        private DataGridView dataGridView1;
        private Label label3;
        private TextBox txtTelefon;
        private Label label4;
        private TextBox txtAdres;
        private Label label5;
        private Label label6;
        private Label label1;
        private Label label7;
        private TextBox txtaramusteri;
        private Button button1;
        private Panel panel1;
        private Label label8;
    }
}