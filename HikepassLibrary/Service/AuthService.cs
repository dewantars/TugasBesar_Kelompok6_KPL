using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class AuthService
    {
        private readonly List<User> _users = new List<User>();  // Menyimpan daftar pengguna yang terdaftar

        // Constructor untuk mengisi pengguna awal (untuk testing)
        public AuthService()
        {
            // Menambahkan pengelola dan pendaki contoh
            _users.Add(new Pengelola { Username = "admin", Password = "admin123", FullName = "Admin Pengelola", Role = "Pengelola" });
            _users.Add(new Pendaki { Username = "john", Password = "john123", FullName = "John Doe", Role = "Pendaki" });
        }

        // Metode Register untuk mendaftarkan pengguna baru
        public void Register(string username, string password, string role)
        {
            // Memeriksa apakah username sudah ada
            if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Username sudah digunakan.");
                return;
            }

            // Menambahkan pengguna baru berdasarkan role
            User newUser = role.ToLower() switch
            {
                "pengelola" => new Pengelola
                {
                    Username = username,
                    Password = password,
                    Role = role,
                    FullName = $"{username} Pengelola"  // Ganti dengan data yang relevan
                },
                "pendaki" => new Pendaki
                {
                    Username = username,
                    Password = password,
                    Role = role,
                    FullName = $"{username} Pendaki"  // Ganti dengan data yang relevan
                },
                _ => throw new InvalidOperationException("Role tidak valid.")
            };

            _users.Add(newUser);  // Menyimpan pengguna baru
            Console.WriteLine($"{role} {newUser.FullName} berhasil terdaftar.");
        }

        // Metode Authenticate untuk login
        public User Authenticate(string username, string password, string role)
        {
            var user = _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);

            if (user != null && user.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Login berhasil sebagai {role}: {user.FullName}");
                return user;  // Mengembalikan pengguna yang berhasil login
            }

            Console.WriteLine("Login gagal.");
            return null;  // Jika tidak berhasil login
        }

        // Metode untuk mengubah password pengguna
        public void ChangePassword(User user, string newPassword)
        {
            if (user != null)
            {
                user.Password = newPassword;
                Console.WriteLine($"Password untuk {user.FullName} berhasil diperbarui.");
            }
        }
    }
}
