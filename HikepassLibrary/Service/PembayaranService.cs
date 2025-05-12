using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Service
{
    public class PembayaranService
    {
        // Simulasi pengecekan pembayaran berdasarkan ID Pendaki
        public bool SudahMelakukanPembayaran(int idPendaki)
        {
            // Misalnya kita asumsikan pendaki dengan ID genap sudah membayar
            if (idPendaki % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
