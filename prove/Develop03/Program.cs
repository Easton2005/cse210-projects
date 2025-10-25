using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to begin...");
        Console.ReadLine();

        // Create a few scriptures to choose from
        List<Scripture> scriptures = new List<Scripture>();
        scriptures.Add(new Scripture(new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."));

        Random random = new Random();
        int randomIndex = random.Next(0, scriptures.Count);
        Scripture currentScripture = scriptures[randomIndex];

        bool allHidden = false;

        while (!allHidden)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to end.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            allHidden = currentScripture.HideRandomWords(3);

            if (allHidden)
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words are hidden! Great job memorizing!");
                break;
            }
        }
    }
}
