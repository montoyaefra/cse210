using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    // Base Activity class
    public abstract class Activity
    {
        public string Date { get; protected set; }
        public int Length { get; protected set; } // Length in minutes

        public Activity(string date, int length)
        {
            Date = date;
            Length = length;
        }

        public virtual double GetDistance() { return 0; }
        public virtual double GetSpeed() { return 0; }
        public virtual double GetPace() { return 0; }

        public string GetSummary()
        {
            return $"{Date} {GetType().Name} ({Length} min): Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace {GetPace():F2} min per mile";
        }
    }

    // Running class
    public class Running : Activity
    {
        private double _distance; // in miles

        public Running(string date, int length, double distance)
            : base(date, length)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;
        public override double GetSpeed() => (_distance / Length) * 60;
        public override double GetPace() => Length / _distance;
    }

    // Cycling class
    public class Cycling : Activity
    {
        private double _speed; // in mph

        public Cycling(string date, int length, double speed)
            : base(date, length)
        {
            _speed = speed;
        }

        public override double GetDistance() => (_speed * Length) / 60;
        public override double GetSpeed() => _speed;
        public override double GetPace() => 60 / _speed;
    }

    // Swimming class
    public class Swimming : Activity
    {
        private int _numberOfLaps; // each lap is 50 meters

        public Swimming(string date, int length, int numberOfLaps)
            : base(date, length)
        {
            _numberOfLaps = numberOfLaps;
        }

        public override double GetDistance() => (_numberOfLaps * 50) / 1609.34; // converting meters to miles
        public override double GetSpeed() => (GetDistance() / Length) * 60;
        public override double GetPace() => Length / GetDistance();
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create activity objects
            Running running = new Running("2024-05-30", 30, 3.0); // 3 miles in 30 minutes
            Cycling cycling = new Cycling("2024-05-30", 45, 15.0); // 15 mph for 45 minutes
            Swimming swimming = new Swimming("2024-05-30", 60, 30); // 30 laps in 60 minutes

            // Store activities in a list
            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            // Display summaries for each activity
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
