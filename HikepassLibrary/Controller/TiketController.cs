using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassLibrary.Controller
{
    public class TiketController
    {
        private readonly TiketService _tiketService;
        private readonly MonitoringService _monitoringService;

        public TiketController(TiketService tiketService, MonitoringService monitoringService)
        {
            _tiketService = tiketService;
            _monitoringService = monitoringService;
        }

        public List<Tiket> GetTiketSaya(string kontak)
        {
            return _tiketService.GetTiketByKontak(kontak);
        }

        public Tiket GetTiketById(int id)
        {
            return _tiketService.GetTiketById(id);
        }

        public bool CheckinTiket(Tiket tiket, List<string> barangBawaan)
        {
            if (tiket != null && tiket.StatusPembayaran && !tiket.IsCheckedIn)
            {
                tiket.IsCheckedIn = true;
                tiket.BarangBawaanSaatCheckin = barangBawaan;
                _tiketService.UpdateTiket(tiket);
                _monitoringService.TambahPendakiMonitoring(tiket.Id, tiket.DaftarPendaki,tiket.BarangBawaanSaatCheckin);
                Console.WriteLine("Check-in berhasil.");
                return true;
            }
            else if (tiket != null && tiket.IsCheckedIn)
            {
                Console.WriteLine("Tiket ini sudah check-in sebelumnya.");
            }
            else
            {
                Console.WriteLine("Tiket tidak valid atau belum dibayar.");
            }
            return false;
        }

        public bool CheckoutTiket(Tiket tiket, List<string> barangBawaanKembali)
        {
            if (tiket != null && tiket.IsCheckedIn)
            {
                tiket.IsCheckedIn = false;
                tiket.BarangBawaanSaatCheckout = barangBawaanKembali;
                _tiketService.UpdateTiket(tiket);
                _monitoringService.RemovePendakiFromMonitoring(tiket.Id, tiket.DaftarPendaki);
                Console.WriteLine("Check-out berhasil.");
                return true;
            }
            else if (tiket != null && !tiket.IsCheckedIn)
            {
                Console.WriteLine("Tiket ini belum check-in.");
            }
            else
            {
                Console.WriteLine("Tiket tidak valid.");
            }
            return false;
        }
    }
}
