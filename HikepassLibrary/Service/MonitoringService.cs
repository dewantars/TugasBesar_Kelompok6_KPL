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
        private readonly Dictionary<int, Tiket> _monitoredTikets = new();
        private readonly Dictionary<int, Dictionary<string, MonitoringFSM>> _pendakiStates = new();
        public int Count => _monitoredTikets.Count;
        public IEnumerable<Tiket> Values => _monitoredTikets.Values;

        public bool ContainsKey(int id) => _monitoredTikets.ContainsKey(id);

        public MonitoringService() { }
        public void AddToMonitoring(Tiket tiket)
        {
            if (!_monitoredTikets.ContainsKey(tiket.Id))
            {
                _monitoredTikets[tiket.Id] = tiket;

                var fsmPerPendaki = new Dictionary<string, MonitoringFSM>();

                if (tiket.DaftarPendaki != null)
                {
                    foreach (var namaPendaki in tiket.DaftarPendaki.Keys)
                    {
                        fsmPerPendaki[namaPendaki] = new MonitoringFSM();
                    }
                }
                else
                {
                    Console.WriteLine($"[!] Tiket ID {tiket.Id} tidak memiliki daftar pendaki.");
                }

                _pendakiStates[tiket.Id] = fsmPerPendaki;

                Console.WriteLine($"[+] Tiket ID {tiket.Id} dimasukkan ke daftar monitoring.");
            }
            else
            {
                Console.WriteLine($"[!] Tiket ID {tiket.Id} sudah ada dalam monitoring.");
            }
        }


        public void RemoveFromMonitoring(Tiket tiket)
{
    if (_monitoredTikets.ContainsKey(tiket.Id))
    {
        _monitoredTikets.Remove(tiket.Id);
        _pendakiStates.Remove(tiket.Id);
        Console.WriteLine($"[-] Tiket ID {tiket.Id} dihapus dari daftar monitoring.");
    }
    else
    {
        Console.WriteLine($"[x] Tiket ID {tiket.Id} tidak ditemukan di monitoring.");
    }
}

        public void RemoveFromMonitoring(int id)
        {
            if (_monitoredTikets.TryGetValue(id, out var tiket))
            {
                RemoveFromMonitoring(tiket);
            }
            else
            {
                Console.WriteLine($"[x] Tiket ID {id} tidak ditemukan saat ingin dihapus dari monitoring.");
            }
        }
            

        // Lanjutkan status FSM pendaki berdasarkan ID
        public string LanjutkanPendakian(int tiketId, string namaPendaki)
        {
            if (!_pendakiStates.ContainsKey(tiketId))
                return $"[x] Tiket ID {tiketId} belum dimonitoring.";

            var fsmDict = _pendakiStates[tiketId];

            if (!fsmDict.ContainsKey(namaPendaki))
                return $"[x] Pendaki '{namaPendaki}' tidak ditemukan dalam tiket {tiketId}.";

            var fsm = fsmDict[namaPendaki];

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
                    return $"✓ Pendaki {namaPendaki} telah menyelesaikan pendakian.";
            }

            return $"→ Pendaki {namaPendaki} sekarang di tahap: {fsm.current}";
        }

        public void HandleStatusUpdate()
        {
            Console.Write("Ingin mengubah status pendaki? (y/n): ");
            var jawab = Console.ReadLine()?.Trim().ToLower();
            if (jawab != "y") return;

            Console.Write("Masukkan ID Tiket: ");
            if (!int.TryParse(Console.ReadLine(), out int tiketId))
            {
                Console.WriteLine("[x] ID tiket tidak valid.");
                return;
            }

            Console.Write("Masukkan Nama Pendaki: ");
            string namaPendaki = Console.ReadLine()?.Trim();

            Console.Write("Naik ke mana? [pos1/pos2/puncak/turun]: ");
            string tujuan = Console.ReadLine()?.Trim().ToLower();

            string result = UpdateStatus(tiketId, namaPendaki, tujuan);
            Console.WriteLine(result);
        }


        public string UpdateStatus(int tiketId, string namaPendaki, string tujuan)
        {
            if (!_pendakiStates.ContainsKey(tiketId))
                return $"[x] Tiket ID {tiketId} belum dimonitoring.";

            var fsmDict = _pendakiStates[tiketId];

            if (!fsmDict.ContainsKey(namaPendaki))
                return $"[x] Pendaki '{namaPendaki}' tidak ditemukan dalam tiket {tiketId}.";

            var fsm = fsmDict[namaPendaki];

            switch (tujuan)
            {
                case "pos1":
                case "pos2":
                    fsm.NaikPos(); break;
                case "puncak":
                    fsm.CapaiPuncak(); break;
                case "turun":
                    fsm.TurunGunung(); break;
                case "selesai":
                    return $"[!] Selesaikan pendakian hanya bisa lewat proses checkout.";
                default:
                    return "[x] Input tujuan tidak dikenali. Gunakan: pos1, pos2, puncak, turun.";
            }

            return $"→ Pendaki {namaPendaki} sekarang di tahap: {fsm.current}";
        }
        public void ShowMonitoring()
        {
            if (_monitoredTikets.Count == 0)
            {
                Console.WriteLine("Belum ada tiket yang dimonitoring.");
                return;
            }

            foreach (var tiketEntry in _monitoredTikets)
            {
                int tiketId = tiketEntry.Key;
                Tiket tiket = tiketEntry.Value;

                Console.WriteLine($"Tiket ID: {tiketId}");
                Console.WriteLine($"Daftar Pendaki:");

                if (_pendakiStates.TryGetValue(tiketId, out var fsmDict))
                {
                    foreach (var pendakiEntry in fsmDict)
                    {
                        string namaPendaki = pendakiEntry.Key;
                        MonitoringFSM fsm = pendakiEntry.Value;

                        Console.WriteLine($" - {namaPendaki}: Status sekarang = {fsm.current}");
                    }
                }
                else
                {
                    Console.WriteLine("  [x] Tidak ada data FSM untuk tiket ini.");
                }
            }

        }

    }
}


