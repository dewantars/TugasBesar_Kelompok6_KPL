using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassForm.View
{
    public partial class LogIn : UserControl
    {
        private readonly UserController userController;
        private static bool isDummyDataAdded = false;
        public LogIn()
        {
            InitializeComponent();
            userController = new UserController();
        }


        private void LoadPage(UserControl page)
        {
            this.Controls.Clear();
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtUn.Text;
            string password = txtPw.Text;

            var user = userController.Login(username, password);
            if (user is Pendaki)
            {
                var dashboardPendaki = new DashboardPendaki();
                LoadPage(dashboardPendaki);
                return;
            }

            if (user is Pengelola)
            {
                var dashboardPengelola = new DashboardPengelola();
                LoadPage(dashboardPengelola);
                return;
            }

            MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            if (!isDummyDataAdded)
            {
                userController.AddUser(new Pendaki
                {
                    Id = 1,
                    FullName = "John Doe",
                    Username = "user",
                    Password = "user",
                    Email = "john.doe@example.com"
                });

                userController.AddUser(new Pengelola
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Username = "admin",
                    Password = "admin",
                    Email = "admin@example.com"
                });
                isDummyDataAdded = true;
            }

        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Password text changed");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
