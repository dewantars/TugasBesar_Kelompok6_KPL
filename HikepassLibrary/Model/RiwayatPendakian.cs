using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class RiwayatPendakian
    {
        public int Id { get; set; }
        public User Pendaki { get; set; }
        public DateTime TanggalNaik { get; set; }
        public DateTime TanggalTurun { get; set; }

        public RiwayatPendakian(int id, User pendaki, DateTime tanggalNaik, DateTime tanggalTurun)
        {
            Id = id;
            Pendaki = pendaki;
            TanggalNaik = tanggalNaik;
            TanggalTurun = tanggalTurun;
        }
    }

}
