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

        public bool CheckInTicket(int ticketId, Dictionary<string, string> daftarPendaki, List<string> barangBawaan)
        {
            var ticket = _tiketService.GetTiketById(ticketId); // Ambil tiket dari service

            if (ticket != null && ticket.StatusPembayaran && !ticket.IsCheckedIn)
            {
                ticket.IsCheckedIn = true;
                ticket.BarangBawaanSaatCheckin = barangBawaan;
                ticket.DaftarPendaki = daftarPendaki;
                _tiketService.UpdateTiket(ticket);
                _monitoringService.AddPendakiToMonitoring(ticketId, daftarPendaki, barangBawaan);
                Console.WriteLine("Tiket berhasil check-in.");
                return true;
            }
            else
            {
                Console.WriteLine("Tiket tidak valid atau belum dibayar atau sudah check-in.");
                return false;
            }
        }

        public bool CheckOutTicket(int ticketId, List<string> barangBawaanKembali)
        {
            var ticket = _tiketService.GetTiketById(ticketId); // Ambil tiket dari service

            if (ticket != null && ticket.IsCheckedIn)
            {
                ticket.IsCheckedIn = false;
                ticket.BarangBawaanSaatCheckout = barangBawaanKembali;
                _tiketService.UpdateTiket(ticket);
                _monitoringService.RemovePendakiFromMonitoring(ticketId, ticket.DaftarPendaki);
                Console.WriteLine("Tiket berhasil checkout.");
                return true;
            }
            else
            {
                Console.WriteLine("Tiket tidak ditemukan atau belum check-in.");
                return false;
            }
        }
    }
}

