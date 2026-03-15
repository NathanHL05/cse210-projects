public class Checklist : Goal
{
    private int _reps;
    private int _progress;

    private int _reward;


    public Checklist(int reward, int reps, string description, int points, string name) : base(description, points, name)
    {
        _reps = reps;
        _progress = 0;
        _reward = reward;
    }
    public Checklist(int reward, int reps, string description, int points, int progress, string name) : base(description, points, name)
    {
        _reps = reps;
        _progress = progress;
        _reward = reward;
    }

    public override int Points()
    {
        if (IsComplete())
        {
            return GetPoints();
        }

        else
        {
            return _reward;
        }        
    }

    public override string GetProgress()
    {
        return $" -- Current progress: {_progress}/{_reps}";
    }

    public override void AddProgress()
    {
        _progress ++;
        if(_progress == _reps)
        {
            SetComplete(true);
        }
    }    
}