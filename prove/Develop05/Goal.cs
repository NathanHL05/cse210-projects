public abstract class Goal
{
    private string _name;
    private string _description;
    private bool _complete;

    private int _points;

    public bool IsComplete()
    {
        return _complete;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetComplete(bool complete)
    {
        _complete = complete;
    }

    public int GetPoints()
    {
        return _points;
    }

    public Goal(string description, int points, string name, bool complete)
    {
        _description = description;

        _points = points;

        _name = name;
    }

    public Goal(string description, int points, string name)
    {
        _description = description;

        _points = points;

        _complete = false;

        _name = name;
    }

    public abstract int Points();

    public abstract string GetProgress();

    public void DisplayGoal()
    {
        if (IsComplete())
        {
            Console.Write("[X] ");
        }
        else
        {
            Console.Write("[ ] ");
        }
        Console.WriteLine($"{_name} ({_description}) {GetProgress()}");
    }

    public abstract void AddProgress();
}