using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HikepassAPI.Controllers;
using HikepassLibrary.Controller;
using HikepassLibrary.Model;
using System;
using System.Collections.Generic;

namespace HikepassTestProject
{
    [TestClass]
    public class UnitTestReservasiController
    {
        [TestInitialize]
        public void Setup()
        {
            ControllerReservasi.reservasiList = new List<Tiket>();
        }

        // ========== GET: api/reservasi ==========
        [TestMethod]
        public void GetAllReservasi_ShouldReturnNotFound_WhenEmpty()
        {
            var controller = new ReservasiController();
            var result = controller.GetAllReservasi();
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void GetAllReservasi_ShouldReturnOk_WhenDataExists()
        {
            ControllerReservasi.reservasiList.Add(new Tiket
            {
                Id = 1,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Andi - Usia 20" } }
            });

            var controller = new ReservasiController();
            var result = controller.GetAllReservasi();
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        // ========== GET: api/reservasi/{id} ==========
        [TestMethod]
        public void GetReservasiById_ShouldReturnNotFound_WhenIdNotExist()
        {
            var controller = new ReservasiController();
            var result = controller.GetReservasiById(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void GetReservasiById_ShouldReturnOk_WhenFound()
        {
            ControllerReservasi.reservasiList = new List<Tiket>();

            ControllerReservasi.reservasiList.Add(new Tiket
            {
                Id = 1,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Panorama,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Dhea - Usia 20" } }
            });

            var controller = new ReservasiController();
            var result = controller.GetReservasiById(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        // ========== POST: api/reservasi ==========
        [TestMethod]
        public void CreateReservasi_ShouldReturnCreated_WhenValid()
        {
            var controller = new ReservasiController();
            var tiket = new Tiket
            {
                Tanggal = DateTime.Now.AddDays(1),
                JumlahPendaki = 2,
                Jalur = Tiket.JalurPendakian.Panorama,
                DaftarPendaki = new Dictionary<string, string>
                {
                    { "123", "Andi - Usia 21" },
                    { "456", "Budi - Usia 22" }
                },
                Keterangan = "Mahasiswa"
            };

            var result = controller.CreateReservasi(tiket);
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }

        // ========== PUT: api/reservasi/{id} ==========
        [TestMethod]
        public void UpdateReservasi_ShouldReturnOk_WhenValid()
        {
            var tiketAwal = new Tiket
            {
                Id = 1,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Siti - Usia 20" } },
                Keterangan = "Awal"
            };
            ControllerReservasi.reservasiList.Add(tiketAwal);

            var tiketUpdate = new Tiket
            {
                Tanggal = DateTime.Now.AddDays(2),
                JumlahPendaki = 2,
                Jalur = Tiket.JalurPendakian.Panorama,
                DaftarPendaki = new Dictionary<string, string>
                {
                    { "002", "Budi - Usia 21" },
                    { "003", "Dhea - Usia 22" }
                },
                Keterangan = "Update sukses",
                StatusPembayaran = true,
                Status = Tiket.StatusTiket.Checkin,
                IsCheckedIn = true,
                BarangBawaanSaatCheckin = new List<string> { "Tenda", "Matras" },
                BarangBawaanSaatCheckout = new List<string> { "Tenda" }
            };

            var controller = new ReservasiController();
            var result = controller.UpdateReservasi(1, tiketUpdate);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        // ========== DELETE: api/reservasi/{id} ==========
        [TestMethod]
        public void DeleteReservasi_ShouldReturnNotFound_WhenIdNotExist()
        {
            var controller = new ReservasiController();
            var result = controller.DeleteReservasi(99);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void DeleteReservasi_ShouldReturnNoContent_WhenFound()
        {
            var tiket = new Tiket
            {
                Id = 1,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Siti - Usia 20" } }
            };
            ControllerReservasi.reservasiList.Add(tiket);

            var controller = new ReservasiController();
            var result = controller.DeleteReservasi(1);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}
