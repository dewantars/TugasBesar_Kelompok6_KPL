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
        private List<MonitoringEntry> monitoringList = new List<MonitoringEntry>();

        public void AddPendakiToMonitoring(int tiketId, Dictionary<string, string> daftarPendaki, List<string> barangBawaan)
        {
            foreach (var pendaki in daftarPendaki)
            {
                if (!monitoringList.Any(m => m.TiketId == tiketId && m.NikPendaki == pendaki.Key))
                {
                    monitoringList.Add(new MonitoringEntry
                    {
                        TiketId = tiketId,
                        NikPendaki = pendaki.Key,
                        NamaPendaki = new List<string> { pendaki.Value },
                        BarangBawaanSaatCheckin = barangBawaan,
                        CheckinTime = DateTime.Now
                    });
                    Console.WriteLine($"Pendaki {pendaki.Value} (NIK: {pendaki.Key}) dari tiket {tiketId} berhasil ditambahkan ke monitoring.");
                }
                else
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {tiketId} sudah terdaftar dalam monitoring.");
                }
            }
        }

        public void RemovePendakiFromMonitoring(int tiketId, Dictionary<string, string> daftarPendaki)
        {
            foreach (var pendaki in daftarPendaki)
            {
                int removedCount = monitoringList.RemoveAll(m => m.TiketId == tiketId && m.NikPendaki == pendaki.Key);
                if (removedCount > 0)
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {tiketId} berhasil dihapus dari monitoring.");
                }
                else
                {
                    Console.WriteLine($"Pendaki dengan NIK {pendaki.Key} dari tiket {tiketId} tidak ditemukan dalam monitoring.");
                }
            }
        }

        public List<MonitoringEntry> GetAllMonitoring()
        {
            return monitoringList;
        }
    }
}


