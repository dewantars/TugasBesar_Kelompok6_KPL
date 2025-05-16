using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HikepassAPI.Controllers;
using HikepassLibrary.Model;
using HikepassLibrary.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HikepassUnitTest
{
    [TestClass]
    public class UnitTestReservasiController
    {
        [TestInitialize]
        public void Setup()
        {
            // Reset list sebelum setiap test
            ControllerReservasi.reservasiList = new List<Tiket>();
        }

        [TestMethod]
        public void GetAllReservasi_ReturnsNotFound_WhenListIsEmpty()
        {
            var controller = new ReservasiController();

            var result = controller.GetAllReservasi();

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void CreateReservasi_ReturnsCreatedAtAction_WhenInputValid()
        {
            var controller = new ReservasiController();
            var tiket = new Tiket
            {
                DaftarPendaki = new List<string> { "Andi", "Budi" },
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                Tanggal = DateTime.Now.AddDays(2),
                JumlahPendaki = 2
            };

            var result = controller.CreateReservasi(tiket);

            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public void CreateReservasi_ReturnsBadRequest_WhenJumlahPendakiZero()
        {
            var controller = new ReservasiController();
            var tiket = new Tiket
            {
                DaftarPendaki = new List<string> { "Andi" },
                Jalur = Tiket.JalurPendakian.Panorama,
                Tanggal = DateTime.Now.AddDays(1),
                JumlahPendaki = 0
            };

            var result = controller.CreateReservasi(tiket);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetReservasiById_ReturnsOk_WhenReservasiAda()
        {
            ControllerReservasi.reservasiList.Add(new Tiket
            {
                Id = 1,
                DaftarPendaki = new List<string> { "Sinta" },
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Status = Tiket.StatusTiket.BelumDibayar
            });

            var controller = new ReservasiController();
            var result = controller.GetReservasiById(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void DeleteReservasi_ReturnsNoContent_WhenReservasiBerhasilDihapus()
        {
            ControllerReservasi.reservasiList.Add(new Tiket
            {
                Id = 1,
                DaftarPendaki = new List<string> { "Toni" },
                Jalur = Tiket.JalurPendakian.Panorama,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Status = Tiket.StatusTiket.BelumDibayar
            });

            var controller = new ReservasiController();
            var result = controller.DeleteReservasi(1);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}

