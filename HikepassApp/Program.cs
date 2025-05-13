using HikepassApp;
using HikepassLibrary.Model;
using HikepassLibrary.Service;
using System.Text.Json;
using System.Text;
using System.Xml.Schema;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
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

        string baseUrl = "http://localhost:5226/api/reservasi";

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
                        await CreateReservasi(baseUrl);
                        break;

                    case "2":
                        await GetAllReservasi(baseUrl);
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
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.\n");
                        break;
                }
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }

            

            
        }





        //// Membaca data dari file
        //var riwayat = RiwayatPendakianConfig.ReadFileConfig();

        //Console.WriteLine("=== Data Riwayat Pendakian (Sebelum Pajak) ===");
        //TampilkanData(riwayat);

        //// Menambahkan pajak 10%
        //riwayat.total_pembayaran = (int)(riwayat.total_pembayaran * 1.10);

        //Console.WriteLine("\n=== Data Riwayat Pendakian (Setelah Pajak 10%) ===");
        //TampilkanData(riwayat);

        //// Simpan kembali data yang telah dimodifikasi
        //RiwayatPendakianConfig.WriteFileConfig(riwayat);
    }

    static void TampilkanData(RiwayatPendakianConfig data)
    {
        Console.WriteLine($"Tanggal Reservasi         : {data.tanggal_reservasi}");
        Console.WriteLine($"Jumlah Reservasi          : {data.jumlah_reservasi}");
        Console.WriteLine($"Jalur Pendakian           : {data.jalur_pendakian}");
        Console.WriteLine($"Tanggal Pembayaran        : {data.tanggal_pembayaran}");
        Console.WriteLine($"Metode Pembayaran         : {data.metode_pembayaran}");
        Console.WriteLine($"Total Pembayaran          : Rp{data.total_pembayaran}");
        Console.WriteLine($"Tanggal Check-In          : {data.tanggal_checkin}");
        Console.WriteLine($"Laporan Sampah Check-In   : {data.laporan_sampah_checkin}");
        Console.WriteLine($"Tanggal Check-Out         : {data.tanggal_checkout}");
        Console.WriteLine($"Laporan Sampah Check-Out  : {data.laporan_sampah_checkout}");
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


    static async Task CreateReservasi(string baseUrl)
    {
        Console.Write("Enter Nama Pendaki: ");
        string namaPendaki = Console.ReadLine();
        Console.Write("Enter Nomor HP: ");
        string nomorHP = Console.ReadLine();
        Console.Write("Enter Jumlah Pendaki: ");
        int jumlahPendaki = int.Parse(Console.ReadLine());
        Random random = new Random();
        int id = random.Next(100, 999);

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
        id = random.Next(100, 999);

        var newReservasi = new
        {
            Id = id,
            DataPendaki = dataPendaki,
            Jalur = jalur,
            TanggalPendakian = tanggalPendakian,
            StatusPembayaran = statusPembayaran,
            Keterangan = keterangan
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
                    Console.WriteLine("Reservasi created successfully!");
                }
                else
                {
                    Console.WriteLine($"Failed to create reservasi. Status code: {response.StatusCode}");
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


    static async Task GetReservasiById(string baseUrl)
    {
        Console.Write("Enter Reservasi ID: ");
        int id = int.Parse(Console.ReadLine());
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{baseUrl}/{id}");
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
    
}
