using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassForm.View
{
    public partial class Selesaikan : UserControl
    {
        // Gunakan naming convention _camelCase untuk atribut private
        private readonly List<Tiket> _daftarTiket;

        public Selesaikan(List<Tiket> tiketList)
        {
            InitializeComponent();
            _daftarTiket = tiketList;

            RefreshTampilan();

            // Pasang event handler button
            btnSelesaikan.Click += BtnSelesaikan_Click;
            btnKembali.Click += BtnKembali_Click;

            // Pasang event handler untuk grid
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }

        private void RefreshTampilan()
        {
            // Ambil tiket dengan status Checkout
            var tiketYangTampil = ControllerReservasi.reservasiList
                .Where(t => t.Status == Tiket.StatusTiket.Checkout)
                .ToList();

            // Reset datasource grid view
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tiketYangTampil;

            // Agar text wrap dan sel menyesuaikan konten
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Refresh();
            UpdateTombolState();
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit edit agar CellValueChanged langsung terpanggil saat checkbox diubah
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan baris dan kolom valid
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Pilih"].Index)
            {
                if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value?.ToString(), out int idTiket))
                {
                    var tiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);
                    if (tiket != null)
                    {
                        UpdateTombolState();
                    }
                }
            }
        }

        private void UpdateTombolState()
        {
            // Cek apakah ada baris yang dipilih
            bool adaYangDipilih = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Any(r => r.Cells["Pilih"].Value != null && (bool)r.Cells["Pilih"].Value);

            btnSelesaikan.Enabled = adaYangDipilih;
        }

        private async void BtnSelesaikan_Click(object sender, EventArgs e)
        {
            bool found = false;
            var tiketYangDiselesaikan = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Cek apakah row dicentang
                if (row.Cells["Pilih"] is DataGridViewCheckBoxCell cell &&
                    cell.Value != null && (bool)cell.Value)
                {
                    found = true;

                    if (int.TryParse(row.Cells["idDataGridViewTextBoxColumn"].Value?.ToString(), out int tiketId))
                    {
                        try
                        {
                            // Secure code: Bungkus API call dengan try-catch
                            await ControllerReservasi.Selesaikan("http://localhost:5226/api/reservasi", tiketId, false);

                            tiketYangDiselesaikan.Add(tiketId);

                            var t = _daftarTiket.FirstOrDefault(x => x.Id == tiketId);
                            if (t != null)
                            {
                                t.Status = Tiket.StatusTiket.Selesai;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Terjadi error saat menyelesaikan tiket ID {tiketId}: {ex.Message}");
                        }
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show("Silakan pilih tiket yang ingin diselesaikan.");
                return;
            }

            RefreshTampilan();

            MessageBox.Show("Proses penyelesaian berhasil diproses.");
        }

        private void BtnKembali_Click(object sender, EventArgs e)
        {
            // Navigasi kembali ke halaman TiketSaya
            if (this.Parent is TiketSaya parent)
            {
                parent.PindahKeTiketSaya();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
