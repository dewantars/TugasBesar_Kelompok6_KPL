using HikepassLibrary.Model;
using HikepassLibrary.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HikepassTestProject
{
    [TestClass]
    public class UnitTsetRiwayat
    {
        private string TestFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            TestFilePath = Path.Combine(Path.GetTempPath(), "TestRiwayatPendakian.json");
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
        public void SaveRiwayat_ShouldWriteToFile()
        {
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

            Assert.IsTrue(File.Exists(TestFilePath), "File riwayat tidak ditemukan setelah penyimpanan.");

            string fileContent = File.ReadAllText(TestFilePath);
            Assert.IsTrue(fileContent.Contains("John Doe"), "Data pendaki tidak ditemukan dalam file.");
        }

        [TestMethod]
        public void LoadRiwayat_ShouldReadFromFile()
        {
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
            var loadedList = service.LoadRiwayat();
            Assert.AreEqual(1, loadedList.Count, "Jumlah data yang dimuat tidak sesuai.");
            Assert.AreEqual("John Doe", loadedList.First().DaftarPendaki["123456789"], "Nama pendaki tidak sesuai.");
        }

        [TestMethod]
        public void LoadRiwayat_ShouldReturnEmptyListIfFileDoesNotExist()
        {
            var service = new RiwayatService(TestFilePath);
            var loadedList = service.LoadRiwayat();
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

    }
}