using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassForm.View;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassForm
{
    public partial class DashboardPendaki : UserControl
    {

        public DashboardPendaki()
        {
            InitializeComponent();
 
        }
        public void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus isi panel konten saja
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }
        public void btnLogout_Click(object sender, EventArgs e)
        {
            this.Controls.Clear(); // Hapus konten sebelumnya
        }
        
        public void back()
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        private void btnRsv_Click(object sender, EventArgs e)
        {
            var halamanReservasi = new View.Reservasi();
            LoadPage(halamanReservasi);
        }

        private void DashboardPendaki_Load(object sender, EventArgs e)
        {

        }

        private void btnTkt_Click(object sender, EventArgs e)
        {
            // Inisialisasi/isi reservasiList dengan data dummy HANYA jika kosong

            if (ControllerReservasi.reservasiList.Count == 0)
            {
                ControllerReservasi.reservasiList.Add(new Tiket
                {
                    Id = 1,
                    Tanggal = new DateTime(2025, 6, 8), 
                    StatusPembayaran = false,
                    JumlahPendaki = 2,
                    Kontak = "0821321",
                    Jalur = Tiket.JalurPendakian.Panorama,
                    IsCheckedIn = false,
                    DaftarPendaki = new Dictionary<string, string>
                    {
                        { "3273010101010001", "Andi" },
                        { "3273010101010002", "Budi" }
                    },
                    Status = Tiket.StatusTiket.BelumDibayar,
                    BarangBawaanSaatCheckin = new List<string> { null },
                    BarangBawaanSaatCheckout = new List<string> { null },
                    Keterangan = "orang tua 1"
                });

                ControllerReservasi.reservasiList.Add(new Tiket
                {
                    Id = 2,
                    Tanggal = new DateTime(2025, 6, 15), 
                    StatusPembayaran = false,
                    JumlahPendaki = 1,
                    Kontak = "08123456789",
                    Jalur = Tiket.JalurPendakian.Cinyiruan,
                    IsCheckedIn = false,
                    DaftarPendaki = new Dictionary<string, string>
                    {
                        { "3273010101010003", "Citra" }
                    },
                    Status = Tiket.StatusTiket.BelumDibayar,
                    BarangBawaanSaatCheckin = new List<string> { null },
                    BarangBawaanSaatCheckout = new List<string> { null },
                    Keterangan = "bawa anak"
                });

                Console.WriteLine($"[DashboardPendaki] Menambahkan {ControllerReservasi.reservasiList.Count} tiket dummy.");
            }
            else
            {
                Console.WriteLine($"[DashboardPendaki] reservasiList sudah berisi {ControllerReservasi.reservasiList.Count} tiket. Tidak menambahkan dummy.");
            }


            Pembayaran halamanPembayaran = new Pembayaran(ControllerReservasi.reservasiList, this);
            LoadPage(halamanPembayaran);


        }
        private void btnCheckIndanCheckOut_Click(object sender, EventArgs e)
        {

            if (ControllerReservasi.reservasiList.Count == 0)
            {
               

                btnTkt_Click(sender, e); 
                this.Controls.Clear();  
            }

            var halamanCheckin = new CheckinDanCheckout(ControllerReservasi.reservasiList,this);


            LoadPage(halamanCheckin);
            
        }


    }
}
