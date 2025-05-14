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
        public List<Pendaki> DaftarPendakiMonitoring { get; set; } = new List<Pendaki>();

        public void AddToMonitoring(Pendaki pendaki)
        {
            DaftarPendakiMonitoring.Add(pendaki);
            Console.WriteLine($"{pendaki.FullName} telah ditambahkan ke daftar monitoring.");
        }

        public void RemoveFromMonitoring(Pendaki pendaki)
        {
            DaftarPendakiMonitoring.Remove(pendaki);
            Console.WriteLine($"{pendaki.FullName} telah dikeluarkan dari daftar monitoring.");
        }

        public void ShowMonitoring()
        {
            Console.WriteLine("Daftar Pendaki yang Sedang Check-in:");
            foreach (var pendaki in DaftarPendakiMonitoring)
            {
                Console.WriteLine($"{pendaki.FullName} ({pendaki.Nik})");
            }
        }
    }
}


