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
    public partial class bayi_ekle : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("");

        public bayi_ekle()
        {
            InitializeComponent();
            IlListesiniGetir();
            comboBoxIl.SelectedIndexChanged += ComboBoxIl_SelectedIndexChanged;
        }

        private void IlListesiniGetir()
        {
            try
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT il_adi, plaka_kodu FROM public.Il", conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBoxIl.Items.Add(new IlItem
                            {
                                IlAdi = dr["il_adi"].ToString(),
                                PlakaKodu = Convert.ToInt32(dr["plaka_kodu"])
                            });
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

        private void ComboBoxIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIlce.Items.Clear();

            if (comboBoxIl.SelectedItem is IlItem selectedIl)
            {
                IlceleriGetir(selectedIl.PlakaKodu);
            }
        }

        private void IlceleriGetir(int ilPlakaKodu)
        {
            try
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT ilce_adi FROM public.Ilce WHERE il_id = @ilPlakaKodu", conn))
                {
                    cmd.Parameters.AddWithValue("@ilPlakaKodu", ilPlakaKodu);

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBoxIlce.Items.Add(dr["ilce_adi"].ToString());
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

        private void buttonEkle_Click(object sender, EventArgs e)
        {

        }

        private class IlItem
        {
            public string IlAdi { get; set; }
            public int PlakaKodu { get; set; }

            public override string ToString()
            {
                return IlAdi;
            }
        }

        private void buttonEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                IlItem selectedIl = comboBoxIl.SelectedItem as IlItem;
                if (selectedIl == null)
                {
                    MessageBox.Show("Lütfen bir il seçin.");
                    return;
                }

                string selectedIlce = comboBoxIlce.SelectedItem as string;
                if (string.IsNullOrEmpty(selectedIlce))
                {
                    MessageBox.Show("Lütfen bir ilçe seçin.");
                    return;
                }

                string mail = textBoxMail.Text;
                string telefon = textBoxTelefon.Text;
                string adres = textBoxAdres.Text;

                int iletisimId;
                // Iletisim tablosuna ekleme
                using (NpgsqlCommand cmdIletisim = new NpgsqlCommand("INSERT INTO public.Iletisim (telefon, mail) VALUES (@telefon, @mail) RETURNING iletisim_id", conn))
                {
                    cmdIletisim.Parameters.AddWithValue("@telefon", telefon);
                    cmdIletisim.Parameters.AddWithValue("@mail", mail);

                    iletisimId = Convert.ToInt32(cmdIletisim.ExecuteScalar());
                }

                int ilceId;
                // Ilce tablosundan ilce_id değerini alın
                using (NpgsqlCommand cmdIlceId = new NpgsqlCommand("SELECT posta_kodu FROM public.Ilce WHERE ilce_adi = @ilceAdi", conn))
                {
                    cmdIlceId.Parameters.AddWithValue("@ilceAdi", selectedIlce);

                    ilceId = Convert.ToInt32(cmdIlceId.ExecuteScalar());
                }

                int adresId;
                // Adres tablosuna ekleme
                using (NpgsqlCommand cmdAdres = new NpgsqlCommand("INSERT INTO public.Adres (adres, ilce_id) VALUES (@adres, @ilceId) RETURNING adres_id", conn))
                {
                    cmdAdres.Parameters.AddWithValue("@adres", adres);
                    cmdAdres.Parameters.AddWithValue("@ilceId", ilceId);

                    adresId = Convert.ToInt32(cmdAdres.ExecuteScalar());
                }

                // Bayi tablosuna ekleme
                using (NpgsqlCommand cmdBayi = new NpgsqlCommand("INSERT INTO public.Bayi (iletisim_id, adres_id) VALUES (@iletisimId, @adresId)", conn))
                {
                    cmdBayi.Parameters.AddWithValue("@iletisimId", iletisimId);
                    cmdBayi.Parameters.AddWithValue("@adresId", adresId);

                    int affectedRows = cmdBayi.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Bayi başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bayi eklenirken bir hata oluştu.");
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
    }
}