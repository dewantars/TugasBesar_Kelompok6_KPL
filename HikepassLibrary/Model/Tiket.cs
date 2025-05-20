using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        public enum Jarak
        {
            Pendek,
            Sedang
        }
        public enum StatusTiket
        {
            BelumDibayar,
            Dibayar,
            Checkin,
            Checkout,
            Selesai
        }
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public bool StatusPembayaran { get; set; }
        public int JumlahPendaki { get; set; }
        public string Kontak { get; set; }
        public JalurPendakian Jalur {  get; set; }
        public Dictionary<Tuple<JalurPendakian, Jarak>, string> tabelKeputusan;
        public bool IsCheckedIn {  get; set; }
        public Dictionary<string, string> DaftarPendaki { get; set; } // Nik -> Nama
        public StatusTiket Status { get; set; }
        public List<string> BarangBawaanSaatCheckin { get; set; } = new List<string>();
        public List<string> BarangBawaanSaatCheckout { get; set; } = new List<string>();
        public string Keterangan { get; set; }


        public Tiket() { }
        public Tiket(int id, DateTime tanggalPendakian, JalurPendakian jalur, int jumlahPendaki, String keterangan)
        {
            Id = id;
            Jalur = jalur;
            Tanggal = tanggalPendakian;
            JumlahPendaki = jumlahPendaki;
            DaftarPendaki = new Dictionary<string, string>();
            StatusPembayaran = false;
            Status = StatusTiket.BelumDibayar;
            Keterangan = Keterangan;
        }
       
        public void ShowTiketInfo()
        {
            Console.WriteLine($"ID Tiket: {Id}");
            Console.WriteLine($"Jalur Pendakian: {Jalur}");
            Console.WriteLine($"Tanggal Pendakian: {Tanggal.ToShortDateString()}");
            Console.WriteLine($"Jumlah Pendaki: {JumlahPendaki}");
            Console.WriteLine($"Status Pembayaran: {(StatusPembayaran ? "Dibayar" : "BelumDibayar" )}");
            Console.WriteLine($"Status Tiket: {Status}");
            Console.WriteLine("Daftar Pendaki:");

            foreach (var pendaki in DaftarPendaki)
            {
                // Menangani data kosong atau tidak lengkap
                string pendakiInfo = pendaki.Value;
                if (string.IsNullOrWhiteSpace(pendakiInfo))
                {
                    // Jika data pendaki kosong, beri tahu bahwa data tidak lengkap
                    Console.WriteLine($"{pendaki.Key}: Data tidak lengkap");
                }
                else
                {
                    // Jika data lengkap, tampilkan informasi pendaki
                    Console.WriteLine($"{pendaki.Key}: {pendakiInfo}");
                }
            }
        }

    }
}


