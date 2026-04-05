public class Pawn : Piece
{
    private bool _hasMoved;

    public void SetMoved(bool hasMoved)
    {
        _hasMoved = hasMoved;
    }


    public Pawn(List<int> coordinates, int team) : base(coordinates, team)
    {
        _hasMoved = false;
    }

    public override void Move(List<int> _coordinates, List<int> destination)
    {
        
    }

    public override bool[,] GetLegalMoves(List<int> pieceCoordinates, int team, Tile[,] board)
    {
        bool[,] legal = new bool[8, 8];
        
        if (GetTeam() == 0)
        {
            if (pieceCoordinates[0] + 1 < 8 && board[pieceCoordinates[0] + 1, pieceCoordinates[1]].IsEmpty() == true)
            {
                legal[pieceCoordinates[0] + 1, pieceCoordinates[1]] = true;
                if (_hasMoved == false && pieceCoordinates[0] + 2 < 8 && board[pieceCoordinates[0] + 2, pieceCoordinates[1]].IsEmpty() == true && board[pieceCoordinates[0] + 1, pieceCoordinates[1]].IsEmpty() == true)
                {
                    legal[pieceCoordinates[0] + 2, pieceCoordinates[1]] = true;
                }
            }
            if (pieceCoordinates[0] + 1 < 8 && pieceCoordinates[1] + 1 < 8 && board[pieceCoordinates[0] + 1, pieceCoordinates[1] + 1].IsEmpty() == false && board[pieceCoordinates[0] + 1, pieceCoordinates[1] + 1].GetPiece().GetTeam() != team)
            {
                legal[pieceCoordinates[0] + 1, pieceCoordinates[1] + 1] = true;
            }
            if (pieceCoordinates[0] + 1 < 8 && pieceCoordinates[1] - 1 >= 0 && board[pieceCoordinates[0] + 1, pieceCoordinates[1] - 1].IsEmpty() == false && board[pieceCoordinates[0] + 1, pieceCoordinates[1] - 1].GetPiece().GetTeam() != team)
            {
                legal[pieceCoordinates[0] + 1, pieceCoordinates[1] - 1] = true;
            }
        }
        else
        {
            if (pieceCoordinates[0] - 1 >= 0 && board[pieceCoordinates[0] - 1, pieceCoordinates[1]].IsEmpty() == true)
            {
                legal[pieceCoordinates[0] - 1, pieceCoordinates[1]] = true;
                if (_hasMoved == false && pieceCoordinates[0] - 2 >= 0 && board[pieceCoordinates[0] - 2, pieceCoordinates[1]].IsEmpty() == true && board[pieceCoordinates[0] - 1, pieceCoordinates[1]].IsEmpty() == true)
                {
                    legal[pieceCoordinates[0] - 2, pieceCoordinates[1]] = true;
                }   
            }
            if (pieceCoordinates[0] - 1 >= 0 && pieceCoordinates[1] + 1 < 8 && board[pieceCoordinates[0] - 1, pieceCoordinates[1] + 1].IsEmpty() == false && board[pieceCoordinates[0] - 1, pieceCoordinates[1] + 1].GetPiece().GetTeam() != team)
            {
                legal[pieceCoordinates[0] - 1, pieceCoordinates[1] + 1] = true;
            }
            if (pieceCoordinates[0] - 1 >= 0 && pieceCoordinates[1] - 1 >= 0 && board[pieceCoordinates[0] - 1, pieceCoordinates[1] - 1].IsEmpty() == false && board[pieceCoordinates[0] - 1, pieceCoordinates[1] - 1].GetPiece().GetTeam() != team)
            {
                legal[pieceCoordinates[0] - 1, pieceCoordinates[1] - 1] = true;
            }
        }
        return legal;
    }

    public override string GetSymbol()
    {
        if(GetTeam() == 0)
        {
            return "WP";
        }
        else
        {
            return "BP";
        }
    }
}