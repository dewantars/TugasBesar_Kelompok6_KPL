using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassLibrary.Controller
{
    public class PengelolaController
    {
        private Pengelola pengelola;

        public PengelolaController(string namaPengelola)
        {
            pengelola = new Pengelola(namaPengelola);
        }

        public void LihatStatusPendaki(List<User> pendakiList)
        {
            pengelola.LihatStatusPendaki(pendakiList);
        }

        public void KelolaTiket(List<Ticket> tiketList)
        {
            pengelola.KelolaTiket(tiketList);
        }
    }
}
