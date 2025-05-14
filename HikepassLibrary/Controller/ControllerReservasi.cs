using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HikepassLibrary.Model;

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


        public static async Task CreateReservasi(string baseUrl, Pendaki pendaki)
        {
            try
            {
                Console.Write("Enter Nama Pendaki: ");
                string namaPendaki = Console.ReadLine();
                Console.Write("Enter Nomor HP: ");
                string nomorHP = Console.ReadLine();
                Random random = new Random();
                int id = random.Next(100, 999);
                Console.Write("Enter Jalur Pendakian (Cinyiruan/Panorama): ");
                int jalur = int.Parse(Console.ReadLine());
                Console.Write("Masukkan tanggal pendakian (format:YYYY-MM-DD): ");
                DateTime tanggalPendakian;
                while (!DateTime.TryParse(Console.ReadLine(), out tanggalPendakian))
                {
                    Console.WriteLine("Tanggal tidak valid. Masukkan ulang (format:YYYY-MM-DD): ");
                }

                Console.Write("Masukkan jumlah pendaki: ");
                int jumlahPendaki;
                while (!int.TryParse(Console.ReadLine(), out jumlahPendaki) || jumlahPendaki <= 0)
                {
                    Console.WriteLine("Jumlah pendaki tidak valid. Masukkan angka lebih dari 0: ");
                }
                Dictionary<string, string> daftarPendaki = new Dictionary<string, string>();
                daftarPendaki.Add(pendaki.FullName, $"NIK: {pendaki.Nik}, Kontak: {pendaki.Kontak}, Usia: {pendaki.Usia}");

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

                Console.Write("Enter Keterangan: ");
                string keterangan = Console.ReadLine();

                var newReservasi = new
                {
                    Id = id,
                    Tanggal = tanggalPendakian,
                    StatusPembayaran = "BelumDibayar",
                    JumlahPendaki = jumlahPendaki,
                    Kontak = nomorHP,
                    Jalur = jalur,
                    IsCheckedIn = false,
                    DaftarPendaki = daftarPendaki,
                    Status = Tiket.StatusTiket.BelumDibayar,
                    BarangBawaanSaatCheckin = new List<string> { null },
                    BarangBawaanSaatCheckout = new List<string> { null },
                    Keterangan = keterangan
                };

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);  // Mengatur timeout lebih panjang
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



        public static async Task UpdateReservasi(string baseUrl,Pendaki pendaki)
        {
            Console.Write("Enter Reservasi ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Nama Pendaki: ");
            string namaPendaki = Console.ReadLine();
            Console.Write("Enter Nomor HP: ");
            string nomorHP = Console.ReadLine();
            Console.Write("Enter Jalur Pendakian (Cinyiruan/Panorama): ");
            int jalur = int.Parse(Console.ReadLine());
            Console.Write("Masukkan tanggal pendakian (format:YYYY-MM-DD): ");
            DateTime tanggalPendakian;
            while (!DateTime.TryParse(Console.ReadLine(), out tanggalPendakian))
            {
                Console.WriteLine("Tanggal tidak valid. Masukkan ulang (format:YYYY-MM-DD): ");
            }

            Console.Write("Masukkan jumlah pendaki: ");
            int jumlahPendaki;
            while (!int.TryParse(Console.ReadLine(), out jumlahPendaki) || jumlahPendaki <= 0)
            {
                Console.WriteLine("Jumlah pendaki tidak valid. Masukkan angka lebih dari 0: ");
            }
            Dictionary<string, string> daftarPendaki = new Dictionary<string, string>();
            daftarPendaki.Add(pendaki.FullName, $"NIK: {pendaki.Nik}, Kontak: {pendaki.Kontak}, Usia: {pendaki.Usia}");

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
            Console.Write("Enter Keterangan: ");
            string keterangan = Console.ReadLine();


            var updatedReservasi = new
            {
                Id = id,
                Tanggal = tanggalPendakian,
                StatusPembayaran = "BelumDibayar",
                JumlahPendaki = jumlahPendaki,
                Kontak = nomorHP,
                Jalur = jalur,
                IsCheckedIn = false,
                DaftarPendaki = daftarPendaki,
                Status = Tiket.StatusTiket.BelumDibayar,
                BarangBawaanSaatCheckin = new List<string> { null },
                BarangBawaanSaatCheckout = new List<string> { null },
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
