using System;

namespace SingletonPattern
{
    public sealed class Logger
    {
        private static Logger instance;

        private Logger()
        {
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }

            return instance;
        }

        public void ShowMessage()
        {
            Console.WriteLine("Singleton Pattern Implemented Successfully");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.GetInstance();
            logger.ShowMessage();
        }
    }
}