using System;

public class Fraction
{
    // The top number (numerator)
    private int top;
    // The bottom number (denominator)
    private int bottom;

    // Constructor with no parameters (1/1)
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    // Constructor with one parameter (top / 1)
    public Fraction(int t)
    {
        top = t;
        bottom = 1;
    }

    // Constructor with two parameters (top / bottom)
    public Fraction(int t, int b)
    {
        top = t;
        bottom = b;
    }

    // Getter for top
    public int GetTop()
    {
        return top;
    }

    // Setter for top
    public void SetTop(int t)
    {
        top = t;
    }

    // Getter for bottom
    public int GetBottom()
    {
        return bottom;
    }

    // Setter for bottom
    public void SetBottom(int b)
    {
        bottom = b;
    }

    // Returns the fraction as a string (like "3/4")
    public string GetFractionString()
    {
        string text = top + "/" + bottom;
        return text;
    }

    // Returns the fraction as a decimal (like 0.75)
    public double GetDecimalValue()
    {
        double result = (double)top / (double)bottom;
        return result;
    }
}
