namespace vtys
{
    partial class bayiler
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
            btn_sil = new Button();
            btn_guncelle = new Button();
            ilceComboBox = new ComboBox();
            ilComboBox = new ComboBox();
            label6 = new Label();
            adrestxt = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            telefontxt = new TextBox();
            label2 = new Label();
            mailtxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 128, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.ButtonFace;
            dataGridView1.Location = new Point(105, 68);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1170, 398);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btn_ekle
            // 
            btn_ekle.BackColor = Color.Violet;
            btn_ekle.ForeColor = Color.White;
            btn_ekle.Location = new Point(262, 611);
            btn_ekle.Margin = new Padding(4, 3, 4, 3);
            btn_ekle.Name = "btn_ekle";
            btn_ekle.Size = new Size(189, 45);
            btn_ekle.TabIndex = 1;
            btn_ekle.Text = "ekle";
            btn_ekle.UseVisualStyleBackColor = false;
            btn_ekle.Click += btn_ekle_Click;
            // 
            // btn_sil
            // 
            btn_sil.BackColor = Color.Violet;
            btn_sil.ForeColor = Color.White;
            btn_sil.Location = new Point(489, 611);
            btn_sil.Margin = new Padding(4, 3, 4, 3);
            btn_sil.Name = "btn_sil";
            btn_sil.Size = new Size(189, 45);
            btn_sil.TabIndex = 2;
            btn_sil.Text = "sil";
            btn_sil.UseVisualStyleBackColor = false;
            btn_sil.Click += btn_sil_Click;
            // 
            // btn_guncelle
            // 
            btn_guncelle.BackColor = Color.Violet;
            btn_guncelle.ForeColor = Color.White;
            btn_guncelle.Location = new Point(732, 611);
            btn_guncelle.Margin = new Padding(4, 3, 4, 3);
            btn_guncelle.Name = "btn_guncelle";
            btn_guncelle.Size = new Size(189, 45);
            btn_guncelle.TabIndex = 3;
            btn_guncelle.Text = "güncelle";
            btn_guncelle.UseVisualStyleBackColor = false;
            btn_guncelle.Click += btn_guncelle_Click;
            // 
            // ilceComboBox
            // 
            ilceComboBox.ForeColor = Color.Purple;
            ilceComboBox.FormattingEnabled = true;
            ilceComboBox.Location = new Point(732, 543);
            ilceComboBox.Margin = new Padding(4, 3, 4, 3);
            ilceComboBox.Name = "ilceComboBox";
            ilceComboBox.Size = new Size(206, 26);
            ilceComboBox.TabIndex = 27;
            // 
            // ilComboBox
            // 
            ilComboBox.ForeColor = Color.Purple;
            ilComboBox.FormattingEnabled = true;
            ilComboBox.Location = new Point(732, 513);
            ilComboBox.Margin = new Padding(4, 3, 4, 3);
            ilComboBox.Name = "ilComboBox";
            ilComboBox.Size = new Size(206, 26);
            ilComboBox.TabIndex = 26;
            ilComboBox.SelectedIndexChanged += ilComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(978, 519);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(62, 18);
            label6.TabIndex = 24;
            label6.Text = "Adres:";
            // 
            // adrestxt
            // 
            adrestxt.ForeColor = Color.Purple;
            adrestxt.Location = new Point(1056, 513);
            adrestxt.Margin = new Padding(4, 3, 4, 3);
            adrestxt.Name = "adrestxt";
            adrestxt.Size = new Size(171, 25);
            adrestxt.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(676, 543);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(40, 18);
            label5.TabIndex = 22;
            label5.Text = "İlçe:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(695, 515);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(20, 18);
            label4.TabIndex = 21;
            label4.Text = "İl:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(395, 513);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(74, 18);
            label3.TabIndex = 20;
            label3.Text = "Telefon:";
            // 
            // telefontxt
            // 
            telefontxt.ForeColor = Color.Purple;
            telefontxt.Location = new Point(489, 510);
            telefontxt.Margin = new Padding(4, 3, 4, 3);
            telefontxt.Name = "telefontxt";
            telefontxt.Size = new Size(171, 25);
            telefontxt.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(127, 515);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 18);
            label2.TabIndex = 18;
            label2.Text = "Mail:";
            // 
            // mailtxt
            // 
            mailtxt.ForeColor = Color.Purple;
            mailtxt.Location = new Point(192, 510);
            mailtxt.Margin = new Padding(4, 3, 4, 3);
            mailtxt.Name = "mailtxt";
            mailtxt.Size = new Size(171, 25);
            mailtxt.TabIndex = 17;
            // 
            // bayiler
            // 
            AutoScaleDimensions = new SizeF(11F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(1476, 746);
            Controls.Add(ilceComboBox);
            Controls.Add(ilComboBox);
            Controls.Add(label6);
            Controls.Add(adrestxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(telefontxt);
            Controls.Add(label2);
            Controls.Add(mailtxt);
            Controls.Add(btn_guncelle);
            Controls.Add(btn_sil);
            Controls.Add(btn_ekle);
            Controls.Add(dataGridView1);
            Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlDarkDark;
            Margin = new Padding(4, 3, 4, 3);
            Name = "bayiler";
            ShowIcon = false;
            Text = "BAYİLER";
            Load += bayiler_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_sil;
        private Button btn_ekle;
        private Button btn_guncelle;
        private ComboBox ilceComboBox;
        private ComboBox ilComboBox;
        private Label label6;
        private TextBox adrestxt;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox telefontxt;
        private Label label2;
        private TextBox mailtxt;
    }
}