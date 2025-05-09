namespace HikepassForm
{
    public partial class Main : Form
    {
        private Dashboard dashboard;
        
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
            var dashboard = new Dashboard();
            LoadPage(dashboard);
        }
    }

}
