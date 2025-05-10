using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class MonitoringService
    {
        private Dictionary<string, string> stateTable = new Dictionary<string, string>
        {
            { "paid_checkin", "checked_in" },
            { "checked_in_checkout", "checked_out" }
        };

        public void HandleTransition(User user, string aksi)
        {
            string key = $"{user.Status}_{aksi}";
            if (stateTable.ContainsKey(key))
            {
                user.Status = stateTable[key];
                Console.WriteLine($"{user.Nama} berhasil {aksi}.");
            }
            else
            {
                Console.WriteLine($"Aksi {aksi} tidak valid untuk {user.Nama}. Status saat ini: {user.Status}");
            }
        }
    }
}
