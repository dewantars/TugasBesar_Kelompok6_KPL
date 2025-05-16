using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

using System;
using System.Collections.Generic;

namespace HikepassLibrary.Service
{
    public class MonitoringService
    {
        // Daftar pendaki yang sedang dalam proses monitoring (aktif)
        public static List<Tiket> DaftarPendakiMonitoring { get; set; } = new();

        // FSM per pendaki berdasarkan ID tiket
        private static Dictionary<int, MonitoringFSM> PendakiStates = new();

        // Tambah pendaki ke monitoring
        public void AddToMonitoring(Tiket tiket)
        {
            if (!DaftarPendakiMonitoring.Contains(tiket))
            {
                DaftarPendakiMonitoring.Add(tiket);
                PendakiStates[tiket.Id] = new MonitoringFSM();
                Console.WriteLine($"[+] Tiket ID {tiket.Id} dimasukkan ke daftar monitoring.");
            }
            else
            {
                Console.WriteLine($"[!] Tiket ID {tiket.Id} sudah ada dalam monitoring.");
            }
        }

        // Hapus pendaki dari monitoring
        public void RemoveFromMonitoring(Tiket tiket)
        {
            if (DaftarPendakiMonitoring.Remove(tiket))
            {
                PendakiStates.Remove(tiket.Id);
                Console.WriteLine($"[-] Tiket ID {tiket.Id} dikeluarkan dari monitoring.");
            }
            else
            {
                Console.WriteLine($"[!] Tiket ID {tiket.Id} tidak ditemukan.");
            }
        }

        // Lanjutkan status FSM pendaki berdasarkan ID
        public string LanjutkanPendakian(int id)
        {
            if (!PendakiStates.ContainsKey(id))
                return $"[x] Pendaki ID {id} belum dimonitoring.";

            var fsm = PendakiStates[id];

            switch (fsm.current)
            {
                case MonitoringFSM.State.Basecamp:
                case MonitoringFSM.State.Pos1:
                    fsm.NaikPos(); break;
                case MonitoringFSM.State.Pos2:
                    fsm.CapaiPuncak(); break;
                case MonitoringFSM.State.Puncak:
                    fsm.TurunGunung(); break;
                case MonitoringFSM.State.Turun:
                    fsm.SelesaiPendakian(); break;
                case MonitoringFSM.State.Selesai:
                    return $"✓ Pendaki ID {id} telah menyelesaikan pendakian.";
            }

            return $"→ Pendaki ID {id} sekarang di tahap: {fsm.current}";
        }

        // Tampilkan daftar semua pendaki dalam monitoring
        public void ShowMonitoring()
        {
            Console.WriteLine("=== Daftar Pendaki yang Sedang Dimonitoring ===");
            foreach (var tiket in DaftarPendakiMonitoring)
            {
                Console.WriteLine($"Tiket ID: {tiket.Id}");
                foreach (var pendaki in tiket.DaftarPendaki.Keys)
                {
                    Console.WriteLine($"- Nama: {pendaki} | Status: {PendakiStates[tiket.Id].current}");
                }
                Console.WriteLine("---------------------------------------------");
            }
        }
    }
}


