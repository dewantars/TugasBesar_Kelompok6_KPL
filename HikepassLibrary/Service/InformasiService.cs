// InformasiService.cs
using HikepassLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;

namespace HikepassLibrary.Service
{
    // Mengelola daftar Informasi dari dan ke file JSON
    public class InformasiService
    {
        private readonly string filePath;

        // Konstruktor untuk menentukan lokasi file penyimpanan Informasi
        public InformasiService(string filePath = "informasi.json")
        {
            this.filePath = filePath;
        }

        // Membaca objek Informasi dari file JSON
        private List<Informasi<string>> GetAllInformasi()
        {
            if (!File.Exists(filePath))
                return new List<Informasi<string>>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Informasi<string>>>(json) ?? new List<Informasi<string>>();
        }

        // Menampilkan Informasi dari kategori tertentu
        public void TampilkanInformasi()
        {
            string kategori = BacaKategoriDariUser();

            var daftar = GetAllInformasi().FindAll(i =>
                i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

            if (daftar.Count == 0)
            {
                Console.WriteLine($"\nTidak ada informasi dalam kategori '{kategori}'.");
                return;
            }

            foreach (var info in daftar)
            {
                Console.WriteLine();
                info.TampilkanInformasi();
            }
        }

        // Mengedit Informasi pada kategori tertentu oleh pengelola
        public void EditInformasi()
        {
            string kategori = BacaKategoriDariUser();
            var semuaInformasi = GetAllInformasi();

            var daftar = semuaInformasi.FindAll(i =>
                i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

            if (daftar.Count > 0)
            {
                foreach (var info in daftar)
                    info.TampilkanInformasi();
            }
            else
            {
                Console.WriteLine($"\nTidak ada informasi dalam kategori '{kategori}'.");
            }

            string konfirmasi;
            do
            {
                Console.Write("\nApakah Anda ingin mengedit informasi kategori ini? (y/n): ");
                konfirmasi = Console.ReadLine()?.Trim().ToLower();

                if (konfirmasi == "y")
                {
                    var infoBaru = Informasi<string>.EditInformasi();
                    semuaInformasi.RemoveAll(i =>
                        i.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));
                    semuaInformasi.Add(infoBaru);

                    SimpanInformasi(semuaInformasi);
                    Console.WriteLine("\nInformasi telah diperbarui.");
                    break;
                }
                else if (konfirmasi == "n")
                {
                    Console.WriteLine("Tidak ada perubahan informasi.");
                    break;
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Harap masukkan 'y' atau 'n'.");
                }
            } while (true);
        }

        // Menyimpan Informasi ke file JSON, Secure coding: WriteIndented
        private void SimpanInformasi(List<Informasi<string>> data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, JsonSerializer.Serialize(data, options));
        }

        // Validasi input kategori dari pengelola/pendaki
        private string BacaKategoriDariUser()
        {
            while (true)
            {
                Console.Write("Masukkan kategori (1 = Peraturan, 2 = Tips, 3 = Umum): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                return input switch
                {
                    "1" or "peraturan" => "Peraturan",
                    "2" or "tips" => "Tips",
                    "3" or "umum" => "Umum",
                    _ => HandleInputInvalid(input)
                };
            }
        }

        // Secure coding: penanganan input tidak valid
        private string HandleInputInvalid(string input)
        {
            Console.WriteLine("Input tidak valid. Masukkan angka 1, 2, 3 atau nama kategori secara langsung.\n");
            return BacaKategoriDariUser();
        }
    }
}