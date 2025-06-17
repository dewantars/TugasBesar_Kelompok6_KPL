using HikepassLibrary.Model;
using HikepassLibrary.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HikepassForm.View
{
    // Komponen UserControl untuk halaman Informasi Pendaki
    public partial class InformasiPendaki : UserControl
    {
        // Service untuk akses data
        private readonly InformasiService informasiService;

        // Konstruktor
        public InformasiPendaki()
        {
            // Clean code: PascalCase
            InitializeComponent();
            informasiService = new InformasiService("informasi.json");
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
            kategori = KonversiInputKeKategori(input);

            // Secure code: memastikan dan tampil pesan jika kategori tidak valid
            if (kategori == null)
            {
                MessageBox.Show("Kategori tidak valid. Masukkan Peraturan / Tips / Umum.");
                return;
            }

            // Buat list untuk data informasi
            List<Informasi<string>> informasi = new();

            try
            {
                // Ambil semua informasi dari service
                informasi = informasiService.GetAllInformasi();
            }
            catch (Exception ex)
            {
                // Secure code: memastikan dan tampil pesan jika file gagal dibaca
                MessageBox.Show($"Gagal membaca file informasi: {ex.Message}");
                return;
            }

            // Filter data sesuai kategori
            var hasil = informasi
                .FindAll(i => i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

            // Secure code: memastikan dan tampil pesan jika Informasi tidak ditemukan
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

        // Mapping input pengguna ke nama kategori
        private string KonversiInputKeKategori(string input)
        {
            if (int.TryParse(input, out int angka))
            {
                // Mapping input integer ke kategori string
                return angka switch
                {
                    1 => "Peraturan",
                    2 => "Tips",
                    3 => "Umum",
                    _ => null
                };
            }

            // Mapping input string ke kategori string
            string lower = input.ToLower();
            return lower switch
            {
                "peraturan" => "Peraturan",
                "tips" => "Tips",
                "umum" => "Umum",
                _ => null
            };
        }

        // Kembali ke halaman dashboard
        private void buttonKembali_Click(object sender, EventArgs e)
        {
            var dashboard = this.Parent as DashboardPendaki;
            dashboard?.PindahKeDashboard();
        }

        private void labelInformasiPendaki_Click(object sender, EventArgs e) { }

        private void InformasiPendaki_Load(object sender, EventArgs e) { }
    }
}
