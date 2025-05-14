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

        public void AddPendakiToMonitoring(Pendaki pendaki)
        {
            _monitoringService.AddToMonitoring(pendaki);
        }

        public void RemovePendakiFromMonitoring(Pendaki pendaki)
        {
            _monitoringService.RemoveFromMonitoring(pendaki);
        }
    }

}

