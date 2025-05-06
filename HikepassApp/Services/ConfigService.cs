using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HikepassApp.Services
{
    public static class ConfigService
    {
        public static string[] AvailableTrails { get; set; } = new string[0];

        public static void LoadConfig(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File konfigurasi tidak ditemukan.");
                return;
            }

            try
            {
                string json = File.ReadAllText(path);
                var config = JsonSerializer.Deserialize<ConfigFile>(json);
                if (config != null && config.AvailableTrails.Length > 0)
                {
                    AvailableTrails = config.AvailableTrails;
                }
                else
                {
                    Console.WriteLine("Konfigurasi tidak valid. Menggunakan jalur default.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi: {ex.Message}");
            }
        }

        public static void ShowAvailableTrails()
        {
            Console.WriteLine("\nDaftar Jalur Pendakian Tersedia:");
            foreach (var trail in AvailableTrails)
            {
                Console.WriteLine($"- {trail}");
            }
        }

        private class ConfigFile
        {
            public string[] AvailableTrails { get; set; }
        }
    }
}
