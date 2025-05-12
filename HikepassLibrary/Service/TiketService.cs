using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class TiketService
    {
        private List<Tiket> _daftarTiket = new List<Tiket>(); // In-memory storage

        public void TambahTiket(Tiket tiket)
        {
            _daftarTiket.Add(tiket);
        }
        // Buat user pendaki dummy
       

        public Tiket GetTiketById(int id)
        {
            return _daftarTiket.FirstOrDefault(t => t.Id == id);
        }

        public List<Tiket> GetTiketByKontak(string kontak)
        {
            return _daftarTiket.Where(t => t.Kontak == kontak).ToList();
        }

        public void UpdateTiket(Tiket tiket)
        {
            var existingTiketIndex = _daftarTiket.FindIndex(t => t.Id == tiket.Id);
            if (existingTiketIndex != -1)
            {
                _daftarTiket[existingTiketIndex] = tiket;
            }
        }
    }
}
