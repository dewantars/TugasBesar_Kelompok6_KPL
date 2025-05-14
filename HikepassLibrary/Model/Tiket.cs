using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    
    
    public class Tiket
    {
        public enum JalurPendakian
        {
            Panorama,
            Cinyiruan
        }
        public enum StatusTiket
        {
            BelumDibayar,
            Dibayar,
            Checkin,
            Checkout,
            selesai
        }
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public bool StatusPembayaran { get; set; }
        public int JumlahPendaki { get; set; }
        public string Kontak { get; set; }
        public string Jalur {  get; set; }
        public Dictionary<string, string> DaftarPendaki { get; set; } // Nik -> Nama
        public bool IsCheckedIn { get; set; }
        public StatusTiket Status { get; set; }
        public List<string> BarangBawaanSaatCheckin { get; set; } = new List<string>();
        public List<string> BarangBawaanSaatCheckout { get; set; } = new List<string>();

        public Tiket(int id, DateTime tanggalPendakian, String jalur, int jumlahPendaki)
        {
            Id = id;
            Jalur = jalur;
            Tanggal = tanggalPendakian;
            JumlahPendaki = jumlahPendaki;
            DaftarPendaki = new Dictionary<string, string>();
            StatusPembayaran = false;
            Status = StatusTiket.BelumDibayar;
        }
        public void ShowTiketInfo()
        {
            Console.WriteLine($"ID Tiket: {Id}");
            Console.WriteLine($"Jalur Pendakian: {Jalur}");
            Console.WriteLine($"Tanggal Pendakian: {Tanggal.ToShortDateString()}");
            Console.WriteLine($"Jumlah Pendaki: {JumlahPendaki}");
            Console.WriteLine($"Status Pembayaran: {(StatusPembayaran ? "Dibayar" : "Belum Dibayar")}");
            Console.WriteLine($"Status Tiket: {Status}");
            Console.WriteLine("Daftar Pendaki:");
            foreach (var pendaki in DaftarPendaki)
            {
                Console.WriteLine($"{pendaki.Key}: {pendaki.Value}");
            }
        }
    }
}


