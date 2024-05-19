using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");

                string choice = Console.ReadLine();

                if (choice == "4")
                    break;

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                        continue;
                }

                activity.Run();
            }
        }
    }
}
