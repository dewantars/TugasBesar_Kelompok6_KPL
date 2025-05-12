using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class PendakiService
    {
        private List<Pendaki> _daftarPendaki = new List<Pendaki>();

        public PendakiService()
        {
            // Tambahkan beberapa pendaki awal
            _daftarPendaki.Add(new Pendaki
            {
                Id = 1,
                Nama = "pendaki1",
                Kontak = "08123456789",
                Alamat = "Jakarta",
                Nik = "123456789012345",
                Usia = 25
            });

            _daftarPendaki.Add(new Pendaki
            {
                Id = 2,
                Nama = "pendaki2",
                Kontak = "08987654321",
                Alamat = "Bandung",
                Nik = "987654321098765",
                Usia = 22
            });
        }

        public Pendaki GetPendakiByUsername(string username)
        {
            return _daftarPendaki.FirstOrDefault(p => p.Nama == username);
        }

        public void TambahPendaki(Pendaki pendaki)
        {
            if (_daftarPendaki.Any(p => p.Nik == pendaki.Nik))
            {
                Console.WriteLine("Pendaki dengan NIK tersebut sudah ada.");
                return;
            }

            _daftarPendaki.Add(pendaki);
        }
    }
}
