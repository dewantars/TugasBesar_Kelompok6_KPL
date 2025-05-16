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
                var informasi = Informasi<string>.BacaDariFileJson(filePath);
                informasi.TampilkanInformasi();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Belum ada informasi yang tersedia.");
            }
        }

        public void TambahAtauEditInformasi()
        {
            var informasi = Informasi<string>.BacaDariFileJson(filePath);
            try
            {
                
                Console.WriteLine("\nInformasi yang ada:");
                informasi.TampilkanInformasi();

                Console.WriteLine("\nApakah Anda ingin mengedit informasi ini? (y/n)");
                var pilihan = Console.ReadLine()?.Trim().ToLower();

                if (pilihan == "y")
                {
                    informasi = Informasi<string>.EditInformasi();
                }
                else
                {
                    Console.WriteLine("Tidak ada perubahan yang dilakukan.");
                    return;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nBelum ada informasi yang tersedia. Membuat informasi baru.");
                informasi = Informasi<string>.EditInformasi();
                informasi.TulisKeFileJson(filePath);
                Console.WriteLine("\nInformasi baru telah disimpan.");
                return;
            }

            // Menyimpan informasi setelah diedit
            informasi.TulisKeFileJson(filePath);
            Console.WriteLine("\nInformasi telah diperbarui.");
        }
    }
}
