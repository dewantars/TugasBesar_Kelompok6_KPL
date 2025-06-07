using HikepassLibrary.Model;
using System;
using System.Text.Json;

namespace HikepassLibrary.Service
{
    public class InformasiService
    {
        private readonly string filePath;

        public InformasiService(string filePath = "informasi.json")
        {
            this.filePath = filePath;
        }

        private List<Informasi<string>> GetAllInformasi()
        {
            if (!File.Exists(filePath))
                return new List<Informasi<string>>();

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Informasi<string>>>(jsonString)
                   ?? new List<Informasi<string>>();
        }

        public void TampilkanInformasi()
        {
            Console.Write("Masukkan kategori yang ingin dilihat (Peraturan/Tips/Umum): ");
            string kategori = Console.ReadLine()?.Trim();

            var daftarInformasi = GetAllInformasi()
                                  .FindAll(info => info.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

            if (daftarInformasi.Count == 0)
            {
                Console.WriteLine($"Tidak ada informasi pada kategori '{kategori}'.");
                return;
            }

            foreach (var info in daftarInformasi)
            {
                Console.WriteLine();
                info.TampilkanInformasi();
            }
        }

        public void EditInformasi()
        {

            var semuaInformasi = GetAllInformasi();

            Console.Write("Masukkan kategori yang ingin diedit (Peraturan/Tips/Umum): ");
            string kategori = Console.ReadLine()?.Trim();

            var daftarKategori = semuaInformasi.FindAll(info =>
                info.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));

            if (daftarKategori.Count > 0)
            {
                Console.WriteLine("\nInformasi yang sudah ada:");
                foreach (var info in daftarKategori)
                {
                    info.TampilkanInformasi();
                }
            }
            else
            {
                Console.WriteLine("\nBelum ada informasi pada kategori ini.");
            }

            Console.Write("\nApakah Anda ingin mengedit informasi kategori ini? (y/n): ");
            var konfirmasi = Console.ReadLine()?.Trim().ToLower();
            if (konfirmasi == "y")
            {
                var infoBaru = Informasi<string>.EditInformasi();

                // Hapus yang lama & tambahkan yang baru
                semuaInformasi.RemoveAll(info => info.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase));
                semuaInformasi.Add(infoBaru);

                // Simpan ulang
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(filePath, JsonSerializer.Serialize(semuaInformasi, options));

            // Menyimpan informasi setelah diedit
                //Informasi.TulisKeFileJson(filePath);
                Console.WriteLine("\nInformasi telah diperbarui.");
            }
            else
            {
                Console.WriteLine("Tidak ada perubahan yang dilakukan.");
            }
        }

    }
}
