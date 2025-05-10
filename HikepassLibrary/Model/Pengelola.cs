using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    class Pengelola
    {
        public string Nama {  get; set; }
        public Pengelola(string nama) {
            Nama = Nama;
        }
        // Method untuk melihat status pendaki
        public void LihatStatusPendaki(List<User> pendakiList)
        {
            Console.WriteLine($"Pengelola {Nama} melihat status pendaki:");
            foreach (var pendaki in pendakiList)
            {
                Console.WriteLine($"Pendaki {pendaki.Nama} dengan ID {pendaki.Id} memiliki status {pendaki.Status}");
            }
        }

        // Method untuk mengelola tiket, misalnya melihat tiket yang sudah dibeli
        public void KelolaTiket(List<Ticket> tiketList)
        {
            Console.WriteLine($"Pengelola {Nama} mengelola tiket:");
            foreach (var tiket in tiketList)
            {
                Console.WriteLine($"Tiket ke {tiket.Tujuan} pada {tiket.TanggalPendakian.ToShortDateString()} dengan harga {tiket.Harga}");
            }
        }
    }
}
