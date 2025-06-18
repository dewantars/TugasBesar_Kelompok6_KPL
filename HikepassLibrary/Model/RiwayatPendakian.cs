using HikepassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    // Kelas untuk mengelola riwayat pendakian
    public class RiwayatPendakian
    {
        // Menyimpan daftar tiket pendakian
        public static List<Tiket> riwayatList = new List<Tiket>();

        // Objek service untuk mengelola data riwayat pendakian
        private readonly RiwayatService _riwayatService;

        // Konstruktor untuk menginisialisasi kelas dan memuat data dari file JSON
        public RiwayatPendakian(string filePath = "RiwayatPendakian.json")
        {
            _riwayatService = new RiwayatService(filePath);
            riwayatList = _riwayatService.LoadRiwayat(); // Memuat riwayat saat inisialisasi
        }

        // Menampilkan daftar riwayat pendakian di konsol
        public void ShowRiwayat()
        {
            if (riwayatList.Count == 0)
            {
                Console.WriteLine("Riwayat pendakian kosong.");
                return;
            }

            foreach (var tiket in riwayatList)
            {
                Console.WriteLine("---------------------- Riwayat Pendakian ------------------------");
                tiket.ShowTiketInfo();
                Console.WriteLine("Barang Bawaan Saat Check-In: " + string.Join(", ", tiket.BarangBawaanSaatCheckin));
                Console.WriteLine("Barang Bawaan Saat Check-Out: " + string.Join(", ", tiket.BarangBawaanSaatCheckout));
                Console.WriteLine($"Keterangan: {tiket.Keterangan}");
            }
        }

        // Menyimpan data riwayat pendakian ke file JSON
        public void SaveRiwayat()
        {
            _riwayatService.SaveRiwayat(riwayatList);
        }
    }

}
