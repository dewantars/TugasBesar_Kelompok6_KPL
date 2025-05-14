using HikepassApp;

class Program
{
    static void Main(string[] args)
    {
        // Membaca data dari file
        var riwayat = RiwayatPendakianConfig.ReadFileConfig();

        Console.WriteLine("=== Data Riwayat Pendakian (Sebelum Pajak) ===");
        TampilkanData(riwayat);

        // Menambahkan pajak 10%
        riwayat.total_pembayaran = (int)(riwayat.total_pembayaran * 1.10);

        Console.WriteLine("\n=== Data Riwayat Pendakian (Setelah Pajak 10%) ===");
        TampilkanData(riwayat);

        // Simpan kembali data yang telah dimodifikasi
        RiwayatPendakianConfig.WriteFileConfig(riwayat);
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
