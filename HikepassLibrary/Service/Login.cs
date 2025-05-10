using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class Login
    {
        private Dictionary<string, Tuple<string, string>> kredensial = new Dictionary<string, Tuple<string, string>>();

        public Login()
        {
            kredensial.Add("pendaki1", new Tuple<string, string>("password123", "Pendaki"));
            kredensial.Add("pengelola1", new Tuple<string, string>("password456", "Pengelola"));
        }

        public User CekLogin(string id, string password)
        {
            if (kredensial.ContainsKey(id) && kredensial[id].Item1 == password)
            {
                string role = kredensial[id].Item2;
                Console.WriteLine("Login berhasil!");
                return new User(id, id, role);
            }
            else
            {
                Console.WriteLine("Login gagal. Cek ID dan password Anda.");
                return null;
            }
        }
    }

}
