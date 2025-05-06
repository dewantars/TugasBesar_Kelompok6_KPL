using HikepassApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassApp.View
{
    public class TicketView
    {
        public void DisplayTicket(Ticket ticket)
        {
            Console.WriteLine("\n--- TIKET PENDAKIAN ---");
            Console.WriteLine($"Nama Pemesan : {ticket.Name}");
            Console.WriteLine($"Jalur Pendakian : {ticket.Trail}");
            Console.WriteLine($"Tanggal Naik : {ticket.Date.ToShortDateString()}");
            Console.WriteLine($"Jumlah Peserta : {ticket.Participants}");
        }
    }
}
