using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;


namespace HikepassApp.Controller
{
    public class PendakiController
    {
        private readonly TiketService _tiketService;
        private readonly MonitoringService _monitoringService;

        public PendakiController(TiketService tiketService, MonitoringService monitoringService)
        {
            _tiketService = tiketService;
            _monitoringService = monitoringService;
        }

        public void ShowMyTickets(string kontak)
        {
            var myTickets = _tiketService.GetTiketByKontak(kontak); // Gunakan TiketService
            if (myTickets.Count > 0)
            {
                Console.WriteLine("\n=== Tiket Saya ===");
                foreach (var ticket in myTickets)
                {
                    Console.WriteLine($"ID Tiket: {ticket.Id}, Tanggal: {ticket.Tanggal.ToShortDateString()}, Jumlah Pendaki: {ticket.JumlahPendaki}, Status Pembayaran: {(ticket.StatusPembayaran ? "Lunas" : "Belum Lunas")}, Status Check-in: {(ticket.IsCheckedIn ? "Sudah Check-in" : "Belum Check-in")}");
                }
            }
            else
            {
                Console.WriteLine("Anda belum memiliki tiket yang dibayar.");
            }
        }

    }
}