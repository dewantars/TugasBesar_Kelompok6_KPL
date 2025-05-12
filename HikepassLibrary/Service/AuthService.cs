using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class AuthService
    {
        private List<User> _users = new List<User>();

        public AuthService()
        {
            // Tambahkan akun default
            _users.Add(new User { Username = "pendaki1", Password = "password1", Role = "pendaki" });
            _users.Add(new User { Username = "pengelola1", Password = "admin1", Role = "pengelola" });
        }

        public User Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void Register(string username, string password)
        {
            if (_users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username sudah terdaftar.");
                return;
            }

            _users.Add(new User { Username = username, Password = password, Role = "pendaki" });
            Console.WriteLine("Pendaftaran berhasil.");
        }

        public void ChangePassword(User user, string newPassword)
        {
            if (user != null)
            {
                user.Password = newPassword;
                Console.WriteLine("Password berhasil diubah.");
            }
            else
            {
                Console.WriteLine("Pengguna tidak ditemukan.");
            }
        }
    }
}
