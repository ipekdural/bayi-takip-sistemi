namespace vtys
{
    partial class bayi_ekle
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
            textBoxMail = new TextBox();
            label3 = new Label();
            textBoxTelefon = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxAdres = new TextBox();
            buttonEkle = new Button();
            comboBoxIl = new ComboBox();
            comboBoxIlce = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 79);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 3;
            label2.Text = "Mail:";
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(185, 72);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(125, 27);
            textBoxMail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(117, 124);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 5;
            label3.Text = "Telefon:";
            // 
            // textBoxTelefon
            // 
            textBoxTelefon.Location = new Point(185, 121);
            textBoxTelefon.Name = "textBoxTelefon";
            textBoxTelefon.Size = new Size(125, 27);
            textBoxTelefon.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 168);
            label4.Name = "label4";
            label4.Size = new Size(20, 20);
            label4.TabIndex = 7;
            label4.Text = "İl:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(142, 219);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 9;
            label5.Text = "İlçe:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(127, 274);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 11;
            label6.Text = "Adres:";
            // 
            // textBoxAdres
            // 
            textBoxAdres.Location = new Point(184, 267);
            textBoxAdres.Name = "textBoxAdres";
            textBoxAdres.Size = new Size(125, 27);
            textBoxAdres.TabIndex = 10;
            // 
            // buttonEkle
            // 
            buttonEkle.Location = new Point(185, 329);
            buttonEkle.Name = "buttonEkle";
            buttonEkle.Size = new Size(114, 29);
            buttonEkle.TabIndex = 14;
            buttonEkle.Text = "ekle";
            buttonEkle.UseVisualStyleBackColor = true;
            buttonEkle.Click += buttonEkle_Click_1;
            // 
            // comboBoxIl
            // 
            comboBoxIl.FormattingEnabled = true;
            comboBoxIl.Location = new Point(184, 165);
            comboBoxIl.Name = "comboBoxIl";
            comboBoxIl.Size = new Size(151, 28);
            comboBoxIl.TabIndex = 15;
            // 
            // comboBoxIlce
            // 
            comboBoxIlce.FormattingEnabled = true;
            comboBoxIlce.Location = new Point(183, 219);
            comboBoxIlce.Name = "comboBoxIlce";
            comboBoxIlce.Size = new Size(151, 28);
            comboBoxIlce.TabIndex = 16;
            // 
            // bayi_ekle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(483, 444);
            Controls.Add(comboBoxIlce);
            Controls.Add(comboBoxIl);
            Controls.Add(buttonEkle);
            Controls.Add(label6);
            Controls.Add(textBoxAdres);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxTelefon);
            Controls.Add(label2);
            Controls.Add(textBoxMail);
            Name = "bayi_ekle";
            ShowIcon = false;
            Text = "Bayi Ekleme Paneli";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox textBoxMail;
        private Label label3;
        private TextBox textBoxTelefon;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxAdres;
        private Label label7;
        private Button buttonEkle;
        private ComboBox comboBoxIl;
        private ComboBox comboBoxIlce;
        private ComboBox comboBox1;
    }
}