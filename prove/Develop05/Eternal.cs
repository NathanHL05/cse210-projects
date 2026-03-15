public class Eternal : Goal
{
    private int _repeated;

    public Eternal(string description, int points, string name, bool complete) : base(description, points, name, complete)
    {
        _repeated = 0;
    }
    public Eternal(string description, int points, int repeated, string name, bool complete) : base(description, points, name, complete)
    {
        _repeated = repeated;
    }

    public override int Points()
    {
        return GetPoints();
    }

    public override string GetProgress()
    {
        return $"-- You've completed this {_repeated} times.";
    }

    public override void AddProgress()
    {
        _repeated++;
    }

    public override void Save(string fileName)
    {
        File.AppendAllLines(fileName, new[] {$"2\n{GetName()}\n{GetDescription()}\n{IsComplete()}\n{GetPoints()}\n{_repeated}|"});
    }
}