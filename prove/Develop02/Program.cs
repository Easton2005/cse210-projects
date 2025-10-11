using System;

// EXCEEDING REQUIREMENTS:
// Uses a consistent date format (yyyy-MM-dd) so users can reliably search by date.
// Adds file-exists checks and error messages for save/load operations.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. View entries by date");
            Console.Write("Choose an option (1-6): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a number between 1 and 6.");
                continue;
            }

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                // Use a consistent date format to make searching easier
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
                Console.WriteLine($"Entry added for {date}.");
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save (e.g., journal.txt): ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load (e.g., journal.txt): ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else if (choice == 6)
            {
                Console.Write("Enter a date to view (format: yyyy-MM-dd, e.g., 2025-10-11): ");
                string date = Console.ReadLine();
                journal.DisplayEntriesByDate(date);
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }
}
