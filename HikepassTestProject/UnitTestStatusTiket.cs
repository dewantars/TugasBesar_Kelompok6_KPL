using System;
using System.Collections.Generic;
using HikepassLibrary.Model;
using HikepassLibrary.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using static HikepassLibrary.Model.Tiket;
using HikepassAPI.Controllers;
using HikepassLibrary.Service;
using Newtonsoft.Json.Linq;

namespace HikepassTestProject
{
    [TestClass]

    public class UnitTestStatusTiket
    {
        [TestMethod]
        public void CheckIn_ShouldUpdateStatusToCheckin_WhenPaymentIsSuccessful()
        {

            var tiket = new Tiket
            {
                Id = 4,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Andi - Usia 20" } },
                Status = StatusTiket.Dibayar,
                StatusPembayaran = true
            };

            ControllerReservasi.reservasiList.Add(tiket);


            var monitoringController = new MonitoringController(new MonitoringService());


            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);


                var userInput = new List<string> { "4", "y", "BarangCheckOut", "selesai" };
                var reader = new StringReader(string.Join(Environment.NewLine, userInput));
                Console.SetIn(reader);


                var tiketCtrl = new TiketController();
                tiketCtrl.KonfirmasiTiket(new Pendaki { FullName = "Andi", Nik = "001", Kontak = "12345", Usia = 20 }, monitoringController);


                Assert.AreEqual(StatusTiket.Checkin, tiket.Status);
                Assert.AreEqual(1, tiket.BarangBawaanSaatCheckin.Count);
            }
        }

        [TestMethod]
        public void CheckOut_ShouldUpdateStatusToCheckout_WhenCheckInIsDone()
        {
            
            var tiket = new Tiket
            {
                Id = 4,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Andi - Usia 20" } },
                Status = StatusTiket.Checkin,  
                StatusPembayaran = true
            };

            ControllerReservasi.reservasiList.Add(tiket);

           
            var monitoringController = new MonitoringController(new MonitoringService());

            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); 

                
                var userInput = new List<string> { "4","y", "BarangCheckOut", "selesai" }; 
                var reader = new StringReader(string.Join(Environment.NewLine, userInput));
                Console.SetIn(reader);

                
                var tiketCtrl = new TiketController(); 
                tiketCtrl.KonfirmasiTiket(new Pendaki { FullName = "Andi", Nik = "001", Kontak = "12345", Usia = 20 }, monitoringController);

               
                Assert.AreEqual(StatusTiket.Checkout, tiket.Status); 
                Assert.AreEqual(1, tiket.BarangBawaanSaatCheckout.Count); 
            }
        }

        [TestMethod]
        public void Selesaikan_ShouldUpdateStatusToSelesai_WhenCheckOutIsDone()
        {
            
            var tiket = new Tiket
            {
                Id = 6,
                Tanggal = DateTime.Now,
                JumlahPendaki = 1,
                Jalur = Tiket.JalurPendakian.Cinyiruan,
                DaftarPendaki = new Dictionary<string, string> { { "001", "Andi - Usia 20" } },
                Status = StatusTiket.Checkout,  
                StatusPembayaran = true
            };

            ControllerReservasi.reservasiList.Add(tiket);

            
            var monitoringController = new MonitoringController(new MonitoringService());

            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); 

                
                var userInput = new List<string> { "6","y" };  
                var reader = new StringReader(string.Join(Environment.NewLine, userInput));
                Console.SetIn(reader);

               
                var tiketCtrl = new TiketController();  
                tiketCtrl.Selesaikan(tiket);

                
                Assert.AreEqual(StatusTiket.Selesai, tiket.Status);  
                Assert.IsFalse(tiket.IsCheckedIn);  
            }
        }

        
    }
}
