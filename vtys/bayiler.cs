using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vtys
{
    public partial class bayiler : Form
    {

        public bayiler()
        {
            InitializeComponent();
        }
        readonly NpgsqlConnection conn = new NpgsqlConnection("");
        private void bayiler_Load(object sender, EventArgs e)
        {

            conn.Open();

            // "İl" ComboBox'ını "Il" tablosundan doldur
            string ilQuery = "SELECT * FROM public.Il";
            NpgsqlDataAdapter ilDataAdapter = new NpgsqlDataAdapter(ilQuery, conn);
            DataTable ilDataTable = new DataTable();
            ilDataAdapter.Fill(ilDataTable);
            ilComboBox.DataSource = ilDataTable;
            ilComboBox.DisplayMember = "il_adi";
            ilComboBox.ValueMember = "plaka_kodu";

            // Seçilen ile göre "İlçe" ComboBox'ını güncelle
            ilComboBox_SelectedIndexChanged(sender, e);
            try
            {
                conn.Open();

                string query = @"SELECT 
                    b.bayi_id AS ""Bayi ID"",
                    il.il_adi AS ""İl"",
                    ilce.ilce_adi AS ""İlçe"",
                    a.adres || ', ' || ilce.ilce_adi || ', ' || il.il_adi AS ""Açık Adres"",
                    i.telefon || ', ' || i.mail AS ""İletişim Bilgileri""
                  
                FROM public.Bayi b
                INNER JOIN public.Iletisim i ON b.iletisim_id = i.iletisim_id
                INNER JOIN public.Adres a ON b.adres_id = a.adres_id
                INNER JOIN public.Ilce ilce ON a.ilce_id = ilce.posta_kodu
                INNER JOIN public.Il il ON ilce.il_id = il.plaka_kodu";


                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ilceComboBox.SelectedItem = null; ilComboBox.SelectedItem = null;
                // DataGridView'e verileri yükle
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Veritabanından veriler çekilemedi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            bayi_ekle b = new bayi_ekle();
            b.Show();
            bayiler_Load(sender, e); // DataGridView'i güncelle

        }
        private DataTable ilDataTable; // ilDataTable'ı global alanda tanımlayın

        private void btn_sil_Click(object sender, EventArgs e)
        {
            // DataGridView'den seçili satırı kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Kullanıcıdan onay al
                DialogResult result = MessageBox.Show("Seçili bayiyi silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Seçili bayi ID'sini al
                    int selectedBayiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Bayi ID"].Value);

                    try
                    {
                        conn.Open();

                        // Bayiye ait iletisim_id ve adres_id'yi al
                        string selectIletisimAdresQuery = "SELECT iletisim_id, adres_id FROM public.Bayi WHERE bayi_id = @BayiID";
                        NpgsqlCommand selectCmd = new NpgsqlCommand(selectIletisimAdresQuery, conn);
                        selectCmd.Parameters.AddWithValue("@BayiID", selectedBayiID);

                        NpgsqlDataReader reader = selectCmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int iletisimID = reader.GetInt32(0);
                            int adresID = reader.GetInt32(1);

                            reader.Close();

                            // Bayi silme sorgusu
                            string deleteBayiQuery = "DELETE FROM public.Bayi WHERE bayi_id = @BayiID";
                            NpgsqlCommand deleteBayiCmd = new NpgsqlCommand(deleteBayiQuery, conn);
                            deleteBayiCmd.Parameters.AddWithValue("@BayiID", selectedBayiID);

                            int rowsAffectedBayi = deleteBayiCmd.ExecuteNonQuery();

                            if (rowsAffectedBayi > 0)
                            {
                                // Iletisim silme sorgusu
                                string deleteIletisimQuery = "DELETE FROM public.Iletisim WHERE iletisim_id = @IletisimID";
                                NpgsqlCommand deleteIletisimCmd = new NpgsqlCommand(deleteIletisimQuery, conn);
                                deleteIletisimCmd.Parameters.AddWithValue("@IletisimID", iletisimID);
                                deleteIletisimCmd.ExecuteNonQuery();

                                // Adres silme sorgusu
                                string deleteAdresQuery = "DELETE FROM public.Adres WHERE adres_id = @AdresID";
                                NpgsqlCommand deleteAdresCmd = new NpgsqlCommand(deleteAdresQuery, conn);
                                deleteAdresCmd.Parameters.AddWithValue("@AdresID", adresID);
                                deleteAdresCmd.ExecuteNonQuery();

                                MessageBox.Show("Bayi ve ilişkili bilgiler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // DataGridView'i güncelle
                                bayiler_Load(sender, e);
                            }
                            else
                            {
                                //  MessageBox.Show("Bayi silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("Bayi silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bayiyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bayiler_Load(sender, e); // DataGridView'i güncelle
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the selected Bayi ID
                    int selectedBayiId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Bayi ID"].Value);

                    // Get the updated values from the form controls
                    string updatedAdres = adrestxt.Text;
                    string updatedIlce = ilceComboBox.SelectedValue?.ToString(); // Use SelectedValue
                    string updatedIl = ilComboBox.SelectedValue?.ToString();
                    string updatedTelefon = telefontxt.Text;
                    string updatedMail = mailtxt.Text;

                    // Update the Bayi information in the database
                    UpdateBayi(selectedBayiId, updatedAdres, updatedIlce, updatedIl, updatedTelefon, updatedMail);

                    // Display a success message
                    MessageBox.Show("Bayi bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the DataGridView
                    bayiler_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bayi güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz bayiyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Bayi ID'yi al
                    int selectedBayiId = Convert.ToInt32(row.Cells["Bayi ID"].Value);

                    // Veritabanından il, ilçe, adres ve iletişim bilgilerini çek
                    string query = @"SELECT 
                            a.adres AS ""Adres"",
                            ilce.ilce_adi AS ""Ilce"",
                            il.il_adi AS ""Il"",
                            i.telefon AS ""Telefon"",
                            i.mail AS ""Mail""
                         FROM public.Bayi b
                         INNER JOIN public.Adres a ON b.adres_id = a.adres_id
                         INNER JOIN public.Ilce ilce ON a.ilce_id = ilce.posta_kodu
                         INNER JOIN public.Il il ON ilce.il_id = il.plaka_kodu
                         INNER JOIN public.Iletisim i ON b.iletisim_id = i.iletisim_id
                         WHERE b.bayi_id = @BayiID";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BayiID", selectedBayiId);

                        conn.Open();
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Adres bilgisini al
                                string adres = reader["Adres"].ToString();
                                adrestxt.Text = adres;

                                // İlçe bilgisini al
                                string ilce = reader["Ilce"].ToString();
                                ilceComboBox.SelectedItem = ilce;

                                // İl bilgisini al
                                string il = reader["Il"].ToString();
                                ilComboBox.SelectedItem = il;

                                // Telefon bilgisini al
                                string telefon = reader["Telefon"].ToString();
                                telefontxt.Text = telefon;

                                // Mail bilgisini al
                                string mail = reader["Mail"].ToString();
                                mailtxt.Text = mail;
                            }
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

        private void ilComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ilComboBox.SelectedValue != null)
                {
                    conn.Open();

                    // Seçilen ile göre "İlçe" ComboBox'ını güncelle
                    string ilceQuery = "SELECT * FROM public.Ilce WHERE il_id = @IlID";
                    NpgsqlDataAdapter ilceDataAdapter = new NpgsqlDataAdapter(ilceQuery, conn);
                    ilceDataAdapter.SelectCommand.Parameters.AddWithValue("@IlID", ilComboBox.SelectedValue);
                    DataTable ilceDataTable = new DataTable();
                    ilceDataAdapter.Fill(ilceDataTable);

                    // ilceComboBox'un DataSource'ını ve DisplayMember ile ValueMember'ını güncelle
                    ilceComboBox.DataSource = ilceDataTable;
                    ilceComboBox.DisplayMember = "ilce_adi";
                    ilceComboBox.ValueMember = "posta_kodu";

                    // Varsayılan değeri seçili olmayan bir değer yap

                }
            }
            catch (Exception ex)
            {
                // Hata durumlarını yönet
            }
            finally
            {
                conn.Close();
            }

            // Varsayılan değeri seçili olmayan bir değer yap (il için)
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }
        private void UpdateBayi(int bayiId, string adres, string ilce, string il, string telefon, string mail)
        {
            try
            {
                conn.Open();

                // Get iletisim_id and adres_id for the selected Bayi
                string selectIletisimAdresQuery = "SELECT iletisim_id, adres_id FROM public.Bayi WHERE bayi_id = @BayiID";
                using (NpgsqlCommand selectCmd = new NpgsqlCommand(selectIletisimAdresQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@BayiID", bayiId);

                    using (NpgsqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int iletisimID = reader.GetInt32(0);
                            int adresID = reader.GetInt32(1);

                            reader.Close();

                            // Update Iletisim information
                            string updateIletisimQuery = "UPDATE public.Iletisim SET telefon = @Telefon, mail = @Mail WHERE iletisim_id = @IletisimID";
                            using (NpgsqlCommand updateIletisimCmd = new NpgsqlCommand(updateIletisimQuery, conn))
                            {
                                updateIletisimCmd.Parameters.AddWithValue("@Telefon", telefon);
                                updateIletisimCmd.Parameters.AddWithValue("@Mail", mail);
                                updateIletisimCmd.Parameters.AddWithValue("@IletisimID", iletisimID);
                                updateIletisimCmd.ExecuteNonQuery();
                            }

                            // Update Adres information
                            string updateAdresQuery = "UPDATE public.Adres SET adres = @Adres, ilce_id = @IlceID WHERE adres_id = @AdresID";
                            using (NpgsqlCommand updateAdresCmd = new NpgsqlCommand(updateAdresQuery, conn))
                            {
                                updateAdresCmd.Parameters.AddWithValue("@Adres", adres);
                                updateAdresCmd.Parameters.AddWithValue("@IlceID", Convert.ToInt32(ilce)); // Convert to integer
                                updateAdresCmd.Parameters.AddWithValue("@AdresID", adresID);
                                updateAdresCmd.ExecuteNonQuery();
                            }

                            // Update Bayi information
                            string updateBayiQuery = "UPDATE public.Bayi SET adres_id = @AdresID WHERE bayi_id = @BayiID";
                            using (NpgsqlCommand updateBayiCmd = new NpgsqlCommand(updateBayiQuery, conn))
                            {
                                updateBayiCmd.Parameters.AddWithValue("@AdresID", adresID);
                                updateBayiCmd.Parameters.AddWithValue("@BayiID", bayiId);
                                updateBayiCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
