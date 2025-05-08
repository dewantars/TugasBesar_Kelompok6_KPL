using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikepassLibrary.Model;

namespace HikepassLibrary.Controller
{
    public class Monitoring
    {
        private Dictionary<string, Dictionary<string, string>> transitionTable = new()
        {
            { "paid", new Dictionary<string, string> { { "checkin", "checked_in" } } },
            { "checked_in", new Dictionary<string, string> { { "checkout", "checked_out" } } }
        };

        public void HandleTransition(User user, string action)
        {
            string currentStatus = user.Status;

            if (transitionTable.ContainsKey(currentStatus) &&
                transitionTable[currentStatus].ContainsKey(action))
            {
                string newStatus = transitionTable[currentStatus][action];

                // Eksekusi handler berdasarkan aksi
                switch (action)
                {
                    case "checkin":
                        CheckInHandler.Execute(user);
                        break;
                    case "checkout":
                        CheckOutHandler.Execute(user);
                        break;
                }

                user.Status = newStatus;
                Console.WriteLine($"Status user diperbarui menjadi: {user.Status}");
            }
            else
            {
                Console.WriteLine($"Transisi dari '{currentStatus}' dengan aksi '{action}' tidak valid.");
            }
        }
        public class CheckInHandler
        {
            public static void Execute(User user)
            {
                Console.WriteLine($"User {user.Name} telah melakukan Check-In.");
            }
        }

        public class CheckOutHandler
        {
            public static void Execute(User user)
            {
                Console.WriteLine($"User {user.Name} telah melakukan Check-Out.");
            }
        }
    }
}
