using HikepassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HikepassLibrary.Service
{
    public class RiwayatService
    {
        private readonly string _filePath;

        public RiwayatService(string filePath)
        {
            _filePath = filePath;
        }

        // Method untuk menyimpan riwayat ke file JSON
        public void SaveRiwayat(List<Tiket> riwayatList)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };
                string jsonString = JsonSerializer.Serialize(riwayatList, options);
                File.WriteAllText(_filePath, jsonString);
                Console.WriteLine("Riwayat berhasil disimpan ke file");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat menyimpan riwayat: {ex.Message}");
            }
        }

        // Method untuk memuat riwayat dari file JSON
        public List<Tiket> LoadRiwayat()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                    };
                    var riwayatList = JsonSerializer.Deserialize<List<Tiket>>(jsonString, options) ?? new List<Tiket>();
                    Console.WriteLine("Riwayat berhasil dimuat dari file.");
                    return riwayatList;
                }
                else
                {
                    Console.WriteLine("File tidak ditemukan. Memuat riwayat kosong.");
                    return new List<Tiket>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat memuat riwayat: {ex.Message}");
                return new List<Tiket>();
            }
        }
    }
}
