using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassForm.View
{
    
   
    
    public partial class CheckinDanCheckout : UserControl
    {
        // Daftar tiket yang diterima dari form utama
        private readonly List<Tiket> daftarTiket;

        // Menyimpan barang-barang baru yang dimasukkan saat check-in/check-out
        private List<string> daftarBarangBaru;

        
        /// Konstruktor: menginisialisasi komponen dan data awal.
        
        public CheckinDanCheckout(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;
            this.daftarBarangBaru = new List<string>();

            // Tampilkan data pertama kali saat kontrol dibuat
            RefreshTampilan();
        }

        
        /// Event handler untuk load control (double trigger dapat dihapus bila tidak dipakai)
        
        private void CheckinDanCheckout_Load(object sender, EventArgs e)
        {
            RefreshTampilan();
        }

        
        /// Memperbarui tampilan DataGridView dengan tiket berstatus Dibayar atau Checkin.
        
        private void RefreshTampilan()
        {
            // Filter hanya tiket dengan status Dibayar atau Checkin
            var tiketYangTampil = ControllerReservasi.reservasiList
                .Where(t => t.Status == Tiket.StatusTiket.Dibayar || t.Status == Tiket.StatusTiket.Checkin)
                .ToList();

            // Reset data source grid agar tidak terjadi duplikasi binding
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tiketYangTampil;

            // Pengaturan visual grid agar konten terlihat rapi
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Refresh();

            // Update status tombol setelah refresh
            UpdateTombolState();
        }

       
        /// Memeriksa tiket yang dipilih dan menyesuaikan tombol Check-in/Check-out.
        
        private void UpdateTombolState()
        {
            var tiketTercentang = new List<Tiket>();

            // Loop setiap baris grid untuk mencari tiket terpilih
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true)
                {
                    int id = (int)row.Cells["idDataGridViewTextBoxColumn"].Value;
                    var tiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == id);
                    if (tiket != null)
                    {
                        tiketTercentang.Add(tiket);
                    }
                }
            }

            // Nonaktifkan tombol jika tidak ada yang dipilih
            if (!tiketTercentang.Any())
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                return;
            }

            // Atur tombol aktif hanya jika semua tiket valid untuk aksi terkait
            btnCheckIn.Enabled = tiketTercentang.All(t => t.Status == Tiket.StatusTiket.Dibayar);
            btnCheckOut.Enabled = tiketTercentang.All(t => t.Status == Tiket.StatusTiket.Checkin);
        }

        
        /// Menangani event klik pada kolom checkbox untuk memilih tiket.
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan kolom yang diklik adalah kolom 'Pilih'
            if (e.ColumnIndex == dataGridView1.Columns["Pilih"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Toggle nilai checkbox
                bool currentValue = Convert.ToBoolean(row.Cells["Pilih"].Value);
                row.Cells["Pilih"].Value = !currentValue;

                dataGridView1.EndEdit();

                // Update tombol setelah toggle
                UpdateTombolState();
            }
        }

        
        /// Menambahkan barang baru ke daftar barang bawaan.
        
        private void btnTambahBarang_Click(object sender, EventArgs e)
        {
            string barang = txtBoxInputBarang.Text.Trim();

            // Validasi: hanya tambahkan jika input tidak kosong
            if (!string.IsNullOrEmpty(barang))
            {
                listBoxBarang.Items.Add(barang);
                daftarBarangBaru.Add(barang);

                txtBoxInputBarang.Clear();
                txtBoxInputBarang.Focus();
            }

            // (Optional) Refresh tampilan jika perlu memperbarui grid
            RefreshTampilan();
        }

        
        /// Memulai proses Check-in saat tombol diklik.
        
        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            await ProsesAksi("Check-in");
        }

        /// <summary>
        /// Memulai proses Check-out saat tombol diklik.
        /// </summary>
        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            await ProsesAksi("Check-out");
        }

        
        /// Proses utama untuk Check-in/Check-out tiket.
        
        private async Task ProsesAksi(string namaAksi)
        {
            // Validasi: pastikan ada barang bawaan
            if (!daftarBarangBaru.Any())
            {
                MessageBox.Show("Harap masukkan minimal satu barang bawaan sebagai syarat.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tentukan status asal sesuai aksi
            Tiket.StatusTiket statusSumber = namaAksi == "Check-in" ? Tiket.StatusTiket.Dibayar : Tiket.StatusTiket.Checkin;

            var tiketUntukProses = new List<Tiket>();

            // Cari tiket yang dipilih dan sesuai status
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true)
                {
                    int id = (int)row.Cells["idDataGridViewTextBoxColumn"].Value;
                    var tiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == id);

                    if (tiket != null && tiket.Status == statusSumber)
                    {
                        tiketUntukProses.Add(tiket);
                    }
                }
            }

            if (!tiketUntukProses.Any())
            {
                MessageBox.Show($"Tidak ada tiket dengan status '{statusSumber}' yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nonaktifkan tombol selama proses
            btnCheckIn.Enabled = false;
            btnCheckOut.Enabled = false;

            var updateTasks = new List<Task>();

            // Tambahkan barang bawaan ke tiket dan kirim update ke API
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

                // Panggil API update (sebaiknya ditambahkan try-catch di sini untuk secure code)
                updateTasks.Add(ControllerReservasi.UpdatedCheckInCheckOut("http://localhost:5226/api/reservasi", tiket.Id));
            }

            await Task.WhenAll(updateTasks);

            // Tampilkan pesan sukses
            MessageBox.Show($"{tiketUntukProses.Count} tiket berhasil di-{namaAksi}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form input
            listBoxBarang.Items.Clear();
            daftarBarangBaru.Clear();
            txtBoxInputBarang.Clear();

            RefreshTampilan();
        }

        
        /// Navigasi kembali ke form utama TiketSaya.
        
        private void btnKembali_Click(object sender, EventArgs e)
        {
            var tiketSaya = this.Parent as TiketSaya;
            tiketSaya?.PindahKeTiketSaya();
        }

        // Event handler tambahan (tidak digunakan, placeholder)
        private void listBoxBarang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBoxInputBarang_TextChanged(object sender, EventArgs e) { }
        private void CheckinDanCheckout_Load_1(object sender, EventArgs e) { }
    }
}
