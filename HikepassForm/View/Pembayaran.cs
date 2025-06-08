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

        public Pembayaran(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;
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
            // 1. DAPATKAN TIKET YANG DIPILIH
            var tiketTerpilih = (tiketBindingSource.DataSource as List<Tiket>)?
                                .Where(t => t.StatusPembayaran).ToList();

            if (tiketTerpilih == null || !tiketTerpilih.Any())
            {
                MessageBox.Show("Silakan centang minimal satu tiket yang ingin Anda bayar.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnBayar.Enabled = false;
            lblStatusInfo.Text = "Memproses pembayaran...";

            try
            {

                // panggil controller untuk setiap tiket.

                foreach (Tiket tiket in tiketTerpilih)
                {
                    // Pastikan tiket ini memang belum dibayar sebelum diproses.
                    if (tiket.Status == Tiket.StatusTiket.BelumDibayar)
                    {
                        // Panggil controller. `await` akan membuat kode ini menunggu sampai
                        await ControllerReservasi.UpdatedPembayaran("http://localhost:5226/api/reservasi", tiket.Id);
                    }
                }


                //refresh DataGridView untuk perubahan tersebut.

                // Filter ulang daftar master. Tiket yang statusnya sudah diubah menjadi 'Dibayar' oleh controller tidak akan masuk lagi ke daftar ini.
                var tiketSisa = this.daftarTiket.Where(t => t.Status == Tiket.StatusTiket.BelumDibayar).ToList();

                // Set ulang data source untuk memaksa grid menggambar ulang isinya.
                tiketBindingSource.DataSource = tiketSisa;

                // Beri pesan sukses umum.
                MessageBox.Show($"{tiketTerpilih.Count} tiket telah diproses untuk pembayaran.", "Proses Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!tiketSisa.Any())
                {
                    lblStatusInfo.Text = "Semua tiket sudah lunas.";
                }
                else
                {
                    lblStatusInfo.Text = "Pembayaran selesai.";
                }

            }
            catch (Exception ex)
            {
                // Menangkap error tak terduga yang mungkin terjadi di sisi UI.
                MessageBox.Show("Terjadi kesalahan teknis: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatusInfo.Text = "Terjadi kesalahan.";
            }
            finally
            {
                // Aktifkan kembali tombol jika masih ada yang bisa dibayar.
                if ((tiketBindingSource.DataSource as List<Tiket>)?.Any() == true)
                {
                    btnBayar.Enabled = true;
                }
                else
                {
                    btnBayar.Enabled = false;
                }
            }
        }
        

        private void btnKembali_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}
