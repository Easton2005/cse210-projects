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

        // Cap duration at 30 seconds maximum
        if (_duration > 30)
        {
            Console.WriteLine("\nNote: The reflection activity has a maximum time of 30 seconds.");
            _duration = 30;
            Thread.Sleep(2000);
        }

        Random rand = new Random();
        Console.WriteLine($"\n{_prompts[rand.Next(_prompts.Count)]}\n");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder the following questions:\n");

        int questionTime = 10; // show each question for 10 seconds
        int totalQuestions = Math.Min(_duration / questionTime, _questions.Count);

        for (int i = 0; i < totalQuestions; i++)
        {
            Console.WriteLine($"> {_questions[i]}");
            Thread.Sleep(questionTime * 1000);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}

