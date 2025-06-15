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
        }

        private void RefreshTampilan()
        {
            var tiketYangTampil = ControllerReservasi.reservasiList
                .Where(t => t.Status == Tiket.StatusTiket.Checkout)
                .Select(t => new
                {
                    t.Id,
                    NamaPemesan = t.DaftarPendaki?.Values.FirstOrDefault() ?? "-",
                    Tanggal = t.Tanggal.ToShortDateString(),
                    Jalur = t.Jalur.ToString(),
                    t.JumlahPendaki,
                    DaftarPendaki = string.Join(Environment.NewLine, t.DaftarPendaki.Select(p => $"NIK: {p.Key}; {p.Value}")),
                    t.Kontak,
                    t.Keterangan,
                    BarangBawaan = t.BarangBawaanSaatCheckout != null && t.BarangBawaanSaatCheckout.Any()
                        ? string.Join(", ", t.BarangBawaanSaatCheckout)
                        : "-",
                    Status = t.Status.ToString(),
                    Pilih = false // default uncheck
                })
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tiketYangTampil;

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

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
            if (e.ColumnIndex == dataGridView1.Columns["Pilih"].Index && e.RowIndex >= 0)
            {
                UpdateTombolState();
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
                    int tiketId = Convert.ToInt32(row.Cells["Id"].Value);

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
    }
}
