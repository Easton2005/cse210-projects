using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        // Step 1: Determine the letter grade
        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Step 2: Stretch Challenge - determine the + or - sign
        string sign = "";
        int lastDigit = grade % 10;

        if (letter != "F" && letter != "A") // Only apply to B, C, D
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A")
        {
            // A- is allowed, but no A+
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        

        // Step 3: Print the letter grade with sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Step 4: Pass/Fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Keep working hard! You'll do better next time!");
        }
    }
}
