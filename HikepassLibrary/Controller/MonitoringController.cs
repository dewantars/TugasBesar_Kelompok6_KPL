using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using HikepassLibrary.Service;

namespace HikepassLibrary.Controller
{
    public class MonitoringController
    {
        private readonly MonitoringService _monitoringService;

        public MonitoringController(MonitoringService monitoringService)
        {
            _monitoringService = monitoringService;
        }

        public void ShowMonitoring()
        {
            _monitoringService.ShowMonitoring();
        }

        public void AddPendakiToMonitoring(Tiket tiket)
        {
            _monitoringService.AddToMonitoring(tiket);
        }

        public void RemovePendakiFromMonitoring(Tiket tiket)
        {
            _monitoringService.RemoveFromMonitoring(tiket.Id);
        }

        public void HandleStatusUpdate()
        {
            _monitoringService.HandleStatusUpdate();
        }
    }

}

