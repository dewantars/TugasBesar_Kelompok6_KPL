using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public class ListPendaki
    {
        public List<Pendaki> PendakiList { get; set; }

        public ListPendaki()
        {
            PendakiList = new List<Pendaki>();
        }

        public void AddPendaki(Pendaki pendaki)
        {
            PendakiList.Add(pendaki);
        }
        public void RemovePendaki(Pendaki pendaki)
        {
            PendakiList.Remove(pendaki);
        }
        public Pendaki GetPendakiById(int id)
        {
            return PendakiList.FirstOrDefault(p => p.Id == id);
        }
        public List<Pendaki> GetAllPendaki()
        {
            return PendakiList;
        }
        public void ClearPendakiList()
        {
            PendakiList.Clear();
        }
        public int CountPendaki()
        {
            return PendakiList.Count;
        }

    }
}
