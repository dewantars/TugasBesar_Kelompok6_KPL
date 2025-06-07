using HikepassLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HikepassLibrary.Service
{
    public class RiwayatService
    {
        private readonly string _filePath;

        public RiwayatService(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path tidak boleh null atau kosong.", nameof(filePath));

            _filePath = filePath;
        }

        // Method untuk menyimpan riwayat ke file JSON
        public void SaveRiwayat(List<Tiket> riwayatList)
        {
            if (riwayatList == null)
                throw new ArgumentNullException(nameof(riwayatList), "Riwayat list tidak boleh null.");

            try
            {
                string directory = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };

                string jsonString = JsonSerializer.Serialize(riwayatList, options);
                File.WriteAllText(_filePath, jsonString);

                if (!File.Exists(_filePath))
                    throw new IOException("Gagal menyimpan riwayat ke file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat menyimpan riwayat: {ex.Message}");
                throw;
            }
        }

        // Method untuk memuat riwayat dari file JSON
        public List<Tiket> LoadRiwayat()
        {
            if (string.IsNullOrWhiteSpace(_filePath))
                throw new InvalidOperationException("File path belum diatur atau tidak valid.");

            try
            {
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                    };

                    var riwayatList = JsonSerializer.Deserialize<List<Tiket>>(jsonString, options);

                    if (riwayatList == null)
                        throw new InvalidDataException("File JSON tidak dapat di-deserialisasi dengan benar.");

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
                throw;
            }
        }
    }
}
