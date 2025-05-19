using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;

namespace HikepassLibrary.Controller
{
    public static class ControllerReservasi
    {
        public static List<Tiket> reservasiList = new List<Tiket>();
        public static async Task GetAllReservasi(string baseUrl)
        {
            try
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
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
            catch (TaskCanceledException ex)
            {
                // Timeout atau masalah lain terkait pembatalan task
                Console.WriteLine($"Request timeout: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }



        public static async Task CreateReservasi(string baseUrl, Pendaki pendaki)
        {
            try
            {
                Console.Write("Nama Pendaki: ");
                string namaPendaki = Console.ReadLine();
                Console.Write("NIK: ");
                string nikPendaki = Console.ReadLine();
                Console.Write("Nomor HP: ");
                string nomorHP = Console.ReadLine();
                Console.Write("Usia: ");
                string usiaPendaki = Console.ReadLine();

                int usiaPendakiInt = int.Parse(usiaPendaki);
                pendaki.FullName = namaPendaki;
                pendaki.Nik = nikPendaki;
                pendaki.Kontak = nomorHP;
                pendaki.Usia = usiaPendakiInt;
                
                int id = reservasiList.Count == 0 ? 1 : reservasiList.Max(r => r.Id) + 1;
                Dictionary<int, Jarak> jarakTabel = new Dictionary<int, Jarak>
                {
                    { 0, Jarak.Pendek }, 
                    { 1, Jarak.Sedang }  
                };

                Console.Write("Jarak Pendakian (0 = Panorama(pendek) / 1 = Cinyiruan(sedang): ");
                int jarakInput = int.Parse(Console.ReadLine());

                // Menentukan Jarak Pendakian menggunakan tabel
                Jarak jarak;
                if (jarakTabel.ContainsKey(jarakInput))
                {
                    jarak = jarakTabel[jarakInput];
                }
                else
                {
                    Console.WriteLine("Pilihan jarak tidak valid. Menggunakan default: Pendek.");
                    jarak = Jarak.Pendek; 
                }

                
                Tiket.JalurPendakian jalur;
                if (jarak == Jarak.Pendek)
                {
                    jalur = Tiket.JalurPendakian.Panorama;  
                }
                else if (jarak == Jarak.Sedang)
                {
                    jalur = Tiket.JalurPendakian.Cinyiruan; 
                }
                else
                {
                    Console.WriteLine("Jalur tidak valid berdasarkan jarak.");
                    jalur = Tiket.JalurPendakian.Panorama; 
                }
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

                    
                    if (string.IsNullOrWhiteSpace(nikRekan) || string.IsNullOrWhiteSpace(kontakRekan) || string.IsNullOrWhiteSpace(usiaRekan))
                    {
                        Console.WriteLine("Data pendaki tidak valid. Semua kolom harus diisi.");
                        continue; 
                    }

                    daftarPendaki.Add(namaRekan, $"NIK: {nikRekan}, Kontak: {kontakRekan}, Usia: {usiaRekan}");
                }


                Console.Write("Enter Keterangan: ");
                string keterangan = Console.ReadLine();

                var newReservasi = new
                {
                    Id = id,  
                    Tanggal = tanggalPendakian.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), 
                    StatusPembayaran = false, 
                    JumlahPendaki = jumlahPendaki,
                    Kontak = nomorHP,
                    Jalur = jalur,  
                    IsCheckedIn = false,
                    DaftarPendaki = daftarPendaki.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value), 
                    Status = Tiket.StatusTiket.BelumDibayar, 
                    BarangBawaanSaatCheckin = new List<string> { null },
                    BarangBawaanSaatCheckout = new List<string> { null },
                    Keterangan = keterangan
                };
                
                var tiketBaru = new Tiket
                {
                    Id = newReservasi.Id,
                    Tanggal = tanggalPendakian,
                    StatusPembayaran = newReservasi.StatusPembayaran,
                    JumlahPendaki = newReservasi.JumlahPendaki,
                    Kontak = newReservasi.Kontak,
                    Jalur = jalur,
                    IsCheckedIn = newReservasi.IsCheckedIn,
                    DaftarPendaki = newReservasi.DaftarPendaki,
                    Status = (Tiket.StatusTiket)newReservasi.Status,
                    BarangBawaanSaatCheckin = newReservasi.BarangBawaanSaatCheckin,
                    BarangBawaanSaatCheckout = newReservasi.BarangBawaanSaatCheckout,
                    Keterangan = newReservasi.Keterangan
                };

               
                reservasiList.Add(tiketBaru);

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);  
                    var json = JsonSerializer.Serialize(newReservasi);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(baseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Reservasi created successfully!\n");
                        foreach (var tiket in reservasiList)
                        {
                            tiket.ShowTiketInfo();
                        }
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

        public static async Task UpdatedPembayaran(string baseUrl, int id)
        {
            try
            {
                Tiket tiketToUpdate = reservasiList.FirstOrDefault(t => t.Id == id);

                if (tiketToUpdate == null)
                {
                    Console.WriteLine("Tiket dengan ID tersebut tidak ditemukan.");
                    return;
                }

               
                if (tiketToUpdate.Status == Tiket.StatusTiket.BelumDibayar)
                {
                    tiketToUpdate.StatusPembayaran = true;
                    tiketToUpdate.Status = Tiket.StatusTiket.Dibayar;
                    tiketToUpdate.IsCheckedIn = false;
                }
                else
                {
                    Console.WriteLine("Tiket sudah dibayar.");
                    return;
                }

                

                // Mengupdate data pada server
                var updatedReservasi = new
                {
                    Id = tiketToUpdate.Id,
                    Tanggal = tiketToUpdate.Tanggal.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    StatusPembayaran = tiketToUpdate.StatusPembayaran,
                    JumlahPendaki = tiketToUpdate.JumlahPendaki,
                    Kontak = tiketToUpdate.Kontak,
                    Jalur = (int)tiketToUpdate.Jalur,
                    IsCheckedIn = false,
                    DaftarPendaki = tiketToUpdate.DaftarPendaki.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                    Status = tiketToUpdate.Status,
                    BarangBawaanSaatCheckin = tiketToUpdate.BarangBawaanSaatCheckin,
                    BarangBawaanSaatCheckout = tiketToUpdate.BarangBawaanSaatCheckout,
                    Keterangan = tiketToUpdate.Keterangan
                };

                // Menampilkan tiket yang telah diperbarui
                tiketToUpdate.ShowTiketInfo();
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var json = JsonSerializer.Serialize(updatedReservasi);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"{baseUrl}/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Reservasi berhasil diperbarui pada server!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to update reservasi. Status code: {response.StatusCode}");
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task UpdatedCheckInCheckOut(string baseUrl, int id)
        {
            try
            {
                Tiket tiketToUpdate = reservasiList.FirstOrDefault(t => t.Id == id);

                if (tiketToUpdate == null)
                {
                    Console.WriteLine("Tiket dengan ID tersebut tidak ditemukan.");
                    return;
                }
                // Jika status pembayaran sudah dibayar
                if (tiketToUpdate.Status == Tiket.StatusTiket.Dibayar)
                {
                    tiketToUpdate.Status = Tiket.StatusTiket.Checkin;
                    tiketToUpdate.IsCheckedIn = true; // Menandakan bahwa sudah check-in
                    Console.WriteLine("Pendakian berhasil Check-in!");
                    Console.WriteLine();
                }
                else if(tiketToUpdate.Status == Tiket.StatusTiket.Checkin)
                {
                    tiketToUpdate.Status = Tiket.StatusTiket.Checkout;
                    tiketToUpdate.IsCheckedIn = false; // Menandakan bahwa sudah check-out
                    Console.WriteLine("Pendakian berhasil Check-out!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Tiket belum dibayar. Silakan lakukan pembayaran terlebih dahulu.");
                    return;
                }

                // Menampilkan tiket yang telah diperbarui
                tiketToUpdate.ShowTiketInfo();

                // Mengupdate data pada server
                var updatedReservasi = new
                {
                    Id = tiketToUpdate.Id,
                    Tanggal = tiketToUpdate.Tanggal.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    StatusPembayaran = tiketToUpdate.StatusPembayaran,
                    JumlahPendaki = tiketToUpdate.JumlahPendaki,
                    Kontak = tiketToUpdate.Kontak,
                    Jalur = (int)tiketToUpdate.Jalur,
                    IsCheckedIn = tiketToUpdate.IsCheckedIn,
                    DaftarPendaki = tiketToUpdate.DaftarPendaki.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                    Status = (int)tiketToUpdate.Status,
                    BarangBawaanSaatCheckin = tiketToUpdate.BarangBawaanSaatCheckin,
                    BarangBawaanSaatCheckout = tiketToUpdate.BarangBawaanSaatCheckout,
                    Keterangan = tiketToUpdate.Keterangan
                };

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var json = JsonSerializer.Serialize(updatedReservasi);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"{baseUrl}/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Reservasi berhasil diperbarui pada server!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to update reservasi. Status code: {response.StatusCode}");
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static async Task Selesaikan(string baseUrl, int id, bool isCheckIn)
        {
            try
            {
                Tiket tiketToUpdate = reservasiList.FirstOrDefault(t => t.Id == id);

                if (tiketToUpdate == null)
                {
                    Console.WriteLine("Tiket dengan ID tersebut tidak ditemukan.");
                    return;
                }

                // Jika status pembayaran sudah dibayar
                if (tiketToUpdate.Status == Tiket.StatusTiket.Checkout)
                {
                    tiketToUpdate.Status = Tiket.StatusTiket.Selesai;
                    tiketToUpdate.IsCheckedIn = false;
                }
                else
                {
                    Console.WriteLine("Tiket belum dibayar. Silakan lakukan pembayaran terlebih dahulu.");
                    return;
                }

                // Menampilkan tiket yang telah diperbarui
                tiketToUpdate.ShowTiketInfo();

                // Mengupdate data pada server
                var updatedReservasi = new
                {
                    Id = tiketToUpdate.Id,
                    Tanggal = tiketToUpdate.Tanggal.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    StatusPembayaran = tiketToUpdate.StatusPembayaran,
                    JumlahPendaki = tiketToUpdate.JumlahPendaki,
                    Kontak = tiketToUpdate.Kontak,
                    Jalur = (int)tiketToUpdate.Jalur,
                    IsCheckedIn = tiketToUpdate.IsCheckedIn,
                    DaftarPendaki = tiketToUpdate.DaftarPendaki.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                    Status = (int)tiketToUpdate.Status,
                    BarangBawaanSaatCheckin = tiketToUpdate.BarangBawaanSaatCheckin,
                    BarangBawaanSaatCheckout = tiketToUpdate.BarangBawaanSaatCheckout,
                    Keterangan = tiketToUpdate.Keterangan
                };

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var json = JsonSerializer.Serialize(updatedReservasi);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"{baseUrl}/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Tiket berhasil diperbarui pada server!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to update reservasi. Status code: {response.StatusCode}");
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task RescheduleTanggalTiket(string baseUrl, int id, DateTime newTanggal)
        {
            try
            {
                Tiket tiketToReschedule = reservasiList.FirstOrDefault(t => t.Id == id);

                if (tiketToReschedule == null)
                {
                    Console.WriteLine("Tiket dengan ID tersebut tidak ditemukan.");
                    return;
                }

                // Memeriksa apakah tiket dapat diubah tanggalnya
                if (tiketToReschedule.Status != Tiket.StatusTiket.BelumDibayar)
                {
                    Console.WriteLine("Tanggal tidak dapat diubah karena tiket sudah dibayar atau digunakan.");
                    return;
                }

                // Mengubah tanggal tiket
                tiketToReschedule.Tanggal = newTanggal;

                // Membuat objek untuk dikirim ke server
                var updatedReservasi = new
                {
                    Id = tiketToReschedule.Id,
                    Tanggal = tiketToReschedule.Tanggal.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    StatusPembayaran = tiketToReschedule.StatusPembayaran,
                    JumlahPendaki = tiketToReschedule.JumlahPendaki,
                    Kontak = tiketToReschedule.Kontak,
                    Jalur = (int)tiketToReschedule.Jalur,
                    IsCheckedIn = tiketToReschedule.IsCheckedIn,
                    DaftarPendaki = tiketToReschedule.DaftarPendaki.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                    Status = tiketToReschedule.Status,
                    BarangBawaanSaatCheckin = tiketToReschedule.BarangBawaanSaatCheckin,
                    BarangBawaanSaatCheckout = tiketToReschedule.BarangBawaanSaatCheckout,
                    Keterangan = tiketToReschedule.Keterangan
                };

                // Menampilkan informasi tiket yang diperbarui
                tiketToReschedule.ShowTiketInfo();

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var json = JsonSerializer.Serialize(updatedReservasi);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"{baseUrl}/{id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Tanggal tiket berhasil diperbarui pada server!");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to update tiket. Status code: {response.StatusCode}");
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                    // Menemukan tiket yang akan diupdate dan melakukan pembaruan di reservasiList
                    Tiket tiketUpdated = reservasiList.FirstOrDefault(t => t.Id == id);
                    if (tiketUpdated != null)
                    {
                        tiketUpdated.Tanggal = tanggalPendakian;
                        tiketUpdated.StatusPembayaran = false;  // Status pembayarannya masih "BelumDibayar"
                        tiketUpdated.JumlahPendaki = jumlahPendaki;
                        tiketUpdated.Kontak = nomorHP;
                        tiketUpdated.Jalur = (Tiket.JalurPendakian)jalur;
                        tiketUpdated.IsCheckedIn = false;
                        tiketUpdated.DaftarPendaki = daftarPendaki;
                        tiketUpdated.Status = Tiket.StatusTiket.BelumDibayar;
                        tiketUpdated.BarangBawaanSaatCheckin = new List<string> { null };
                        tiketUpdated.BarangBawaanSaatCheckout = new List<string> { null };
                        tiketUpdated.Keterangan = keterangan;

                        Console.WriteLine("Reservasi di aplikasi telah berhasil diperbarui!");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to update reservasi. Status code: {response.StatusCode}");
                }
            }
        }

        public static async Task DeleteTiket(string baseUrl, int id)
        {
            try
            {
                // Cari tiket di dalam reservasiList
                Tiket tiketToDelete = reservasiList.FirstOrDefault(t => t.Id == id);

                if (tiketToDelete == null)
                {
                    Console.WriteLine("Tiket dengan ID tersebut tidak ditemukan.");
                    return;
                }

                // Hapus dari server
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var response = await client.DeleteAsync($"{baseUrl}/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Hapus dari daftar lokal
                        reservasiList.Remove(tiketToDelete);
                        Console.WriteLine("Tiket berhasil dihapus!");
                    }
                    else
                    {
                        Console.WriteLine($"Gagal menghapus tiket. Status code: {response.StatusCode}");
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
