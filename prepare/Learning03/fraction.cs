using System;

public class Fraction
{
    private double _top;
    private int _bottom;

// CONSTRUCTORS
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

// GETTERS AND SETTERS
    public void GetTop()
    {
        Console.WriteLine(_top);
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public void GetBottom()
    {
        Console.WriteLine(_bottom);
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
// METHODS
    public string GetFractionString()
    {
        string top = _top.ToString();
        string bottom = _bottom.ToString();
        return $"{top}/{bottom}";
    }
    public double GetDecimalValue()
    {

        double decimalValue = _top / _bottom;
        return decimalValue;
    }
}