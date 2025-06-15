using HikepassLibrary.Model;
using HikepassLibrary.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikepassForm.View
{
    public partial class LaporanPendaki : UserControl
    {
        // Clean code: constructor menggunakan PascalCase sesuai standar method/fungsi
        public LaporanPendaki()
        {
            InitializeComponent();
        }

        // Event handler disiapkan jika ingin menambahkan interaksi saat item dipilih
        private void labelJudul_Click(object sender, EventArgs e) { }
        private void labelDeskripsi_Click(object sender, EventArgs e) { }
        private void textBoxDeskripsi_TextChanged(object sender, EventArgs e) { }
        private void labelLokasi_Click(object sender, EventArgs e) { }
        private void textBoxLokasi_TextChanged(object sender, EventArgs e) { }
        private void labelKeparahan_Click(object sender, EventArgs e) { }
        private void textBoxKeparahan_TextChanged(object sender, EventArgs e) { }
        private void labelHintKeparahan_Click(object sender, EventArgs e) { }
        private void LaporanPendaki_Load(object sender, EventArgs e) { }

        // Clean code: white space antar logika validasi ditambahkan untuk keterbacaan
        private void buttonKirim_Click(object sender, EventArgs e) 
        {
            string deskripsi = textBoxDeskripsi.Text.Trim(); // Clean code: variable menggunakan camelCase
            string lokasi = textBoxLokasi.Text.Trim(); // Clean code: variable declaration jelas dan deskriptif
            string keparahan = textBoxKeparahan.Text.Trim();

            if (string.IsNullOrWhiteSpace(deskripsi))
            {
                MessageBox.Show("Deskripsi tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(lokasi))
            {
                MessageBox.Show("Titik lokasi tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(keparahan))
            {
                MessageBox.Show("Tingkat keparahan tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Clean code: variable menggunakan camelCase, nama deskriptif dan mudah dipahami
            string idLaporan = "LAP" + DateTime.Now.ToString("yyyyMMddHHmmss");
            DateTime waktu = DateTime.Now;

            try
            {
                // Clean code: pemanggilan service ditempatkan terpisah dan jelas
                var laporan = new Laporan<string>(idLaporan, deskripsi, lokasi, waktu, keparahan);
                LaporanService.AddLaporan(laporan);

                MessageBox.Show("Laporan berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clean code: reset input setelah submit dilakukan
                textBoxDeskripsi.Text = "";
                textBoxLokasi.Text = "";
                textBoxKeparahan.Text = "";
            }
            catch (Exception ex)
            {
                // Clean code: exception handling dengan pesan yang jelas
                MessageBox.Show("Terjadi kesalahan saat mengirim laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var dashboard = this.Parent as DashboardPendaki;
            dashboard?.PindahKeDashboard();
        }
    }
}
