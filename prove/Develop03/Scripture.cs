using System;
using System.Collections.Generic;

public class Scripture
{
    // Private attributes
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();
    private bool _nextHintIsFirst = true;   // hints alternate: first letter, last letter, first letter...
    private int _hintsUsed = 0;             // how many hints have been given

    // Constructor: receives a reference and scripture text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the scripture into individual words
        string[] words = text.Split(' ');

        // Create a Word object for each word
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    // Returns the scripture reference and words as a string
    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + " ";

        // Add each word to the display string
        foreach (Word word in _words)
        {
            display += word.GetDisplayString() + " ";
        }

        return display.TrimEnd();
    }

    // Returns just the reference, such as "John 3:16"
    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }

    // Returns the full original scripture text (no reference, nothing hidden)
    public string GetOriginalText()
    {
        string text = "";

        foreach (Word word in _words)
        {
            text += word.GetText() + " ";
        }

        return text.TrimEnd();
    }

    // Returns the total number of words in the scripture
    public int GetWordCount()
    {
        return _words.Count;
    }

    // Returns how many hints have been used so far
    public int GetHintsUsed()
    {
        return _hintsUsed;
    }

    // Hides a specified number of randomly selected visible words
    public void HideRandomWords(int numberToHide)
    {
        // Create a list of words that are still visible
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // Prevent hiding more words than are available
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        // Randomly select and hide words
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);

            visibleWords[index].Hide();

            // Remove the selected word to prevent selecting it again
            visibleWords.RemoveAt(index);
        }
    }

    // Reveals one letter of a random hidden word. Returns false if no hint is possible.
    public bool GiveHint()
    {
        List<Word> candidates = GetHintCandidates(_nextHintIsFirst);

        // If this type of hint has nowhere to go, try the other type
        if (candidates.Count == 0)
        {
            _nextHintIsFirst = !_nextHintIsFirst;
            candidates = GetHintCandidates(_nextHintIsFirst);
        }

        // Nothing left to reveal
        if (candidates.Count == 0)
        {
            return false;
        }

        Word chosen = candidates[_random.Next(candidates.Count)];

        if (_nextHintIsFirst)
        {
            chosen.RevealFirstLetter();
        }
        else
        {
            chosen.RevealLastLetter();
        }

        // Alternate for the next hint
        _nextHintIsFirst = !_nextHintIsFirst;

        // Count this hint (only reached when a hint was actually given)
        _hintsUsed++;

        return true;
    }

    // Private helper: collects the hidden words that can still receive this type of hint
    private List<Word> GetHintCandidates(bool firstLetter)
    {
        List<Word> candidates = new List<Word>();

        foreach (Word word in _words)
        {
            if (firstLetter && word.CanRevealFirst())
            {
                candidates.Add(word);
            }
            else if (!firstLetter && word.CanRevealLast())
            {
                candidates.Add(word);
            }
        }

        return candidates;
    }

    // Checks whether every word is hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}