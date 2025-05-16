using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public static class Menu
    {
        public static void SwitchUser()
        {
            Console.WriteLine("Pilih Pengguna:");
            Console.WriteLine("1. Pengelola");
            Console.WriteLine("2. Pendaki");
            Console.Write("Pilih: ");
        }
       
        public static void menuAdmin()
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Selamat Datang Admin!");
            Console.WriteLine("1. Riwayat Pendakian");
            Console.WriteLine("2. Edit Informasi");
            Console.WriteLine("3. Monitoring");
            Console.WriteLine("4. Log Out");
            Console.Write("Pilih: ");
        }
        public static void menuUser()
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Selamat Datang Pendaki!");
            Console.WriteLine("1. Reservasi");
            Console.WriteLine("2. Tiket Saya");
            Console.WriteLine("3. Lihat Informasi");
            Console.WriteLine("4. Edit Profil");
            Console.WriteLine("5. Log Out");
            Console.Write("Pilih: ");
        }
        public static void menuTiketSaya() 
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Tiket Saya");
            Console.WriteLine("1. Lihat Tiket");
            Console.WriteLine("2. Bayar Tiket");
            Console.WriteLine("3. Resechedule Tiket");
            Console.WriteLine("4. Batalkan Tiket");
            Console.WriteLine("5. Lihat Riwayat Pendakian");
            Console.WriteLine("6. Check-in/Check-out Tiket:");
            Console.WriteLine("7. Selesaikan Pendakian");
            Console.WriteLine("8. Kembali");
            Console.Write("Pilih: ");
        }
        public static void DaftarTiket()
        {
            Console.WriteLine("================= Pendakian Gunung Malabar =================");
            Console.WriteLine("Daftar Jalur:");
            Console.WriteLine("1. Puncak Besar Malabar Via Cinyiruan 150k/orang");
            Console.WriteLine("2. Puncak Besar Malabar Via Panorama 20k/orang");
            Console.WriteLine("Lanjutkan reservasi y/n?");
        }
        public static void TampilkanData(RiwayatPendakianConfig data)
        {
            Console.WriteLine($"Tanggal Reservasi         : {data.tanggal_reservasi}");
            Console.WriteLine($"Jumlah Pendaki            : {data.jumlah_reservasi}");
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
