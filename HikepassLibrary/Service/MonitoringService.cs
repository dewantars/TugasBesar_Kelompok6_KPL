using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

using System;
using System.Collections.Generic;
using static HikepassLibrary.Model.MonitoringFSM;

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
            string? namaPendaki = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(namaPendaki))
            {
                Console.WriteLine("[x] Nama pendaki tidak boleh kosong.");
                return;
            }

            if (!_pendakiStates.TryGetValue(tiketId, out var fsmDict) || !fsmDict.TryGetValue(namaPendaki, out var fsm))
            {
                Console.WriteLine($"[x] Data pendaki '{namaPendaki}' di tiket ID {tiketId} tidak ditemukan.");
                return;
            }

            Console.WriteLine($"-> Status saat ini untuk '{namaPendaki}' adalah: {fsm.current}");

            var availableTriggers = fsm.GetAvailableTriggers();

            if (availableTriggers.Count == 0)
            {
                Console.WriteLine("-> Tidak ada aksi selanjutnya yang tersedia untuk pendaki ini.");
                return;
            }

            Console.WriteLine("\n[Aksi yang bisa dilakukan: " + string.Join(", ", availableTriggers)+"]");
            Console.WriteLine();
            Console.Write("Masukkan aksi yang akan dilakukan [NaikPos/CapaiPuncak/TurunGunung/SelesaiPendakian]: ");
            var aksi = Console.ReadLine()?.Trim();

            if (!Enum.TryParse<MonitoringFSM.Trigger>(aksi, out var trigger))
            {
                Console.WriteLine("[x] Input tujuan tidak dikenali. Gunakan: NaikPos, CapaiPuncak, TurunGunung, SelesaiPendakian.");
                return;
            }

            var result = UpdateStatusWithTrigger(tiketId, namaPendaki, trigger);
            Console.WriteLine(result);
        }

        private string UpdateStatusWithTrigger(int tiketId, string namaPendaki, MonitoringFSM.Trigger trigger)
        {
            var fsm = _pendakiStates[tiketId][namaPendaki];
            var before = fsm.current;

            switch (trigger)
            {
                case MonitoringFSM.Trigger.NaikPos: fsm.NaikPos(); break;
                case MonitoringFSM.Trigger.CapaiPuncak: fsm.CapaiPuncak(); break;
                case MonitoringFSM.Trigger.TurunGunung: fsm.TurunGunung(); break;
                case MonitoringFSM.Trigger.SelesaiPendakian: fsm.SelesaiPendakian(); break;
            }

            var after = fsm.current;
            var sb = new StringBuilder();

            sb.AppendLine($"\n[INFO] Tiket ID: {tiketId} | Pendaki: '{namaPendaki}'");
            sb.AppendLine($"[AKSI] {trigger} diminta dari status {before}");

            if (before == after)
            {
                sb.AppendLine($"[!] Aksi '{trigger}' tidak valid dari status '{before}'.");
                sb.AppendLine("Transisi status harus dilakukan secara berurutan sesuai alur automata");
            }
            else
            {
                sb.AppendLine($"[✓] Status berhasil diperbarui: {before} → {after}");
            }

            sb.AppendLine("-------------------------------------------------------------");

            return sb.ToString();
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


