class Word{
    private string _word;
    private int _length;
    private bool _show;

    public Word(string word)
    {
        _word = word;
        _length = word.Length;
        _show = true;
    }

    public void SetWord(string word)
    {
        _word = word;
        _length = word.Length;
    }

    public void SetVisibility(bool show)
    {
        _show = show;
    }
    public bool GetVisibility()
    {
        return _show;
    }
    public string Get()
    {
        return _word;
    }

    public void Display()
    {
        if (_show)
        {
            Console.Write($"{_word} ");
        }
        else
        {
            for(int i = 0; i<_length; i++)
            {
                Console.Write("_");
            }
            Console.Write(" ");
        }
    }
}