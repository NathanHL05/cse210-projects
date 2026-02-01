public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void makeEntry()
    {
        int amount = _entries.Count;
        _entries.Add(new Entry());
        var time = DateTime.Now;

        _entries[amount]._dateTime = time.ToString("dddd, MMMM, d, yyyy, hh:mm");

        Prompt prompter = new Prompt();
        _entries[amount]._prompt = prompter.randomPrompt();
        Console.WriteLine($"{_entries[amount]._prompt}: \n");
        _entries[amount]._entry = Console.ReadLine();
    }

    public void display()
    {
        foreach (Entry x in _entries)
        {
            x.display();
        }
    }

    public void saveFile(string fileName = "MyJournal.txt")
    {
        foreach (Entry x in _entries)
        {
            File.AppendAllLines(fileName, new[] {$"{x._dateTime}\n{x._prompt}\n{x._entry}|"});
        } 
    }

    public void loadFile(string fileName = "MyJournal.txt")
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("This file cannot be found");
            return;
        }
        _entries.Clear();
        string contents = File.ReadAllText(fileName);
        contents = contents.Replace("\r\n", string.Empty);
        Console.WriteLine(contents);
        string[] entries = contents.Split(new string[] {"|"}, StringSplitOptions.None);
        int i = 0;
        foreach (string x in entries)
        {
            if(x == "")
            {
               break; 
            }
            _entries.Insert(i,new Entry());
            string[] types = x.Split(new string[] {"\n"}, StringSplitOptions.None);
            _entries[i]._dateTime = types[0];
            _entries[i]._prompt = types[1];
            _entries[i]._entry = types[2];
            i++;
        }

    }

    

}