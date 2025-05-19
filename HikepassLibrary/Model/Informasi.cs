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
        public string Isi { get; set; }
        public DateTime TanggalDibuat { get; set; }
        public Informasi() { }
        public Informasi(string id, T kategori, string judul, string isi, DateTime tanggal)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID Informasi tidak boleh kosong.", nameof(id));
            if (kategori == null)
                throw new ArgumentNullException(nameof(kategori), "Kategori tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(judul))
                throw new ArgumentException("Judul tidak boleh kosong.", nameof(judul));
            if (string.IsNullOrWhiteSpace(isi))
                throw new ArgumentException("Isi tidak boleh kosong.", nameof(isi));
            if (tanggal == default)
                throw new ArgumentException("Tanggal dibuat tidak valid.", nameof(tanggal));

            IdInformasi = id;
            Kategori = kategori;
            Judul = judul;
            Isi = isi;
            TanggalDibuat = tanggal;
        }

        public void TampilkanInformasi()
        {
            Console.WriteLine("ID Informasi   : " + IdInformasi);
            Console.WriteLine("Kategori       : " + Kategori);
            Console.WriteLine("Judul          : " + Judul);
            Console.WriteLine("Isi            : " + Isi);
            Console.WriteLine("Tanggal Dibuat : " + TanggalDibuat.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public static Informasi<T> EditInformasi()
        {
            DateTime tanggal = DateTime.Now;
            string idOtomatis = "INF" + tanggal.ToString("yyyyMMddHHmmss");

            T kategori;
            if (typeof(T) == typeof(string))
            {
                string inputKategori;
                do
                {
                    Console.Write("Kategori (contoh: Peraturan, Tips, Umum): ");
                    inputKategori = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(inputKategori))
                        Console.WriteLine("Kategori tidak boleh kosong.");
                } while (string.IsNullOrWhiteSpace(inputKategori));

                kategori = (T)(object)inputKategori;
            }
            else if (typeof(T) == typeof(int))
            {
                int value;
                string input;
                do
                {
                    Console.Write("Kategori (1 = Peraturan, 2 = Tips, 3 = Umum): ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out value) || value < 1 || value > 3)
                        Console.WriteLine("Input salah! Tolong masukkan angka antara 1 - 3.");
                } while (!int.TryParse(input, out value) || value < 1 || value > 3);

                kategori = (T)(object)value;
            }
            else
            {
                throw new InvalidOperationException("Tipe kategori tidak didukung.");
            }

            string judul;
            do
            {
                Console.Write("Judul Informasi  : ");
                judul = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(judul))
                    Console.WriteLine("Judul tidak boleh kosong.");
            } while (string.IsNullOrWhiteSpace(judul));

            string isi;
            do
            {
                Console.Write("Isi Informasi    : ");
                isi = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(isi))
                    Console.WriteLine("Isi tidak boleh kosong.");
            } while (string.IsNullOrWhiteSpace(isi));

            return new Informasi<T>(idOtomatis, kategori, judul, isi, tanggal);
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
                throw new InvalidOperationException("Gagal membaca data Informasi.");

            if (string.IsNullOrWhiteSpace(informasi.IdInformasi) ||
                informasi.Kategori == null ||
                string.IsNullOrWhiteSpace(informasi.Judul) ||
                string.IsNullOrWhiteSpace(informasi.Isi) ||
                informasi.TanggalDibuat == default)
            {
                throw new InvalidOperationException("Data Informasi dari file tidak lengkap atau salah.");
            }

            return informasi;
        }
    }
}