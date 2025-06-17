using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;

namespace HikepassForm.View
{
    public partial class Pembayaran : UserControl
    {
        private readonly List<Tiket> _daftarTiket;

        public Pembayaran(List<Tiket> tiketList)
        {
            InitializeComponent();
            _daftarTiket = tiketList ?? new List<Tiket>(); // pastikan tidak null untuk keamanan
        }

        public void LoadPage(UserControl page)
        {
            // Ganti halaman saat navigasi
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        private void RefreshTampilan()
        {
            // Ambil tiket dengan status 'Belum Dibayar'
            var tiketBelumDibayar = ControllerReservasi.reservasiList
                .Where(t => t.Status == StatusTiket.BelumDibayar)
                .ToList();

            // Bind data ke DataGridView
            var bindingList = new BindingList<Tiket>(tiketBelumDibayar);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingList;
            dataGridView1.Refresh();

            // Update tampilan label dan tombol
            if (tiketBelumDibayar.Any())
            {
                lblStatusInfo.Text = "Silakan pilih tiket yang akan dibayar.";
                btnBayar.Enabled = true;
            }
            else
            {
                lblStatusInfo.Text = "Tidak ada tiket yang perlu dibayar.";
                btnBayar.Enabled = false;
            }
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            // Inisialisasi tampilan saat form dimuat
            RefreshTampilan();

            // Pengaturan wrap text dan ukuran sel
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit perubahan saat checkbox di-edit
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan bukan baris header
            if (e.RowIndex < 0) return;

            // Cek perubahan pada kolom PilihTiket
            if (dataGridView1.Columns["PilihTiket"] != null &&
                e.ColumnIndex == dataGridView1.Columns["PilihTiket"].Index)
            {
                var idCell = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                var pilihCell = dataGridView1.Rows[e.RowIndex].Cells["PilihTiket"].Value;

                if (idCell != null && pilihCell != null)
                {
                    int idTiket = Convert.ToInt32(idCell);
                    bool isChecked = Convert.ToBoolean(pilihCell);

                    // Update status pembayaran tiket
                    var tiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);
                    if (tiket != null)
                    {
                        tiket.StatusPembayaran = isChecked;
                    }
                }
            }
        }

        private async void btnBayar_Click(object sender, EventArgs e)
        {
            try
            {
                // Kumpulkan ID tiket yang dicentang
                var tiketYangDibayar = new List<int>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["checkBox"] is DataGridViewCheckBoxCell cell &&
                        cell.Value != null && (bool)cell.Value)
                    {
                        int tiketId = Convert.ToInt32(row.Cells["idDataGridViewTextBoxColumn"].Value);
                        tiketYangDibayar.Add(tiketId);
                    }
                }

                if (!tiketYangDibayar.Any())
                {
                    // Validasi: Tidak ada tiket dipilih
                    MessageBox.Show("Silakan pilih tiket yang ingin dibayar.");
                    return;
                }

                foreach (var id in tiketYangDibayar)
                {
                    // Update status pada objek lokal
                    var tiket = _daftarTiket.FirstOrDefault(t => t.Id == id);
                    if (tiket != null)
                    {
                        tiket.Status = StatusTiket.Dibayar;
                        tiket.StatusPembayaran = false;
                    }

                    // Kirim update ke API
                    await ControllerReservasi.UpdatedPembayaran("http://localhost:5226/api/reservasi", id);
                }

                RefreshTampilan();
                MessageBox.Show("Pembayaran berhasil diproses.");
            }
            catch (Exception ex)
            {
                // Tangani error tak terduga
                MessageBox.Show($"Terjadi kesalahan saat memproses pembayaran: {ex.Message}");
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Navigasi ke halaman TiketSaya
            var tiketSaya = new TiketSaya();
            LoadPage(tiketSaya);
        }
    }
}
