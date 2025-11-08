using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you helped someone in need.",
        "Think of a time you did something difficult but worthwhile.",
        "Think of a time you stood up for what was right."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How can you apply this lesson in your life today?",
        "What could you do differently next time?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", 
               "This activity helps you reflect on times when you demonstrated strength or resilience.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine($"\n{_prompts[rand.Next(_prompts.Count)]}\n");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder the following questions:\n");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {_questions[rand.Next(_questions.Count)]}");
            Thread.Sleep(4000); // short pause instead of spinner
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}

