
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static HikepassLibrary.Model.Tiket;
using HikepassAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using HikepassLibrary.Service;

namespace HikepassTestProject
{
    [TestClass]
    public class UnitTestBayarTiket
    {
        [TestMethod]
        
        public void BayarTiket_ShouldUpdateStatusToDibayar_WhenPaymentIsSuccessful()
        {
            var tiket = new Tiket
            {
                Id = 10,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Andi - Usia 20" } },
                Status = StatusTiket.BelumDibayar,
                StatusPembayaran = false
            };

            ControllerReservasi.reservasiList.Add(tiket);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);


                var userInput = new List<string> { "10", "y"};
                var reader = new StringReader(string.Join(Environment.NewLine, userInput));
                Console.SetIn(reader);


                var tiketCtrl = new TiketController();
                tiketCtrl.BayarTiket(tiket);


                Assert.AreEqual(StatusTiket.Dibayar, tiket.Status);
                
            }
        }
    }
    
}
