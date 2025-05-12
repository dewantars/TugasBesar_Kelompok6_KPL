using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class MonitoringService
    {
        private List<MonitoringEntry> _daftarMonitoring = new List<MonitoringEntry>(); // In-memory storage

        public void TambahPendakiMonitoring(int TiketId, Dictionary<string, string> daftarPendaki, List<string> barangBawaan)
        {
            foreach (var pendaki in daftarPendaki)
            {
                if (!_daftarMonitoring.Any(m => m.TiketId == TiketId && m.NikPendaki == pendaki.Key))
                {
                    _daftarMonitoring.Add(new MonitoringEntry
                    {
                        TiketId = TiketId,
                        NikPendaki = pendaki.Key,
                        NamaPendaki = new List<string> { pendaki.Value },
                        CheckinTime = DateTime.Now,
                        BarangBawaanSaatCheckin = barangBawaan
                    });
                    Console.WriteLine($"Pendaki {pendaki.Value} (NIK: {pendaki.Key}) dari tiket {TiketId} berhasil ditambahkan ke monitoring.");
                }
                else
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {TiketId} sudah terdaftar dalam monitoring.");
                }
            }
        }

        public void RemovePendakiFromMonitoring(int TiketId, Dictionary<string, string> daftarPendaki)
        {
            foreach (var pendaki in daftarPendaki)
            {
                int removedCount = _daftarMonitoring.RemoveAll(m => m.TiketId == TiketId && m.NikPendaki == pendaki.Key);
                if (removedCount > 0)
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {TiketId} berhasil dihapus dari monitoring.");
                }
                else
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {TiketId} tidak ditemukan dalam monitoring.");
                }
            }
        }

        public List<MonitoringEntry> GetAllMonitoring()
        {
            return _daftarMonitoring;
        }
    }
}
