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
        // Clean code: constructor menggunakan PascalCase sesuai standar method/fungsi
        public LaporanPengelola()
        {
            InitializeComponent();
            LoadLaporan();
        }

        // Event handler disiapkan jika ingin menambahkan interaksi saat item dipilih
        private void labelJudul_Click(object sender, EventArgs e) { }
        private void listViewLaporan_SelectedIndexChanged(object sender, EventArgs e) { }

        // Clean code: method menggunakan PascalCase
        // Clean code: white space dan indentation konsisten 4 spasi untuk blok kode
        private void LoadLaporan()
        {
            // Clean code: pemanggilan service dan iterasi diberi jarak baris (white space) untuk keterbacaan
            listViewLaporan.Items.Clear();

            foreach (var laporan in LaporanService.listLaporan)
            {
                // Clean code: variable lokal menggunakan camelCase dan variable atau attribute declaration sudah jelas
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
            var dashboard = this.Parent as DashboardPengelola;
            dashboard?.PindahKeDashboard();
        }
    }
}
