using System;
 using System.IO; 
class Scripture
{
    private Reference _reference = new Reference();
    private List<Word> _words = new List<Word>();

// CONSTRUCTOR
    public Scripture(string reference, string text)
    {
        _reference.SetReference(reference);
        string[] splitText = text.Split(" ");
        foreach (string word in splitText)
        {
            Word newWord = new Word(word);
            this._words.Add(newWord);
        }
    }
// METHODS
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            bool going = true;
            while (going)
            {
                int r = rand.Next(_words.Count);
                if (!_words[r].IsHidden())
                {
                    _words[r].Hide();
                    going = false;
                }
                else
                {
                    if (this.IsCompletelyHidden())
                    {
                        return;
                    }
                }
            }
            
        }
    }
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
    public string GetDisplayText()
    {
        string finalText = "";
        foreach (Word word in _words)
        {
            finalText += word.GetDisplayText() + " ";
        }
        string finalRef = _reference.GetDisplayText();
        return $"{finalRef} {finalText}";
    }
}
