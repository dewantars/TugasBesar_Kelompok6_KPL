using HikepassApp;
using System;

using HikepassLibrary.Model;
using HikepassLibrary.Service;
using HikepassLibrary.Controller;
using System.Text.Json;
using System.Text;
using System.Xml.Schema;

using HikepassApp;
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
        var tiketCtrl = new TiketController();
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
                            Console.WriteLine("Monitoring Pendaki");
                            monitoring.ShowMonitoring();
                                break;

                            case "2":
                                Console.WriteLine("Edit Informasi:");
                                informasiService.TambahAtauEditInformasi();
                            break;

                            case "3":
                                Console.WriteLine("Lihat Laporan:");
                                LaporanService.PrintLaporan();
                            break;
                            case "4":
                                Console.WriteLine("Lihat Riwayat Pendakian:");
                                riwayat.SaveRiwayat();
                                riwayat.ShowRiwayat();
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
                                        Console.WriteLine("Reservasi Tiket:");
                                        await ControllerReservasi.CreateReservasi(baseUrl, loggedInPendaki);
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
                                        Console.WriteLine("Lihat Tiket:");
                                        tiketCtrl.TampilkanTiket();
                                    break;
                                    case 2:
                                        Console.WriteLine("Bayar Tiket:");
                                        tiketCtrl.BayarTiket(tiket);
                                        break;
                                    case 3:
                                        Console.WriteLine("Reschedule Tiket:");
                                        tiketCtrl.RescheduleTiket();
                                    break;
                                    case 4:
                                        Console.WriteLine("Batalkan Tiket:");
                                        tiketCtrl.HapusTiket();
                                    break;
                                    case 5:
                                        Console.WriteLine("Lihat Riwayat Pendakian:");
                                        riwayat.ShowRiwayat();
                                    break;
                                    case 6:
                                        Console.WriteLine("Check-in/Check-out Tiket:");
                                        tiketCtrl.KonfirmasiTiket(loggedInPendaki, monitoring);
                                        break;
                                    case 7:
                                        Console.WriteLine("Selesaikan Pendakian");
                                        tiketCtrl.Selesaikan(tiket);
                                        break;
                                    default:
                                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                                        break;
                                }
                                break;

                            case "3":
                                Console.WriteLine("Lihat Informasi:");
                                informasiService.TampilkanInformasi(); 
                            break;

                            case "4":
                                Console.WriteLine("Laporan:");
                                LaporanService.inputLaporan();
                            break;
                            
                            case "5":
                                Console.WriteLine("Edit Profil:");
                                // pendakiController.EditProfil(loggedInPendaki);  // Implement profile editing logic here
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


//    static async Task CheckInTiket(string baseUrl)
//    {
//        Console.Write("Masukkan ID Tiket untuk Check-in: ");
//        int idTiket = int.Parse(Console.ReadLine());

//        // Proses Check-in
//        var tiket = new { Id = idTiket, Status = "Checkin" };
//        using (var client = new HttpClient())
//        {
//            var json = JsonSerializer.Serialize(tiket);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");
//            var response = await client.PutAsync($"{baseUrl}/{idTiket}/checkin", content);
//            if (response.IsSuccessStatusCode)
//            {
//                Console.WriteLine("Tiket berhasil check-in.");
//            }
//            else
//            {
//                Console.WriteLine("Gagal check-in tiket.");
//            }
//        }
//    }

//    static async Task CheckOutTiket(string baseUrl)
//    {
//        Console.Write("Masukkan ID Tiket untuk Check-out: ");
//        int idTiket = int.Parse(Console.ReadLine());

//        // Proses Check-out
//        var tiket = new { Id = idTiket, Status = "Checkout" };
//        using (var client = new HttpClient())
//        {
//            var json = JsonSerializer.Serialize(tiket);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");
//            var response = await client.PutAsync($"{baseUrl}/{idTiket}/checkout", content);
//            if (response.IsSuccessStatusCode)
//            {
//                Console.WriteLine("Tiket berhasil check-out.");
//            }
//            else
//            {
//                Console.WriteLine("Gagal check-out tiket.");
//            }
//        }
//    }
//    static async Task BayarTiket(string baseUrl)
//    {

//        var payment = new Payment();

//        Console.WriteLine("== SIMULASI PEMBAYARAN ==\n");
//        Console.Write("Apakah pembayaran berhasil? (y/n): ");
//        var input = Console.ReadLine();

//        bool isSuccess = input?.ToLower() == "y";

//        payment.ProcessPayment(isSuccess);

//        Console.WriteLine("\nStatus Akhir:");
//        switch (payment.StateMachine.CurrentState)
//        {
//            case PaymentState.NotPaid:
//                Console.WriteLine("Status: Belum Bayar");
//                break;
//            case PaymentState.WaitingConfirmation:
//                Console.WriteLine("Status: Menunggu Konfirmasi");
//                break;
//            case PaymentState.Paid:
//                Console.WriteLine("Status: Sudah Bayar");
//                break;
//            case PaymentState.Failed:
//                Console.WriteLine("Status: Gagal");
//                break;
//            default:
//                Console.WriteLine("Status: Tidak diketahui");
//                break;
//        }

//        Console.WriteLine("\n== SELESAI ==\n");
//    }

//}

//        Console.Write("Masukkan ID Tiket yang ingin dibayar: ");
//        int idTiket = int.Parse(Console.ReadLine());

//        // Simulasi pembayaran
//        Console.WriteLine("Pilih metode pembayaran:");
//        Console.WriteLine("1. QRIS");
//        Console.WriteLine("2. Bayar di Tempat");
//        string metodePembayaran = Console.ReadLine();


//        //// Membaca data dari file
        
//        //Console.WriteLine("=== Data Riwayat Pendakian (Sebelum Pajak) ===");


//        //// Menambahkan pajak 10%
//        //riwayat.total_pembayaran = (int)(riwayat.total_pembayaran * 1.10);

//        //Console.WriteLine("\n=== Data Riwayat Pendakian (Setelah Pajak 10%) ===");
//        //TampilkanData(riwayat);

//        //// Simpan kembali data yang telah dimodifikasi
//        //RiwayatPendakianConfig.WriteFileConfig(riwayat);
//    }

    
}
