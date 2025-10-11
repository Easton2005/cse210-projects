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

        foreach (Entry e in Entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry e in Entries)
            {
                outputFile.WriteLine($"{e.Date}|{e.Prompt}|{e.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
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
        }

        SortEntriesByDate();
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
        Entries.Sort((a, b) => a.Date.CompareTo(b.Date));
    }
}
