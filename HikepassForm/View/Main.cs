using HikepassForm.View;

namespace HikepassForm
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            var LogIn = new LogIn();
            LoadPage(LogIn);
        }

        private void LoadPage(UserControl page)
        {
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

    }
}
