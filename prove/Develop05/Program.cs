using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine("Score: " + score);
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) { CreateGoal(); }
            if (choice == 2) { ListGoals(); }
            if (choice == 3) { RecordEvent(); }
            if (choice == 4) { Save(); }
            if (choice == 5) { Load(); }
        }
    }

    // ---------------------
    // CREATE GOAL
    // ---------------------
    static void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Points Earned: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            SimpleGoal g = new SimpleGoal(name, points);
            goals.Add(g);
        }
        else if (type == 2)
        {
            EternalGoal g = new EternalGoal(name, points);
            goals.Add(g);
        }
        else if (type == 3)
        {
            Console.Write("Times Needed: ");
            int needed = int.Parse(Console.ReadLine());

            Console.Write("Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal g = new ChecklistGoal(name, points, needed, bonus);
            goals.Add(g);
        }
    }

    // ---------------------
    // LIST GOALS
    // ---------------------
    static void ListGoals()
    {
        Console.WriteLine("\n--- Goals ---");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + goals[i].GetDisplay());
        }
    }

    // ---------------------
    // RECORD EVENT
    // ---------------------
    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you complete? ");
        int num = int.Parse(Console.ReadLine()) - 1;

        if (num >= 0 && num < goals.Count)
        {
            int points = goals[num].RecordEvent();
            score += points;

            Console.WriteLine("You earned " + points + " points!");
        }
    }

    // ---------------------
    // SAVE
    // ---------------------
    static void Save()
    {
        StreamWriter writer = new StreamWriter("goals.txt");

        writer.WriteLine(score);

        for (int i = 0; i < goals.Count; i++)
        {
            writer.WriteLine(goals[i].SaveString());
        }

        writer.Close();

        Console.WriteLine("Saved!");
    }

    // ---------------------
    // LOAD
    // ---------------------
    static void Load()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No file found.");
            return;
        }

        goals.Clear();

        string[] lines = File.ReadAllLines("goals.txt");

        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split("|");

            string type = p[0];
            string name = p[1];
            int pts = int.Parse(p[2]);

            if (type == "Simple")
            {
                bool done = bool.Parse(p[3]);
                SimpleGoal g = new SimpleGoal(name, pts);
                g.completed = done;
                goals.Add(g);
            }
            else if (type == "Eternal")
            {
                EternalGoal g = new EternalGoal(name, pts);
                goals.Add(g);
            }
            else if (type == "Checklist")
            {
                int times = int.Parse(p[3]);
                int need = int.Parse(p[4]);
                int bonus = int.Parse(p[5]);

                ChecklistGoal g = new ChecklistGoal(name, pts, need, bonus);
                g.current = times;
                goals.Add(g);
            }
        }

        Console.WriteLine("Loaded!");
    }
}
