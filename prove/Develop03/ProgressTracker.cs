using System;
using System.Collections.Generic;
using System.IO;

public class ProgressTracker
{
    // Private attributes
    private string _filePath = "progress.txt";
    private List<SessionRecord> _records;

    // Constructor: creates an empty list, then loads any saved sessions
    public ProgressTracker()
    {
        _records = new List<SessionRecord>();
        Load();
    }

    // Adds a session to the list and saves it to the file
    public void AddSession(SessionRecord record)
    {
        _records.Add(record);

        try
        {
            File.AppendAllText(_filePath, record.ToLine() + Environment.NewLine);
        }
        catch (Exception)
        {
            Console.WriteLine("Could not save your progress to the file.");
        }
    }

    // Streak including today (if you've practiced today); otherwise the streak ending yesterday
    public int GetCurrentStreak()
    {
        HashSet<DateTime> days = GetPracticedDays();

        if (days.Contains(DateTime.Today))
        {
            return CountStreakBackFrom(DateTime.Today, days);
        }

        return CountStreakBackFrom(DateTime.Today.AddDays(-1), days);
    }

    // Streak of consecutive days ending yesterday (used for the score bonus)
    public int GetStreakBeforeToday()
    {
        return CountStreakBackFrom(DateTime.Today.AddDays(-1), GetPracticedDays());
    }

    // Private helper: reads saved sessions from the file
    private void Load()
    {
        if (!File.Exists(_filePath))
        {
            return;
        }

        string[] lines = File.ReadAllLines(_filePath);

        foreach (string line in lines)
        {
            if (line.Trim() == "")
            {
                continue;
            }

            try
            {
                _records.Add(new SessionRecord(line));
            }
            catch (Exception)
            {
                // Skip any line that can't be read instead of crashing
            }
        }
    }

    // Private helper: the set of dates with at least one finished session
    private HashSet<DateTime> GetPracticedDays()
    {
        HashSet<DateTime> days = new HashSet<DateTime>();

        foreach (SessionRecord record in _records)
        {
            days.Add(record.GetDate().Date);
        }

        return days;
    }

    // Private helper: counts consecutive practiced days going backward from the given day
    private int CountStreakBackFrom(DateTime day, HashSet<DateTime> days)
    {
        int streak = 0;

        while (days.Contains(day))
        {
            streak++;
            day = day.AddDays(-1);
        }

        return streak;
    }
}