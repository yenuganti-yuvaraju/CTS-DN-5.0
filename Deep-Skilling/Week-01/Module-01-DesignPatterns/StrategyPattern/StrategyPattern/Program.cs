using System;

namespace StrategyPattern
{
    interface IPaymentStrategy
    {
        void Pay(int amount);
    }

    class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paid Rs." + amount + " using Credit Card");
        }
    }

    class UpiPayment : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paid Rs." + amount + " using UPI");
        }
    }

    class ShoppingCart
    {
        private IPaymentStrategy paymentStrategy;

        public ShoppingCart(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void Checkout(int amount)
        {
            paymentStrategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart1 = new ShoppingCart(new CreditCardPayment());
            cart1.Checkout(5000);

            ShoppingCart cart2 = new ShoppingCart(new UpiPayment());
            cart2.Checkout(2500);
        }
    }
}