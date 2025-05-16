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
        private List<Pendaki> pendakis = new List<Pendaki>(); // Data pendaki yang sedang dipantau

        // Method to monitor hikers
        public void MonitorHikers()
        {
            Console.WriteLine("Daftar pendaki yang sedang dipantau:");
            foreach (var pendaki in pendakis)
            {
                Console.WriteLine($"Nama: {pendaki.Nama}, Usia: {pendaki.Usia}, Kontak: {pendaki.Kontak}, Alamat: {pendaki.Alamat}");
            }
        }

        // Method to view reports
        public void ViewReports()
        {
            Console.WriteLine("Laporan pendakian:");
            // Implementasi untuk melihat laporan
        }
    }
}
