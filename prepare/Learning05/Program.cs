using System;

class Program
{
    // Function 1: Display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function 2: Ask for and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function 3: Ask for and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function 4: Ask for birth year (using out parameter)
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    // Function 5: Return the square of a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 6: Display result
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");

        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;
        Console.WriteLine($"{name}, you will turn {age} this year.");
    }

    // Main function to tie everything together
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int favNumber = PromptUserNumber();
        PromptUserBirthYear(out int birthYear);

        int squared = SquareNumber(favNumber);

        DisplayResult(userName, squared, birthYear);
    }
}
