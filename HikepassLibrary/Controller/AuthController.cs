using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;
using static HikepassLibrary.Model.User;

namespace HikepassLibrary.Controller
{
    public class AuthController
    {
        private readonly AuthService _authService;
        private User _currentUser;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        public User GetCurrentUser() => _currentUser;

        // Daftar dengan role
        public bool Daftar(string username, string password, string role)
        {
            _authService.Register(username, password, role); 
            return true; 
        }

        // Login dengan role
        public bool Login(string username, string password, string role)
        {
            _currentUser = _authService.Authenticate(username, password, role); 
            if (_currentUser != null && _currentUser.Role == role)
            {
                Console.WriteLine($"Login berhasil sebagai {role}: {_currentUser.FullName}");
                return true;
            }
            Console.WriteLine("Login gagal.");
            return false;
        }

        // Ubah password
        public bool UbahPassword(string newPassword)
        {
            if (_currentUser != null)
            {
                _authService.ChangePassword(_currentUser, newPassword);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _currentUser = null;
            Console.WriteLine("Berhasil logout.");
        }
    }
}


