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
    public partial class InformasiPendaki : UserControl
    {
        public InformasiPendaki()
        {
            InitializeComponent();
        }

        private void labelInformasi_Click(object sender, EventArgs e) { }

        private void labelTampilkanInformasi_Click(object sender, EventArgs e) { }

        private void textBoxKategori_TextChanged(object sender, EventArgs e) { }

        private void buttonTampilkan_Click(object sender, EventArgs e)
        {
            // isi berdasarkan Informasi.cs dan InformasiService.cs
            string kategoriInput = textBoxKategori.Text.Trim();

            if (string.IsNullOrWhiteSpace(kategoriInput))
            {
                MessageBox.Show("Kategori tidak boleh kosong.");
                return;
            }

            string kategori = kategoriInput.ToLower() switch
            {
                "1" or "peraturan" => "Peraturan",
                "2" or "tips" => "Tips",
                "3" or "umum" => "Umum",
                _ => null
            };

            if (kategori == null)
            {
                MessageBox.Show("Kategori tidak valid. Masukkan 1, 2, 3 atau nama kategori langsung.");
                return;
            }

            List<Informasi<string>> daftar = new List<Informasi<string>>();

            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "informasi.json");
                string json = File.ReadAllText(path);
                daftar = JsonSerializer.Deserialize<List<Informasi<string>>>(json) ?? new List<Informasi<string>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal membaca file informasi: {ex.Message}");
                return;
            }

            var hasil = daftar.Where(i => i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase)).ToList();

            if (hasil.Count == 0)
            {
                MessageBox.Show($"Tidak ada informasi dalam kategori '{kategori}'.");
                return;
            }

            string output = "";
            foreach (var info in hasil)
            {
                output += string.Format("{0,-14}: {1}\n", "ID", info.IdInformasi);
                output += string.Format("{0,-10}: {1}\n", "Kategori", info.Kategori);
                output += string.Format("{0,-12}: {1}\n", "Judul", info.Judul);
                output += string.Format("{0,-10}: {1}\n", "Deskripsi", info.Deskripsi);
                output += string.Format("{0,-10}: {1}\n\n", "Tanggal", info.TanggalDibuat.ToString("dd/MM/yyyy HH.mm.ss"));
            }
            labelInformasiPendaki.Text = output;
        }

        private void labelInformasiPendaki_Click(object sender, EventArgs e) { }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            var dashboard = this.Parent as DashboardPendaki;
            dashboard?.PindahKeDashboard();
        }
        private void InformasiPendaki_Load(object sender, EventArgs e) { }
    }
}
