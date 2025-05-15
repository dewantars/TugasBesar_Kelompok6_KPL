using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

using System;
using System.Collections.Generic;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class MonitoringService
    {
        public static List<Tiket> DaftarPendakiMonitoring { get; set; } = new List<Tiket>();

        public void AddToMonitoring(Tiket tiket)
        {
            DaftarPendakiMonitoring.Add(tiket);
            Console.WriteLine($"{tiket.DaftarPendaki.Values} telah ditambahkan ke daftar monitoring.");
        }

        public void RemoveFromMonitoring(Tiket tiket)
        {
            DaftarPendakiMonitoring.Remove(tiket);
            Console.WriteLine($"{tiket.DaftarPendaki.Values} telah dikeluarkan dari daftar monitoring.");
        }

        public void ShowMonitoring()
        {
            Console.WriteLine("Daftar Pendaki yang Sedang Check-in:");
            foreach (var tiket in DaftarPendakiMonitoring)
            {
                // Menampilkan semua nama pendaki yang terdaftar di DaftarPendaki
                Console.WriteLine($"Tiket ID: {tiket.Id} - Pendaki: ");

                foreach (var pendaki in tiket.DaftarPendaki.Keys)
                {
                    Console.WriteLine($"Nama: {pendaki}");
                }

                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}


