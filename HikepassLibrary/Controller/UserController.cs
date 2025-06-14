using HikepassLibrary.Model;
using HikepassLibrary.Service;
using System.Collections.Generic;

namespace HikepassLibrary.Controller
{
    public class UserController
    {
        private readonly PendakiService pendakiService;
        private readonly PengelolaService pengelolaService;

        public UserController()
        {
            pendakiService = PendakiService.GetInstance();
            pengelolaService = PengelolaService.GetInstance();
        }

        public User? Login(string username, string password)
        {
            var pendaki = pendakiService.Login(username, password);
            if (pendaki != null)
            {
                return pendaki;
            }

            var pengelola = pengelolaService.Login(username, password);
            if (pengelola != null)
            {
                return pengelola;
            }

            return null; // Jika tidak ditemukan
        }

        public bool AddUser(User user)
        {
            if (user is Pendaki pendaki)
            {
                pendakiService.AddPendaki(pendaki);
                return true;
            }

            if (user is Pengelola pengelola)
            {
                pengelolaService.AddPengelola(pengelola);
                return true;
            }

            return false; // Jika tipe user tidak dikenal
        }

        public bool RemoveUser(int id, string role)
        {
            if (role == "Pendaki")
            {
                pendakiService.RemovePendaki(id);
                return true;
            }

            if (role == "Pengelola")
            {
                pengelolaService.RemovePengelola(id);
                return true;
            }

            return false; // Jika role tidak valid
        }

    }
}
