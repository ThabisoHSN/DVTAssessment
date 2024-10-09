using System;

namespace Assessment.Classes;

public class Prompts
{
    public int GetValidInput(string message)
    {
        int result;
        Console.WriteLine($"{message}");
        string input = Console.ReadLine() ?? "";

        while (!int.TryParse(input, out result))
        {
            Console.WriteLine("Invalid Input Number");
            Console.WriteLine($"{message}");
            input = Console.ReadLine() ?? "";
        }

        return result;
    }
}
