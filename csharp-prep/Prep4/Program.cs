using System;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        int count = 0;
        int max = int.MinValue;

        while (true)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            if (number == 0)
                break;

            sum += number;
            count++;
            max = Math.Max(max, number);
        }

        if (count == 0)
        {
            Console.WriteLine("No numbers were entered.");
        }
        else
        {
            float average = (float)sum / count;

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The max is: {max}");
        }
    }
}
