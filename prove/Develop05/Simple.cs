class Simple : Goal
{

    public Simple(string description, int points, string name) : base(description, points, name){}

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
}