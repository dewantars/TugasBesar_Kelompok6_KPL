using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;
using static HikepassLibrary.Model.Tiket;

namespace HikepassApp.Controller
{
    public class TiketController
    {
        private readonly TiketService _tiketService;
        private readonly MonitoringService _monitoringService;
        private static List<Tiket> reservasiList = new List<Tiket>();

        public TiketController(){}
        public TiketController(TiketService tiketService, MonitoringService monitoringService)
        {
            _tiketService = tiketService;
            _monitoringService = monitoringService;
        }

        public void KonfirmasiTiket(Pendaki pendaki,MonitoringService monitoring)
        {
            Console.Write("Masukkan ID Tiket yang ingin di Check-in/Check-out (0 untuk kembali): ");
            if (int.TryParse(Console.ReadLine(), out int idTiket))
            {
                if (idTiket == 0)
                {
                    return; 
                }

                Tiket selectedTiket = reservasiList.FirstOrDefault(t => t.Id == idTiket);
                if (selectedTiket != null)
                {
                    if (selectedTiket.Status == StatusTiket.Dibayar) 
                    {
                        Console.Write("Apakah Anda ingin Check-in? (y/n): ");
                        string jawaban = Console.ReadLine();
                        if (jawaban.ToLower() == "y")
                        {
                            selectedTiket.Status = StatusTiket.Checkin;
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
                            monitoring.AddToMonitoring(pendaki);
                            Console.WriteLine("Check-in berhasil!");
                            
                        }
                    }
                    else if (selectedTiket.Status == StatusTiket.Checkin)
                    {
                        Console.Write("Apakah Anda ingin Check-out? (y/n): ");
                        string jawab = Console.ReadLine();
                        if (jawab.ToLower() == "y")
                        {
                            selectedTiket.Status = StatusTiket.Checkout;
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
                            monitoring.RemoveFromMonitoring(pendaki);
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
                    else
                    {
                        Console.WriteLine("Tiket belum dibayar. Silakan lakukan pembayaran terlebih dahulu.");
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
        

        
    }
}

