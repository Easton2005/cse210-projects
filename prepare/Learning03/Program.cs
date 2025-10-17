using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the numerator (top number): ");
        int top = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the denominator (bottom number): ");
        int bottom = int.Parse(Console.ReadLine());

        // Create a new fraction using what the user typed
        Fraction userFraction = new Fraction(top, bottom);

        Console.WriteLine("Your fraction is: " + userFraction.GetFractionString());
        Console.WriteLine("The decimal value is: " + userFraction.GetDecimalValue());
    }
}
