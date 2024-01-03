namespace vtys
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_bayiler = new Button();
            btn_ciro = new Button();
            btn_randevular = new Button();
            btn_musteri = new Button();
            btn_personel = new Button();
            btn_hizmetler = new Button();
            SuspendLayout();
            // 
            // btn_bayiler
            // 
            btn_bayiler.BackColor = Color.FromArgb(192, 0, 192);
            btn_bayiler.ForeColor = SystemColors.ButtonHighlight;
            btn_bayiler.Location = new Point(579, 89);
            btn_bayiler.Margin = new Padding(4, 3, 4, 3);
            btn_bayiler.Name = "btn_bayiler";
            btn_bayiler.Size = new Size(226, 74);
            btn_bayiler.TabIndex = 0;
            btn_bayiler.Text = "Bayiler";
            btn_bayiler.UseVisualStyleBackColor = false;
            btn_bayiler.Click += btn_bayiler_Click;
            // 
            // btn_ciro
            // 
            btn_ciro.BackColor = Color.FromArgb(192, 0, 192);
            btn_ciro.ForeColor = SystemColors.ButtonHighlight;
            btn_ciro.Location = new Point(1108, 89);
            btn_ciro.Margin = new Padding(4, 3, 4, 3);
            btn_ciro.Name = "btn_ciro";
            btn_ciro.Size = new Size(226, 74);
            btn_ciro.TabIndex = 1;
            btn_ciro.Text = "Aylık Ciro";
            btn_ciro.UseVisualStyleBackColor = false;
            btn_ciro.Click += btn_ciro_Click;
            // 
            // btn_randevular
            // 
            btn_randevular.BackColor = Color.FromArgb(192, 0, 192);
            btn_randevular.ForeColor = SystemColors.ButtonHighlight;
            btn_randevular.Location = new Point(579, 197);
            btn_randevular.Margin = new Padding(4, 3, 4, 3);
            btn_randevular.Name = "btn_randevular";
            btn_randevular.Size = new Size(226, 74);
            btn_randevular.TabIndex = 2;
            btn_randevular.Text = "Randevular";
            btn_randevular.UseVisualStyleBackColor = false;
            btn_randevular.Click += btn_randevular_Click;
            // 
            // btn_musteri
            // 
            btn_musteri.BackColor = Color.FromArgb(192, 0, 192);
            btn_musteri.ForeColor = SystemColors.ButtonHighlight;
            btn_musteri.Location = new Point(837, 89);
            btn_musteri.Margin = new Padding(4, 3, 4, 3);
            btn_musteri.Name = "btn_musteri";
            btn_musteri.Size = new Size(226, 74);
            btn_musteri.TabIndex = 3;
            btn_musteri.Text = "Müşteri İşlemleri";
            btn_musteri.UseVisualStyleBackColor = false;
            btn_musteri.Click += btn_musteri_Click;
            // 
            // btn_personel
            // 
            btn_personel.BackColor = Color.FromArgb(192, 0, 192);
            btn_personel.ForeColor = SystemColors.ButtonHighlight;
            btn_personel.Location = new Point(837, 197);
            btn_personel.Margin = new Padding(4, 3, 4, 3);
            btn_personel.Name = "btn_personel";
            btn_personel.Size = new Size(226, 74);
            btn_personel.TabIndex = 4;
            btn_personel.Text = "Personel İşlemleri";
            btn_personel.UseVisualStyleBackColor = false;
            btn_personel.Click += btn_personel_Click;
            // 
            // btn_hizmetler
            // 
            btn_hizmetler.BackColor = Color.FromArgb(192, 0, 192);
            btn_hizmetler.ForeColor = SystemColors.ButtonHighlight;
            btn_hizmetler.Location = new Point(1108, 197);
            btn_hizmetler.Margin = new Padding(4, 3, 4, 3);
            btn_hizmetler.Name = "btn_hizmetler";
            btn_hizmetler.Size = new Size(226, 74);
            btn_hizmetler.TabIndex = 5;
            btn_hizmetler.Text = "Hizmetler";
            btn_hizmetler.UseVisualStyleBackColor = false;
            btn_hizmetler.Click += btn_hizmetler_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(1476, 746);
            Controls.Add(btn_hizmetler);
            Controls.Add(btn_personel);
            Controls.Add(btn_musteri);
            Controls.Add(btn_randevular);
            Controls.Add(btn_ciro);
            Controls.Add(btn_bayiler);
            Font = new Font("Orbitron", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            ShowIcon = false;
            Text = "ANASAYFA";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_bayiler;
        private Button btn_ciro;
        private Button btn_randevular;
        private Button btn_musteri;
        private Button btn_personel;
        private Button btn_hizmetler;
    }
}