class Scripture
{
    private string _reference;

    private int _verses;

    private List<Verse> _scripture = new List<Verse>();

    public Scripture()
    {
        _reference = "John 3:16";

        _verses = 1;

        _scripture.Add(new Verse(16, "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
    }
    public Scripture(string reference, int verses,List<int> number, List<string> scripture)
    {
        _reference = reference;
        _verses = verses;
        for(int i=0; i < scripture.Count; i++)
        {
            _scripture.Add(new Verse(number[i], scripture[i]));
        }
    }
     public Scripture(string reference, int verses,int number, string scripture)
    {
        _reference = reference;
        _verses = verses;
        _scripture.Add(new Verse(number, scripture));
    }
    
    public void Display()
    {
        Console.WriteLine($"{_reference}");
        for(int i = 0; i < _scripture.Count; i++)
        {
            _scripture[i].Display();
        }
    }

    public void Reduce()
    {
        for(int i =0; i < _scripture.Count; i++)
        {
            _scripture[i].Hide();
        }
    }
}