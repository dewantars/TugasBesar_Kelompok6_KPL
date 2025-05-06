using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassApp.Model
{
    public class User
    {
        private string username;
        private string password;
        private string nama;
        private string NIK;

        public User(string username, string password, string nama, string NIK)
        {
            this.username = username;
            this.password = password;
            this.nama = nama;
            this.NIK = NIK;
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }
        
    }
}
