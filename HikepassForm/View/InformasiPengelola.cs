// Import class dan library
using HikepassLibrary.Model;
using HikepassLibrary.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace HikepassForm.View
{
    // Komponen UserControl untuk halaman Informasi Pengelola
    public partial class InformasiPengelola : UserControl
    {
        // Service untuk mengelola data
        private readonly InformasiService informasiService;

        // Konstruktor
        public InformasiPengelola()
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

            string kategori = KonversiInputKeKategori(input);

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
            var hasil = informasi.FindAll(i =>
                i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

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

            // Secure code: memastikan dan tampil pesan jika input kosong
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
            }
            else if (input == "y")
            {
                // Jika ada Informasi ingin diedit, aktifkan textbox, button
                textBoxJudul.Enabled = true;
                textBoxDeskripsi.Enabled = true;
                buttonSimpan.Enabled = true;
                MessageBox.Show("Silakan edit informasi pada kolom Judul dan Deskripsi, lalu tekan Simpan.");
            }
            else
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
            string kategori = KonversiInputKeKategori(input);

            // Validasi input
            if (kategori == null)
            {
                MessageBox.Show("Kategori tidak valid. Masukkan Peraturan / Tips / Umum.");
                return;
            }

            string judul = textBoxJudul.Text.Trim();
            string deskripsi = textBoxDeskripsi.Text.Trim();

            // Secure code: memastikan dan tampil pesan jika judul/kategori kosong
            if (string.IsNullOrWhiteSpace(judul) || string.IsNullOrWhiteSpace(deskripsi))
            {
                MessageBox.Show("Judul dan Deskripsi tidak boleh kosong.");
                return;
            }

            // Hapus dan ganti informasi lewat service
            List<Informasi<string>> semua = informasiService.GetAllInformasi();
            semua.RemoveAll(i => i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));
            semua.Add(new Informasi<string>(
                id: "INF" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                kategori: kategori,
                judul: judul,
                deskripsi: deskripsi,
                tanggal: DateTime.Now
            ));

            try
            {
                informasiService.SimpanInformasi(semua);
                MessageBox.Show("Informasi berhasil disimpan!");
            }
            catch (Exception ex)
            {
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

        private string KonversiInputKeKategori(string input)
        {
            if (int.TryParse(input, out int angka))
            {
                return angka switch
                {
                    1 => "Peraturan",
                    2 => "Tips",
                    3 => "Umum",
                    _ => null
                };
            }

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
