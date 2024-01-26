using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public string GetDisplayText()
    {
        if (_endVerse != 0)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        
    }
    public void SetReference(string ref1)
    {
        // Setting _book
        List<string> refs = ref1.Split(" ").ToList();
        _book = refs[0];

        // Setting _chapter
        string num = refs[1];
        List<string> nums = num.Split(":").ToList();
        int x = Int32.Parse(nums[0]);
        _chapter = x;

        // Setting _verse & _endVerse
        List<string> nums2 = nums[1].Split("-").ToList();
        int y = Int32.Parse(nums2[0]);
        _verse = y;
        if (nums2.Count == 2)
        {
            int z = Int32.Parse(nums2[1]);
            _endVerse = z;
        }
        else
        {
            _endVerse = 0;
        }
    }
}
