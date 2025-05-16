using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Service
{
    public class TiketStatusTransition
    {
        public static readonly Dictionary<Tiket.StatusTiket, Dictionary<string, Tiket.StatusTiket>> StatusTransitions = new()
        {
            { Tiket.StatusTiket.BelumDibayar, new Dictionary<string, Tiket.StatusTiket>
                {
                    { "bayar", Tiket.StatusTiket.Dibayar }
                }
            },
            { Tiket.StatusTiket.Dibayar, new Dictionary<string, Tiket.StatusTiket>
                {
                    { "checkin", Tiket.StatusTiket.Checkin }
                }
            },
            { Tiket.StatusTiket.Checkin, new Dictionary<string, Tiket.StatusTiket>
                {
                    { "checkout", Tiket.StatusTiket.Checkout }
                }
            },
            { Tiket.StatusTiket.Checkout, new Dictionary<string, Tiket.StatusTiket>
                {
                    { "selesai", Tiket.StatusTiket.Selesai }
                }
            }
        };

        public static Tiket.StatusTiket GetNextStatus(Tiket.StatusTiket currentStatus, string action)
        {
            if (StatusTransitions.ContainsKey(currentStatus) && StatusTransitions[currentStatus].ContainsKey(action))
            {
                return StatusTransitions[currentStatus][action];
            }
            else
            {
                throw new InvalidOperationException("Invalid action for the current status.");
            }
        }
    }


}
