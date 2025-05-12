using HikepassApp;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using HikepassLibrary.Service;


namespace HikepassApp
{
    class Program
    {
        static AuthController _authController;
        static TiketController _tiketController;
        static MonitoringPendaki _monitoringPendaki;
        static PendakiService _pendakiService = new PendakiService();

        static void Main(string[] args)
        {
            AuthService authService = new AuthService();
            TiketService tiketService = new TiketService();
            MonitoringService monitoringService = new MonitoringService();

            _authController = new AuthController(authService);
            _tiketController = new TiketController(tiketService, monitoringService);
            _monitoringPendaki = new MonitoringPendaki(monitoringService);

            // Tambahkan pendaki baru
            _pendakiService.TambahPendaki(new Pendaki
            {
                Id = 3,
                Nama = "Budi Gunawan",
                Kontak = "budi123",
                Alamat = "Bandung",
                Nik = "3201010101010001",
                Usia = 30
            });

            // Tambahkan tiket dummy
            var tiketDummy = new Tiket
            {
                Id = 1,
                Tanggal = DateTime.Today,
                StatusPembayaran = true,
                JumlahPendaki = 2,
                Kontak = "budi123",
                DaftarPendaki = new Dictionary<string, string>
            {
                { "3201010101010001", "Budi Gunawan" },
                { "3201010101010002", "Ani Lestari" }
            },
                IsCheckedIn = false
            };
            tiketService.TambahTiket(tiketDummy);

            while (true)
            {
                if (_authController.GetCurrentUser() == null)
                {
                    TampilkanMenuLogin();
                }
                else if (_authController.GetCurrentUser().Role == "pendaki")
                {
                    TampilkanMenuPendaki();
                }
                else if (_authController.GetCurrentUser().Role == "pengelola")
                {
                    TampilkanMenuPengelola();
                }
            }
        }

        static void TampilkanMenuLogin()
        {
            Console.WriteLine("\n=== Menu Login ===");
            Console.WriteLine("1. Daftar");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Ubah Password");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            
            switch (pilihan)
            {
                case "1":
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Role (pendaki/pengelola): ");
                    string role = Console.ReadLine();
                    _authController.Daftar(username, password);
                    break;
                case "2":
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();
                    _authController.Login(username, password);
                    break;
                case "3":
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    Console.Write("Password lama: ");
                    string oldPassword = Console.ReadLine();
                    Console.Write("Password baru: ");
                    string newPassword = Console.ReadLine();
                    _authController.UbahPassword(newPassword);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
            }
        }

        static void TampilkanMenuPendaki()
        {
            Console.WriteLine("\n=== Menu Pendaki ===");
            Console.WriteLine("1. Informasi (belum diimplementasikan)");
            Console.WriteLine("2. Reservasi (belum diimplementasikan)");
            Console.WriteLine("3. Tiket Saya");
            Console.WriteLine("4. Lapor (belum diimplementasikan)");
            Console.WriteLine("5. Logout");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();
            

            switch (pilihan)
            {
                case "3":
                    Console.Write("Masukkan ID tiket: ");
                    string nokontak = Console.ReadLine();
                    _tiketController.GetTiketSaya(nokontak);



                    break;
                case "5":
                    _authController.Logout();
                    break;
                    // ... pilihan lainnya
            }
        }

