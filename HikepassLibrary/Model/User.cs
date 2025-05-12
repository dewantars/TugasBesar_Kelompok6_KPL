using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// User.cs
namespace HikepassLibrary.Model
{
    public class User
    {
       
        public string Username { get; set; }   // Username untuk login
        public string Password { get; set; }   // Password untuk login
        public string Role { get; set; }       // Role (Pendaki atau Pengelola)

        // Constructor untuk mempermudah pembuatan objek User
        public User() { }
        public User(string username, string password, string role)
        {
            
            Username = username;
            Password = password;
            Role = role;
        }
    }
}

