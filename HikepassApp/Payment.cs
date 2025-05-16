using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HikepassApp
{
    
    public class Payment
    {
        public PaymentStateMachine StateMachine { get; private set; }
        public Payment()
        {
            StateMachine = new PaymentStateMachine();
        }
        public void ProcessPayment (bool isSuccess)
        {
            StateMachine.SelectPaymentMethod();
            if (isSuccess)
            {
                StateMachine.ConfirmPayment();
                Console.WriteLine("Payment successful");
            }
            else
            {
                StateMachine.MarkPaymentFailed();
                Console.WriteLine("Payment failed");
            }
        }
    }

}
