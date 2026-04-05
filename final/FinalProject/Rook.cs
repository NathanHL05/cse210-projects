public class Rook : Piece
{
    public Rook(List<int> coordinates, int team) : base(coordinates, team)
    {
    }

    public override void Move(List<int> _coordinates, List<int> destination)
    {
        
    }

    public override bool[,] GetLegalMoves(List<int> _coordinates, int team, Tile[,] board)
    {
        bool[,] legal = new bool[8, 8];

        // Up
        int r = _coordinates[0] + 1;
        int c = _coordinates[1];
        while (r < 8)
        {
            if (board[r, c].IsEmpty() == true)
            {
                legal[r, c] = true;
            }
            else
            {
                if (board[r, c].GetPiece().GetTeam() != team)
                {
                    legal[r, c] = true;
                }
                break;
            }
            r++;
        }

        // Down
        r = _coordinates[0] - 1;
        c = _coordinates[1];
        while (r >= 0)
        {
            if (board[r, c].IsEmpty() == true)
            {
                legal[r, c] = true;
            }
            else
            {
                if (board[r, c].GetPiece().GetTeam() != team)
                {
                    legal[r, c] = true;
                }
                break;
            }
            r--;
        }

        // Right
        r = _coordinates[0];
        c = _coordinates[1] + 1;
        while (c < 8)
        {
            if (board[r, c].IsEmpty() == true)
            {
                legal[r, c] = true;
            }
            else
            {
                if (board[r, c].GetPiece().GetTeam() != team)
                {
                    legal[r, c] = true;
                }
                break;
            }
            c++;
        }

        // Left
        r = _coordinates[0];
        c = _coordinates[1] - 1;
        while (c >= 0)
        {
            if (board[r, c].IsEmpty() == true)
            {
                legal[r, c] = true;
            }
            else
            {
                if (board[r, c].GetPiece().GetTeam() != team)
                {
                    legal[r, c] = true;
                }
                break;
            }
            c--;
        }

        return legal;
    }

    public override string GetSymbol()
    {
        if(GetTeam() == 0)
        {
            return "WR";
        }
        else
        {
            return "BR";
        }
    }
}