public class Entry
{
    public string _dateTime;
    public string _prompt;
    public string _entry;

    public void display()
    {
        Console.WriteLine($"{_dateTime}");
        Console.WriteLine($"{_prompt}");
        Console.WriteLine($"{_entry}\n");
    }

}