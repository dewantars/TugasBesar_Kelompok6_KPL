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
    public partial class Pembayaran : Form
    {
        private List<Tiket> daftarTiket;

        public Pembayaran(List<Tiket> tiketList)
        {
            InitializeComponent();
            daftarTiket = tiketList;
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            tiketBindingSource.DataSource = daftarTiket;
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            bool adaYangDipilih = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["checkBox"].Value);

                if (isChecked)
                {
                    Tiket tiket = row.DataBoundItem as Tiket;
                    if (tiket != null && tiket.Status != Tiket.StatusTiket.Dibayar)
                    {
                        tiket.Status = Tiket.StatusTiket.Dibayar;
                        adaYangDipilih = true;
                    }
                }
            }

            dataGridView1.Refresh();

            if (adaYangDipilih)
            {
                lblStatusInfo.Text = "Pembayaran berhasil dilakukan.";
            }
            else
            {
                lblStatusInfo.Text = "Tidak ada tiket yang dipilih atau semua sudah dibayar.";
            }
        }
    }
}
