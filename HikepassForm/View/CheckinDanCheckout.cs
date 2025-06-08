using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Controller; // Pastikan using ini ada
using HikepassLibrary.Model;      // Pastikan using ini ada

namespace HikepassForm.View
{
    public partial class CheckinDanCheckout : UserControl
    {
        // Variabel untuk menyimpan daftar tiket master dari controller
        private readonly List<Tiket> daftarTiket;
        // Variabel untuk menyimpan daftar barang yang baru diinput oleh pengguna
        private List<string> daftarBarangBaru;

        // PENTING: Konstruktor harus diubah untuk bisa menerima data tiket
        public CheckinDanCheckout(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;
            this.daftarBarangBaru = new List<string>();
        }

        // TAMBAHKAN EVENT LOAD: Ini akan dijalankan saat UserControl pertama kali ditampilkan
        private void CheckinDanCheckout_Load(object sender, EventArgs e)
        {
            RefreshTampilan();
        }

        // Method utama untuk menyegarkan dan mereset tampilan
        private void RefreshTampilan()
        {
            var tiketRelevan = daftarTiket
                .Where(t => t.Status == Tiket.StatusTiket.Dibayar || t.Status == Tiket.StatusTiket.Checkin)
                .ToList();

            tiketBindingSource.DataSource = tiketRelevan;
            // Kita tidak perlu set dataGridView1.DataSource lagi karena sudah terikat ke tiketBindingSource di desainer

            // Reset checkbox dan state tombol
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Gunakan nama kolom checkbox dari desainer Anda: "Pilih"
                row.Cells["Pilih"].Value = false;
            }
            UpdateTombolState();
        }

        // Mengisi logika saat sel di grid diklik
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan yang diklik adalah kolom checkbox "Pilih"
            if (e.ColumnIndex == dataGridView1.Columns["Pilih"].Index && e.RowIndex >= 0)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                UpdateTombolState(); // Update kondisi tombol setiap kali checkbox berubah
            }
        }

        // Method "pintar" untuk mengatur enabled/disabled tombol
        private void UpdateTombolState()
        {
            var tiketTercentang = new List<Tiket>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true)
                {
                    tiketTercentang.Add(row.DataBoundItem as Tiket);
                }
            }

            if (!tiketTercentang.Any())
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                return;
            }

            // Aturan Tombol Check-in: Aktif HANYA JIKA SEMUA yang dicentang berstatus 'Dibayar'
            btnCheckIn.Enabled = tiketTercentang.All(t => t.Status == Tiket.StatusTiket.Dibayar);

            // Aturan Tombol Check-out: Aktif HANYA JIKA SEMUA yang dicentang berstatus 'Checkin'
            btnCheckOut.Enabled = tiketTercentang.All(t => t.Status == Tiket.StatusTiket.Checkin);
        }

        // Mengisi logika untuk tombol Tambah Barang
        private void btnTambahBarang_Click(object sender, EventArgs e)
        {
            string barang = txtBoxInputBarang.Text.Trim();
            if (!string.IsNullOrEmpty(barang))
            {
                listBoxBarang.Items.Add(barang);
                daftarBarangBaru.Add(barang);
                txtBoxInputBarang.Clear();
                txtBoxInputBarang.Focus();
            }
        }

        // Mengisi logika untuk tombol Check-in
        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            await ProsesAksi(Tiket.StatusTiket.Dibayar, "Check-in");
        }

        // Mengisi logika untuk tombol Check-out
        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            await ProsesAksi(Tiket.StatusTiket.Checkin, "Check-out");
        }

        // Method pusat untuk memproses aksi agar tidak ada duplikasi kode
        private async Task ProsesAksi(Tiket.StatusTiket statusTarget, string namaAksi)
        {
            if (!daftarBarangBaru.Any())
            {
                MessageBox.Show("Harap masukkan minimal satu barang bawaan sebagai syarat.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tiketUntukProses = new List<Tiket>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true && (row.DataBoundItem as Tiket).Status == statusTarget)
                {
                    tiketUntukProses.Add(row.DataBoundItem as Tiket);
                }
            }

            if (!tiketUntukProses.Any()) return;

            foreach (var tiket in tiketUntukProses)
            {
                if (namaAksi == "Check-in")
                {
                    tiket.BarangBawaanSaatCheckin.AddRange(daftarBarangBaru);
                }
                else
                {
                    tiket.BarangBawaanSaatCheckout.AddRange(daftarBarangBaru);
                }

                await ControllerReservasi.UpdatedCheckInCheckOut("http://localhost:5226/api/reservasi", tiket.Id);
            }

            MessageBox.Show($"{tiketUntukProses.Count} tiket berhasil di-{namaAksi}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listBoxBarang.Items.Clear();
            daftarBarangBaru.Clear();
            txtBoxInputBarang.Clear();

            RefreshTampilan();
        }

        // Mengisi logika untuk tombol Kembali
        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        // Event sisa yang tidak terpakai bisa dibiarkan kosong
        private void listBoxBarang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBoxInputBarang_TextChanged(object sender, EventArgs e) { }
    }
}