using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassForm.View
{
    public partial class LihatTiket : UserControl
    {
        private readonly List<Tiket> daftarTiket;

        public LihatTiket(List<Tiket> tiketList)
        {
            InitializeComponent();
            this.daftarTiket = tiketList;

            RefreshTampilan();

            btnKembali.Click += btnKembali_Click;
        }

        private void RefreshTampilan()
        {
            var tiketYangTampil = ControllerReservasi.reservasiList.ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tiketYangTampil;

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Refresh();
            

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as TiketSaya;
            parent?.PindahKeTiketSaya();
        }
    }
}
