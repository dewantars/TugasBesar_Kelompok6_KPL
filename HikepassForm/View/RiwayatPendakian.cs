using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Model;

namespace HikepassForm.View
{
    public partial class RiwayatPendakian : UserControl
    {
        public RiwayatPendakian()
        {
            InitializeComponent();
            LoadRiwayatToGrid();
        }

        private void LoadRiwayatToGrid()
        {
            try
            {
                // Memuat data dari model RiwayatPendakian
                var riwayatList = HikepassLibrary.Model.RiwayatPendakian.riwayatList;

                if (riwayatList == null || !riwayatList.Any())
                {
                    MessageBox.Show("Riwayat pendakian kosong.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var dashboard = new DashboardPendaki();
                    LoadPage(dashboard);
                }

                // Mengatur kolom DataGridView
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID Tiket", DataPropertyName = "Id" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tanggal", DataPropertyName = "Tanggal" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Jalur", DataPropertyName = "Jalur" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Jumlah Pendaki", DataPropertyName = "JumlahPendaki" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Barang Bawaan", DataPropertyName = "BarangBawaanDisplay" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Pendaki", DataPropertyName = "DaftarPendakiDisplay" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });

                // Mengikat data ke DataGridView
                dataGridView1.DataSource = riwayatList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat riwayat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lRiwayat_Click(object sender, EventArgs e)
        {

        }

        public void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus isi panel konten saja
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dashboard = new DashboardPendaki();
            LoadPage(dashboard);
        }
    }
}
