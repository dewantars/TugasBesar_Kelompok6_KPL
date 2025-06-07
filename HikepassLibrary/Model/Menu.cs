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
            Console.WriteLine("3. Exit");
            Console.Write("Pilih: ");
        }
       
        public static void menuAdmin()
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Selamat Datang Admin!");
            Console.WriteLine("1. Monitoring Pendaki");
            Console.WriteLine("2. Edit Informasi");
            Console.WriteLine("3. Lihat Laporan");
            Console.WriteLine("4. Lihat Riwayat Pendakian");
            Console.WriteLine("5. Log Out");
            Console.Write("Pilih: ");
        }
        public static void menuUser()
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Selamat Datang Pendaki!");
            Console.WriteLine("1. Reservasi");
            Console.WriteLine("2. Tiket Saya");
            Console.WriteLine("3. Lihat Informasi");
            Console.WriteLine("4. Input Laporan");
            Console.WriteLine("5. Edit Profil");
            Console.WriteLine("6. Log Out");
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
            Console.WriteLine("1. Puncak Besar Malabar Via Cinyiruan(Sedang) 50k/orang");
            Console.WriteLine("2. Puncak Besar Malabar Via Panorama(Pendek) 20k/orang");
            Console.WriteLine("Lanjutkan reservasi y/n?");
        }
        
    }
}
