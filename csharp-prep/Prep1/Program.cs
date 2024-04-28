using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is you first name? ");
        string FirstName = Console.ReadLine();

        Console.Write("what is you last name? ");
        string LastName = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"your name is {LastName}, {FirstName}, {LastName}");
    }
}