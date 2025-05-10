using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    class PengelolaService
    {
        // PembelianTiketService.cs (Service)
        public class PembelianTiketService
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

        // MonitoringService.cs (Service)
        public class MonitoringService
        {
            public void HandleTransition(User user, string aksi)
            {
                if (aksi == "checkin" && user.Status == "paid")
                {
                    user.Status = "checked_in";
                    Console.WriteLine($"{user.Nama} berhasil check-in.");
                }
                else if (aksi == "checkout" && user.Status == "checked_in")
                {
                    user.Status = "checked_out";
                    Console.WriteLine($"{user.Nama} berhasil checkout.");
                }
                else
                {
                    Console.WriteLine($"Aksi {aksi} tidak valid untuk {user.Nama}. Status saat ini: {user.Status}");
                }
            }
        }

    }

}
