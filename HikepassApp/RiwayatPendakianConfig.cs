using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HikepassApp
{
    class RiwayatPendakianConfig
    {
        private const string ConfigFileName = "RiwayatPendakian.json";

        public string tanggal_reservasi { get; set; }
        public int jumlah_reservasi { get; set; }
        public string jalur_pendakian { get; set; }
        public string tanggal_pembayaran { get; set; }
        public string metode_pembayaran { get; set; }
        public int total_pembayaran { get; set; }
        public string tanggal_checkin { get; set; }
        public string laporan_sampah_checkin { get; set; }
        public string tanggal_checkout { get; set; }
        public string laporan_sampah_checkout { get; set; }

        public static RiwayatPendakianConfig ReadFileConfig()
        {
            try
            {
                if (!File.Exists(ConfigFileName))
                {
                    Console.WriteLine("File tidak ditemukan, membuat file default...");
                    var defaultData = new RiwayatPendakianConfig();
                    WriteFileConfig(defaultData);
                    return defaultData;
                }

                string json = File.ReadAllText(ConfigFileName);
                return JsonSerializer.Deserialize<RiwayatPendakianConfig>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal membaca file config: " + ex.Message);
                return new RiwayatPendakianConfig(); // fallback to default object
            }
        }

        public static void WriteFileConfig(RiwayatPendakianConfig data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigFileName, json);
                Console.WriteLine("Data berhasil disimpan ke file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal menulis ke file config: " + ex.Message);
            }
        }
    }
}
