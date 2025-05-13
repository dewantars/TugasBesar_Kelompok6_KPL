using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class Reservasi
    {
        public int Id { get; set; }
        public Pendaki DataPendaki { get; set; }
        public JalurPendakian Jalur { get; set; }
        public DateTime TanggalPendakian { get; set; }
        public string StatusPembayaran { get; set; }
        public string Keterangan { get; set; }
    }

    public enum JalurPendakian
    {
        Cinyiruan,
        Panorama
    }
}
