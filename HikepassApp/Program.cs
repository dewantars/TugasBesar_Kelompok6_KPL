using System.Text.Json;
using System.Text;
using System.Xml.Schema;

using HikepassApp;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

using System.Threading.Tasks;
using HikepassLibrary.Controller;
using HikepassApp.Controller;

class Program
{
    public static async Task Main(string[] args)
    {
        
        // Inisialisasi service
        var pendakiService = new PendakiService();
        var pengelolaService = new PengelolaService();
        var tiketService = new TiketService();
        var monitoringService = new MonitoringService();

        // Inisialisasi Controller
        var authController = new AuthController(new AuthService());
        var pendakiController = new PendakiController(tiketService, monitoringService);
        var tiketController = new TiketController(tiketService, monitoringService);
        var monitoringPendakiController = new MonitoringPendaki(monitoringService);

        // Menambahkan data awal untuk testing
        pendakiService.AddPendaki(new Pendaki { Id = 1, FullName = "John Doe", Username = "john.doe", Password = "12345", Email = "john.doe@example.com" });
        pengelolaService.AddPengelola(new Pengelola { Id = 2, FullName = "Jane Smith", Username = "admin", Password = "admin123", Email = "admin@example.com" });

        // Variabel login
        Pendaki loggedInPendaki = null;
        Pengelola loggedInPengelola = null;

        // Menu utama aplikasi
        string username, password;
        bool isLoggedIn = false;

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
                

                bool isValid = pengelolaService.ValidatePengelola(username, password,"Pengelola");
                if (isValid)
                {
                    loggedInPengelola = pengelolaService.GetPengelolaByUsername(username);
                    Console.WriteLine($"Selamat datang, {loggedInPengelola.FullName}!");
                    isLoggedIn = true;
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

                bool isValid = pendakiService.ValidasiPendaki(username, password,"Pendaki");
                if (isValid)
                {
                    loggedInPendaki = pendakiService.GetPendakiByUsername(username);
                    Console.WriteLine($"Selamat datang, {loggedInPendaki.FullName}!");
                    isLoggedIn = true;
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
                Pendaki pendaki;
                Menu.menuUser();
                string pilihan = Console.ReadLine();
                Console.WriteLine();
                switch (pilihan)
                {
                    case "1":
                        await CreateReservasi("http://localhost:5226/api/reservasi",pendaki);
                        break;

                    case "2":
                        Menu.menuTiketSaya();
                        int pilihanTiket = int.Parse(Console.ReadLine());
                        switch (pilihanTiket)
                        {
                            case 1:
                                Console.WriteLine("Lihat Tiket:");
                                await GetAllReservasi("http://localhost:5226/api/reservasi");
                                break;
                            case 2:
                                Console.WriteLine("Bayar Tiket:");
                                await BayarTiket("http://localhost:5226/api/reservasi");
                                break;
                            case 3:
                                Console.WriteLine("Reschedule Tiket:");
                                await GetAllReservasi("http://localhost:5226/api/reservasi");
                                await UpdateReservasi("http://localhost:5226/api/reservasi");
                                break;
                            case 4:
                                Console.WriteLine("Batalkan Tiket:");
                                await GetAllReservasi("http://localhost:5226/api/reservasi");
                                await DeleteReservasi("http://localhost:5226/api/reservasi");
                                break;
                            case 5:
                                Console.WriteLine("Lihat Riwayat Pendakian:");
                                await GetAllReservasi("http://localhost:5226/api/reservasi");
                                break;
                            case 6:
                                Console.WriteLine("Check-in Tiket:");
                                await CheckInTiket("http://localhost:5226/api/reservasi");
                                break;
                            case 7:
                                Console.WriteLine("Check-out Tiket:");
                                await CheckOutTiket("http://localhost:5226/api/reservasi");
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

        if (metodePembayaran == "1")
        {
            // Pembayaran menggunakan QRIS
            var tiket = new { Id = idTiket, StatusPembayaran = "Lunas" };
            using (var client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(tiket);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{baseUrl}/{idTiket}/bayar", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pembayaran berhasil menggunakan QRIS.");
                }
                else
                {
                    Console.WriteLine("Pembayaran gagal.");
                }
            }
        }
        else if (metodePembayaran == "2")
        {
            // Pembayaran di tempat
            var tiket = new { Id = idTiket, StatusPembayaran = "Lunas" };
            using (var client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(tiket);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{baseUrl}/{idTiket}/bayar", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Pembayaran berhasil dilakukan di tempat.");
                }
                else
                {
                    Console.WriteLine("Pembayaran gagal.");
                }
            }
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid.");
        }
    }

