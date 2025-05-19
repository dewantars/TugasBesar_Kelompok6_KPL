using HikepassLibrary.Model;
using HikepassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassTestProject
{
    [TestClass]
    public class RiwayatServiceTests
    {
        private const string TestFilePath = "TestRiwayatPendakian.json";

        [TestInitialize]
        public void TestInitialize()
        {
            // Hapus file test jika ada
            if (File.Exists(TestFilePath))
                File.Delete(TestFilePath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Bersihkan file test setelah pengujian
            if (File.Exists(TestFilePath))
                File.Delete(TestFilePath);
        }

        [TestMethod]
        public void SaveRiwayat_ShouldWriteToFile()
        {
            // Arrange
            var service = new RiwayatService(TestFilePath);
            var riwayatList = new List<Tiket>
            {
                new Tiket
                {
                    Id = 1,
                    Tanggal = new DateTime(2025, 5, 17),
                    Jalur = Tiket.JalurPendakian.Panorama,
                    JumlahPendaki = 5,
                    DaftarPendaki = new Dictionary<string, string> { { "123456789", "John Doe" } },
                    BarangBawaanSaatCheckin = new List<string> { "Tenda", "Sleeping Bag" },
                    BarangBawaanSaatCheckout = new List<string> { "Tenda" },
                    Keterangan = "Pendakian berhasil",
                    StatusPembayaran = true,
                    Status = Tiket.StatusTiket.Checkout
                }
            };

            // Act
            service.SaveRiwayat(riwayatList);

            // Assert
            Assert.IsTrue(File.Exists(TestFilePath), "File riwayat tidak ditemukan setelah penyimpanan.");

            string fileContent = File.ReadAllText(TestFilePath);
            Assert.IsTrue(fileContent.Contains("John Doe"), "Data pendaki tidak ditemukan dalam file.");
        }

        [TestMethod]
        public void LoadRiwayat_ShouldReadFromFile()
        {
            // Arrange
            var service = new RiwayatService(TestFilePath);
            var riwayatList = new List<Tiket>
            {
                new Tiket
                {
                    Id = 1,
                    Tanggal = new DateTime(2025, 5, 17),
                    Jalur = Tiket.JalurPendakian.Panorama,
                    JumlahPendaki = 5,
                    DaftarPendaki = new Dictionary<string, string> { { "123456789", "John Doe" } },
                    BarangBawaanSaatCheckin = new List<string> { "Tenda", "Sleeping Bag" },
                    BarangBawaanSaatCheckout = new List<string> { "Tenda" },
                    Keterangan = "Pendakian berhasil",
                    StatusPembayaran = true,
                    Status = Tiket.StatusTiket.Checkout
                }
            };
            service.SaveRiwayat(riwayatList);

            // Act
            var loadedList = service.LoadRiwayat();

            // Assert
            Assert.AreEqual(1, loadedList.Count, "Jumlah data yang dimuat tidak sesuai.");
            Assert.AreEqual("John Doe", loadedList.First().DaftarPendaki["123456789"], "Nama pendaki tidak sesuai.");
        }

        [TestMethod]
        public void LoadRiwayat_ShouldReturnEmptyListIfFileDoesNotExist()
        {
            // Arrange
            var service = new RiwayatService(TestFilePath);

            // Act
            var loadedList = service.LoadRiwayat();

            // Assert
            Assert.AreEqual(0, loadedList.Count, "Riwayat tidak kosong meskipun file tidak ada.");
        }

    }

    [TestClass]
    public class RiwayatPendakianTests
    {
        private const string TestFilePath = "TestRiwayatPendakian.json";

        [TestInitialize]
        public void TestInitialize()
        {
            if (File.Exists(TestFilePath))
                File.Delete(TestFilePath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(TestFilePath))
                File.Delete(TestFilePath);
        }

        [TestMethod]
        public void ShowRiwayat_ShouldDisplayCorrectData()
        {
            var riwayatPendakian = new RiwayatPendakian(TestFilePath);
            RiwayatPendakian.riwayatList.Add(new Tiket
            {
                Id = 1,
                Tanggal = new DateTime(2025, 5, 17),
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                JumlahPendaki = 3,
                DaftarPendaki = new Dictionary<string, string> { { "987654321", "Jane Doe" } },
                BarangBawaanSaatCheckin = new List<string> { "Kompor", "Gas" },
                BarangBawaanSaatCheckout = new List<string> { "Kompor" },
                Keterangan = "Pendakian terganggu oleh cuaca",
                StatusPembayaran = true,
                Status = Tiket.StatusTiket.Checkout
            });

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                riwayatPendakian.ShowRiwayat();
                var output = sw.ToString();

                Assert.IsTrue(output.Contains("Jane Doe"), "Output tidak berisi nama pendaki yang sesuai.");
                Assert.IsTrue(output.Contains("Pendakian terganggu oleh cuaca"), "Output tidak berisi keterangan yang sesuai.");
            }
        }

        [TestMethod]
        public void SaveRiwayat_ShouldPersistData()
        {
            var riwayatPendakian = new RiwayatPendakian(TestFilePath);
            RiwayatPendakian.riwayatList.Add(new Tiket
            {
                Id = 2,
                Tanggal = new DateTime(2025, 5, 18),
                Jalur = Tiket.JalurPendakian.Panorama,
                JumlahPendaki = 4,
                DaftarPendaki = new Dictionary<string, string> { { "456789123", "Michael Smith" } },
                BarangBawaanSaatCheckin = new List<string> { "Tenda", "Kompor" },
                BarangBawaanSaatCheckout = new List<string> { "Tenda" },
                Keterangan = "Pendakian sukses tanpa kendala",
                StatusPembayaran = true,
                Status = Tiket.StatusTiket.Selesai
            });

            riwayatPendakian.SaveRiwayat();
            var loadedData = new RiwayatPendakian(TestFilePath);

            Assert.AreEqual(1, RiwayatPendakian.riwayatList.Count, "Jumlah data dalam riwayat tidak sesuai setelah penyimpanan.");
            Assert.AreEqual("Michael Smith", RiwayatPendakian.riwayatList.First().DaftarPendaki["456789123"], "Nama pendaki tidak sesuai setelah penyimpanan.");
        }
    }
}
