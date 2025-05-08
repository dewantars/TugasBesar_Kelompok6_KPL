using HikepassLibrary.Controller;
using HikepassLibrary.Model;


class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("U001", "Agus");

        Monitoring monitor = new Monitoring();

        monitor.HandleTransition(user1, "checkin");
        monitor.HandleTransition(user1, "checkout");
        monitor.HandleTransition(user1, "checkin"); // Tidak valid, sudah checkout
    }
}
