using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class ListPengelola
    {
        private List<Pengelola> pengelolaList;
        public ListPengelola()
        {
            pengelolaList = new List<Pengelola>();
        }
        public void AddPengelola(Pengelola pengelola)
        {
            pengelolaList.Add(pengelola);
        }
        public void RemovePengelola(Pengelola pengelola)
        {
            pengelolaList.Remove(pengelola);
        }
        public Pengelola GetPengelolaById(int id)
        {
            return pengelolaList.FirstOrDefault(p => p.Id == id);
        }
        public List<Pengelola> GetAllPengelola()
        {
            return pengelolaList;
        }
        public void ClearPengelolaList()
        {
            pengelolaList.Clear();
        }
        public int CountPengelola()
        {
            return pengelolaList.Count;
        }
    }
}
