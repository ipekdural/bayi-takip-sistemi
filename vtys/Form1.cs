namespace vtys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_bayiler_Click(object sender, EventArgs e)
        {

            bayiler b = new bayiler();
            b.Show();
        }

        private void btn_ciro_Click(object sender, EventArgs e)
        {

            cirolar c = new cirolar();
            c.Show();
        }

        private void btn_randevular_Click(object sender, EventArgs e)
        {

            randevular r = new randevular();
            r.Show();
        }

        private void btn_musteri_Click(object sender, EventArgs e)
        {
            musteriler m = new musteriler();
            m.Show();
        }

        private void btn_personel_Click(object sender, EventArgs e)
        {
            personeller p = new personeller();
            p.Show();
        }

        private void btn_hizmetler_Click(object sender, EventArgs e)
        {
            hizmetler h = new hizmetler();
            h.Show();
        }
    }
}