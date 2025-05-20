using HikepassLibrary.Model;
using System;

namespace HikepassLibrary.Service
{
    public class InformasiService
    {
        private readonly string filePath;

        public InformasiService(string filePath = "informasi.json")
        {
            this.filePath = filePath;
        }

        public void TampilkanInformasi()
        {
            try
            {
                List<Informasi<string>> daftarInformasi = Informasi<string>.BacaDariFileJson<string>(filePath);

                Console.WriteLine("\n===== Daftar Informasi Pendakian =====");
                foreach (var info in daftarInformasi)
                {
                    info.TampilkanInformasi();
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Belum ada informasi yang tersedia.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan saat membaca informasi: " + ex.Message);
            }
        }

        public void TambahAtauEditInformasi()
        {
            List<Informasi<string>> daftarInformasi;

            try
            {
                daftarInformasi = Informasi<string>.BacaDariFileJson<string>(filePath);
            }
            catch (FileNotFoundException)
            {
                daftarInformasi = new List<Informasi<string>>();
            }

            Console.WriteLine("\n===== Daftar Informasi Saat Ini =====");
            for (int i = 0; i < daftarInformasi.Count; i++)
            {
                Console.WriteLine($"\n[{i + 1}]");
                daftarInformasi[i].TampilkanInformasi();
            }

            Console.WriteLine("\nIngin menambahkan informasi baru atau mengedit yang lama?");
            Console.WriteLine("[1] Tambah baru");
            Console.WriteLine("[2] Edit informasi lama");
            Console.Write("Pilihan Anda: ");
            var input = Console.ReadLine();

            if (input == "1")
            {
                var infoBaru = Informasi<string>.EditInformasi();
                daftarInformasi.Add(infoBaru);
                Console.WriteLine("\nInformasi baru ditambahkan.");
            }
            else if (input == "2" && daftarInformasi.Count > 0)
            {
                Console.Write("Pilih nomor informasi yang ingin diedit: ");
                if (int.TryParse(Console.ReadLine(), out int index) &&
                    index >= 1 && index <= daftarInformasi.Count)
                {
                    var infoBaru = Informasi<string>.EditInformasi();
                    daftarInformasi[index - 1] = infoBaru;
                    Console.WriteLine("\nInformasi berhasil diperbarui.");
                }
                else
                {
                    Console.WriteLine("Nomor tidak valid.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid atau belum ada data.");
                return;
            }

            // Simpan kembali seluruh daftar informasi ke file
            string jsonString = System.Text.Json.JsonSerializer.Serialize(daftarInformasi, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
