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
            Console.WriteLine("Pilih Pengguna");
            Console.WriteLine("1. Pengelola");
            Console.WriteLine("2. Pendaki");
        }
        public static void loginpage()
        {
            Console.WriteLine("===Log In====");
            Console.WriteLine("Masukkan username :");
            Console.WriteLine("Masukkan Password :");
        }
        public static void menuAdmin()
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Selamat Datang Admin!");
            Console.WriteLine("1. Riwayat Pendakian");
            Console.WriteLine("2. Edit Informasi");
            Console.WriteLine("3. Monitoring");
            Console.WriteLine("4. Log Out");
        }
        public static void menuUser()
        {
            Console.WriteLine("==================== HikePass App ====================");
            Console.WriteLine("Selamat Datang Pendaki!");
            Console.WriteLine("1. Riwayat Pendakian");
            Console.WriteLine("2. Edit Informasi");
            Console.WriteLine("3. Monitoring");
            Console.WriteLine("4. Log Out");
        }
    }
}
