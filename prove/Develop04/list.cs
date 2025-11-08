using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped recently?",
        "What are things you are grateful for?"
    };

    public ListingActivity()
        : base("Listing Activity", 
               "This activity helps you reflect on the good things in your life.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine($"\n{_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("You have a few seconds to think...");
        ShowCountDown(5);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            responses.Add(input);
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}
