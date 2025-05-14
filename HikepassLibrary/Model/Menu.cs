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
            Console.WriteLine("6. Kembali");
            Console.Write("Pilih: ");
        }
    }
}
