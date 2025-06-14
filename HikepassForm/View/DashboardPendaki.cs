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
            TiketSaya halamanTiketSaya = new TiketSaya();
            LoadPage(halamanTiketSaya);

            


        }
        


        private void btnLaporan_Click(object sender, EventArgs e)
        {
            var halamanLaporan = new View.LaporanPendaki();
            LoadPage(halamanLaporan);
        }
        public void PindahKeDashboard()
        {
            var dashboardPendaki = new DashboardPendaki();
            LoadPage(dashboardPendaki);
        }

        private void btnInf_Click(object sender, EventArgs e)
        {
            var halamanInformasi = new View.InformasiPendaki();
            LoadPage(halamanInformasi);
        }
    }
}
