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

namespace HikepassForm.View
{
    public partial class TiketSaya : UserControl
    {

        public TiketSaya()
        {
            InitializeComponent();

        }

        public void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus isi panel konten saja
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        public void back()
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        private void btnLihatTiket_Click(object sender, EventArgs e)
        {
            LihatTiket halamanTiketSaya = new LihatTiket(ControllerReservasi.reservasiList);
            LoadPage(halamanTiketSaya );
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            Pembayaran halamanPembayaran = new Pembayaran(ControllerReservasi.reservasiList);
            LoadPage(halamanPembayaran);
        }

        private void btnCheckinDanCheckout_Click(object sender, EventArgs e)
        {

            var halamanCheckin = new CheckinDanCheckout(ControllerReservasi.reservasiList);
            LoadPage(halamanCheckin);
        }
        private void btnSelesaikan_Click(object sender, EventArgs e)
        {
            var halamanSelesaikan = new Selesaikan(ControllerReservasi.reservasiList);
            LoadPage(halamanSelesaikan);
        }

        public void PindahKeTiketSaya()
        {
            var tiketSaya = new TiketSaya();
            LoadPage(tiketSaya);

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            var dashboard = new DashboardPendaki();
            LoadPage(dashboard);
        }

        
    }

}
