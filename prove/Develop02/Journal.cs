using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayAll()
    {
        SortEntriesByDate();
        if (Entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (Entry e in Entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry e in Entries)
                {
                    // separator '|' used per assignment simplification
                    outputFile.WriteLine($"{e.Date}|{e.Prompt}|{e.Response}");
                }
            }
            Console.WriteLine($"Saved {Entries.Count} entries to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File not found: {filename}");
                return;
            }

            Entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    Entries.Add(entry);
                }
                else
                {
                    Console.WriteLine("Skipped malformed line in file.");
                }
            }

            SortEntriesByDate();
            Console.WriteLine($"Loaded {Entries.Count} entries from '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public void DisplayEntriesByDate(string date)
    {
        bool found = false;
        foreach (Entry e in Entries)
        {
            if (e.Date == date)
            {
                e.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found for that date.");
        }
    }

    public void SortEntriesByDate()
    {
        Entries.Sort((Entry a, Entry b) => a.Date.CompareTo(b.Date));
    }
}
