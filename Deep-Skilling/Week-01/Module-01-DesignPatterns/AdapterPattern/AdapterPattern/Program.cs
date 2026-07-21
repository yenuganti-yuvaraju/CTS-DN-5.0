using System;

namespace AdapterPattern
{
    // Target Interface
    interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // Adaptee 1
    class PayPalGateway
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Payment of Rs.{amount} processed through PayPal.");
        }
    }

    // Adaptee 2
    class StripeGateway
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Payment of Rs.{amount} processed through Stripe.");
        }
    }

    // Adapter for PayPal
    class PayPalAdapter : IPaymentProcessor
    {
        private PayPalGateway paypal = new PayPalGateway();

        public void ProcessPayment(double amount)
        {
            paypal.MakePayment(amount);
        }
    }

    // Adapter for Stripe
    class StripeAdapter : IPaymentProcessor
    {
        private StripeGateway stripe = new StripeGateway();

        public void ProcessPayment(double amount)
        {
            stripe.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor payment1 = new PayPalAdapter();
            payment1.ProcessPayment(500);

            IPaymentProcessor payment2 = new StripeAdapter();
            payment2.ProcessPayment(1000);
        }
    }
}