    static async Task GetAllReservasi(string baseUrl)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Reservasi: ");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"Failed to get reservasi. Status code: {response.StatusCode}");
            }
        }
    }

    static async Task CreateReservasi(string baseUrl, Pendaki pendaki)
    {
        Console.WriteLine("Pilih jalur pendakian:");
        Console.WriteLine("1. Panorama");
        Console.WriteLine("2. Cinyiruan");
        Console.Write(">> ");
        string jalurChoice = Console.ReadLine();
        Tiket.JalurPendakian jalur;
        

        if (jalurChoice == "1")
        {
            jalur = Tiket.JalurPendakian.Panorama;
        }
        else if (jalurChoice == "2")
        {
            jalur = Tiket.JalurPendakian.Cinyiruan;
        }
        else
        {
            Console.WriteLine("Pilihan jalur tidak valid. Reservasi dibatalkan.");
            return;
        }
        string jalurEnum = jalur.ToString();

        // Input untuk tanggal pendakian
        Console.Write("Masukkan tanggal pendakian (format: YYYY-MM-DD): ");
        DateTime tanggalPendakian;
        while (!DateTime.TryParse(Console.ReadLine(), out tanggalPendakian))
        {
            Console.WriteLine("Tanggal tidak valid. Masukkan ulang (format: YYYY-MM-DD): ");
        }

        // Input jumlah pendaki
        Console.Write("Masukkan jumlah pendaki: ");
        int jumlahPendaki;
        while (!int.TryParse(Console.ReadLine(), out jumlahPendaki) || jumlahPendaki <= 0)
        {
            Console.WriteLine("Jumlah pendaki tidak valid. Masukkan angka lebih dari 0: ");
        }

        // Daftar pendaki
        Dictionary<string, string> daftarPendaki = new Dictionary<string, string>();
        daftarPendaki.Add(pendaki.FullName, $"NIK: {pendaki.Nik}, Kontak: {pendaki.Kontak}, Usia: {pendaki.Usia}");

        // Input data pendaki tambahan
        for (int i = 1; i < jumlahPendaki; i++)
        {
            Console.WriteLine($"Masukkan data pendaki ke-{i + 1}:");
            Console.Write("Nama: ");
            string namaRekan = Console.ReadLine();
            Console.Write("NIK: ");
            string nikRekan = Console.ReadLine();
            Console.Write("Kontak: ");
            string kontakRekan = Console.ReadLine();
            Console.Write("Usia: ");
            string usiaRekan = Console.ReadLine();
            daftarPendaki.Add(namaRekan, $"NIK: {nikRekan}, Kontak: {kontakRekan}, Usia: {usiaRekan}");
        }

        // Menentukan ID tiket
        Random random = new Random();
        int id = random.Next(100, 999);

        // Menyiapkan objek tiket untuk dikirim
        Tiket tiket = new Tiket(id, tanggalPendakian, jalurEnum, jumlahPendaki)
        {
            DaftarPendaki = daftarPendaki,
            Status = StatusTiket.BelumDibayar,
            StatusPembayaran = false
        };

        // Menambahkan tiket ke dalam list reservasi
       tiketService.AddTiket(tiket);

        // Menampilkan konfirmasi
        Console.WriteLine("Reservasi berhasil.");

        // Pilih metode pembayaran
        Console.WriteLine("Pilih metode pembayaran:");
        Console.WriteLine("1. Bayar langsung");
        Console.WriteLine("2. Bayar di tempat");
        Console.Write(">> ");
        string bayarChoice = Console.ReadLine();

        if (bayarChoice == "1")
        {
            Console.WriteLine("Metode pembayaran pakai QRIS, lanjut?");
            Console.WriteLine("1. Ya");
            Console.WriteLine("2. Tidak");
            Console.Write(">> ");
            string qrisChoice = Console.ReadLine();

            if (qrisChoice == "1")
            {
                tiket.Status = StatusTiket.Dibayar;
                Console.WriteLine("Pembayaran berhasil. Tiket sudah dibayar.");
                tiket.StatusPembayaran = true;
                tiket.ShowTiketInfo();
            }
            else
            {
                Console.WriteLine("Kembali ke menu sebelumnya.");
            }
        }
        else if (bayarChoice == "2")
        {
            tiket.Status = StatusTiket.BelumDibayar;
            Console.WriteLine("Reservasi berhasil, harap bayar di tempat.");
            tiket.ShowTiketInfo();
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid.");
        }

        // Proses pengiriman data reservasi melalui HTTP (API)
        var newReservasi = new
        {
            Id = id,
            DataPendaki = daftarPendaki,
            Jalur = jalur,
            TanggalPendakian = tanggalPendakian.ToString("yyyy-MM-dd"),
            StatusPembayaran = "Belum Lunas",
            Status = "BelumDibayar",
            Keterangan = "Tidak ada keterangan"
        };

        try
        {
            using (var client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(newReservasi);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(baseUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reservasi berhasil dibuat di server!");
                }
                else
                {
                    Console.WriteLine($"Failed to create reservasi on the server. Status code: {response.StatusCode}");
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error details: {errorContent}");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }


    static async Task UpdateReservasi(string baseUrl)
    {
        Console.Write("Enter Reservasi ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Nama Pendaki: ");
        string namaPendaki = Console.ReadLine();
        Console.Write("Enter Nomor HP: ");
        string nomorHP = Console.ReadLine();
        Console.Write("Enter Jumlah Pendaki: ");
        int jumlahPendaki = int.Parse(Console.ReadLine());

        var dataPendaki = new
        {
            Id = id,
            NamaPendaki = namaPendaki,
            NomorHP = nomorHP,
            JumlahPendaki = jumlahPendaki
        };

        Console.Write("Enter Jalur Pendakian (Cinyiruan/Panorama): ");
        int jalur = int.Parse(Console.ReadLine());
        Console.Write("Enter Tanggal Pendakian (yyyy-MM-dd): ");
        string tanggalPendakian = Console.ReadLine();
        Console.Write("Enter Status Pembayaran: ");
        string statusPembayaran = Console.ReadLine();
        Console.Write("Enter Keterangan: ");
        string keterangan = Console.ReadLine();

        var updatedReservasi = new
        {
            Id = id,
            DataPendaki = dataPendaki,
            Jalur = jalur,
            TanggalPendakian = tanggalPendakian,
            StatusPembayaran = statusPembayaran,
            Keterangan = keterangan
        };

        using (var client = new HttpClient())
        {
            var json = JsonSerializer.Serialize(updatedReservasi);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Reservasi updated successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to update reservasi. Status code: {response.StatusCode}");
            }
        }
    }

    static async Task DeleteReservasi(string baseUrl)
    {
        Console.Write("Enter Reservasi ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        using (var client = new HttpClient())
        {
            var response = await client.DeleteAsync($"{baseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Reservasi deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Failed to delete reservasi. Status code: {response.StatusCode}");
            }
        }
    }
}
