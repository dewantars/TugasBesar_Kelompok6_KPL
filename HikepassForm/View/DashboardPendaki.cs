using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikepassForm
{
    public partial class DashboardPendaki: UserControl
    {
        public DashboardPendaki()
        {
            InitializeComponent();
        }
        public void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus konten sebelumnya
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }
        public void btnLogout_Click(object sender, EventArgs e)
        {
            this.Controls.Clear(); // Hapus konten sebelumnya
        }

    }
}
