using System;

class Word
{
    private string _text;
    private bool _isHidden;

    // CONSTRUCTOR
    public Word(string text)
    {
        _text = text;
        Show();
    }

    public void Hide() 
    {
            int count = _text.Length;
            string chara = "";
            for (int i = 0; i < count; i++)
            {
                chara += "_";
            }
            this._text = chara;
            this._isHidden = true;
    }
    private void Show() 
    {
        _isHidden = false;
    }
    public bool IsHidden() 
    {
        if (this._isHidden)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string GetDisplayText() 
    {
        return $"{_text}";
    }
}
