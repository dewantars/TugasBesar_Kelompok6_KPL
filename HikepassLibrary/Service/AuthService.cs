using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Service
{
    class AuthService
    {
        public bool Login(string username, string password)
        {
            // Placeholder logic for login
            return username == "admin" && password == "password";
        }

        public bool Register(string username, string password, string fullName, string email)
        {
            // Placeholder logic for registration
            return true;
        }
    }
}
