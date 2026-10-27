// Reference.cs stores the book, chapter, and verse numbers of a scripture.

public class Reference
{
    // Private attributes
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse (passes its work to the range constructor)
    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse)
    {
    }

    // Constructor for a range of verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Returns the scripture reference as a formatted string
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}