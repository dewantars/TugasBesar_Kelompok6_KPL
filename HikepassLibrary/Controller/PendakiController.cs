using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassLibrary.Controller
{
    public class PendakiController
    {
        private List<Tiket> tickets = new List<Tiket>(); // Daftar tiket pendaki
        private List<Pendaki> pendaki = new List<Pendaki>(); // Data pendaki

        private readonly TiketService _tiketService;
        private readonly MonitoringService _monitoringService; // Tambahkan MonitoringService

        // Dependency Injection: Menerima instance dari service yang dibutuhkan.
        public PendakiController(TiketService tiketService, MonitoringService monitoringService)
        {
            _tiketService = tiketService;
            _monitoringService = monitoringService; // Inisialisasi MonitoringService
        }

        // Method untuk menampilkan daftar tiket pendaki
        public void ShowMyTickets(string kontak) // Gunakan kontak untuk mencari tiket
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

        // Method untuk check-in tiket
        public bool CheckInTicket(int ticketId, Dictionary<string, string> daftarPendaki, List<string> barangBawaan)
        {
            var ticket = _tiketService.GetTiketById(ticketId); // Ambil tiket dari service

            if (ticket != null && ticket.StatusPembayaran && !ticket.IsCheckedIn)
            {
                ticket.IsCheckedIn = true; // Update status check-in
                ticket.BarangBawaanSaatCheckin = barangBawaan; // Simpan barang bawaan
                ticket.DaftarPendaki = daftarPendaki; // Simpan daftar pendaki
                _tiketService.UpdateTiket(ticket); // Update tiket di service
                _monitoringService.TambahPendakiMonitoring(ticketId, daftarPendaki,barangBawaan); // Tambah ke monitoring
                Console.WriteLine("Tiket berhasil check-in.");
                return true;
            }
            else
            {
                Console.WriteLine("Tiket tidak valid atau belum dibayar atau sudah check-in.");
                return false; // Mengembalikan nilai boolean untuk memberi tahu keberhasilan/kegagalan
            }
        }

        // Method untuk checkout tiket
        public bool CheckOutTicket(int ticketId, List<string> barangBawaanKembali)
        {
            var ticket = _tiketService.GetTiketById(ticketId); // Ambil tiket dari service

            if (ticket != null && ticket.IsCheckedIn)
            {
                ticket.IsCheckedIn = false; // Update status
                ticket.BarangBawaanSaatCheckout = barangBawaanKembali; // Simpan barang bawaan kembali
                _tiketService.UpdateTiket(ticket); // Update tiket
                _monitoringService.RemovePendakiFromMonitoring(ticketId, ticket.DaftarPendaki); // Hapus dari monitoring
                Console.WriteLine("Tiket berhasil checkout.");
                return true;
            }
            else
            {
                Console.WriteLine("Tiket tidak ditemukan atau belum check-in.");
                return false; // Mengembalikan nilai boolean
            }
        }
    }
}
