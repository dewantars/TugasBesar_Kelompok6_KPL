using HikepassLibrary.Model;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Service
{
    // Clean code: nama class menggunakan PascalCase sesuai standar konvensi C# 
    public class LaporanService
    {
        // Clean code: deklarasi variabel menggunakan camelCase dan tipe generic eksplisit 
        // Secure coding: list tidak diinisialisasi dengan null (fail-safe terhadap NullReferenceException) 
        public static List<Laporan<string>> listLaporan = new List<Laporan<string>>();

        // Clean code: Method PascalCase dan nama parameter jelas sesuai fungsi 
        public static void AddLaporan(Laporan<string> laporan)
        {
            listLaporan.Add(laporan); // Clean code: metode satu baris langsung eksekusi
        }

        // Clean code: white space antar logika validasi ditambahkan untuk keterbacaan
        // Clean code: nama method jelas (PrintLaporan), sesuai dengan fungsi yang dilakukan 
        public static void PrintLaporan()
        {
            // Secure coding: Cek jika list kosong untuk mencegah iterasi kosong dan clean code: variable declaration jelas dan deskriptif
            if (listLaporan.Count == 0)
            {
                Console.WriteLine("Belum ada laporan tersedia."); // Feedback jelas ke user 
            }
            else
            {
                foreach (var laporan in listLaporan) // Clean code: variabel lokal camelCase 
                {
                    laporan.PrintLaporan(); // Pemanggilan method dari objek, sesuai konvensi OOP 
                }
            }
        }

        // Clean code: nama method deskriptif (PrintLaporanById) dan parameter camelCase 
        public static void PrintLaporanById(string id)
        {
            // Secure coding: menggunakan FirstOrDefault untuk menghindari exception jika tidak ketemu 
            var laporan = listLaporan.FirstOrDefault(l => l.IdLaporan == id);
            if (laporan != null)
            {
                laporan.PrintLaporan();
            }
            else
            {
                Console.WriteLine("Laporan dengan ID " + id + " tidak ditemukan."); // Secure coding: tidak memberikan informasi sensitif 
            }
        }

        // Clean code: method static dengan PascalCase 
        // Secure coding: validasi dilakukan di dalam InputLaporan() yang sudah mengandung validasi lengkap 
        public static void InputLaporan()
        {
            var laporan = Laporan<string>.InputLaporan(); // Clean code: pemanggilan method modular dari class Model 
            listLaporan.Add(laporan);
        }
    }
}
