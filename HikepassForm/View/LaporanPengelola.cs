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
            LoadLaporan(); // Clean code: data langsung dimuat saat form dibuat
        }

        private void listViewLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler disiapkan jika ingin menambahkan interaksi saat item dipilih
        }

        private void LoadLaporan()
        {
            listViewLaporan.Items.Clear(); // Clean code: selalu clear sebelum load ulang

            foreach (var laporan in LaporanService.listLaporan)
            {
                // Clean code: penggunaan ListViewItem untuk menampilkan setiap kolom data laporan
                var item = new ListViewItem(laporan.IdLaporan);
                item.SubItems.Add(laporan.WaktuLaporan.ToString("dd/MM/yyyy HH:mm:ss")); // Format tanggal konsisten dan mudah dibaca
                item.SubItems.Add(laporan.Deskripsi);
                item.SubItems.Add(laporan.TitikLokasi);
                item.SubItems.Add(laporan.TingkatKeparahan.ToString());

                listViewLaporan.Items.Add(item); // Clean code: tambah item secara eksplisit ke list
            }

            // Secure coding: tidak memproses jika list kosong, mencegah error atau tampilan kosong yang tidak jelas
            // (Bisa ditambah MessageBox jika ingin)
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Clean code: pengecekan Parent memastikan tidak terjadi NullReferenceException
            if (this.Parent is Panel parentPanel)
            {
                parentPanel.Controls.Clear();

                // Clean code: dashboard baru ditambahkan secara eksplisit sebagai kontrol utama
                var dashboard = new DashboardPengelola();
                parentPanel.Controls.Add(dashboard);
            }

            // Secure coding: penggantian panel dilakukan hanya jika Parent valid dan bertipe Panel
        }
    }
}
