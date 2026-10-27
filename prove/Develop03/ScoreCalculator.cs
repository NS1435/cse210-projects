using System;

public class ScoreCalculator
{
    // Private attributes: the tuning numbers live in one place, so they're easy to change
    private int _hintPenalty = 5;                 // points lost per hint
    private double _streakBonusPerDay = 0.05;     // +5% per streak day
    private double _maxStreakBonus = 0.25;        // the bonus never goes above +25%

    // Returns the final score as a whole number
    public int CalculateScore(double accuracy, int hintsUsed, double difficultyMultiplier, int streakDays)
    {
        // Subtract the hint penalty, but never go below zero
        double baseScore = Math.Max(0, accuracy - (hintsUsed * _hintPenalty));

        // Streak bonus grows with each day, up to the cap
        double streakBonus = Math.Min(streakDays * _streakBonusPerDay, _maxStreakBonus);

        double total = baseScore * difficultyMultiplier * (1 + streakBonus);

        return (int)Math.Round(total);
    }
}