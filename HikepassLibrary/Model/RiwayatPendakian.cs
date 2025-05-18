using HikepassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class RiwayatPendakian
    {
        public static List<Tiket> riwayatList = new List<Tiket>();
        private readonly RiwayatService _riwayatService;

        public RiwayatPendakian(string filePath = "RiwayatPendakian.json")
        {
            _riwayatService = new RiwayatService(filePath);
            riwayatList = _riwayatService.LoadRiwayat(); // Memuat riwayat saat inisialisasi
        }

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

        public void SaveRiwayat()
        {
            _riwayatService.SaveRiwayat(riwayatList);
        }
    }

}
