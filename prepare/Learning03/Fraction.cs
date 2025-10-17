using System;

public class Fraction
{
    private int top;
    private int bottom;

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int t)
    {
        top = t;
        bottom = 1;
    }

    public Fraction(int t, int b)
    {
        top = t;
        bottom = b;
    }

    public int GetTop()
    {
        return top;
    }

    public void SetTop(int t)
    {
        top = t;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int b)
    {
        bottom = b;
    }

    public string GetFractionString()
    {
        string text = top + "/" + bottom;
        return text;
    }

    public double GetDecimalValue()
    {
        double result = (double)top / (double)bottom;
        return result;
    }
}
