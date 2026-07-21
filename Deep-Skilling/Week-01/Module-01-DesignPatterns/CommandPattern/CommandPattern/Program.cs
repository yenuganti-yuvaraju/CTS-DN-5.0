using System;

namespace CommandPattern
{
    interface ICommand
    {
        void Execute();
    }

    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    class TurnOnCommand : ICommand
    {
        private Light light;

        public TurnOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    class TurnOffCommand : ICommand
    {
        private Light light;

        public TurnOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
    }

    class RemoteControl
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();

            ICommand onCommand = new TurnOnCommand(light);
            ICommand offCommand = new TurnOffCommand(light);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(onCommand);
            remote.PressButton();

            remote.SetCommand(offCommand);
            remote.PressButton();
        }
    }
}