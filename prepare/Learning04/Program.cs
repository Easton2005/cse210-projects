using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for student info
        Console.Write("Enter the student's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the topic: ");
        string topic = Console.ReadLine();

        Console.WriteLine();

        // Create a basic assignment using what the user typed
        Assignment a = new Assignment(name, topic);
        Console.WriteLine(a.GetSummary());
        Console.WriteLine();

        // Create a math assignment
        Console.Write("Enter the math section: ");
        string section = Console.ReadLine();

        Console.Write("Enter the problem numbers: ");
        string problems = Console.ReadLine();

        MathAssignment m = new MathAssignment(name, topic, section, problems);
        Console.WriteLine();
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());
        Console.WriteLine();

        // Create a writing assignment
        Console.Write("Enter the title of the writing assignment: ");
        string title = Console.ReadLine();

        WritingAssignment w = new WritingAssignment(name, topic, title);
        Console.WriteLine();
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInfo());
    }
}
