using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vtys
{
    public partial class cirolar : Form
    {
        public cirolar()
        {
            InitializeComponent();
            FillComboBox();
            AtamaIslemi();
        }
        NpgsqlConnection conn = new NpgsqlConnection("");
        private void AtamaIslemi()
        {
            try
            {
                conn.Open();

                // Total ciro hesaplama saklı yordamını çağır
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT public.HesaplaToplamCiro()", conn))
                {
                    decimal totalCiro = Convert.ToDecimal(command.ExecuteScalar());

                    // label7'ye total ciro değerini ata
                    label7.Text = " " + totalCiro.ToString("C");
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemleri yapabilirsiniz
            }
            finally
            {
                conn.Close();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void btn_ciro_goruntule_Click(object sender, EventArgs e)
        {

            try
            {

                // Seçilen bayi_id'yi al
                int selectedBayiId = Convert.ToInt32(comboBox1.SelectedItem);


                // Ciro tablosundan ilgili bayi_id'ye ait ciro bilgilerini çek
                string ciroQuery = $"SELECT tarih AS \"Tarih\", bayi_id AS \"Bayi ID\", ciro_miktari AS \"Ciro Miktarı\" FROM public.Ciro WHERE bayi_id = {selectedBayiId}";


                using (NpgsqlDataAdapter ciroAdapter = new NpgsqlDataAdapter(ciroQuery, conn))
                {
                    DataTable ciroTable = new DataTable();
                    ciroAdapter.Fill(ciroTable);

                    // DataGridView'e ciro bilgilerini aktar
                    dataGridView1.DataSource = ciroTable;

                    if (ciroTable.Rows.Count > 0)
                    {
                        // İlk satırdaki ciro_id'yi al
                        int selectedCiroId = Convert.ToInt32(ciroTable.Rows[0]["ciro_id"]);

                        // Gelir tablosundan ilgili ciro_id'ye ait bilgileri çek
                        string gelirQuery = $"SELECT aciklama AS \"Gelir Tablosu\", toplam_gelir AS \"Gelirler\" FROM public.Gelir WHERE ciro_id = {selectedCiroId}";

                        using (NpgsqlDataAdapter gelirAdapter = new NpgsqlDataAdapter(gelirQuery, conn))
                        {
                            DataTable gelirTable = new DataTable();
                            gelirAdapter.Fill(gelirTable);

                            // DataGridView2'ye gelir tablosunu aktar
                            dataGridView2.DataSource = gelirTable;
                        }

                        // Gider tablosundan ilgili ciro_id'ye ait bilgileri çek
                        string giderQuery = $"SELECT aciklama AS \"Gider Tablosu\", toplam_gider FROM public.Gider WHERE ciro_id = {selectedCiroId}";

                        using (NpgsqlDataAdapter giderAdapter = new NpgsqlDataAdapter(giderQuery, conn))
                        {
                            DataTable giderTable = new DataTable();
                            giderAdapter.Fill(giderTable);

                            // DataGridView3'e gider tablosunu aktar
                            dataGridView3.DataSource = giderTable;
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



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ciro_ekle_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();

                // Step 1: Insert into Ciro table
                string insertCiroQuery = "INSERT INTO public.Ciro (bayi_id, ciro_miktari, tarih) VALUES (@bayi_id, @ciro_miktari, @tarih) RETURNING ciro_id";

                using (NpgsqlCommand insertCiroCmd = new NpgsqlCommand(insertCiroQuery, conn))
                {
                    insertCiroCmd.Parameters.AddWithValue("@bayi_id", Convert.ToInt32(comboBox1.SelectedItem));

                    // Calculate ciro_miktari by subtracting total gider from total gelir
                    decimal totalGelir = Convert.ToDecimal(gelirtxt.Text);
                    decimal totalGider = Convert.ToDecimal(gidertxt.Text);
                    decimal ciroMiktari = totalGelir - totalGider;

                    insertCiroCmd.Parameters.AddWithValue("@ciro_miktari", ciroMiktari);
                    insertCiroCmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);

                    int ciroId = (int)insertCiroCmd.ExecuteScalar();

                    // Step 2: Insert into Gelir table
                    string insertGelirQuery = "INSERT INTO public.Gelir (ciro_id, aciklama, toplam_gelir) VALUES (@ciro_id, @aciklama, @toplam_gelir)";

                    using (NpgsqlCommand insertGelirCmd = new NpgsqlCommand(insertGelirQuery, conn))
                    {
                        insertGelirCmd.Parameters.AddWithValue("@ciro_id", ciroId);
                        insertGelirCmd.Parameters.AddWithValue("@aciklama", aciklamagelirtxt.Text);
                        insertGelirCmd.Parameters.AddWithValue("@toplam_gelir", totalGelir);

                        insertGelirCmd.ExecuteNonQuery();
                    }

                    // Step 3: Insert into Gider table
                    string insertGiderQuery = "INSERT INTO public.Gider (ciro_id, aciklama, toplam_gider) VALUES (@ciro_id, @aciklama, @toplam_gider)";

                    using (NpgsqlCommand insertGiderCmd = new NpgsqlCommand(insertGiderQuery, conn))
                    {
                        insertGiderCmd.Parameters.AddWithValue("@ciro_id", ciroId);
                        insertGiderCmd.Parameters.AddWithValue("@aciklama", aciklamagidertxt.Text);
                        insertGiderCmd.Parameters.AddWithValue("@toplam_gider", totalGider);

                        insertGiderCmd.ExecuteNonQuery();
                    }

                    // Refresh DataGridView1, DataGridView2, and DataGridView3
                    btn_ciro_goruntule_Click(sender, e);

                    // DataGridView2'ye yeni eklenen gelir verilerini getir
                    RefreshDataGridView2(ciroId);
                    // DataGridView3'e yeni eklenen gider verilerini getir
                    RefreshDataGridView3(ciroId);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (uncomment the line below to show a message box)
                // MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void RefreshDataGridView2(int ciroId)
        {
            try
            {
                // Yeni eklenen gelir verilerini çek
                string gelirQuery = $"SELECT aciklama AS \"Gelir Tablosu\", toplam_gelir FROM public.Gelir WHERE ciro_id = {ciroId}";

                using (NpgsqlDataAdapter gelirAdapter = new NpgsqlDataAdapter(gelirQuery, conn))
                {
                    DataTable gelirTable = new DataTable();
                    gelirAdapter.Fill(gelirTable);

                    // DataGridView2'ye gelir tablosunu aktar
                    dataGridView2.DataSource = gelirTable;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void RefreshDataGridView3(int ciroId)
        {
            try
            {
                // Yeni eklenen verileri çek
                string giderQuery = $"SELECT aciklama AS \"Gider Tablosu\", toplam_gider FROM public.Gider WHERE ciro_id = {ciroId}";

                using (NpgsqlDataAdapter giderAdapter = new NpgsqlDataAdapter(giderQuery, conn))
                {
                    DataTable giderTable = new DataTable();
                    giderAdapter.Fill(giderTable);

                    // DataGridView3'e gider tablosunu aktar
                    dataGridView3.DataSource = giderTable;
                }
            }
            catch (Exception ex)
            {
                //    MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            gidertxt.Text = string.Empty;
            gelirtxt.Text = string.Empty;
            aciklamagelirtxt.Text = string.Empty;
            aciklamagidertxt.Text = string.Empty;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

