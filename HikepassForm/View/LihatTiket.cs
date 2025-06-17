using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassForm.View
{
    public partial class LihatTiket : UserControl
    {
        // Menyimpan daftar tiket yang diterima dari konstruktor
        private readonly List<Tiket> daftarTiket;

        public LihatTiket(List<Tiket> tiketList)
        {
            InitializeComponent();

            // Inisialisasi daftar tiket
            this.daftarTiket = tiketList;

            // Langsung tampilkan tiket di grid saat control dibuat
            RefreshTampilan();

            // Pasang event handler tombol kembali
            btnKembali.Click += btnKembali_Click;
        }

        private void RefreshTampilan()
        {
            // Ambil list tiket dari controller, pastikan tidak null
            List<Tiket> tiketListToDisplay = ControllerReservasi.reservasiList?.ToList() ?? new List<Tiket>();

            try
            {
                // Reset data source agar binding baru bersih
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tiketListToDisplay;

                // Atur tampilan agar teks wrap dan tinggi baris menyesuaikan isi
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Refresh DataGridView untuk memastikan tampilan diperbarui
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                // Tampilkan pesan jika terjadi error saat bind data
                MessageBox.Show($"Terjadi kesalahan saat menampilkan tiket: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Navigasi kembali ke halaman TiketSaya
            if (this.Parent is TiketSaya parent)
            {
                parent.PindahKeTiketSaya();
            }
        }
    }
}
