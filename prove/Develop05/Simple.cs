using System;

public class SimpleGoal : Goal
{
    public bool completed;

    public SimpleGoal(string n, int p) : base(n, p)
    {
        completed = false;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return points;
        }
        return 0;
    }

    public override string GetDisplay()
    {
        if (completed) { return "[X] " + name; }
        return "[ ] " + name;
    }

    public override string SaveString()
    {
        return "Simple|" + name + "|" + points + "|" + completed;
    }
}
