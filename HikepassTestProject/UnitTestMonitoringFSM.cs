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
    public class UnitTestMonitoringFSM
    {
        [TestMethod]
        public void FSM_InitialState_ShouldBeBasecamp()
        {
            var fsm = new MonitoringFSM();
            Assert.AreEqual(MonitoringFSM.State.Basecamp, fsm.current);
        }

        [TestMethod]
        public void FSM_ValidTransition_ShouldMoveToNextState()
        {
            var fsm = new MonitoringFSM();
            fsm.NaikPos(); // Basecamp → Pos1
            Assert.AreEqual(MonitoringFSM.State.Pos1, fsm.current);

            fsm.NaikPos(); // Pos1 → Pos2
            Assert.AreEqual(MonitoringFSM.State.Pos2, fsm.current);

            fsm.CapaiPuncak(); // Pos2 → Puncak
            Assert.AreEqual(MonitoringFSM.State.Puncak, fsm.current);

            fsm.TurunGunung(); // Puncak → Turun
            Assert.AreEqual(MonitoringFSM.State.Turun, fsm.current);

            fsm.SelesaiPendakian(); // Turun → Selesai
            Assert.AreEqual(MonitoringFSM.State.Selesai, fsm.current);
        }

        [TestMethod]
        public void FSM_InvalidTransition_ShouldRemainInCurrentState()
        {
            var fsm = new MonitoringFSM();
            fsm.CapaiPuncak(); // Tidak valid dari Basecamp
            Assert.AreEqual(MonitoringFSM.State.Basecamp, fsm.current);
        }

        [TestMethod]
        public void MonitoringService_ShouldTrackPendakiStateCorrectly()
        {
            var service = new MonitoringService();
            var tiket = new Tiket { Id = 1, DaftarPendaki = new Dictionary<string, string> { { "Andi", null } } };

            service.AddToMonitoring(tiket);

            string msg1 = service.LanjutkanPendakian(1, "Andi");
            Assert.IsTrue(msg1.Contains("Pos1"));

            string msg2 = service.LanjutkanPendakian(1, "Andi");
            Assert.IsTrue(msg2.Contains("Pos2"));
        }

        [TestMethod]
        public void MonitoringService_InvalidPendaki_ShouldReturnError()
        {
            var service = new MonitoringService();
            var tiket = new Tiket { Id = 2, DaftarPendaki = new Dictionary<string, string> { { "Budi", null } } };

            service.AddToMonitoring(tiket);

            string msg = service.LanjutkanPendakian(2, "SalahNama");
            Assert.IsTrue(msg.Contains("tidak ditemukan"));
        }


    }


}
