using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.User;

namespace HikepassLibrary.Service
{
    public class PengelolaService
    {
        private Dictionary<int, User> daftarPengelola;

        public PengelolaService()
        {
            daftarPengelola = new Dictionary<int, User>();
        }

        // Fungsi untuk menambah pengelola baru (hanya sebagai contoh)
        public void TambahPengelola(int id, string username, string password,string role)
        {
            var pengelola = new User(username , password, role);
            daftarPengelola[id] = pengelola;
        }
    }

}
