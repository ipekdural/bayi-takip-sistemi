using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using System.Windows.Forms;

namespace vtys
{
    public partial class randevular : Form
    {
        private int selectedPersonelId;  // Declare a class-level variable to store the selected personel_id
        NpgsqlConnection conn = new NpgsqlConnection("");

        public randevular()
        {


            InitializeComponent();
            FillComboBox();
            FillMusteriComboBox();
            FillHizmetComboBox();

        }


        private void randevular_Load(object sender, EventArgs e)
        {

            // HizmetComboBox'ı doldur
            FillHizmetComboBox();
        }

        private void FillHizmetComboBox()
        {
            try
            {
                conn.Open();

                // Hizmet adlarını hizmetComboBox'a ekleyen fonksiyon
                string query = "SELECT ad FROM public.hizmetler";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string hizmetAdi = reader.GetString(0);
                            hizmetComboBox.Items.Add(hizmetAdi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void FillComboBox()
        {
            try
            {
                conn.Open();

                string query = "SELECT bayi_id FROM public.Bayi";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bayiId = reader.GetInt32(0);
                            comboBox1.Items.Add(bayiId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_randevu_goruntule_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Seçilen bayi_id'yi al
                int selectedBayiId = Convert.ToInt32(comboBox1.SelectedItem);

                // Bayi_id'ye göre randevu bilgilerini getir
                string query = $@"SELECT
                    r.randevu_id AS ""Randevu ID"",
                    CONCAT(mu.ad, ' ', mu.soyad) AS ""Müşteri"",
                    CONCAT(mu.telefon,', ', mu.adres) AS ""Müşteri Bilgileri"",
                    r.bayi_id AS ""Bayi No"",
                    
                    r.tarih AS ""Tarih"",
                    h.ad AS ""Hizmet""
                FROM public.""randevu"" AS r
                LEFT JOIN public.""musteri"" AS mu ON r.musteri_id = mu.musteri_id
          
                LEFT JOIN public.""hizmetler"" AS h ON r.hizmet_id = h.hizmet_id
                WHERE r.bayi_id = {selectedBayiId}";



                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'e verileri aktar
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void FillMusteriComboBox()
        {
            try
            {
                conn.Open();

                // Müşteri adı ve soyadını birleştirip müşteri ComboBox'ına ekleyen fonksiyon
                string query = "SELECT musteri_id, ad || ' ' || soyad AS adsoyad FROM public.musteri";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string adSoyad = reader.GetString(1);
                            musteriComboBox.Items.Add(adSoyad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btn_randevu_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Get selected bayi_id, musteri, hizmet, and tarih
                int selectedBayiId = Convert.ToInt32(comboBox1.SelectedItem);
                string selectedMusteriAdSoyad = musteriComboBox.SelectedItem.ToString();
                string selectedHizmetAdi = hizmetComboBox.SelectedItem.ToString();
                DateTime randevuTarih = dateTimePicker1.Value;

                // Parse müşteri ad-soyad bilgisi
                string[] musteriAdSoyadParts = selectedMusteriAdSoyad.Split(' ');
                string musteriAd = musteriAdSoyadParts[0];
                string musteriSoyad = musteriAdSoyadParts[1];

                // Get müşteri_id and hizmet_id based on the selected names
                int musteriId = GetMusteriId(musteriAd, musteriSoyad);
                int hizmetId = GetHizmetId(selectedHizmetAdi);

                // Insert new randevu into the database
                string insertQuery = $@"INSERT INTO public.""randevu"" (musteri_id, bayi_id, hizmet_id, tarih)
                                VALUES ({musteriId}, {selectedBayiId}, {hizmetId}, '{randevuTarih.ToString("yyyy-MM-dd HH:mm:ss")}')";
                using (NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, conn))
                {
                    insertCommand.ExecuteNonQuery();
                }


                // Refresh DataGridView

                btn_randevu_goruntule_Click(sender, e);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private int GetMusteriId(string ad, string soyad)
        {
            // Retrieve musteri_id based on ad and soyad
            string query = $@"SELECT musteri_id FROM public.musteri
                      WHERE ad = '{ad}' AND soyad = '{soyad}'";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private int GetHizmetId(string hizmetAdi)
        {
            // Retrieve hizmet_id based on hizmet_adı
            string query = $@"SELECT hizmet_id FROM public.hizmetler
                      WHERE ad = '{hizmetAdi}'";
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }




    }
}
