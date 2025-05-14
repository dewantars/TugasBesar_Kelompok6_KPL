using System;

namespace HikepassApp
{
    class Laporan<T>
    {
        public string IdLaporan { get; set; }
        public string Deskripsi { get; set; }
        public string TitikLokasi { get; set; }
        public DateTime WaktuLaporan { get; set; }
        public T TingkatKeparahan { get; set; }

        public Laporan(string id, string deskripsi, string lokasi, DateTime waktu, T keparahan)
        {
            IdLaporan = id;
            Deskripsi = deskripsi;
            TitikLokasi = lokasi;
            WaktuLaporan = waktu;
            TingkatKeparahan = keparahan;
        }

        public void PrintLaporan()
        {
            Console.WriteLine("\n---------------------- Laporan ----------------------");
            Console.WriteLine("ID                : " + IdLaporan);
            Console.WriteLine("Waktu             : " + WaktuLaporan.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("Deskripsi Laporan : " + Deskripsi);
            Console.WriteLine("Lokasi            : " + TitikLokasi);
            Console.WriteLine("Keparahan         : " + TingkatKeparahan);
            Console.WriteLine(" ");
        }

        public static Laporan<T> InputLaporan()
        {
            Console.WriteLine("----------------- Input Data Laporan ----------------");

            Console.Write("Deskripsi Laporan  : ");
            string deskripsi = Console.ReadLine();

            Console.Write("Titik Lokasi       : ");
            string lokasi = Console.ReadLine();

            string tingkatKeparahan;
            T keparahan;

            if (typeof(T) == typeof(string))
            {
                Console.Write("Tingkat Keparahan (misalnya: Ringan, Sedang, Berat, atau Lainnya): ");
                tingkatKeparahan = Console.ReadLine().Trim();
                keparahan = (T)(object)tingkatKeparahan;
            }
            else if (typeof(T) == typeof(int))
            {
                Console.Write("Tingkat Keparahan (misalnya: 1 untuk Ringan, 2 untuk Sedang, 3 untuk Berat): ");
                string input = Console.ReadLine();

                int level;
                while (!int.TryParse(input, out level) || level < 1 || level > 3)
                {
                    Console.Write("Input tidak valid! Masukkan angka 1-3: ");
                    input = Console.ReadLine();
                }

                keparahan = (T)(object)level;
            }
            else
            {
                throw new InvalidOperationException("Tipe data yang tidak didukung.");
            }

            DateTime waktu = DateTime.Now;

            string idOtomatis = "LAP" + waktu.ToString("yyyyMMddHHmmss");

            return new Laporan<T>(idOtomatis, deskripsi, lokasi, waktu, keparahan);
        }
    }
}