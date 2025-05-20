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
                informasi.TampilkanInformasi();

                Console.Write("\nApakah Anda ingin mengedit informasi ini? (y/n): ");
                var pilihan = Console.ReadLine()?.Trim().ToLower();

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
