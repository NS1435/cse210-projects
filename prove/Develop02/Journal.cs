using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries = [];

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using StreamWriter outputFile = new(filename);
        foreach (Entry entry in _entries)
        {
            outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
        }
    }

public void LoadFromFile(string filename)
{
    string[] lines = File.ReadAllLines(filename);
    _entries.Clear();

    foreach (string line in lines)
    {
        string[] parts = line.Split("~|~", 3);

        if (parts.Length == 3)
        {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };

                _entries.Add(entry);
        }
    }
}
}

