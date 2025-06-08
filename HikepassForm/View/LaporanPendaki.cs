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
            InitializeComponent();
        }
        private void labelJudul_Click(object sender, EventArgs e) { }

        private void labelDeskripsi_Click(object sender, EventArgs e) { }

        private void textBoxDeskripsi_TextChanged(object sender, EventArgs e) { }

        private void labelLokasi_Click(object sender, EventArgs e) { }

        private void textBoxLokasi_TextChanged(object sender, EventArgs e) { }

        private void labelKeparahan_Click(object sender, EventArgs e) { }

        private void comboBoxKeparahan_SelectedIndexChanged(object sender, EventArgs e) { }
        private void buttonKirim_Click(object sender, EventArgs e)
        {
            string deskripsi = textBoxDeskripsi.Text.Trim();
            string lokasi = textBoxLokasi.Text.Trim();
            string keparahan = comboBoxKeparahan.SelectedItem?.ToString();

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

            string idLaporan = "LAP" + DateTime.Now.ToString("yyyyMMddHHmmss");
            DateTime waktu = DateTime.Now;

            try
            {
                var laporan = new Laporan<string>(idLaporan, deskripsi, lokasi, waktu, keparahan);
                LaporanService.AddLaporan(laporan);

                MessageBox.Show("Laporan berhasil dikirim!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxDeskripsi.Text = "";
                textBoxLokasi.Text = "";
                comboBoxKeparahan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
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
