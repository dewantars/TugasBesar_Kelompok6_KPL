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

        public bool Daftar(string username, string password)
        {
            _authService.Register(username, password);
            return true; // Simplifikasi, perlu penanganan error lebih baik
        }

        public bool Login(string username, string password)
        {
            _currentUser = _authService.Authenticate(username, password);
            return _currentUser != null;
        }

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
