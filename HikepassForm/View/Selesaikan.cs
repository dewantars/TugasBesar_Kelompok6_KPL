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
        private readonly List<Tiket> daftarTiket;

        public Selesaikan(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;

            RefreshTampilan();

            btnSelesaikan.Click += btnSelesaikan_Click;
            btnKembali.Click += btnKembali_Click;

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }

        private void RefreshTampilan()
        {
            // Ambil tiket dengan status Dibayar atau Checkin
            var tiketYangTampil = ControllerReservasi.reservasiList.Where(t => t.Status == Tiket.StatusTiket.Checkout).ToList();

            // Reset datasource
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tiketYangTampil;

            // Agar wrap dan ukuran sel otomatis menyesuaikan konten
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Refresh();
            UpdateTombolState();
        }


        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan index valid
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Pilih"].Index)
            {
                int idTiket = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value);


                var tiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);
                if (tiket != null)
                {
                    UpdateTombolState();
                }
            }
        }



        private void UpdateTombolState()
        {
            bool adaYangDipilih = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Any(r => r.Cells["Pilih"].Value != null && (bool)r.Cells["Pilih"].Value);

            btnSelesaikan.Enabled = adaYangDipilih;
        }

        private async void btnSelesaikan_Click(object sender, EventArgs e)
        {
            bool found = false;
            List<int> tiketYangDiselesaikan = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Ambil sel checkbox (gunakan nama kolom checkbox yang sesuai)
                if (row.Cells["Pilih"] is DataGridViewCheckBoxCell cell &&
                    cell.Value != null && (bool)cell.Value)
                {
                    found = true;
                    int tiketId = Convert.ToInt32(row.Cells["idDataGridViewTextBoxColumn"].Value);

                    // Panggil API update
                    await ControllerReservasi.Selesaikan("http://localhost:5226/api/reservasi", tiketId, false);

                    tiketYangDiselesaikan.Add(tiketId);

                    // Update data lokal
                    var t = daftarTiket.FirstOrDefault(x => x.Id == tiketId);
                    if (t != null)
                    {
                        t.Status = Tiket.StatusTiket.Selesai;
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show("Silakan pilih tiket yang ingin diselesaikan.");
                return;
            }

            // Perbarui tampilan
            RefreshTampilan();

            MessageBox.Show("Proses penyelesaian berhasil diproses.");
        }


        private void btnKembali_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as TiketSaya;
            parent?.PindahKeTiketSaya();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
