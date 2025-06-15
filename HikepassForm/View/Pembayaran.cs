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
        private readonly List<Tiket> daftarTiket;

        public Pembayaran(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;
        }

        public void LoadPage(UserControl page)
        {
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        private void RefreshTampilan()
        {

            var tiketYangTampil = ControllerReservasi.reservasiList.Where(t => t.Status == Tiket.StatusTiket.BelumDibayar).ToList();

            var bindingList = new BindingList<Tiket>(tiketYangTampil);

            // untuk "mereset" grid
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingList;
            dataGridView1.Refresh();

        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            var tiketYangTampil = ControllerReservasi.reservasiList.Where(t => t.Status == Tiket.StatusTiket.BelumDibayar).ToList();

            // Reset datasource
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tiketYangTampil;

            // Agar wrap dan ukuran sel otomatis menyesuaikan konten
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (!tiketYangTampil.Any())
            {
                lblStatusInfo.Text = "Tidak ada tiket yang perlu dibayar.";
                btnBayar.Enabled = false;
            }
            else
            {
                lblStatusInfo.Text = "Silakan pilih tiket yang akan dibayar.";
                btnBayar.Enabled = true;
            }
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
            if (e.ColumnIndex == dataGridView1.Columns["PilihTiket"].Index && e.RowIndex >= 0)
            {
                int idTiket = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                bool isChecked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["PilihTiket"].Value);

                var tiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);
                if (tiket != null)
                {
                    tiket.StatusPembayaran = isChecked;
                }
            }
        }

        private async void btnBayar_Click(object sender, EventArgs e)
        {
            bool found = false;
            List<int> tiketYangDibayar = new List<int>();

             foreach (var id in tiketYangDibayar)
            {
                var t = daftarTiket.FirstOrDefault(x => x.Id == id);
                if (t != null)
                {
                    t.Status = Tiket.StatusTiket.Dibayar;
                    t.StatusPembayaran = false;
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["checkBox"] is DataGridViewCheckBoxCell cell &&
                    cell.Value != null && (bool)cell.Value)
                {
                    found = true;
                    int tiketId = (int)row.Cells["idDataGridViewTextBoxColumn"].Value;

                    await ControllerReservasi.UpdatedPembayaran("http://localhost:5226/api/reservasi", tiketId);
                    tiketYangDibayar.Add(tiketId);
                }
            }

            if (!found)
            {
                MessageBox.Show("Silakan pilih tiket yang ingin dibayar.");
                return;
            }

           

            RefreshTampilan();
            MessageBox.Show("Pembayaran berhasil diproses.");
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            var tiketSaya = new TiketSaya();
            LoadPage(tiketSaya);
        }
    }
}
