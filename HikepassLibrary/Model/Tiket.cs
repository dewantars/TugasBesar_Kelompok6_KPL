using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public enum StatusTiket
    {
        BelumDibayar,
        Dibayar,
        Checkin,
        Checkout
    }

    public class Tiket
    {
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public bool StatusPembayaran { get; set; }
        public int JumlahPendaki { get; set; }
        public string Kontak { get; set; }
        public Dictionary<string, string> DaftarPendaki { get; set; } // Nik -> Nama
        public bool IsCheckedIn { get; set; }
        public string status {  get; set; }
        public List<string> BarangBawaanSaatCheckin { get; set; } = new List<string>();
        public List<string> BarangBawaanSaatCheckout { get; set; } = new List<string>();
    }

    
}

