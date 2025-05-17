using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HikepassLibrary.Model; 

namespace HikepassTestProject
{
    [TestClass]
    public sealed class UnitTestLaporan
    {
        [TestMethod]
        public void Laporan_Constructor_ValidInput_ShouldSucceed()
        {
            // Arrange
            var id = "LAP001";
            var deskripsi = "Terjadi longsor";
            var lokasi = "Pos 1";
            var waktu = DateTime.Now;
            var keparahan = "Berat";

            // Act
            var laporan = new Laporan<string>(id, deskripsi, lokasi, waktu, keparahan);

            // Assert
            Assert.AreEqual(id, laporan.IdLaporan);
            Assert.AreEqual(deskripsi, laporan.Deskripsi);
            Assert.AreEqual(lokasi, laporan.TitikLokasi);
            Assert.AreEqual(waktu, laporan.WaktuLaporan);
            Assert.AreEqual(keparahan, laporan.TingkatKeparahan);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Laporan_Constructor_EmptyDeskripsi_ShouldThrow()
        {
            var laporan = new Laporan<string>("LAP002", "", "Pos 2", DateTime.Now, "Sedang");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Laporan_Constructor_NullKeparahan_ShouldThrow()
        {
            var laporan = new Laporan<string>("LAP003", "Deskripsi", "Pos 3", DateTime.Now, null);
        }

        [TestMethod]
        public void Laporan_PrintLaporan_ShouldPrintExpectedOutput()
        {
            // Arrange
            var laporan = new Laporan<string>("LAP004", "Test output", "Pos 4", new DateTime(2024, 1, 1, 8, 0, 0), "Ringan");
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            laporan.PrintLaporan();
            string result = sw.ToString();

            // Assert
            Assert.IsTrue(result.Contains("LAP004"));
            Assert.IsTrue(result.Contains("Test output"));
            Assert.IsTrue(result.Contains("Pos 4"));
            Assert.IsTrue(result.Contains("Ringan"));
        }
    }
}

