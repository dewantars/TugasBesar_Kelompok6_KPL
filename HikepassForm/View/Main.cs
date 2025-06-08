namespace HikepassForm
{
    public partial class Main : Form
    {
        private DashboardPendaki dashboard;

        public Main()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void LoadPage(UserControl page)
        {
            this.Controls.Clear(); // Hapus konten sebelumnya
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dashboard = new DashboardPendaki();
            LoadPage(dashboard);
        }

        private void signin_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }

}
