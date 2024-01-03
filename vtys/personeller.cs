using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace vtys
{
    public partial class personeller : Form
    {
        private readonly NpgsqlConnection conn = new NpgsqlConnection("");
        private NpgsqlDataAdapter yoneticiDataAdapter;
        private NpgsqlDataAdapter calisanDataAdapter;
        private DataSet dataSet;

        public personeller()
        {
            InitializeComponent();
            InitializeData();
            FillComboBoxes();
            CreateTriggers();
        }

        private void CreateTriggers()
        {
            try
            {
                using (NpgsqlCommand cmdTrigger = new NpgsqlCommand(
                    @"
                CREATE OR REPLACE FUNCTION yonetici_trigger_function()
                RETURNS TRIGGER AS $$
                BEGIN
                    -- Your trigger logic goes here
                    -- For example, you can print a message to the server log
                    RAISE NOTICE 'Yonetici tablosu % tarihinde değiştirildi', NOW();
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER yonetici_trigger
                AFTER INSERT OR UPDATE OR DELETE ON public.Yonetici
                FOR EACH ROW
                EXECUTE FUNCTION yonetici_trigger_function();
                ", conn))
                {
                    conn.Open();
                    cmdTrigger.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or display an error message
                //   MessageBox.Show($"Error creating triggers: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private void InitializeData()
        {
            // Create DataSets
            dataSet = new DataSet();

            // Create DataAdapters with modified queries
            yoneticiDataAdapter = new NpgsqlDataAdapter("SELECT y.personel_id AS \"Yönetici ID\", p.ad || ' ' || p.soyad AS \"Yönetici\", y.bayi_id AS \"Bayi ID\" FROM public.Yonetici y JOIN public.Personel p ON y.personel_id = p.personel_id", conn);

            calisanDataAdapter = new NpgsqlDataAdapter("SELECT c.personel_id AS \"Çalışan ID\", p.ad || ' ' || p.soyad AS \"Çalışan\", c.bayi_id AS \"Bayi ID\" FROM public.Calisan c JOIN public.Personel p ON c.personel_id = p.personel_id", conn);

            // Fill DataSets with data
            yoneticiDataAdapter.Fill(dataSet, "Yonetici");
            calisanDataAdapter.Fill(dataSet, "Calisan");

            // Bind DataSets to DataGridViews
            dataGridView1.DataSource = dataSet.Tables["Yonetici"];
            dataGridView2.DataSource = dataSet.Tables["Calisan"];
        }

        private void FillComboBoxes()
        {
            // Fill ComboBox1 with bayi_id values from Bayi table
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT bayi_id FROM public.Bayi", conn))
            {
                conn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["bayi_id"]);
                    comboBox2.Items.Add(reader["bayi_id"]);
                }
                conn.Close();
            }

            // Fill ComboBoxPozisyon with pozisyon ad values from Pozisyon table
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT ad FROM public.Pozisyon", conn))
            {
                conn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxPozisyon.Items.Add(reader["ad"]);
                }
                conn.Close();
            }
        }

        private void btn_yonetici_ekle_Click(object sender, EventArgs e)
        {
            // Get values from form controls
            string ad = yoneticiadtxt.Text;
            string soyad = yoneticisoyadtxt.Text;
            int bayiId = Convert.ToInt32(comboBox1.SelectedItem);

            // Insert into Personel table
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.Personel (ad, soyad) VALUES (@ad, @soyad) RETURNING personel_id", conn))
            {
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);

                conn.Open();
                int personelId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                // Insert into Yonetici table
                using (NpgsqlCommand cmdYonetici = new NpgsqlCommand("INSERT INTO public.Yonetici (personel_id, bayi_id) VALUES (@personelId, @bayiId)", conn))
                {
                    cmdYonetici.Parameters.AddWithValue("@personelId", personelId);
                    cmdYonetici.Parameters.AddWithValue("@bayiId", bayiId);

                    conn.Open();
                    cmdYonetici.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Refresh the DataGridView
            dataSet.Tables["Yonetici"].Clear();
            yoneticiDataAdapter.Fill(dataSet, "Yonetici");
        }

        private void btn_calisan_ekle_Click(object sender, EventArgs e)
        {
            // Get values from form controls
            string ad = calisanadtxt.Text;
            string soyad = calisansoyadtxt.Text;
            string pozisyonAd = comboBoxPozisyon.SelectedItem.ToString();
            int bayiId = Convert.ToInt32(comboBox2.SelectedItem);

            // Insert into Personel table
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.Personel (ad, soyad) VALUES (@ad, @soyad) RETURNING personel_id", conn))
            {
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);

                conn.Open();
                int personelId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                // Get pozisyon_id based on the selected pozisyonAd
                int pozisyonId;
                using (NpgsqlCommand cmdPozisyonId = new NpgsqlCommand("SELECT pozisyon_id FROM public.Pozisyon WHERE ad = @pozisyonAd", conn))
                {
                    cmdPozisyonId.Parameters.AddWithValue("@pozisyonAd", pozisyonAd);

                    conn.Open();
                    pozisyonId = Convert.ToInt32(cmdPozisyonId.ExecuteScalar());
                    conn.Close();
                }

                // Insert into Calisan table
                using (NpgsqlCommand cmdCalisan = new NpgsqlCommand("INSERT INTO public.Calisan (personel_id, bayi_id, pozisyon_id) VALUES (@personelId, @bayiId, @pozisyonId)", conn))
                {
                    cmdCalisan.Parameters.AddWithValue("@personelId", personelId);
                    cmdCalisan.Parameters.AddWithValue("@bayiId", bayiId);
                    cmdCalisan.Parameters.AddWithValue("@pozisyonId", pozisyonId);

                    conn.Open();
                    cmdCalisan.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Refresh the DataGridView
            dataSet.Tables["Calisan"].Clear();
            calisanDataAdapter.Fill(dataSet, "Calisan");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Yonetici tablosundan silme işlemi
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int personelId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Yönetici ID"].Value);

                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM public.Yonetici WHERE personel_id = @personelId", conn))
                {
                    cmd.Parameters.AddWithValue("@personelId", personelId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // Personel tablosundan silme işlemi
                using (NpgsqlCommand cmdPersonel = new NpgsqlCommand("DELETE FROM public.Personel WHERE personel_id = @personelId", conn))
                {
                    cmdPersonel.Parameters.AddWithValue("@personelId", personelId);

                    conn.Open();
                    cmdPersonel.ExecuteNonQuery();
                    conn.Close();
                }

                // Yeniden yükleme işlemi
                dataSet.Tables["Yonetici"].Clear();
                yoneticiDataAdapter.Fill(dataSet, "Yonetici");
            }
            else if (dataGridView2.SelectedRows.Count > 0)
            {
                // Calisan tablosundan silme işlemi
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;
                int personelId = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["Çalışan ID"].Value);

                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM public.Calisan WHERE personel_id = @personelId", conn))
                {
                    cmd.Parameters.AddWithValue("@personelId", personelId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // Personel tablosundan silme işlemi
                using (NpgsqlCommand cmdPersonel = new NpgsqlCommand("DELETE FROM public.Personel WHERE personel_id = @personelId", conn))
                {
                    cmdPersonel.Parameters.AddWithValue("@personelId", personelId);

                    conn.Open();
                    cmdPersonel.ExecuteNonQuery();
                    conn.Close();
                }

                // Yeniden yükleme işlemi
                dataSet.Tables["Calisan"].Clear();
                calisanDataAdapter.Fill(dataSet, "Calisan");
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir kaydı seçin.");
            }
        }
    }
}
