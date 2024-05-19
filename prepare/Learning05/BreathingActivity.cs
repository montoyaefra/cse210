using System;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            Start();
            int interval = 5; // Each breathe in and out lasts 5 seconds
            for (int i = 0; i < _duration / interval; i++)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(interval / 2);
                Console.WriteLine("Breathe out...");
                ShowCountDown(interval / 2);
            }
            End();
        }
    }
}
