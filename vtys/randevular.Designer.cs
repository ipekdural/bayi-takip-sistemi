namespace vtys
{
    partial class randevular
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btn_randevu_goruntule = new Button();
            musteriComboBox = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            hizmetComboBox = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            btn_randevu_ekle = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Orbitron", 12F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.ForeColor = Color.Purple;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(491, 12);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(206, 32);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Orbitron", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(364, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 24);
            label1.TabIndex = 1;
            label1.Text = "Bayi girin:";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 128, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 145);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1087, 389);
            dataGridView1.TabIndex = 2;
            // 
            // btn_randevu_goruntule
            // 
            btn_randevu_goruntule.BackColor = Color.FromArgb(255, 128, 255);
            btn_randevu_goruntule.Font = new Font("Orbitron", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_randevu_goruntule.ForeColor = Color.White;
            btn_randevu_goruntule.Location = new Point(534, 69);
            btn_randevu_goruntule.Margin = new Padding(4, 3, 4, 3);
            btn_randevu_goruntule.Name = "btn_randevu_goruntule";
            btn_randevu_goruntule.Size = new Size(125, 51);
            btn_randevu_goruntule.TabIndex = 4;
            btn_randevu_goruntule.Text = "listele";
            btn_randevu_goruntule.UseVisualStyleBackColor = false;
            btn_randevu_goruntule.Click += btn_randevu_goruntule_Click;
            // 
            // musteriComboBox
            // 
            musteriComboBox.ForeColor = Color.Purple;
            musteriComboBox.FormattingEnabled = true;
            musteriComboBox.Location = new Point(1219, 218);
            musteriComboBox.Margin = new Padding(4, 3, 4, 3);
            musteriComboBox.Name = "musteriComboBox";
            musteriComboBox.Size = new Size(206, 26);
            musteriComboBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.ForeColor = Color.Purple;
            label2.Location = new Point(1139, 221);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 18);
            label2.TabIndex = 6;
            label2.Text = "Müşteri:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.Purple;
            label4.Location = new Point(1157, 269);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 18);
            label4.TabIndex = 10;
            label4.Text = "İşlem:";
            // 
            // hizmetComboBox
            // 
            hizmetComboBox.ForeColor = Color.Purple;
            hizmetComboBox.FormattingEnabled = true;
            hizmetComboBox.Location = new Point(1219, 266);
            hizmetComboBox.Margin = new Padding(4, 3, 4, 3);
            hizmetComboBox.Name = "hizmetComboBox";
            hizmetComboBox.Size = new Size(206, 26);
            hizmetComboBox.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarForeColor = SystemColors.ControlDarkDark;
            dateTimePicker1.Location = new Point(1127, 355);
            dateTimePicker1.Margin = new Padding(4, 3, 4, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(342, 25);
            dateTimePicker1.TabIndex = 11;
            // 
            // btn_randevu_ekle
            // 
            btn_randevu_ekle.BackColor = Color.FromArgb(255, 128, 255);
            btn_randevu_ekle.ForeColor = SystemColors.ButtonHighlight;
            btn_randevu_ekle.Location = new Point(1230, 444);
            btn_randevu_ekle.Margin = new Padding(4, 3, 4, 3);
            btn_randevu_ekle.Name = "btn_randevu_ekle";
            btn_randevu_ekle.Size = new Size(165, 45);
            btn_randevu_ekle.TabIndex = 12;
            btn_randevu_ekle.Text = "randevu ekle";
            btn_randevu_ekle.UseVisualStyleBackColor = false;
            btn_randevu_ekle.Click += btn_randevu_ekle_Click;
            // 
            // randevular
            // 
            AutoScaleDimensions = new SizeF(11F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(1476, 746);
            Controls.Add(btn_randevu_ekle);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(hizmetComboBox);
            Controls.Add(label2);
            Controls.Add(musteriComboBox);
            Controls.Add(btn_randevu_goruntule);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlDarkDark;
            Margin = new Padding(4, 3, 4, 3);
            Name = "randevular";
            ShowIcon = false;
            Text = "RANDEVULAR";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button btn_randevu_goruntule;
        private ComboBox musteriComboBox;
        private Label label2;
        private Label label4;
        private ComboBox hizmetComboBox;
        private DateTimePicker dateTimePicker1;
        private Button btn_randevu_ekle;
        private Button btn_randevu_guncelle;
    }
}