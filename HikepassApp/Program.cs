using HikepassApp.Controller;
using HikepassApp.Services;
using HikepassApp.View;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("== SISTEM PEMESANAN TIKET PENDAKIAN MALABAR ==\n");

        ConfigService.LoadConfig("config.json");
        ConfigService.ShowAvailableTrails();

        var view = new TicketView();
        var controller = new TicketController(view);
        controller.CreateTicket();

        Console.WriteLine("\nTerima kasih telah menggunakan layanan kami.");
    }
}