        static void MenuTiketSaya()
        {
            User currentUser = _authController.GetCurrentUser();
            if (currentUser != null && currentUser.Role == "pendaki")
            {
                // Asumsi kita punya cara mendapatkan informasi Pendaki berdasarkan User
                Pendaki pendaki = _pendakiService.GetPendakiByUsername(currentUser.Username);

                if (pendaki != null)
                {
                    List<Tiket> daftarTiket = _tiketController.GetTiketSaya(pendaki.Kontak);

                    if (daftarTiket.Any())
                    {
                        Console.WriteLine("\n=== Tiket Saya ===");
                        foreach (var tiket in daftarTiket)
                        {
                            Console.WriteLine($"ID: {tiket.Id}, Tanggal: {tiket.Tanggal.ToShortDateString()}, Status Pembayaran: {(tiket.StatusPembayaran ? "Sudah Dibayar" : "Belum Dibayar")}, Status Check-in: {(tiket.IsCheckedIn ? "Sudah Check-in" : "Belum Check-in")}");
                        }

                        Console.Write("Masukkan ID Tiket untuk Check-in/Check-out (atau ketik 'kembali'): ");
                        string inputId = Console.ReadLine();
                        if (inputId.ToLower() != "kembali" && int.TryParse(inputId, out int idTiket))
                        {
                            Tiket tiketDipilih = _tiketController.GetTiketById(idTiket);
                            if (tiketDipilih != null && daftarTiket.Contains(tiketDipilih))
                            {
                                if (!tiketDipilih.IsCheckedIn)
                                {
                                    ProsesCheckin(tiketDipilih);
                                }
                                else
                                {
                                    ProsesCheckout(tiketDipilih);
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID Tiket tidak valid atau tidak ditemukan dalam daftar tiket Anda.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Anda belum memiliki tiket.");
                    }
                }
                else
                {
                    Console.WriteLine("Informasi pendaki tidak ditemukan untuk pengguna ini.");
                }
            }
            else if (currentUser != null && currentUser.Role != "pendaki")
            {
                Console.WriteLine("Menu ini hanya tersedia untuk pengguna dengan peran Pendaki.");
            }
            else
            {
                Console.WriteLine("Anda belum login.");
            }
        }

        static void ProsesCheckin(Tiket tiket)
        {
            if (!tiket.StatusPembayaran)
            {
                Console.WriteLine("Tiket belum dibayar, tidak bisa check-in.");
                return;
            }

            Console.WriteLine("\n=== Check-in Tiket ID: " + tiket.Id + " ===");
            List<string> barangBawaan = new List<string>();
            string inputBarang;
            Console.WriteLine("Masukkan barang bawaan (ketik 'selesai' jika selesai):");
            while ((inputBarang = Console.ReadLine().ToLower()) != "selesai")
            {
                barangBawaan.Add(inputBarang);
            }

            if (_tiketController.CheckinTiket(tiket, barangBawaan))
            {
                Console.WriteLine("Check-in berhasil.");
            }
        }

        static void ProsesCheckout(Tiket tiket)
        {
            if (!tiket.IsCheckedIn)
            {
                Console.WriteLine("Tiket belum di check-in, tidak bisa check-out.");
                return;
            }

            Console.WriteLine("\n=== Check-out Tiket ID: " + tiket.Id + " ===");
            List<string> barangBawaanKembali = new List<string>();
            string inputBarang;
            Console.WriteLine("Masukkan barang bawaan yang dibawa kembali (ketik 'selesai' jika selesai):");
            while ((inputBarang = Console.ReadLine().ToLower()) != "selesai")
            {
                barangBawaanKembali.Add(inputBarang);
            }

            if (_tiketController.CheckoutTiket(tiket, barangBawaanKembali))
            {
                Console.WriteLine("Check-out berhasil.");
            }
        }

        static void TampilkanMenuPengelola()
        {
            Console.WriteLine("\n=== Menu Pengelola ===");
            Console.WriteLine("1. Monitoring");
            Console.WriteLine("2. Lihat Laporan (belum diimplementasikan)");
            Console.WriteLine("3. Penetapan Aturan (belum diimplementasikan)");
            Console.WriteLine("4. Riwayat Pendakian (belum diimplementasikan)");
            Console.WriteLine("5. Logout");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    TampilkanMonitoring();
                    break;
                case "5":
                    _authController.Logout();
                    break;
                    // ... pilihan lainnya
            }
        }

        static void TampilkanMonitoring()
        {
            Console.WriteLine("\n=== Daftar Pendaki Aktif ===");
            List<MonitoringEntry> daftarPendakiAktif = _monitoringPendaki.GetAllMonitoring();
            if (daftarPendakiAktif.Any())
            {
                Console.WriteLine("ID Tiket\tNIK Pendaki\tNama Pendaki\tWaktu Check-in");
                foreach (var entry in daftarPendakiAktif)
                {
                    Console.WriteLine($"{entry.TiketId}\t\t{entry.NikPendaki}\t\t{entry.NamaPendaki}\t\t{entry.CheckinTime}");
                }
            }
            else
            {
                Console.WriteLine("Tidak ada pendaki aktif saat ini.");
            }
        }
    }
}