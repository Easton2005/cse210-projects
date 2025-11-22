using System;

public class EternalGoal : Goal
{
    public EternalGoal(string n, int p) : base(n, p) { }

    public override int RecordEvent()
    {
        return points;
    }

    public override string GetDisplay()
    {
        return "[∞] " + name;
    }

    public override string SaveString()
    {
        return "Eternal|" + name + "|" + points;
    }
}
