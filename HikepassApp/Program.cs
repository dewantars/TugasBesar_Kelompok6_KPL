using System;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Baca dan proses data riwayat pendakian
            var riwayat = RiwayatPendakianConfig.ReadFileConfig();

            Console.WriteLine("---------- Riwayat Pendakian (Sebelum Pajak) ----------");
            TampilkanData(riwayat);

            // Tambahkan pajak 10%
            riwayat.total_pembayaran = (int)(riwayat.total_pembayaran * 1.10);

            Console.WriteLine("\n---------- Riwayat Pendakian (Setelah Pajak 10%) ----------");
            TampilkanData(riwayat);

            // Simpan kembali ke file
            RiwayatPendakianConfig.WriteFileConfig(riwayat);
        }

        // Fungsi untuk menampilkan data riwayat pendakian
        static void TampilkanData(RiwayatPendakianConfig data)
        {
            Console.WriteLine($"Tanggal Reservasi         : {data.tanggal_reservasi}");
            Console.WriteLine($"Jumlah Pendaki            : {data.jumlah_pendaki}");
            Console.WriteLine($"Jalur Pendakian           : {data.jalur_pendakian}");
            Console.WriteLine($"Tanggal Pembayaran        : {data.tanggal_pembayaran}");
            Console.WriteLine($"Metode Pembayaran         : {data.metode_pembayaran}");
            Console.WriteLine($"Total Pembayaran          : Rp{data.total_pembayaran}");
            Console.WriteLine($"Tanggal Check-In          : {data.tanggal_checkin}");
            Console.WriteLine($"Laporan Sampah Check-In   : {data.laporan_sampah_checkin}");
            Console.WriteLine($"Tanggal Check-Out         : {data.tanggal_checkout}");
            Console.WriteLine($"Laporan Sampah Check-Out  : {data.laporan_sampah_checkout}");
        }
    }
}
