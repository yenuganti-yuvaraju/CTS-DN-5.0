using System;

namespace DecoratorPattern
{
    interface INotifier
    {
        void Send();
    }

    class EmailNotifier : INotifier
    {
        public void Send()
        {
            Console.WriteLine("Email Notification Sent");
        }
    }

    abstract class NotifierDecorator : INotifier
    {
        protected INotifier notifier;

        public NotifierDecorator(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public virtual void Send()
        {
            notifier.Send();
        }
    }

    class SMSDecorator : NotifierDecorator
    {
        public SMSDecorator(INotifier notifier) : base(notifier) { }

        public override void Send()
        {
            base.Send();
            Console.WriteLine("SMS Notification Sent");
        }
    }

    class SlackDecorator : NotifierDecorator
    {
        public SlackDecorator(INotifier notifier) : base(notifier) { }

        public override void Send()
        {
            base.Send();
            Console.WriteLine("Slack Notification Sent");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INotifier notifier =
                new SlackDecorator(
                    new SMSDecorator(
                        new EmailNotifier()));

            notifier.Send();
        }
    }
}