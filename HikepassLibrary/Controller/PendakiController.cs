using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassLibrary.Controller
{
    public class PendakiController
    {
        private User pendaki;
        private MonitoringService monitoringService;

        public PendakiController(User user)
        {
            pendaki = user;
            monitoringService = new MonitoringService();
        }

        public void CheckIn()
        {
            monitoringService.HandleTransition(pendaki, "checkin");
        }

        public void CheckOut()
        {
            monitoringService.HandleTransition(pendaki, "checkout");
        }

        public void EditProfil(string namaBaru)
        {
            pendaki.EditProfil(namaBaru);
        }
    }
}
