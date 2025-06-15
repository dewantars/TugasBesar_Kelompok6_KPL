using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikepassForm.View
{
    public partial class DashboardPengelola : UserControl
    {
        public DashboardPengelola()
        {
            InitializeComponent();
        }
        public void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus konten sebelumnya
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }
        private void DashboardPengelola_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLhtLaporan_Click(object sender, EventArgs e)
        {
            var halamanLaporan = new View.LaporanPengelola();
            LoadPage(halamanLaporan);
        }
        public void PindahKeDashboard()
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        private void btnEditInform_Click(object sender, EventArgs e)
        {
            var halamanInformasi = new View.InformasiPengelola();
            LoadPage(halamanInformasi);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var LoginPage = new LogIn();
            LoadPage(LoginPage);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
