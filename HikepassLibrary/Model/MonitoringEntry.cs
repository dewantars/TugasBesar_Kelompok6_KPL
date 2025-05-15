using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class MonitoringEntry
    {
        public int TiketId { get; set; }
        public string NikPendaki { get; set; }
        public DateTime CheckinTime { get; set; }
        public List<string> NamaPendaki { get; set; } = new List<string>();
        public List<string> BarangBawaanSaatCheckin { get; set; } = new List<string>();
        public List<string> BarangBawaanSaatCheckout { get; set; } = new List<string>();
    }
}
