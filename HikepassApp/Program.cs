using HikepassApp;
using System;
class Program
{
    static void Main(string[] args)
    {
        var payment = new Payment();

        Console.WriteLine("== SIMULASI PEMBAYARAN ==\n");
        Console.Write("Apakah pembayaran berhasil? (y/n): ");
        var input = Console.ReadLine();

        bool isSuccess = input?.ToLower() == "y";

        payment.ProcessPayment(isSuccess);

        Console.WriteLine("\nStatus Akhir:");
        switch (payment.StateMachine.CurrentState)
        {
            case PaymentState.NotPaid:
                Console.WriteLine("Status: Belum Bayar");
                break;
            case PaymentState.WaitingConfirmation:
                Console.WriteLine("Status: Menunggu Konfirmasi");
                break;
            case PaymentState.Paid:
                Console.WriteLine("Status: Sudah Bayar");
                break;
            case PaymentState.Failed:
                Console.WriteLine("Status: Gagal");
                break;
            default:
                Console.WriteLine("Status: Tidak diketahui");
                break;
        }

        Console.WriteLine("\n== SELESAI ==\n");
    }

}
