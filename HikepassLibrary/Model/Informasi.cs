// Informasi.cs
using System;
using System.IO;
using System.Text.Json;

namespace HikepassLibrary.Model
{
    // Kelas generik untuk menyimpan Informasi
    public class Informasi<T>
    {
        public string IdInformasi { get; set; }      // ID unik untuk setiap Informasi
        public T Kategori { get; set; }              // Kategori Informasi (generic)
        public string Judul { get; set; }            // Judul Informasi
        public string Deskripsi { get; set; }        // Deskripsi Informasi
        public DateTime TanggalDibuat { get; set; }  // Waktu saat Informasi dibuat

        public Informasi() { }

        // Konstruktor dengan validasi input
        public Informasi(string id, T kategori, string judul, string deskripsi, DateTime tanggal)
        {
            // Secure coding: validasi input agar tidak terjadi kesalahan saat runtime
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID Informasi tidak boleh kosong.");
            if (kategori == null) throw new ArgumentNullException(nameof(kategori));
            if (string.IsNullOrWhiteSpace(judul)) throw new ArgumentException("Judul tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong.");
            if (tanggal == default) throw new ArgumentException("Tanggal tidak valid.");

            IdInformasi = id;
            Kategori = kategori;
            Judul = judul;
            Deskripsi = deskripsi;
            TanggalDibuat = tanggal;
        }

        // Menampilkan Informasi ke konsol
        public void TampilkanInformasi()
        {
            Console.WriteLine($"ID Informasi   : {IdInformasi}");
            Console.WriteLine($"Kategori       : {Kategori}");
            Console.WriteLine($"Judul          : {Judul}");
            Console.WriteLine($"Deskripsi      : {Deskripsi}");
            Console.WriteLine($"Tanggal Dibuat : {TanggalDibuat:dd/MM/yyyy HH.mm.ss}");
        }

        // Mengedit Informasi pada kategori tertentu oleh pengelola
        public static Informasi<string> EditInformasi()
        {
            DateTime tanggal = DateTime.Now;
            string idOtomatis = "INF" + tanggal.ToString("yyyyMMddHHmmss");
            string kategori = AmbilKategoriDariUser();
            string judul = AmbilInputNonKosong("Judul: ");
            string deskripsi = AmbilInputNonKosong("Deskripsi: ");
            return new Informasi<string>(idOtomatis, kategori, judul, deskripsi, tanggal);
        }

        // Validasi input kategori dari pengelola/pendaki
        private static string AmbilKategoriDariUser()
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
        private static string HandleInputInvalid(string input)
        {
            Console.WriteLine("Input tidak valid. Masukkan angka 1-3 atau nama kategori.");
            return AmbilKategoriDariUser();
        }

        // Secure Coding: memastikan input tidak kosong
        private static string AmbilInputNonKosong(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Input tidak boleh kosong.");
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        // Menulis objek Informasi ke file JSON
        public void TulisKeFileJson(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Membaca objek Informasi dari file JSON
        public static Informasi<T> BacaDariFileJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File tidak ditemukan: " + filePath); // Secure coding: validasi eksistensi file

            string jsonString = File.ReadAllText(filePath);
            var informasi = JsonSerializer.Deserialize<Informasi<T>>(jsonString);

            // Secure coding: validasi hasil deserialisasi
            if (informasi == null ||
                string.IsNullOrWhiteSpace(informasi.IdInformasi) ||
                informasi.Kategori == null ||
                string.IsNullOrWhiteSpace(informasi.Judul) ||
                string.IsNullOrWhiteSpace(informasi.Deskripsi) ||
                informasi.TanggalDibuat == default)
            {
                throw new InvalidOperationException("Informasi dari file tidak lengkap atau salah.");
            }

            return informasi;
        }
    }
}