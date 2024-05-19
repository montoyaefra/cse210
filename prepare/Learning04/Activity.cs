using System;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Start()
        {
            Console.WriteLine($"Starting {_name}");
            Console.WriteLine(_description);

            while (true)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out _duration) && _duration > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number greater than zero.");
                }
            }

            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            Console.WriteLine("Good job!");
            ShowSpinner(3);
        }

        public abstract void Run();

        protected void ShowSpinner(int seconds)
{
    for (int i = 0; i < seconds * 4; i++)
    {
        Console.Write(".");
        Thread.Sleep(250);
        Console.Write("\b \b");
    }
    Console.WriteLine();
}


        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}
