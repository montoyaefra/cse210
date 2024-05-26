using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalNames();
                    ListGoalDetails();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter goal type (1. Simple 2. Eternal 3. Checklist):");
        string type = Console.ReadLine();

        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter points:");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.WriteLine("Enter target times:");
                int target = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter bonus points:");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Enter the goal number to record:");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[goalNumber - 1];
        goal.RecordEvent();
        _score += goal.GetPoints();
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            _score = int.Parse(reader.ReadLine());
            _goals.Clear();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        var simpleGoal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                        simpleGoal.SetCompletionStatus(bool.Parse(details[3])); // Add this method to SimpleGoal
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]));
                        checklistGoal.SetTimesCompleted(int.Parse(details[3])); // Add this method to ChecklistGoal
                        _goals.Add(checklistGoal);
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}
