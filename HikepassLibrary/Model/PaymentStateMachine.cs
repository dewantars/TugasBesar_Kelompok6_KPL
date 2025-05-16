using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Model
{
    public enum PaymentState
    {
        NotPaid,
        WaitingConfirmation,
        Paid,
        Failed
    }
    class PaymentStateMachine
    {
        public PaymentState CurrentState { get; private set; }

        public PaymentStateMachine()
        {
            CurrentState = PaymentState.NotPaid;
        }

        public void SelectPaymentMethode()
        {
            if (CurrentState == PaymentState.NotPaid)
            {
                CurrentState = PaymentState.WaitingConfirmation;
            }
        }

        public void ConfirmPayment()
        {
            if(CurrentState == PaymentState.WaitingConfirmation)
            {
                CurrentState = PaymentState.Paid;
            }
        }

        public void MarkPaymentFailed()
        {
            if(CurrentState == PaymentState.WaitingConfirmation)
            {
                CurrentState = PaymentState.Failed;
            }
        }

        public void RetryPayment()
        {
            if(CurrentState == PaymentState.Failed)
            {
                CurrentState = PaymentState.NotPaid;
            }
        }
    }
}
