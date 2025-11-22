using System;

public class Goal
{
    protected string name;
    protected int points;

    public Goal(string n, int p)
    {
        name = n;
        points = p;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual string GetDisplay()
    {
        return name;
    }

    public virtual string SaveString()
    {
        return "";
    }
}
