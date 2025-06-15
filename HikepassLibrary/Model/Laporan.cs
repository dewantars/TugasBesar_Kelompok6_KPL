using System; // Sudah mengikuti konvensi import .NET standard
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    //  Clean code: nama class menggunakan PascalCase
    public class Laporan<T>
    {
        //  Clean code: variable/property declaration, akses modifier eksplisit dan properti dengan nama yang jelas dan deskriptif 
        public string IdLaporan { get; private set; } // Clean code: PascalCase untuk properti 
        public string Deskripsi { get; private set; } //  Clean code: naming convention & deklarasi bersih 
        public string TitikLokasi { get; private set; }
        public DateTime WaktuLaporan { get; private set; }
        public T TingkatKeparahan { get; private set; }

        // Clean code: nama konstruktor mengikuti nama class (PascalCase) 
        public Laporan(string id, string deskripsi, string lokasi, DateTime waktu, T keparahan)
        {
            // Defensive
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID tidak boleh kosong."); // Secure coding: validasi input untuk menghindari null/injection 
            if (string.IsNullOrWhiteSpace(deskripsi)) throw new ArgumentException("Deskripsi tidak boleh kosong."); // Secure coding: validasi input string 
            if (string.IsNullOrWhiteSpace(lokasi)) throw new ArgumentException("Titik lokasi tidak boleh kosong.");
            if (waktu == default) throw new ArgumentException("Waktu tidak valid.");
            if (keparahan == null) throw new ArgumentNullException(nameof(keparahan), "Tingkat keparahan tidak boleh null.");

            // Design by Contract (preconditions)
            Debug.Assert(id.StartsWith("LAP"), "ID laporan harus diawali dengan 'LAP'"); // Validasi format ID secara logis 

            IdLaporan = id;
            Deskripsi = deskripsi;
            TitikLokasi = lokasi;
            WaktuLaporan = waktu;
            TingkatKeparahan = keparahan;

            // Design by Contract (postcondition)
            Debug.Assert(!string.IsNullOrEmpty(IdLaporan), "ID tidak boleh kosong setelah konstruksi");
        }

        public void PrintLaporan() //  Clean code: nama method pakai PascalCase dan deskriptif 
        {
            Console.WriteLine("---------------------------- Laporan ----------------------------"); // Clean code: white space antar logika validasi ditambahkan untuk keterbacaan
            Console.WriteLine("ID                : " + IdLaporan);
            Console.WriteLine("Waktu             : " + WaktuLaporan.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("Deskripsi Laporan : " + Deskripsi);
            Console.WriteLine("Lokasi            : " + TitikLokasi);
            Console.WriteLine("Keparahan         : " + TingkatKeparahan);
        }

        public static Laporan<T> InputLaporan() 
        {
            Console.WriteLine("----------------------- Input Data Laporan ----------------------");

            // Defensive + precondition
            string deskripsi; // Clean code: variable declaration jelas dan deskriptif
            do
            {
                Console.Write("Deskripsi Laporan  : ");
                deskripsi = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(deskripsi))
                    Console.WriteLine("Deskripsi tidak boleh kosong."); // Secure coding: validasi input kosong 
            } while (string.IsNullOrWhiteSpace(deskripsi));

            string lokasi;
            do
            {
                Console.Write("Titik Lokasi       : ");
                lokasi = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(lokasi))
                    Console.WriteLine("Titik lokasi tidak boleh kosong.");
            } while (string.IsNullOrWhiteSpace(lokasi));

            T keparahan; //  Clean code: variable declaration, penamaan jelas dan berada dekat pemakaian 

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

                keparahan = (T)(object)input; // Penanganan tipe data fleksibel dengan aman 
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
                        Console.WriteLine("Input tidak valid! Masukkan angka 1-3."); // Secure coding: validasi input numerik dalam rentang yang tepat 
                } while (!int.TryParse(input, out level) || level < 1 || level > 3);

                keparahan = (T)(object)level;
            }
            else
            {
                throw new InvalidOperationException("Tipe data untuk TingkatKeparahan tidak didukung. Hanya string dan int."); // Secure coding: fail-safe untuk tipe tidak valid 
            }

            DateTime waktu = DateTime.Now;
            string idOtomatis = "LAP" + waktu.ToString("yyyyMMddHHmmss"); //  Clean code: variabel pakai camelCase 

            // Postcondition
            Debug.Assert(!string.IsNullOrEmpty(idOtomatis), "ID tidak terbentuk dengan benar"); // Validasi hasil pembuatan ID 
            return new Laporan<T>(idOtomatis, deskripsi, lokasi, waktu, keparahan); // Penulisan parameter sesuai urutan deklarasi dan terbaca jelas 
        }
    }
}
