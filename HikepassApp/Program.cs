using HikepassApp;
using System;

using HikepassLibrary.Model;
using HikepassLibrary.Service;
using HikepassLibrary.Controller;
using System.Text.Json;
using System.Text;
using System.Xml.Schema;
using System.Threading.Tasks;
using HikepassApp.Controller;

class Program
{
    public static string baseUrl = "http://localhost:5226/api/reservasi";
    public static async Task Main(string[] args)
    {

        // Inisialisasi layanan
        Pendaki loggedInPendaki = null;
        Pengelola loggedInPengelola = null;
        
        var pendakiService = new PendakiService();
        var pengelolaService = new PengelolaService();
        var tiketService = new TiketService();
        var monitoringService = new MonitoringService();
        var informasiService = new InformasiService();

        RiwayatPendakian riwayat = new RiwayatPendakian();

        // Inisialisasi Controller
        //var authController = new AuthController(new AuthService());
        var pendakiController = new PendakiController(tiketService, monitoringService);
        var tiketController = new TiketController(tiketService, monitoringService);
        var monitoringPendakiController = new MonitoringController(monitoringService);
        var tiketCtrl = new TiketController(tiketService, monitoringService);
        var monitoring = new MonitoringController(monitoringService);
        
        // Menambahkan data awal untuk testing
        pendakiService.AddPendaki(new Pendaki { Id = 1, FullName = "John Doe", Username = "user", Password = "user", Email = "john.doe@example.com" });
        pengelolaService.AddPengelola(new Pengelola { Id = 2, FullName = "Jane Smith", Username = "admin", Password = "admin123", Email = "admin@example.com" });

        var tiket = new Tiket();
        string username = null;
        string password = null;
        Pendaki pendaki;


        // Menu utama aplikasi
        bool running1 = true, running2 = true;
        while (running1)
        {
            Console.Clear();
            Menu.SwitchUser();
            int userType = int.Parse(Console.ReadLine());
            if (userType == 1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("----------- Masuk sebagai Pengelola -----------");
                while (loggedInPengelola == null)
                {
                    Console.Write("Masukkan Username: ");
                    username = Console.ReadLine();
                    Console.Write("Masukkan Password: ");
                    password = Console.ReadLine();


                    bool isValid = pengelolaService.ValidasiPengelola(username, password);
                    if (isValid)
                    {
                        loggedInPengelola = pengelolaService.GetPengelolaByUsername(username);
                        Console.WriteLine($"Selamat datang, {loggedInPengelola.FullName}!");
                        running2 = true;

                    }
                }
            }
            else if (userType == 2)
            {
                Console.WriteLine(" ");
                Console.WriteLine("------------ Masuk sebagai Pendaki ------------");
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
                        running2 = true;

                    }
                }
            }
            else
            {
                running1 = false;
            }

                while (running2)
                {
                    Console.Clear();
                    if (loggedInPengelola != null)
                    {
                        // Menu untuk Pengelola
                        Menu.menuAdmin();
                        string pilihan = Console.ReadLine();
                        Console.WriteLine();
                        switch (pilihan)
                        {
                            case "1":
                            Console.WriteLine("---------------------- Monitoring Pendaki -----------------------");
                            monitoringService.ShowMonitoring();

                            Console.WriteLine();
                            monitoring.HandleStatusUpdate();
                            Console.WriteLine("-----------------------------------------------------------------");


                            break;

                            case "2":
                                Console.WriteLine("-------------------- Edit Informasi Pendakian -------------------");
                                informasiService.TambahAtauEditInformasi();
                                Console.WriteLine("-----------------------------------------------------------------");
                            break;

                            case "3":
                                LaporanService.PrintLaporan();
                                Console.WriteLine("-----------------------------------------------------------------");
                            break;
                            case "4":
                                riwayat.SaveRiwayat();
                                riwayat.ShowRiwayat();
                                Console.WriteLine("-----------------------------------------------------------------");
                            break;
                            case "5":
                                Console.WriteLine("Terima kasih telah menggunakan Hikepass. Sampai jumpa!");
                                loggedInPengelola = null;
                                loggedInPendaki = null;
                                running2 = false;
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
                    // Menu untuk Pendaki
                    
                        Menu.menuUser();
                        string pilihan = Console.ReadLine();
                        Console.WriteLine();
                        switch (pilihan)
                        {
                            case "1":
                                Menu.DaftarTiket();
                                string lanjutkan = "";
                                while (lanjutkan.ToLower() != "y" && lanjutkan.ToLower() != "n")
                                {
                                    lanjutkan = Console.ReadLine();
                                    if (lanjutkan.ToLower() == "y")
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Reservasi Tiket:");
                                        await ControllerReservasi.CreateReservasi(baseUrl, loggedInPendaki);
                                        Console.WriteLine("-----------------------------------------------------------------");
                                }
                                    else if (lanjutkan.ToLower() == "n")
                                    {
                                        Console.WriteLine("Reservasi dibatalkan.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                                    }

                                }

                                break;

                            case "2":

                                Menu.menuTiketSaya();
                                int pilihanTiket = int.Parse(Console.ReadLine());
                                switch (pilihanTiket)
                                {
                                    case 1:
                                        Console.WriteLine();
                                        tiketCtrl.TampilkanDaftarTiket();
                                        Console.WriteLine("-----------------------------------------------------------------");
                                        break;
                                    case 2:
                                        Console.WriteLine();
                                        tiketCtrl.BayarTiket(tiket);
                                        Console.WriteLine("-----------------------------------------------------------------");
                                        break;
                                    case 3:
                                        Console.WriteLine();
                                        await tiketCtrl.UbahTanggalTiketAsync(baseUrl);
                                        Console.WriteLine("-----------------------------------------------------------------");
                                    break;
                                    case 4:
                                        Console.WriteLine();
                                        await tiketCtrl.HapusTiketAsync(baseUrl);
                                        Console.WriteLine("-----------------------------------------------------------------");
                                    break;
                                    case 5:
                                        Console.WriteLine();
                                        riwayat.ShowRiwayat();
                                        Console.WriteLine("-----------------------------------------------------------------");
                                    break;
                                    case 6:
                                        Console.WriteLine();
                                        tiketCtrl.KonfirmasiTiket(loggedInPendaki, monitoring);
                                        Console.WriteLine("-----------------------------------------------------------------");
                                        break;
                                    case 7:
                                        Console.WriteLine();
                                        tiketCtrl.Selesaikan(tiket);
                                        riwayat.SaveRiwayat();
                                        Console.WriteLine("-----------------------------------------------------------------");
                                        break;
                                    case 8:
                                        Console.WriteLine("Kembali ke menu utama");
                                        break;
                                    default:
                                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                                        break;
                                }
                                break;

                            case "3":
                                Console.WriteLine("--------------------------- Informasi ---------------------------");
                                informasiService.TampilkanInformasi();
                                Console.WriteLine("-----------------------------------------------------------------");
                            break;

                            case "4":
                                LaporanService.inputLaporan();
                                Console.WriteLine("-----------------------------------------------------------------");
                            break;
                            
                            case "5":
                                Console.WriteLine("Edit Profil:");
                            // pendakiController.EditProfil(loggedInPendaki);  // Implement profile editing logic here
                                Console.WriteLine("-----------------------------------------------------------------");
                            break;
                            case "6":
                                Console.WriteLine("Terima kasih telah menggunakan Hikepass. Sampai jumpa!");
                                loggedInPendaki = null;
                                loggedInPengelola = null;
                                running2 = false;
                                break;
                            default:
                                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                                break;
                        }
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                    }
                }
            
        }
    }
}
