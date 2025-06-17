// Import class dan library
using HikepassLibrary.Model; 
using HikepassLibrary.Service;
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
    // Komponen UserControl untuk halaman Informasi Pendaki
    public partial class InformasiPendaki : UserControl
    {
        // Konstruktor
        public InformasiPendaki()
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
            labelInformasiPendaki.Text = output.ToString();
        }

        private void labelInformasiPendaki_Click(object sender, EventArgs e) { }

        // Kembali ke halaman dashboard
        private void buttonKembali_Click(object sender, EventArgs e)
        {
            var dashboard = this.Parent as DashboardPendaki;
            dashboard?.PindahKeDashboard();
        }
        private void InformasiPendaki_Load(object sender, EventArgs e) { }
    }
}