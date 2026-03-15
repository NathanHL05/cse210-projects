class Simple : Goal
{

    public Simple(string description, int points, string name) : base(description, points, name){}

    public Simple(string description, int points, string name, bool complete) : base(description, points, name, complete){}

    public override int Points()
    {
        return GetPoints();
    }
    public override string GetProgress()
    {
       return"";
    }

    public override void AddProgress()
    {
        SetComplete(true);
    }

    public override void Save(string fileName)
    {
        File.AppendAllLines(fileName, new[] {$"1\n{GetName()}\n{GetDescription()}\n{IsComplete()}\n{GetPoints()}|"});
    }
}