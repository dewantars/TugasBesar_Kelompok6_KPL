using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassLibrary.Controller
{
    public class MonitoringPendaki
    {
        private List<MonitoringEntry> monitoringList = new List<MonitoringEntry>();
        private readonly MonitoringService _monitoringService;

        public MonitoringPendaki(MonitoringService monitoringService)
        {
            _monitoringService = monitoringService;
        }

        public void AddPendakiToMonitoring(int ticketId, Dictionary<string, string> daftarPendaki, List<string> barangBawaan)
        {
            foreach (var pendaki in daftarPendaki)
            {
                if (!monitoringList.Any(m => m.TiketId == ticketId && m.NikPendaki == pendaki.Key))
                {
                    monitoringList.Add(new MonitoringEntry
                    {
                        TiketId = ticketId,
                        NikPendaki = pendaki.Key,
                        NamaPendaki = new List<string> { pendaki.Value },
                        BarangBawaanSaatCheckin = barangBawaan,
                        CheckinTime = DateTime.Now // Tambahkan waktu check-in jika diperlukan
                    });
                    Console.WriteLine($"Pendaki {pendaki.Value} (NIK: {pendaki.Key}) dari tiket {ticketId} berhasil ditambahkan ke monitoring.");
                }
                else
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {ticketId} sudah terdaftar dalam monitoring.");
                }
            }
        }

        public void DisplayMonitoringData()
        {
            Console.WriteLine("Data Pendaki yang Dipantau:");
            if (monitoringList.Count > 0)
            {
                Console.WriteLine("ID Tiket\tNIK Pendaki\tNama Pendaki\tWaktu Check-in");
                foreach (var entry in monitoringList)
                {
                    Console.WriteLine($"{entry.TiketId}\t\t{entry.NikPendaki}\t\t{entry.NamaPendaki}\t\t{entry.CheckinTime}");
                }
            }
            else
            {
                Console.WriteLine("Tidak ada pendaki yang dipantau.");
            }
        }

        public void RemovePendakiFromMonitoring(int ticketId, Dictionary<string, string> daftarPendaki)
        {
            foreach (var pendaki in daftarPendaki)
            {
                int removedCount = monitoringList.RemoveAll(m => m.TiketId == ticketId && m.NikPendaki == pendaki.Key);
                if (removedCount > 0)
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {ticketId} berhasil dihapus dari monitoring.");
                }
                else
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {ticketId} tidak ditemukan dalam monitoring.");
                }
            }
        }

        public List<MonitoringEntry> GetAllMonitoring()
        {
            return monitoringList;
        }
    }
}

