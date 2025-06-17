// Import class dan library
using HikepassLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikepassForm.View
{
    // Komponen UserControl untuk halaman Informasi Pengelola
    public partial class InformasiPengelola : UserControl
    {
        // Konstruktor
        public InformasiPengelola()
        {
            // Clean code: PascalCase
            InitializeComponent();
        }

        private void labelInformasi_Click(object sender, EventArgs e) { }

        private void labelTampilkanInformasi_Click(object sender, EventArgs e) { }

        private void textBoxKategori_TextChanged(object sender, EventArgs e) { }

        private void buttonTampilkan_Click(object sender, EventArgs e)
        {
            // Clean code: CamelCase
            string input = textBoxKategori.Text.Trim();

            // Secure code: memastikan dan tampil pesan jika kategori kosong
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Kategori tidak boleh kosong.");
                return;
            }

            string kategori;

            // Clean code: white space, indention
            if (int.TryParse(input, out int angka))
            {
                // Mapping input integer ke kategori string
                kategori = angka switch
                {
                    1 => "Peraturan",
                    2 => "Tips",
                    3 => "Umum",
                    _ => null
                };
            }
            else
            {
                // Mapping input string ke kategori string
                string lower = input.ToLower();
                kategori = lower switch
                {
                    "peraturan" => "Peraturan",
                    "tips" => "Tips",
                    "umum" => "Umum",
                    _ => null
                };
            }

            // Secure code: memastikan dan tampil pesan jika kategori tidak valid
            if (kategori == null)
            {
                MessageBox.Show("Kategori tidak valid. Masukkan 1, 2, 3 atau Peraturan/Tips/Umum.");
                return;
            }

            // Buat list untuk data informasi
            List<Informasi<string>> informasi = new List<Informasi<string>>();

            try
            {
                // Baca file informasi.json
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "informasi.json");
                string json = File.ReadAllText(path);
                // Ubah JSON jadi list objek
                informasi = JsonSerializer.Deserialize<List<Informasi<string>>>(json) ?? new List<Informasi<string>>();
            }
            catch (Exception ex)
            {
                // Secure code: memastikan dan tampil pesan jika file gagal dibaca
                MessageBox.Show($"Gagal membaca file informasi: {ex.Message}");
                return;
            }

            // Filter data sesuai kategori
            var hasil = informasi
                .Where(i => i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Secure code: memastikan dan tampil pesan jika Informasi idak ditemukan
            if (hasil.Count == 0)
            {
                MessageBox.Show($"Tidak ada informasi dalam kategori '{kategori}'.");
                return;
            }

            // Format Informasi agar rapi
            StringBuilder output = new();
            foreach (var info in hasil)
            {
                output.AppendLine(string.Format("{0,-14}: {1}", "ID", info.IdInformasi));
                output.AppendLine(string.Format("{0,-10}: {1}", "Kategori", info.Kategori));
                output.AppendLine(string.Format("{0,-12}: {1}", "Judul", info.Judul));
                output.AppendLine(string.Format("{0,-10}: {1}", "Deskripsi", info.Deskripsi));
                output.AppendLine(string.Format("{0,-10}: {1}", "Tanggal", info.TanggalDibuat.ToString("dd/MM/yyyy HH.mm.ss")));
            }

            // Tampil Informasi ke label
            labelInformasiPengelola.Text = output.ToString();

            // Aktifkan textBox, button
            textBoxYorN.Enabled = true;
            buttonEdit.Enabled = true;
        }

        private void labelInformasiPengelola_Click(object sender, EventArgs e) { }

        private void labelEditInformasi_Click(object sender, EventArgs e) { }

        private void textBoxYorN_TextChanged(object sender, EventArgs e) { }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string input = textBoxYorN.Text.Trim().ToLower();

            // Secure code: memastikan dan tampil pesan jika kategori kosong
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Input tidak boleh kosong.");
                return;
            }

           if (input == "n")
           {
                // Jika tidak ada Informasi yang ingin diedit, reset input, output, button
                MessageBox.Show("Tidak ada Informasi yang diedit.");
                textBoxKategori.Clear();
                labelInformasiPengelola.Text = "";
                textBoxYorN.Clear();
                buttonEdit.Enabled = false;
                textBoxJudul.Enabled = false;
                textBoxDeskripsi.Enabled = false;
                return;

           } else if (input == "y") 
           { 
                // Jika ada Informasi ingin diedit, aktifkan tetxtBox, button
                textBoxJudul.Enabled = true;
                textBoxDeskripsi.Enabled = true;
                buttonSimpan.Enabled = true;
                MessageBox.Show("Silakan edit informasi pada kolom Judul dan Deskripsi, lalu tekan Simpan.");
           } else
           {
                MessageBox.Show("Input tidak valid. Masukkan y/n.");
                return;
           }
        }

        private void labelEditJudul_Click(object sender, EventArgs e) { }

        private void textBoxJudul_TextChanged(object sender, EventArgs e) { }

        private void labelEditDeskripsi_Click(object sender, EventArgs e) { }

        private void textBoxDeskripsi_TextChanged(object sender, EventArgs e) { }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            // Clean code: CamelCase
            string input = textBoxKategori.Text.Trim();

            // Secure code: memastikan dan tampil pesan jika kategori kosong
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Kategori tidak boleh kosong.");
                return;
            }

            string kategori;

            // Clean code: white space, indention
            if (int.TryParse(input, out int angka))
            {
                // Mapping input integer ke kategori string
                kategori = angka switch
                {
                    1 => "Peraturan",
                    2 => "Tips",
                    3 => "Umum",
                    _ => null
                };
            }
            else
            {
                // Mapping input string ke kategori string
                string lower = input.ToLower();
                kategori = lower switch
                {
                    "peraturan" => "Peraturan",
                    "tips" => "Tips",
                    "umum" => "Umum",
                    _ => null
                };
            }

            // Secure code: memastikan dan tampil pesan jika kategori tidak valid
            if (kategori == null)
            {
                MessageBox.Show("Kategori tidak valid. Masukkan 1/2/3 atau Peraturan/Tips/Umum.");
                return;
            }

            // Clean code: variable/aatribute declaration
            string judul = textBoxJudul.Text.Trim();
            string deskripsi = textBoxDeskripsi.Text.Trim();

            // Secure code: memastikan dan tampil pesan jika judul/kategori kosong
            if (string.IsNullOrWhiteSpace(judul) || string.IsNullOrWhiteSpace(deskripsi))
            {
                MessageBox.Show("Judul dan Deskripsi tidak boleh kosong.");
                return;
            }

            // Buat list untuk data informasi
            List<Informasi<string>> informasi = new List<Informasi<string>>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "informasi.json");

            try
            {
                if (File.Exists(path))
                {
                    // Baca file informasi.json
                    string json = File.ReadAllText(path);
                    // Ubah JSON jadi list objek
                    informasi = JsonSerializer.Deserialize<List<Informasi<string>>>(json) ?? new List<Informasi<string>>();
                }
            }
            catch (Exception ex)
            {
                // Secure code: memastikan dan tampil pesan jika file gagal dibaca
                MessageBox.Show("Gagal membaca file: " + ex.Message);
                return;
            }

            // Hapus Informasi lama
            informasi.RemoveAll(i => i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

            // Buat Informasi baru
            var informasiBaru = new Informasi<string>(
                id: "INF" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                kategori: kategori,
                judul: judul,
                deskripsi: deskripsi,
                tanggal: DateTime.Now
            );

            // Tambah Informasi ke list
            informasi.Add(informasiBaru);

            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                // Tulis ke file json
                File.WriteAllText(path, JsonSerializer.Serialize(informasi, options));
                MessageBox.Show("Informasi berhasil disimpan!");
            }
            catch (Exception ex)
            {
                // Secure code: memastikan dan tampil pesan jika file gagal disimpan
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }

            // Reset semua input dan output
            textBoxKategori.Clear();
            labelInformasiPengelola.Text = "";
            textBoxYorN.Clear();
            textBoxJudul.Clear();
            textBoxDeskripsi.Clear();

            // Kunci ulang semua textBox dan button
            textBoxYorN.Enabled = false;
            buttonEdit.Enabled = false;
            textBoxJudul.Enabled = false;
            textBoxDeskripsi.Enabled = false;
            buttonSimpan.Enabled = false;
        }

        // Kembali ke halaman dashboard
        private void buttonKembali_Click(object sender, EventArgs e)
        {
            var dashboard = this.Parent as DashboardPengelola;
            dashboard?.PindahKeDashboard();
        }

        // Kunci semua textBox dan button
        private void InformasiPengelola_Load(object sender, EventArgs e) 
        {
            textBoxYorN.Enabled = false;
            buttonEdit.Enabled = false;
            textBoxJudul.Enabled = false;
            textBoxDeskripsi.Enabled = false;
            buttonSimpan.Enabled = false;
        }

    }
}
