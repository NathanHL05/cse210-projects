public class Bishop : Piece
{
    public Bishop(List<int> coordinates, int team) : base(coordinates, team)
    {
    }

    public override void Move(List<int> _coordinates, List<int> destination)
    {
        
    }

    public override bool[,] GetLegalMoves(List<int> _coordinates, int team, Tile[,] board)
    {
        bool[,] legal = new bool[8, 8];

        // Up-Right
        int r = _coordinates[0] + 1;
        int c = _coordinates[1] + 1;
        while (r < 8 && c < 8)
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
            r++; c++;
        }

        // Up-Left
        r = _coordinates[0] + 1;
        c = _coordinates[1] - 1;
        while (r < 8 && c >= 0)
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
            r++; c--;
        }

        // Down-Right
        r = _coordinates[0] - 1;
        c = _coordinates[1] + 1;
        while (r >= 0 && c < 8)
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
            r--; c++;
        }

        // Down-Left
        r = _coordinates[0] - 1;
        c = _coordinates[1] - 1;
        while (r >= 0 && c >= 0)
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
            r--; c--;
        }

        return legal;
    }

    public override string GetSymbol()
    {
        if(GetTeam() == 0)
        {
            return "WB";
        }
        else
        {
            return "BB";
        }
    }
}