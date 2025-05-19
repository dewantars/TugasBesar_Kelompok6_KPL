using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;
using static HikepassLibrary.Model.Tiket;


namespace HikepassLibrary.Service
{
    public class TiketService
    {
        private readonly List<Tiket> _tiketDatabase = new List<Tiket>();

        public Tiket GetTiketById(int id)
        {
            return _tiketDatabase.Find(t => t.Id == id);
        }

        public List<Tiket> GetTiketByKontak(string kontak)
        {
            return _tiketDatabase.FindAll(t => t.Kontak == kontak);
        }

        public void UpdateTiket(Tiket tiket)
        {
            var index = _tiketDatabase.FindIndex(t => t.Id == tiket.Id);
            if (index >= 0)
            {
                _tiketDatabase[index] = tiket;
            }
        }

        public void AddTiket(Tiket tiket)
        {
            _tiketDatabase.Add(tiket);
        }
    }
}
