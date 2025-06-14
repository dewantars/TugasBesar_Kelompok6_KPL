using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;

namespace HikepassForm.View
{
    public partial class Pembayaran : UserControl
    {
        private readonly List<Tiket> daftarTiket;
        private TiketSaya tiketsayaMenu;

        public Pembayaran(List<Tiket> tiketList )
        {
            InitializeComponent();
            this.daftarTiket = tiketList;
            
            
        }
        public void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus isi panel konten saja
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            // Saring untuk menampilkan tiket yang relevan saat form dimuat
            var tiketBelumDibayar = daftarTiket.Where(t => t.Status == Tiket.StatusTiket.BelumDibayar).ToList();
            tiketBindingSource.DataSource = tiketBelumDibayar;

            if (!tiketBelumDibayar.Any())
            {
                lblStatusInfo.Text = "Tidak ada tiket yang perlu dibayar.";
                btnBayar.Enabled = false;
            }
            else
            {
                lblStatusInfo.Text = "Silakan pilih tiket yang akan dibayar.";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Memastikan nilai checkbox langsung tersimpan di objek saat diklik
            if (e.ColumnIndex == dataGridView1.Columns["checkBox"].Index && e.RowIndex >= 0)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private async void btnBayar_Click(object sender, EventArgs e)
        {
            // Ambil dari list reservasiList di controller
            var tiketTerpilih = ControllerReservasi.reservasiList
                                .Where(t => t.StatusPembayaran) // yang dicentang
                                .ToList();

            if (tiketTerpilih == null || !tiketTerpilih.Any())
            {
                MessageBox.Show("Silakan centang minimal satu tiket yang ingin Anda bayar.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnBayar.Enabled = false;
            lblStatusInfo.Text = "Memproses pembayaran...";

            try
            {
                foreach (Tiket tiket in tiketTerpilih)
                {
                    if (tiket.Status == Tiket.StatusTiket.BelumDibayar)
                    {
                        // Update status ke server
                        await ControllerReservasi.UpdatedPembayaran("http://localhost:5226/api/reservasi", tiket.Id);

                        // Jika sukses, update juga status lokalnya di reservasiList
                        var tiketDiList = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == tiket.Id);
                        if (tiketDiList != null)
                        {
                            tiketDiList.Status = Tiket.StatusTiket.Dibayar;
                            tiketDiList.StatusPembayaran = false; // Uncheck lagi biar nggak keikut klik lagi
                        }
                    }
                }

                // Refresh UI: hanya tampilkan tiket yang belum dibayar
                var tiketSisa = ControllerReservasi.reservasiList
                                    .Where(t => t.Status == Tiket.StatusTiket.BelumDibayar)
                                    .ToList();

                tiketBindingSource.DataSource = tiketSisa;

                MessageBox.Show($"{tiketTerpilih.Count} tiket telah diproses untuk pembayaran.", "Proses Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblStatusInfo.Text = tiketSisa.Any() ? "Pembayaran selesai." : "Semua tiket sudah lunas.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan teknis: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatusInfo.Text = "Terjadi kesalahan.";
            }
            finally
            {
                btnBayar.Enabled = ControllerReservasi.reservasiList.Any(t => t.Status == Tiket.StatusTiket.BelumDibayar);
            }
        }


        private void btnKembali_Click(object sender, EventArgs e)
        {
            var tiketSaya = new TiketSaya();
            LoadPage(tiketSaya);


        }
    }
}
