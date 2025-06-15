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
            var bindingList = new BindingList<Tiket>(daftarTiket);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingList;

            // 🔑 Perbaikan: Set Daftar Pendaki tampil di grid
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is Tiket tiket)
                {
                    row.Cells["daftarPendakiDataGridViewTextBoxColumn"].Value =
                        string.Join(", ", tiket.DaftarPendaki.Select(p => $"{p.Value} (NIK: {p.Key})"));
                }
            }

            dataGridView1.Refresh();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            var parent = this.Parent as TiketSaya;
            parent?.PindahKeTiketSaya();
        }
    }
}
