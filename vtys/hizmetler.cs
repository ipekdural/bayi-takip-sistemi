using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace vtys
{
    public partial class hizmetler : Form
    {
        private NpgsqlConnection conn = new NpgsqlConnection("");
        private BindingSource bindingSource = new BindingSource();

        public hizmetler()
        {
            InitializeComponent();
        }

        private void hizmetler_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            try
            {
                conn.Open();

                string query = "SELECT hizmet_id, ad, fiyat, aciklama FROM Hizmetler";
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                // Set column headers
                dataGridView1.Columns["hizmet_id"].HeaderText = "Hizmet ID";
                dataGridView1.Columns["ad"].HeaderText = "İşlem";
                dataGridView1.Columns["fiyat"].HeaderText = "Fiyat Bilgisi";
                dataGridView1.Columns["aciklama"].HeaderText = "Açıklama";
                bindingSource.ResetBindings(false); // BindingSource'ı resetle
                dataGridView1.Update(); // DataGridView'i güncelle
                dataGridView1.Refresh(); // DataGridView'i yeniden çiz
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Get values from form elements
                string ad = txtAd.Text;
                decimal fiyat = Convert.ToDecimal(txtFiyat.Text);
                string aciklama = txtAciklama.Text;

                // Create SQL INSERT statement without specifying the hizmet_id
                string insertQuery = "INSERT INTO Hizmetler(ad, fiyat, aciklama) VALUES(@ad, @fiyat, @aciklama) RETURNING hizmet_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, conn))
                {
                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama);

                    // Execute the query and get the inserted hizmet_id
                    int hizmetId = (int)cmd.ExecuteScalar();

                    // Update DataGridView
                    UpdateDataGridView();
                }

                // Clear the form fields after successful insertion
                txtAd.Clear();
                txtFiyat.Clear();
                txtAciklama.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateDataGridView()
        {
            // Assuming your DataGridView is named dataGridView1
            string selectQuery = "SELECT * FROM Hizmetler";

            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(selectQuery, conn))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Update the DataGridView with the new data
                dataGridView1.DataSource = dataTable;
            }
        }


        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Get the hizmet_id of the selected row
                int selectedHizmetId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["hizmet_id"].Value);

                // Get updated values from form elements
                string updatedAd = txtAd.Text;
                decimal updatedFiyat = Convert.ToDecimal(txtFiyat.Text);
                string updatedAciklama = txtAciklama.Text;

                // Create SQL UPDATE statement
                string updateQuery = "UPDATE Hizmetler SET ad = @ad, fiyat = @fiyat, aciklama = @aciklama WHERE hizmet_id = @hizmet_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", updatedAd);
                    cmd.Parameters.AddWithValue("@fiyat", updatedFiyat);
                    cmd.Parameters.AddWithValue("@aciklama", updatedAciklama);
                    cmd.Parameters.AddWithValue("@hizmet_id", selectedHizmetId);

                    // Execute the UPDATE query
                    cmd.ExecuteNonQuery();

                    // Update the DataGridView with the new values
                    DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                    selectedRow.Cells["ad"].Value = updatedAd;
                    selectedRow.Cells["fiyat"].Value = updatedFiyat;
                    selectedRow.Cells["aciklama"].Value = updatedAciklama;
                }

                // Clear the form fields after successful update
                txtAd.Clear();
                txtFiyat.Clear();
                txtAciklama.Clear();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // DataGridView'de seçilen satırın bilgilerini form elemanlarına aktar
                txtAd.Text = selectedRow.Cells["ad"].Value.ToString();
                txtFiyat.Text = selectedRow.Cells["fiyat"].Value.ToString();
                txtAciklama.Text = selectedRow.Cells["aciklama"].Value.ToString();
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {

            try
            {
                // Kontrol et: Silme işlemi için bir satır seçilmiş mi?
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    // Seçili hücrenin bulunduğu satırın hizmet_id'sini al
                    int selectedHizmetId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["hizmet_id"].Value);

                    // Silme işlemini gerçekleştirmek için DeleteSelectedRow metodunu çağır
                    DeleteSelectedRow(selectedHizmetId, rowIndex);
                }
                else
                {
                    MessageBox.Show("Lütfen silmek için bir hücre seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DeleteSelectedRow(int hizmetId, int rowIndex)
        {
            try
            {
                conn.Open();

                // SQL DELETE sorgusu
                string deleteQuery = "DELETE FROM Hizmetler WHERE hizmet_id = @hizmet_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@hizmet_id", hizmetId);

                    // DELETE sorgusunu çalıştır
                    cmd.ExecuteNonQuery();

                    // DataGridView'dan seçili satırı kaldır
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cevir_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();

                // PostgreSQL saklı yordamını çağıran SQL sorgusu
                string callProcedureQuery = "SELECT usd_cevir()";

                using (NpgsqlCommand cmd = new NpgsqlCommand(callProcedureQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                dataGridView1.Update(); // DataGridView'i güncelle
                dataGridView1.Refresh(); // DataGridView'i yeniden çiz
                // Veritabanındaki değişiklikleri manuel olarak çekip DataGridView'i güncelle
                LoadData();
                dataGridView1.Update(); // DataGridView'i güncelle
                dataGridView1.Refresh(); // DataGridView'i yeniden çiz
                MessageBox.Show("Fiyatlar başarıyla çarpıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void cmbparabirimi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // PostgreSQL saklı yordamını çağıran SQL sorgusu
                string callProcedureQuery = "SELECT try_cevir()";

                using (NpgsqlCommand cmd = new NpgsqlCommand(callProcedureQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                dataGridView1.Update(); // DataGridView'i güncelle
                dataGridView1.Refresh(); // DataGridView'i yeniden çiz
                // Veritabanındaki değişiklikleri manuel olarak çekip DataGridView'i güncelle
                LoadData();
                dataGridView1.Update(); // DataGridView'i güncelle
                dataGridView1.Refresh(); // DataGridView'i yeniden çiz

                MessageBox.Show("Fiyatlar başarıyla çarpıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
