using System;

namespace HikepassApp
{
    class Informasi<T>
    {
        public string IdInformasi { get; set; }
        public T Kategori { get; set; }
        public string Judul { get; set; }
        public string Isi { get; set; }
        public DateTime TanggalDibuat { get; set; }

        public Informasi(string id, T kategori, string judul, string isi, DateTime tanggal)
        {
            IdInformasi = id;
            Kategori = kategori;
            Judul = judul;
            Isi = isi;
            TanggalDibuat = tanggal;
        }

        public void TampilkanInformasi()
        {
            Console.WriteLine("\n------------------- Informasi -------------------");
            Console.WriteLine("ID Informasi   : " + IdInformasi);
            Console.WriteLine("Kategori       : " + Kategori);
            Console.WriteLine("Judul          : " + Judul);
            Console.WriteLine("Isi            : " + Isi);
            Console.WriteLine("Tanggal Dibuat : " + TanggalDibuat.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine();
        }

        public static Informasi<T> InputInformasi()
        {
            Console.WriteLine("------------- Input Informasi Pendakian -------------");

            DateTime tanggal = DateTime.Now;
            string idOtomatis = "INF" + tanggal.ToString("yyyyMMddHHmmss");

            string inputKategori;
            T kategori;

            if (typeof(T) == typeof(string))
            {
                Console.Write("Kategori (misalnya: Peraturan, Tips, Umum): ");
                inputKategori = Console.ReadLine().Trim();
                kategori = (T)(object)inputKategori;
            }
            else if (typeof(T) == typeof(int))
            {
                Console.Write("Kategori (1 = Peraturan, 2 = Tips, 3 = Umum): ");
                string input = Console.ReadLine();

                int value;
                while (!int.TryParse(input, out value) || value < 1 || value > 3)
                {
                    Console.Write("Input tidak valid! Masukkan angka 1-3: ");
                    input = Console.ReadLine();
                }

                kategori = (T)(object)value;
            }
            else
            {
                throw new InvalidOperationException("Tipe kategori tidak didukung.");
            }

            Console.Write("Judul Informasi  : ");
            string judul = Console.ReadLine();

            Console.Write("Isi Informasi    : ");
            string isi = Console.ReadLine();

            return new Informasi<T>(idOtomatis, kategori, judul, isi, tanggal);
        }
    }
}
