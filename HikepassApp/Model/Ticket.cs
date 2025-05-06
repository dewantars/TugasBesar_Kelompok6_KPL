using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassApp.Model
{
    public class Ticket
    {
        public string Name { get; set; }
        public string Trail { get; set; }
        public DateTime Date { get; set; }
        public int Participants { get; set; }

        public Ticket(string name, string trail, DateTime date, int participants)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
            if (string.IsNullOrWhiteSpace(trail)) throw new ArgumentException("Trail is required.");
            if (participants <= 0) throw new ArgumentException("Participants must be greater than 0.");

            Name = name;
            Trail = trail;
            Date = date;
            Participants = participants;
        }
    }
}
