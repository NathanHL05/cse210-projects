class Verse
{
    private int _number;
    private List<Word> _verse = new List<Word>();
    public Verse(int number, string input)
    {
        SetVerse(number, input);
    }

    public void SetVerse(int number, string input)
    {
        _number = number;

        List<string> parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        for(int i = 0; i < parts.Count; i++)
        {
            _verse.Add(new Word(parts[i]));
        }
    }

    public void Display()
    {
        Console.Write($"\n{_number} ");
        for(int i =0; i < _verse.Count; i++)
        {
            _verse[i].Display();
        }
    }

    public void Hide()
    {
        Random rand = new Random();
        int total = _verse.Count;
        int section = (int)Math.Ceiling((double)total/5);
        int i = 0;
        int tries = 0;
        while (i < section)
        {
            int value = rand.Next(0, total);
            if (_verse[value].GetVisibility())
            {
                i++;
                _verse[value].SetVisibility(false);
            }
            tries++;
            if(tries > 100)
            {
                break;
            }
        }
    }
}