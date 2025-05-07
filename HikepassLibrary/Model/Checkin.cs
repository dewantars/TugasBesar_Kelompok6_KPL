using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    class Checkin
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime CheckInTime { get; set; }
    }
}
