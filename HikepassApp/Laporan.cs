using System;

namespace HikepassApp
{
    class Laporan<T>
    {
        public string IdLaporan { get; private set; }
        public string Deskripsi { get; private set; }
        public string TitikLokasi { get; private set; }
        public DateTime WaktuLaporan { get; private set; }
        public T TingkatKeparahan { get; private set; }

        public Laporan(string id, string deskripsi, string lokasi, DateTime waktu, T keparahan)
        {
            // Defensive: validasi parameter konstruktor
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Titik lokasi tidak boleh kosong.");
            if (waktu == default) throw new ArgumentException("Waktu tidak valid.");
            if (keparahan == null) throw new ArgumentNullException(nameof(keparahan), "Tingkat keparahan tidak boleh null.");

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
            Console.WriteLine();
        }

        public static Laporan<T> InputLaporan()
        {
            Console.WriteLine("----------------- Input Data Laporan ----------------");

            // Validasi deskripsi
            string deskripsi;
            do
            {
                Console.Write("Deskripsi Laporan  : ");
                deskripsi = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(deskripsi))
                    Console.WriteLine("Deskripsi tidak boleh kosong.");
            } while (string.IsNullOrWhiteSpace(deskripsi));

            // Validasi lokasi
            string lokasi;
            do
            {
                Console.Write("Titik Lokasi       : ");
                lokasi = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(lokasi))
                    Console.WriteLine("Titik lokasi tidak boleh kosong.");
            } while (string.IsNullOrWhiteSpace(lokasi));

            // Input dan validasi tingkat keparahan
            T keparahan;
            if (typeof(T) == typeof(string))
            {
                string input;
                do
                {
                    Console.Write("Tingkat Keparahan (misalnya: Ringan, Sedang, Berat): ");
                    input = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(input))
                        Console.WriteLine("Tingkat keparahan tidak boleh kosong.");
                } while (string.IsNullOrWhiteSpace(input));

                keparahan = (T)(object)input;
            }
            else if (typeof(T) == typeof(int))
            {
                int level;
                string input;
                do
                {
                    Console.Write("Tingkat Keparahan (1: Ringan, 2: Sedang, 3: Berat): ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out level) || level < 1 || level > 3)
                        Console.WriteLine("Input tidak valid! Masukkan angka 1-3.");
                } while (!int.TryParse(input, out level) || level < 1 || level > 3);

                keparahan = (T)(object)level;
            }
            else
            {
                throw new InvalidOperationException("Tipe data untuk TingkatKeparahan tidak didukung. Hanya string dan int.");
            }

            DateTime waktu = DateTime.Now;
            string idOtomatis = "LAP" + waktu.ToString("yyyyMMddHHmmss");

            return new Laporan<T>(idOtomatis, deskripsi, lokasi, waktu, keparahan);
        }
    }
}
