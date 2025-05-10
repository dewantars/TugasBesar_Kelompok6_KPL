using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class PembelianTiket
    {
        public List<Ticket> TiketTerbeli { get; set; } = new List<Ticket>();

        public void BeliTiket(User user, Ticket tiket, int jumlahOrang)
        {
            for (int i = 0; i < jumlahOrang; i++)
            {
                TiketTerbeli.Add(tiket);
                Console.WriteLine($"Tiket untuk {user.Nama} berhasil dibeli untuk {tiket.Tujuan} pada {tiket.TanggalPendakian.ToShortDateString()}.");
            }
        }
    }

}
