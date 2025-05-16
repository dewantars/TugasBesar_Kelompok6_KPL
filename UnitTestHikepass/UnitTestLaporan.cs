//using System;
//using System.IO;
//using HikepassLibrary.Model;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTestHikepass
//{
//    [TestClass]
//    public class UnitTestLaporan
//    {
//        [TestMethod]
//        public void Constructor_WithValidInput_ShouldCreateObject()
//        {
//            // Arrange
//            string id = "LAP20240516";
//            string deskripsi = "Kecelakaan ringan";
//            string lokasi = "Pos 2";
//            DateTime waktu = DateTime.Now;
//            string keparahan = "Ringan";

//            // Act
//            var laporan = new Laporan<string>(id, deskripsi, lokasi, waktu, keparahan);

//            // Assert
//            Assert.AreEqual(id, laporan.IdLaporan);
//            Assert.AreEqual(deskripsi, laporan.Deskripsi);
//            Assert.AreEqual(lokasi, laporan.TitikLokasi);
//            Assert.AreEqual(waktu, laporan.WaktuLaporan);
//            Assert.AreEqual(keparahan, laporan.TingkatKeparahan);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Constructor_WithEmptyDeskripsi_ShouldThrow()
//        {
//            var laporan = new Laporan<string>("LAP1", "", "Pos 1", DateTime.Now, "Sedang");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Constructor_WithEmptyLokasi_ShouldThrow()
//        {
//            var laporan = new Laporan<string>("LAP1", "Deskripsi", "", DateTime.Now, "Berat");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Constructor_WithDefaultWaktu_ShouldThrow()
//        {
//            var laporan = new Laporan<string>("LAP1", "Deskripsi", "Lokasi", default(DateTime), "Sedang");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Constructor_WithNullKeparahan_ShouldThrow()
//        {
//            var laporan = new Laporan<string>("LAP1", "Deskripsi", "Lokasi", DateTime.Now, null);
//        }

//        [TestMethod]
//        public void PrintLaporan_ShouldOutputCorrectly()
//        {
//            // Arrange
//            var laporan = new Laporan<string>("LAP123", "Insiden kecil", "Pos 3", new DateTime(2024, 5, 16, 10, 30, 0), "Sedang");
//            using var sw = new StringWriter();
//            Console.SetOut(sw);

//            // Act
//            laporan.PrintLaporan();
//            string result = sw.ToString();

//            // Assert (cukup cek sebagian output)
//            Assert.IsTrue(result.Contains("ID                : LAP123"));
//            Assert.IsTrue(result.Contains("Deskripsi Laporan : Insiden kecil"));
//            Assert.IsTrue(result.Contains("Lokasi            : Pos 3"));
//            Assert.IsTrue(result.Contains("Keparahan         : Sedang"));
//        }
//    }
//}
