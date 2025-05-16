using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public interface ITiketState
    {
        void Handle(Tiket tiket);
    }
    public class BelumDibayarState : ITiketState
    {
        public void Handle(Tiket tiket)
        {
            tiket.Status =  Tiket.StatusTiket.BelumDibayar;
            Console.WriteLine("Tiket belum dibayar, silakan bayar terlebih dahulu.");
        }
    }

    public class DibayarState : ITiketState
    {
        public void Handle(Tiket tiket)
        {
            tiket.Status = Tiket.StatusTiket.Dibayar;
            Console.WriteLine("Tiket sudah dibayar, Anda bisa melakukan check-in.");
        }
    }

    public class CheckinState : ITiketState
    {
        public void Handle(Tiket tiket)
        {
            tiket.Status = Tiket.StatusTiket.Checkin;
            Console.WriteLine("Tiket sudah check-in, Anda bisa melakukan check-out.");
        }
    }

    public class CheckoutState : ITiketState
    {
        public void Handle(Tiket tiket)
        {
            tiket.Status = Tiket.StatusTiket.Checkout;
            Console.WriteLine("Tiket sudah check-out, pendakian selesai.");
        }
    }

}
