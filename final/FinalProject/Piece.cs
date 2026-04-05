public abstract class Piece
{
    private List<int> _coordinates;
    private int _team;
    private bool _captured;
    private Array[,] _legalmoves;
    private bool _isAttacked;

    public Piece(List<int> coordinates, int team)
    {
        _coordinates = coordinates;
        _team = team;
    }



    public int GetTeam()
    {
        return _team;
    }

    public List<int> GetCoordinates()
    {
        return _coordinates;
    } 

    public abstract void Move(List<int> _coordinates, List<int> destination);

    public abstract bool[,] GetLegalMoves(List<int> _coordinates, int _team, Tile[,] board);

    public abstract string GetSymbol();
}