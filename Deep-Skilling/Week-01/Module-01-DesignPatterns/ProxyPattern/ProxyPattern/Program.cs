using System;

namespace ProxyPattern
{
    interface IInternet
    {
        void ConnectTo(string website);
    }

    class RealInternet : IInternet
    {
        public void ConnectTo(string website)
        {
            Console.WriteLine("Connected to " + website);
        }
    }

    class ProxyInternet : IInternet
    {
        private RealInternet realInternet = new RealInternet();

        public void ConnectTo(string website)
        {
            if (website.Equals("facebook.com"))
            {
                Console.WriteLine("Access Denied to " + website);
            }
            else
            {
                realInternet.ConnectTo(website);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IInternet internet = new ProxyInternet();

            internet.ConnectTo("google.com");
            internet.ConnectTo("facebook.com");
        }
    }
}