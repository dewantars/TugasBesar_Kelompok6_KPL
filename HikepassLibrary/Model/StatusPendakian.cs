using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    class StatusPendakian
    {
        internal static StatusPendakian SudahCheckOut;

        public enum status
        {
            BelumCheckIn,
            SudahCheckIn,
            SudahCheckOut,
        }
    }
}
