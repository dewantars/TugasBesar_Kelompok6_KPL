//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HikepassLibrary.Model
//{
//    public class RiwayatPembelian
//    {
//        public List<Ticket> TiketYangTelahDibeli { get; set; } = new List<Ticket>();

//        public void TambahRiwayat(Ticket tiket)
//        {
//            TiketYangTelahDibeli.Add(tiket);
//        }

//        public void LihatRiwayat()
//        {
//            foreach (var tiket in TiketYangTelahDibeli)
//            {
//                Console.WriteLine($"Tiket ke {tiket.Tujuan} pada {tiket.TanggalPendakian.ToShortDateString()} dengan harga {tiket.Harga}.");
//            }
//        }
//    }

//}
