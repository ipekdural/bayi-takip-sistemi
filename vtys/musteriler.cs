using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace vtys
{
    public partial class musteriler : Form
    {
        private readonly NpgsqlConnection conn = new NpgsqlConnection("");
        private readonly DataTable dt = new DataTable();

        public musteriler()
        {
            InitializeComponent();
        }

        private void musteriler_Load(object sender, EventArgs e)
        {
            LoadMusteriData();
        }

        private void LoadMusteriData()
        {
            label6.Text = GetCustomerCount().ToString();
            try
            {
                conn.Open();
                string sql = "SELECT musteri_id AS \"Müşteri ID\", ad || ' ' || soyad AS \"Müşteri\", telefon AS \"İletişim\", adres AS \"Adres\" FROM public.Musteri";
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }

                dataGridView1.DataSource = dt;
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

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;

                if (!int.TryParse(txtTelefon.Text, out int telefon))
                {
                    MessageBox.Show("Geçersiz telefon.");
                    return;
                }

                string adres = txtAdres.Text;

                string sql = "INSERT INTO public.Musteri (ad, soyad, telefon, adres) VALUES (@ad, @soyad, @telefon, @adres) RETURNING musteri_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@adres", adres);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int newMusteriId = Convert.ToInt32(result);
                        DataRow newRow = dt.NewRow();
                        newRow["Müşteri ID"] = newMusteriId;
                        newRow["Müşteri"] = ad + " " + soyad;
                        newRow["İletişim"] = telefon.ToString();
                        newRow["Adres"] = adres;
                        dt.Rows.Add(newRow);

                        MessageBox.Show("Müşteri eklendi.");

                    }
                    else
                    {
                        MessageBox.Show("Müşteri eklenirken hata oluştu.");
                    }
                }

            }

            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            label6.Text = string.Empty;
            label6.Text = GetCustomerCount().ToString();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    int musteriID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Müşteri ID"].Value);
                    string ad = txtAd.Text;
                    string soyad = txtSoyad.Text;

                    if (!int.TryParse(txtTelefon.Text, out int telefon))
                    {
                        MessageBox.Show("Telefon must be a valid integer.");
                        return;
                    }

                    string adres = txtAdres.Text;

                    string sql = "UPDATE public.Musteri SET ad = @ad, soyad = @soyad, telefon = @telefon, adres = @adres WHERE musteri_id = @musteriID";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", ad);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@telefon", telefon);
                        cmd.Parameters.AddWithValue("@adres", adres);
                        cmd.Parameters.AddWithValue("@musteriID", musteriID);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            dataGridView1.Rows[rowIndex].Cells["Müşteri"].Value = ad + " " + soyad;
                            dataGridView1.Rows[rowIndex].Cells["İletişim"].Value = telefon.ToString();
                            dataGridView1.Rows[rowIndex].Cells["Adres"].Value = adres;

                            MessageBox.Show("Müşteri güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri güncellenirken hata oluştu.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz müşteriyi seçin.");
                }
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

        private void btn_sil_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;
                    int musteriID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Müşteri ID"].Value);

                    string sql = "DELETE FROM public.Musteri WHERE musteri_id = @musteriID";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@musteriID", musteriID);

                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            dt.Rows.RemoveAt(rowIndex); // Remove the row from the DataTable
                            dataGridView1.DataSource = dt; // Update the DataGridView
                            MessageBox.Show("Müşteri silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri silinirken hata oluştu.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçin.");
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
            label6.Text = string.Empty;
            label6.Text = GetCustomerCount().ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // PostgreSQL saklı yordamı çağırma
        private int GetCustomerCount()
        {
            int customerCount = 0;

            try
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT public.get_customer_count()", conn))
                {
                    customerCount = (int)cmd.ExecuteScalar();
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

            return customerCount;
        }


        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtAd.Text = selectedRow.Cells["Müşteri"].Value.ToString().Split(' ')[0];
                txtSoyad.Text = selectedRow.Cells["Müşteri"].Value.ToString().Split(' ')[1];
                txtTelefon.Text = selectedRow.Cells["İletişim"].Value.ToString();
                txtAdres.Text = selectedRow.Cells["Adres"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string arananMusteri = txtaramusteri.Text.ToLower(); // Arama sorgusunu küçük harfe çeviriyoruz

            try
            {
                conn.Open();

                string query = "SELECT * FROM musteri WHERE LOWER(ad || ' ' ||soyad) LIKE @arananMusteri";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@arananMusteri", "%" + arananMusteri + "%");

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'e verileri aktarma
                    dataGridView1.DataSource = dataTable;
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
    }
}
