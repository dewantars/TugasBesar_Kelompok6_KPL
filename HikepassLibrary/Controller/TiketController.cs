using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using HikepassLibrary.Service;
using static HikepassLibrary.Model.Tiket;
using HikepassApp;
using System.Text.Json;

namespace HikepassLibrary.Controller
{
    public class TiketController
    {
        private readonly TiketService _tiketService;
        private readonly MonitoringService _monitoringService;
        private readonly MonitoringController _monitoringController;

        public TiketController() { }
        public TiketController(TiketService tiketService, MonitoringService monitoringService)
        {
            _tiketService = tiketService;
            _monitoringService = monitoringService;
        }
        // Menampilkan Daftar Tiket yang sudah direservasi
        public void TampilkanDaftarTiket()
        {
            if (ControllerReservasi.reservasiList.Count == 0)
            {
                Console.WriteLine("Tidak ada tiket yang tersedia.");
                return;
            }

            Console.WriteLine("------------------------- Daftar Tiket --------------------------");
            foreach (var tiket in ControllerReservasi.reservasiList)
            {
                tiket.ShowTiketInfo(); 
            }
        }



        public void Selesaikan(Tiket tiket)
        {
            TampilkanDaftarTiket();
            Console.WriteLine(" ");
            Console.Write("Masukkan ID Tiket yang ingin di selesaikan: ");
            if (int.TryParse(Console.ReadLine(), out int idTiket))
            {
                if (idTiket == 0)
                {
                    return;
                }
                Tiket selectedTiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);
                if (selectedTiket != null)
                {
                    if (selectedTiket.Status == StatusTiket.Checkout)
                    {
                        Console.Write("Apakah Anda ingin menyelesaikan pendakian ini (y/n): ");
                        string jawaban = Console.ReadLine();
                        if (jawaban.ToLower() == "y")
                        {
                            
                            selectedTiket.IsCheckedIn = false;
                            ControllerReservasi.Selesaikan("http://localhost:5226/api/reservasi", idTiket, true);
                            selectedTiket.Status = StatusTiket.Selesai;
                            Console.WriteLine("\nPendakian Berakhir!");

                            //RiwayatPendakian.riwayatList.Add(selectedTiket);
                        }
                    }
                    else if (selectedTiket.Status == StatusTiket.BelumDibayar)
                    {
                        Console.WriteLine("Bayar tiket terlebih dahulu.");
                    }
                    else if (selectedTiket.Status == StatusTiket.Dibayar)
                    {
                        Console.Write("Harus Check-In terlebih dahulu.");

                    }
                    else if (selectedTiket.Status == StatusTiket.Checkin)
                    {
                        Console.WriteLine("Harus Check-Out terlebih dahulu.");
                    }
                    else
                    {
                        Console.WriteLine("Tiket tidak Valid.");
                    }
                }
                else
                {
                    Console.WriteLine("ID Tiket tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("ID Tiket tidak valid.");
            }
        }

        public void BayarTiket(Tiket tiket)
        {
            TampilkanDaftarTiket();
            Console.WriteLine(" ");
            Console.Write("Masukkan ID Tiket yang ingin di bayar: ");
            if (int.TryParse(Console.ReadLine(), out int idTiket))
            {
                if (idTiket == 0)
                {
                    return;
                }
                Tiket selectedTiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);

                if (selectedTiket != null)
                {
                    if (selectedTiket.Status == StatusTiket.BelumDibayar)
                    {
                        Console.Write("Apakah Anda ingin melanjutkan pembayaran dengan qris? (y/n): ");
                        string jawaban = Console.ReadLine();
                        Console.WriteLine();
                        if (jawaban.ToLower() == "y")
                        {
                            
                            
                            ControllerReservasi.UpdatedPembayaran("http://localhost:5226/api/reservasi", idTiket);
                            selectedTiket.Status = StatusTiket.Dibayar;
                            selectedTiket.StatusPembayaran = true;
                            Console.WriteLine("Pembayaran berhasil!");

                            _monitoringService.AddToMonitoring(selectedTiket);

                        }
                    }
                    else if (selectedTiket.Status == StatusTiket.Dibayar)
                    {
                        Console.Write("Tiket ini sudah dibayar sebelumnya. ");
                        
                    }
                    else if (selectedTiket.Status == StatusTiket.Checkin)
                    {
                        Console.WriteLine("Tiket ini sudah Check-in sebelumnya.");
                    }
                    else if (selectedTiket.Status == StatusTiket.Checkout)
                    {
                        Console.WriteLine("Tiket ini sudah Check-out sebelumnya.");
                    }
                    else
                    {
                        Console.WriteLine("Tiket tidak Valid.");
                    }
                }
                else
                {
                    Console.WriteLine("ID Tiket tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("ID Tiket tidak valid.");
            }
        }
    
        
        public void KonfirmasiTiket(Pendaki pendaki, MonitoringController monitoring)
        {
            TampilkanDaftarTiket();
            Console.WriteLine(" ");
            Console.Write("Masukkan ID Tiket yang ingin di Check-in/Check-out (0 untuk kembali): ");
            if (int.TryParse(Console.ReadLine(), out int idTiket))
            {
                if (idTiket == 0)
                {
                    return; 
                }

                Tiket selectedTiket = ControllerReservasi.reservasiList.FirstOrDefault(t => t.Id == idTiket);
                if (selectedTiket != null)
                {
                    
                    if (selectedTiket.Status == StatusTiket.Dibayar) 
                    {
                        Console.Write("Apakah Anda ingin Check-in? (y/n): ");
                        string jawaban = Console.ReadLine();
                        if (jawaban.ToLower() == "y")
                        {
                           
                            Console.WriteLine("Barang yang dibawa: ");
                            string InputBarangBawaan;
                            while (true)  
                            {
                                Console.Write("Masukkan nama barang (atau ketik '0' atau 'selesai' untuk selesai): ");
                                InputBarangBawaan = Console.ReadLine();  

                                if (InputBarangBawaan.ToLower() == "selesai" || InputBarangBawaan == "0")
                                {
                                    break;
                                }

                                
                                if (string.IsNullOrWhiteSpace(InputBarangBawaan))
                                {
                                    selectedTiket.BarangBawaanSaatCheckin.Add("Barang kosong");  
                                    Console.WriteLine("Barang kosong ditambahkan.");
                                }
                                else
                                {
                                    selectedTiket.BarangBawaanSaatCheckin.Add(InputBarangBawaan);  
                                }
                            }
                            ControllerReservasi.UpdatedCheckInCheckOut("http://localhost:5226/api/reservasi", selectedTiket.Id);
                            selectedTiket.Status = StatusTiket.Checkin;
                            monitoring.AddPendakiToMonitoring(selectedTiket);
                            Console.WriteLine("Check-in berhasil!");
                        }
                    }
                    else if (selectedTiket.Status == StatusTiket.Checkin)
                    {
                        Console.Write("Apakah Anda ingin Check-out? (y/n): ");
                        string jawab = Console.ReadLine();
                        if (jawab.ToLower() == "y")
                        {

                            Console.WriteLine("Barang yang dibawa: ");
                            string InputBarangBawaan;
                            while (true)  
                            {
                                Console.Write("Masukkan nama barang (atau ketik '0' atau 'selesai' untuk selesai): ");
                                InputBarangBawaan = Console.ReadLine();  

                               
                                if (InputBarangBawaan.ToLower() == "selesai" || InputBarangBawaan == "0")
                                {
                                    break;
                                }

                               
                                if (string.IsNullOrWhiteSpace(InputBarangBawaan))
                                {
                                    selectedTiket.BarangBawaanSaatCheckout.Add("Barang kosong");  
                                    Console.WriteLine("Barang kosong ditambahkan.");
                                }
                                else
                                {
                                    selectedTiket.BarangBawaanSaatCheckout.Add(InputBarangBawaan);  
                                }
                            }
                            ControllerReservasi.UpdatedCheckInCheckOut("http://localhost:5226/api/reservasi", selectedTiket.Id);
                            selectedTiket.Status = StatusTiket.Checkout;
                            monitoring.RemovePendakiFromMonitoring(selectedTiket);
                            Console.WriteLine("Check-out berhasil!");
                        }
                        else
                        {
                            Console.WriteLine("Tiket ini sudah Check-in sebelumnya.");
                        }
                    }
                    else if (selectedTiket.Status == StatusTiket.Checkout)
                    {
                        Console.WriteLine("Tiket ini sudah Check-out sebelumnya.");
                    }
                    else if(selectedTiket.Status == StatusTiket.Dibayar || selectedTiket.Status == StatusTiket.BelumDibayar)
                    {
                        Console.WriteLine("Tiket sedang tidak di masa Check-out.");
                    }
                    else
                    {
                        Console.WriteLine("ID Tiket tidak valid.");
                    }
                }
                else
                {
                    Console.WriteLine("ID Tiket tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("ID Tiket tidak valid.");
            }
        }

        public async Task HapusTiketAsync(string baseUrl)
        {
            Console.Write("Masukkan ID tiket yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int idTiket))
            {
                await ControllerReservasi.DeleteTiket(baseUrl, idTiket);
            }
            else
            {
                Console.WriteLine("Input ID tidak valid.");
            }
        }

        // Meminta input ID dan tanggal baru lalu memanggil RescheduleTanggalTiket
        public async Task UbahTanggalTiketAsync(string baseUrl)
        {
            Console.Write("Masukkan ID tiket yang ingin diubah tanggalnya: ");
            if (!int.TryParse(Console.ReadLine(), out int idTiket))
            {
                Console.WriteLine("Input ID tidak valid.");
                return;
            }

            Console.Write("Masukkan tanggal baru (format YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime tanggalBaru))
            {
                Console.WriteLine("Format tanggal tidak valid.");
                return;
            }

            Console.WriteLine();
            await ControllerReservasi.RescheduleTanggalTiket(baseUrl, idTiket, tanggalBaru);
        }
    }
}

