//Word.cs is responsible for storing an individual word and controlling whether or not it's visible

public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _firstRevealed;
    private bool _lastRevealed;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        _firstRevealed = false;
        _lastRevealed = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
        _firstRevealed = false;
        _lastRevealed = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the original text of the word, whether or not it is hidden
    public string GetText()
    {
        return _text;
    }

    // Reveals the first letter of a hidden word as a hint
    public void RevealFirstLetter()
    {
        _firstRevealed = true;
    }

    // Reveals the last letter of a hidden word as a hint
    public void RevealLastLetter()
    {
        _lastRevealed = true;
    }

    // True if this word can still receive a first-letter hint
    public bool CanRevealFirst()
    {
        if (!_isHidden || _firstRevealed || GetLastLetterIndex() == 0)
        {
            return false;
        }

        // Count how many characters would be showing after this hint
        int revealedAfter = 1;
        if (_lastRevealed)
        {
            revealedAfter++;
        }

        // Always leave at least one underscore
        return revealedAfter < _text.Length;
    }

    // True if this word can still receive a last-letter hint
    public bool CanRevealLast()
    {
        if (!_isHidden || _lastRevealed || GetLastLetterIndex() == 0)
        {
            return false;
        }

        int revealedAfter = 1;
        if (_firstRevealed)
        {
            revealedAfter++;
        }

        return revealedAfter < _text.Length;
    }

    public string GetDisplayString()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Start with all underscores, then fill in any revealed letters
        char[] characters = new char[_text.Length];

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = '_';
        }

        if (_firstRevealed)
        {
            characters[0] = _text[0];
        }

        if (_lastRevealed)
        {
            int lastIndex = GetLastLetterIndex();
            characters[lastIndex] = _text[lastIndex];
        }

        return new string(characters);
    }

    // Private helper: finds the position of the last letter, skipping punctuation
    // so "heart;" gives the position of "t", not ";"
    private int GetLastLetterIndex()
    {
        for (int i = _text.Length - 1; i >= 0; i--)
        {
            if (char.IsLetter(_text[i]))
            {
                return i;
            }
        }

        return 0;
    }
}