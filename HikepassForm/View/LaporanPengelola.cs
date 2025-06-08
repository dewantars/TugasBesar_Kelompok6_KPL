using HikepassLibrary.Service;
using HikepassLibrary.Model;
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
    public partial class LaporanPengelola : UserControl
    {
        public LaporanPengelola()
        {
            InitializeComponent();
            LoadLaporan();
        }

        private void listViewLaporan_SelectedIndexChanged(object sender, EventArgs e) { }
        private void LoadLaporan()
        {
            listViewLaporan.Items.Clear();

            foreach (var laporan in LaporanService.listLaporan)
            {
                var item = new ListViewItem(laporan.IdLaporan);
                item.SubItems.Add(laporan.WaktuLaporan.ToString("dd/MM/yyyy HH:mm:ss"));
                item.SubItems.Add(laporan.Deskripsi);
                item.SubItems.Add(laporan.TitikLokasi);
                item.SubItems.Add(laporan.TingkatKeparahan.ToString());

                listViewLaporan.Items.Add(item);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (this.Parent is Panel parentPanel)
            {
                parentPanel.Controls.Clear();
                var dashboard = new DashboardPengelola();
                parentPanel.Controls.Add(dashboard);
            }
        }
    }
}
