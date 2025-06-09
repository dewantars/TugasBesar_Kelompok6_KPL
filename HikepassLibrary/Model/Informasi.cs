using System;
using System.IO;
using System.Text.Json;

namespace HikepassLibrary.Model
{
    public class Informasi<T>
    {
        public string IdInformasi { get; set; }
        public T Kategori { get; set; }
        public string Judul { get; set; }
        public string Deskripsi { get; set; }
        public DateTime TanggalDibuat { get; set; }

        public Informasi() { }

        public Informasi(string id, T kategori, string judul, string deskripsi, DateTime tanggal)
        {
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

        public void TampilkanInformasi()
        {
            Console.WriteLine($"ID Informasi   : {IdInformasi}");
            Console.WriteLine($"Kategori       : {Kategori}");
            Console.WriteLine($"Judul          : {Judul}");
            Console.WriteLine($"Deskripsi      : {Deskripsi}");
            Console.WriteLine($"Tanggal Dibuat : {TanggalDibuat:dd/MM/yyyy HH.mm.ss}");
        }

        public static Informasi<string> EditInformasi()
        {
            DateTime tanggal = DateTime.Now;
            string idOtomatis = "INF" + tanggal.ToString("yyyyMMddHHmmss");
            string kategori = AmbilKategoriDariUser();
            string judul = AmbilInputNonKosong("Judul: ");
            string deskripsi = AmbilInputNonKosong("Deskripsi: ");
            return new Informasi<string>(idOtomatis, kategori, judul, deskripsi, tanggal);
        }

        private static string AmbilKategoriDariUser()
        {
            while (true)
            {
                Console.Write("Masukkan kategori (1 = Peraturan, 2 = Tips, 3 = Umum): ");
                string input = Console.ReadLine()?.Trim().ToLower();

                return input switch
                {
                    "1" => "Peraturan",
                    "2" => "Tips",
                    "3" => "Umum",
                    "peraturan" => "Peraturan",
                    "tips" => "Tips",
                    "umum" => "Umum",
                    _ => HandleInputInvalid(input)
                };
            }
        }

        private static string HandleInputInvalid(string input)
        {
            Console.WriteLine("Input tidak valid. Masukkan angka 1, 2, 3 atau nama kategori.");
            return AmbilKategoriDariUser();
        }

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

        public void TulisKeFileJson(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static Informasi<T> BacaDariFileJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File tidak ditemukan: " + filePath);

            string jsonString = File.ReadAllText(filePath);
            var informasi = JsonSerializer.Deserialize<Informasi<T>>(jsonString);

            if (informasi == null)
                throw new InvalidOperationException("Gagal membaca Informasi.");

            if (string.IsNullOrWhiteSpace(informasi.IdInformasi) ||
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
