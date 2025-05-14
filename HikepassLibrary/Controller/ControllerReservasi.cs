using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HikepassLibrary.Controller
{
    public static class ControllerReservasi
    {
        public static async Task GetAllReservasi(string baseUrl)
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


        public static async Task CreateReservasi(string baseUrl)
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
            Console.Write("Enter Keterangan: ");
            string keterangan = Console.ReadLine();
            id = random.Next(100, 999);

            var newReservasi = new
            {
                Id = id,
                DataPendaki = dataPendaki,
                Jalur = jalur,
                TanggalPendakian = tanggalPendakian,
                StatusPembayaran = "Belum Lunas",
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


        public static async Task UpdateReservasi(string baseUrl)
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

        public static async Task DeleteReservasi(string baseUrl)
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
        public static async Task GetReservasiById(string baseUrl)
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
}
