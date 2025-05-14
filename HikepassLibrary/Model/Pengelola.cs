using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

// Pengelola.cs
namespace HikepassLibrary.Model
{
    public class Pengelola : User
    {
        public Pengelola() { }
        public Pengelola(string username, string password, string fullName, string email)
        {
            this.Username = username;
            this.Password = password;
            this.FullName = fullName;
            this.Email = email;
        }
    }
}

