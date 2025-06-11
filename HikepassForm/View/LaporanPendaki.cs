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
        public LaporanPendaki()
        {
            InitializeComponent(); // Clean code: konstruktor hanya memanggil inisialisasi visual
        }

        private void labelJudul_Click(object sender, EventArgs e) { }
        private void labelDeskripsi_Click(object sender, EventArgs e) { }
        private void textBoxDeskripsi_TextChanged(object sender, EventArgs e) { }
        private void labelLokasi_Click(object sender, EventArgs e) { }
        private void textBoxLokasi_TextChanged(object sender, EventArgs e) { }
        private void labelKeparahan_Click(object sender, EventArgs e) { }
        private void comboBoxKeparahan_SelectedIndexChanged(object sender, EventArgs e) { }
        private void LaporanPendaki_Load(object sender, EventArgs e) { }

        private void buttonKirim_Click(object sender, EventArgs e)
        {
            // Clean code: pengambilan input dari form dilakukan di awal dan disusun rapi
            string deskripsi = textBoxDeskripsi.Text.Trim();
            string lokasi = textBoxLokasi.Text.Trim();
            string keparahan = comboBoxKeparahan.SelectedItem?.ToString();

            // Secure coding: validasi input dari user dilakukan sebelum diproses
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
                MessageBox.Show("Silakan pilih tingkat keparahan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Clean code: ID dibuat unik dengan format timestamp
            string idLaporan = "LAP" + DateTime.Now.ToString("yyyyMMddHHmmss");
            DateTime waktu = DateTime.Now;

            try
            {
                // Clean code: objek laporan dibuat secara eksplisit
                var laporan = new Laporan<string>(idLaporan, deskripsi, lokasi, waktu, keparahan);

                // Clean code & secure coding: pemanggilan service terpusat, mudah dipantau
                LaporanService.AddLaporan(laporan);

                MessageBox.Show("Laporan berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clean code: reset form setelah berhasil
                textBoxDeskripsi.Text = "";
                textBoxLokasi.Text = "";
                comboBoxKeparahan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Secure coding: penanganan error tidak menyebabkan crash, tampilkan pesan yang aman
                MessageBox.Show("Terjadi kesalahan saat mengirim laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Clean code: navigasi menggunakan referensi parent control dengan pengecekan null
            var dashboard = this.Parent as DashboardPendaki;
            dashboard?.PindahKeDashboard();
        }
    }
}
