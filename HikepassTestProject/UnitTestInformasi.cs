using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HikepassLibrary.Model;

namespace HikepassLibrary.Tests
{
    [TestClass]
    public class UnitTestInformasi
    {
        [TestMethod]
        public void BuatObjek_DenganDataValid_Berhasil()
        {
            var informasi = new Informasi<string>(
                "INF123",
                "Tips",
                "Tips Mendaki",
                "Bawa air yang cukup",
                DateTime.Now
            );

            Assert.AreEqual("INF123", informasi.IdInformasi);
            Assert.AreEqual("Tips", informasi.Kategori);
            Assert.AreEqual("Tips Mendaki", informasi.Judul);
            Assert.AreEqual("Bawa air yang cukup", informasi.Isi);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuatObjek_DenganIdKosong_ThrowException()
        {
            var informasi = new Informasi<string>(
                "",
                "Tips",
                "Judul",
                "Isi",
                DateTime.Now
            );
        }

        [TestMethod]
        public void SimpanDanBaca_DariFileJson_Berhasil()
        {
            string filePath = "test_informasi.json";
            var original = new Informasi<string>(
                "INF001",
                "Peraturan",
                "Peraturan Umum",
                "Dilarang membuang sampah sembarangan.",
                DateTime.Now
            );

            original.TulisKeFileJson(filePath);
            var hasil = Informasi<string>.BacaDariFileJson(filePath);

            Assert.AreEqual(original.IdInformasi, hasil.IdInformasi);
            Assert.AreEqual(original.Kategori, hasil.Kategori);
            Assert.AreEqual(original.Judul, hasil.Judul);
            Assert.AreEqual(original.Isi, hasil.Isi);

            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void BacaDariFileJson_JikaFileTidakAda_ThrowException()
        {
            Informasi<string>.BacaDariFileJson("file_tidak_ada.json");
        }

        [TestMethod]
        public void BacaDariFileJson_DenganDataTidakLengkap_ThrowException()
        {
            string path = "invalid.json";
            File.WriteAllText(path, "{}");

            try
            {
                Informasi<string>.BacaDariFileJson(path);
                Assert.Fail("Ekspektasi exception tidak muncul.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Data Informasi dari file tidak lengkap atau salah.", ex.Message);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
