using HikepassLibrary.Model;
using HikepassLibrary.Service;
using HikepassLibrary.Controller;
using System.Text.Json;
using System.Text;
using System.Xml.Schema;
using System.Threading.Tasks;
using HikepassApp;

class Program
{
    public static async Task Main(string[] args)
    {
        // TEST LAPORAN
        Laporan<string> laporan = Laporan<string>.InputLaporan();
        laporan.PrintLaporan();
      
        // Inisialisasi layanan
        Pendaki loggedInPendaki = null;
        Pengelola loggedInPengelola = null;
        var pendakiService = new PendakiService();
        var pengelolaService = new PengelolaService();

        pendakiService.AddPendaki(new Pendaki
        {
            Id = 1,
            FullName = "John Doe",
            Email = "john.doe@example.com",
            Username = "admin",
            Password = "12345"
        });

        pengelolaService.AddPengelola(new Pengelola
        {
            Id = 2,
            FullName = "Jane Smith",
            Email = "sas",
            Username = "admin",
            Password = "12345"
        });

        string baseUrl = "http://localhost:7108/api/reservasi";

      
        string username = null;
        string password = null;

        Console.WriteLine("=== Selamat Datang di Hikepass ===");
        Menu.SwitchUser();
        int userType = int.Parse(Console.ReadLine());
        if (userType == 1)
        {
            Console.WriteLine("=== Masuk sebagai Pengelola ===");
            while (loggedInPengelola == null)
            {
                Console.Write("Masukkan Username: ");
                username = Console.ReadLine();

                Console.Write("Masukkan Password: ");
                password = Console.ReadLine();
                bool isValid = pengelolaService.ValidatePengelola(username, password);
                if (isValid)
                {
                    loggedInPengelola = pengelolaService.GetPendakiByUsername(username);
                    Console.WriteLine($"Selamat datang, {loggedInPengelola.FullName}!");
                }
            }
        }
        else if (userType == 2)
        {
            Console.WriteLine("=== Masuk sebagai Pendaki ===");
            while (loggedInPendaki == null)
            {
                Console.Write("Masukkan Username: ");
                username = Console.ReadLine();

                Console.Write("Masukkan Password: ");
                password = Console.ReadLine();
                bool isValid = pendakiService.ValidasiPendaki(username, password);
                if (isValid)
                {
                    loggedInPendaki = pendakiService.GetPendakiByUsername(username);
                    Console.WriteLine($"Selamat datang, {loggedInPendaki.FullName}!");
                }
            }
        }

        // Inisialisasi menu utama

        bool running = true;
        while (running)
        {
            Console.Clear();
            if (loggedInPengelola != null)
            {
                Menu.menuAdmin();
                string pilihan = Console.ReadLine();
                Console.WriteLine();
                switch (pilihan)
                {
                    case "1":
                        Console.WriteLine("Daftar Tiket Tersedia:");
                        //tiketController.LihatTiketTersedia();
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("Pemesanan Tiket:");
                        Console.Write("Masukkan ID Tiket yang ingin dipesan: ");
                        //if (int.TryParse(Console.ReadLine(), out int tiketId))
                        //{
                        //    tiketController.PesanTiket(loggedInPendaki, tiketId);
                        //}
                        //else
                        //{
                        //    Console.WriteLine("ID Tiket tidak valid.\n");
                        //}
                        break;

                    case "3":
                        Console.WriteLine("Terima kasih telah menggunakan Hikepass. Sampai jumpa!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                        break;
                }
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
            else if (loggedInPendaki != null)
            {
                Menu.menuUser();
                string pilihan = Console.ReadLine();
                Console.WriteLine();
                switch (pilihan)
                {
                    case "1":
                        Menu.DaftarTiket();
                        string lanjutkan = "";
                        while(lanjutkan.ToLower() != "y" && lanjutkan.ToLower() != "n")
                        {
                            lanjutkan = Console.ReadLine();
                            if (lanjutkan.ToLower() == "y")
                            {
                                Console.WriteLine("Reservasi Tiket:");
                                await ControllerReservasi.CreateReservasi(baseUrl);
                            }
                            else if (lanjutkan.ToLower() == "n")
                            {
                                Console.WriteLine("Reservasi dibatalkan.");
                            }
                            else
                            {
                                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                            }
                            lanjutkan = Console.ReadLine();
                        }
                        
                        break;

                    case "2":
                        Menu.menuTiketSaya();
                        int pilihanTiket = int.Parse(Console.ReadLine());
                        switch(pilihanTiket)
                        {
                            case 1:
                                Console.WriteLine("Lihat Tiket:");
                                await ControllerReservasi.GetAllReservasi(baseUrl);
                                break;
                            case 2:
                                Console.WriteLine("Bayar Tiket:");
                                //tiketController.BayarTiket();
                                break;
                            case 3:
                                Console.WriteLine("Reschedule Tiket:");
                                await ControllerReservasi.GetAllReservasi(baseUrl);
                                await ControllerReservasi.UpdateReservasi(baseUrl);
                                break;
                            case 4:
                                Console.WriteLine("Batalkan Tiket:");
                                await ControllerReservasi.GetAllReservasi(baseUrl);
                                await ControllerReservasi.DeleteReservasi(baseUrl);
                                break;
                            case 5:
                                Console.WriteLine("Lihat Riwayat Pendakian:");
                                var riwayat = RiwayatPendakianConfig.ReadFileConfig();
                                Menu.TampilkanData(riwayat);
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Lihat Informasi:");
                        //tiketController.LihatInformasi();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Edit Profil:");
                        //pendakiController.EditProfil(loggedInPendaki);
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine("Terima kasih telah menggunakan Hikepass. Sampai jumpa!");
                        running = false;
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                        break;
                }
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }

            

            
        }





        //// Membaca data dari file
        
        //Console.WriteLine("=== Data Riwayat Pendakian (Sebelum Pajak) ===");


        //// Menambahkan pajak 10%
        //riwayat.total_pembayaran = (int)(riwayat.total_pembayaran * 1.10);

        //Console.WriteLine("\n=== Data Riwayat Pendakian (Setelah Pajak 10%) ===");
        //TampilkanData(riwayat);

        //// Simpan kembali data yang telah dimodifikasi
        //RiwayatPendakianConfig.WriteFileConfig(riwayat);
    }

    
}