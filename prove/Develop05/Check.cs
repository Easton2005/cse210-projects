using System;

public class ChecklistGoal : Goal
{
    public int current;
    public int needed;
    public int bonus;

    public ChecklistGoal(string n, int p, int need, int b) : base(n, p)
    {
        current = 0;
        needed = need;
        bonus = b;
    }

    public override int RecordEvent()
    {
        current++;

        if (current >= needed)
        {
            return points + bonus;
        }

        return points;
    }

    public override string GetDisplay()
    {
        string check = "[ ]";
        if (current >= needed) { check = "[X]"; }

        return check + " " + name + " --- Completed " + current + "/" + needed;
    }

    public override string SaveString()
    {
        return "Checklist|" + name + "|" + points + "|" + current + "|" + needed + "|" + bonus;
    }
}
