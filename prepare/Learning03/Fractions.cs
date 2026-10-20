using System;
public class Fraction
{
    // Private attributes
    private int _top;
    private int _bottom;
    // Default constructor: creates 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    // Constructor for whole numbers
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    // Constructor for fractions with a numerator and denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        SetBottom(bottom);
    }
    // Set the denominator, preventing division by zero
    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            _bottom = 1;
        }
    }
    // Set the numerator
    public void SetTop(int top)
    {
        _top = top;
    }
    // Get the numerator
    public int GetTop()
    {
        return _top;
    }
    // Get the denominator
    public int GetBottom()
    {
        return _bottom;
    }
    // Convert the numerator and denominator into a fraction string
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }
    // Convert the fraction into a decimal using floating-point division
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}