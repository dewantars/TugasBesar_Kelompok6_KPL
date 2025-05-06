using HikepassApp.Model;
using HikepassApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassApp.Controller
{
    public class TicketController
    {
        private readonly TicketView _view;

        public TicketController(TicketView view)
        {
            _view = view;
        }

        public void CreateTicket()
        {
            Console.Write("Masukkan nama Anda: ");
            string name = Console.ReadLine();

            Console.Write("Masukkan jalur pendakian: ");
            string trail = Console.ReadLine();

            Console.Write("Masukkan tanggal pendakian (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Masukkan jumlah peserta: ");
            int participants = int.Parse(Console.ReadLine());

            try
            {
                Ticket ticket = new Ticket(name, trail, date, participants);
                _view.DisplayTicket(ticket);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kesalahan: {ex.Message}");
            }
        }
    }
}
