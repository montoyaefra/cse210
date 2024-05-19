using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private static List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void Run()
        {
            Start();
            Random random = new Random();
            Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
            ShowCountDown(3);
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            List<string> items = new List<string>();
            while (DateTime.Now < endTime)
            {
                Console.Write("List an item: ");
                items.Add(Console.ReadLine());
            }
            Console.WriteLine($"You listed {items.Count} items.");
            End();
        }
    }
}
