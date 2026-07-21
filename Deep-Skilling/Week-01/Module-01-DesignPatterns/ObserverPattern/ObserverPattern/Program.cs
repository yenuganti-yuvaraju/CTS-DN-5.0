using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    interface IObserver
    {
        void Update(string message);
    }

    class Subscriber : IObserver
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine(name + " received: " + message);
        }
    }

    class YouTubeChannel
    {
        private List<IObserver> subscribers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            subscribers.Add(observer);
        }

        public void NotifySubscribers(string videoTitle)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Update("New Video Uploaded - " + videoTitle);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            YouTubeChannel channel = new YouTubeChannel();

            Subscriber user1 = new Subscriber("Barnabas");
            Subscriber user2 = new Subscriber("Student");

            channel.Subscribe(user1);
            channel.Subscribe(user2);

            channel.NotifySubscribers("Design Patterns Tutorial");
        }
    }
}