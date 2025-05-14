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
    public static async Task Main(string[] args)
    {
        // TEST LAPORAN
        //Laporan<string> laporan = Laporan<string>.InputLaporan();
        //laporan.PrintLaporan();

        // Inisialisasi layanan
        Pendaki loggedInPendaki = null;
        Pengelola loggedInPengelola = null;
        var pendakiService = new PendakiService();
        var pengelolaService = new PengelolaService();
        var tiketService = new TiketService();
        var monitoringService = new MonitoringService();


        // Inisialisasi Controller
        var authController = new AuthController(new AuthService());
        var pendakiController = new PendakiController(tiketService, monitoringService);
        var tiketController = new TiketController(tiketService, monitoringService);
        var monitoringPendakiController = new MonitoringPendaki(monitoringService);
        var checktiket = new TiketController();

        // Menambahkan data awal untuk testing
        pendakiService.AddPendaki(new Pendaki { Id = 1, FullName = "John Doe", Username = "john.doe", Password = "12345", Email = "john.doe@example.com" });
        pengelolaService.AddPengelola(new Pengelola { Id = 2, FullName = "Jane Smith", Username = "admin", Password = "admin123", Email = "admin@example.com" });

        string baseUrl = "http://localhost:7108/api/reservasi";

      
        string username = null;
        string password = null;
        Pendaki pendaki;

        Console.WriteLine("=== Selamat Datang di Hikepass ===");
        Menu.SwitchUser();
        int userType = int.Parse(Console.ReadLine());

        // Proses login
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

        // Menu utama aplikasi
        bool running = true;
        while (running)
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
                        Console.WriteLine("Daftar Tiket Tersedia:");
                        // tiketController.LihatTiketTersedia();  // Uncomment if implemented
                        break;

                    case "2":
                        Console.WriteLine("Pemesanan Tiket:");
                        Console.Write("Masukkan ID Tiket yang ingin dipesan: ");
                        // tiketController.PesanTiket();  // Implement ticket ordering logic here
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
                // Menu untuk Pendaki
                
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
                                await ControllerReservasi.GetAllReservasi(baseUrl);
                                break;
                            case 2:
                                Console.WriteLine("Bayar Tiket:");
                                await BayarTiket("http://localhost:5226/api/reservasi");
                                break;
                            case 3:
                                Console.WriteLine("Reschedule Tiket:");
                                await ControllerReservasi.GetAllReservasi(baseUrl);
                                await ControllerReservasi.UpdateReservasi(baseUrl, loggedInPendaki);
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
                                Console.WriteLine("Check-in/Check-out Tiket:");
                                checktiket.KonfirmasiTiket(loggedInPendaki);
                                break;
                            
                                break;
                            default:
                                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Lihat Informasi:");
                        // tiketController.LihatInformasi();  // Implement info display logic here
                        break;

                    case "4":
                        Console.WriteLine("Edit Profil:");
                        // pendakiController.EditProfil(loggedInPendaki);  // Implement profile editing logic here
                        break;

                    case "5":
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
        }
    }


    static async Task CheckInTiket(string baseUrl)
    {
        Console.Write("Masukkan ID Tiket untuk Check-in: ");
        int idTiket = int.Parse(Console.ReadLine());

        // Proses Check-in
        var tiket = new { Id = idTiket, Status = "Checkin" };
        using (var client = new HttpClient())
        {
            var json = JsonSerializer.Serialize(tiket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/{idTiket}/checkin", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Tiket berhasil check-in.");
            }
            else
            {
                Console.WriteLine("Gagal check-in tiket.");
            }
        }
    }

    static async Task CheckOutTiket(string baseUrl)
    {
        Console.Write("Masukkan ID Tiket untuk Check-out: ");
        int idTiket = int.Parse(Console.ReadLine());

        // Proses Check-out
        var tiket = new { Id = idTiket, Status = "Checkout" };
        using (var client = new HttpClient())
        {
            var json = JsonSerializer.Serialize(tiket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/{idTiket}/checkout", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Tiket berhasil check-out.");
            }
            else
            {
                Console.WriteLine("Gagal check-out tiket.");
            }
        }
    }
    static async Task BayarTiket(string baseUrl)
    {
        Console.Write("Masukkan ID Tiket yang ingin dibayar: ");
        int idTiket = int.Parse(Console.ReadLine());

        // Simulasi pembayaran
        Console.WriteLine("Pilih metode pembayaran:");
        Console.WriteLine("1. QRIS");
        Console.WriteLine("2. Bayar di Tempat");
        string metodePembayaran = Console.ReadLine();


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