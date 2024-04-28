using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string userInput = Console.ReadLine();
        int percentage = int.Parse(userInput);

        string grade = "";

        if (percentage >= 90)
        {
            grade = "A";
        }
        else if (percentage >= 80)
        {
            grade = "B";
        }
        else if (percentage >= 70)
        {
            grade = "C";
        }
        else if (percentage >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine($"Your grade is: {grade}");

        if (percentage >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You not passed");
        }
    }
}
