using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class RiwayatPendakian
    {
        public static List<Tiket> riwayatList = new List<Tiket>();

        public void ShowRiwayat(Tiket tiket)
        {
            foreach (var item in riwayatList)
            {
                if (item.Id == tiket.Id)
                {
                    Console.WriteLine($"ID Tiket: {item.Id}");
                    Console.WriteLine($"Jalur Pendakian: {item.Jalur}");
                    Console.WriteLine($"Tanggal Pendakian: {item.Tanggal.ToShortDateString()}");
                    Console.WriteLine($"Jumlah Pendaki: {item.JumlahPendaki}");
                    Console.WriteLine($"Status Pembayaran: {(item.StatusPembayaran ? "Dibayar" : "BelumDibayar")}");
                    Console.WriteLine($"Status Tiket: {item.Status}");
                    Console.WriteLine("Daftar Pendaki:");
                    foreach (var pendaki in item.DaftarPendaki)
                    {
                        Console.WriteLine($"Nik: {pendaki.Key}, Nama: {pendaki.Value}");
                    }
                }
            }

        }
    }

}
