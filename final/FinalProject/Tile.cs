public class Tile
{
    private bool _empty = true;
    private Piece _piece;
    private bool _isAttacked;

    public void SetPiece(Piece piece)
    {
        _piece = piece;
        _empty = (piece == null);
    }
    public bool IsEmpty()
    {
        return _empty;
    }

    public Piece GetPiece()
    {
        return _piece;
    } 
}