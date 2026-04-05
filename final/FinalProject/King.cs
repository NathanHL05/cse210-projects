public class King : Piece
{
    public King(List<int> coordinates, int team) : base(coordinates, team)
    {
    }

    public override void Move(List<int> _coordinates, List<int> destination)
    {
        
    }

    public override bool[,] GetLegalMoves(List<int> _coordinates, int team, Tile[,] board)
    {
        bool[,] legal = new bool[8, 8];

        // Up
        if (_coordinates[0] + 1 < 8)
        {
            if (board[_coordinates[0] + 1, _coordinates[1]].IsEmpty() == true || board[_coordinates[0] + 1, _coordinates[1]].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 1, _coordinates[1]] = true;
        }
        
        // Down
        if (_coordinates[0] - 1 >= 0)
        {
            if (board[_coordinates[0] - 1, _coordinates[1]].IsEmpty() == true || board[_coordinates[0] - 1, _coordinates[1]].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 1, _coordinates[1]] = true;
        }
        
        // Right
        if (_coordinates[1] + 1 < 8)
        {
            if (board[_coordinates[0], _coordinates[1] + 1].IsEmpty() == true || board[_coordinates[0], _coordinates[1] + 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0], _coordinates[1] + 1] = true;
        }
        
        // Left
        if (_coordinates[1] - 1 >= 0)
        {
            if (board[_coordinates[0], _coordinates[1] - 1].IsEmpty() == true || board[_coordinates[0], _coordinates[1] - 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0], _coordinates[1] - 1] = true;
        }
        
        // Up-Right
        if (_coordinates[0] + 1 < 8 && _coordinates[1] + 1 < 8)
        {
            if (board[_coordinates[0] + 1, _coordinates[1] + 1].IsEmpty() == true || board[_coordinates[0] + 1, _coordinates[1] + 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 1, _coordinates[1] + 1] = true;
        }
        
        // Up-Left
        if (_coordinates[0] + 1 < 8 && _coordinates[1] - 1 >= 0)
        {
            if (board[_coordinates[0] + 1, _coordinates[1] - 1].IsEmpty() == true || board[_coordinates[0] + 1, _coordinates[1] - 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 1, _coordinates[1] - 1] = true;
        }
        
        // Down-Right
        if (_coordinates[0] - 1 >= 0 && _coordinates[1] + 1 < 8)
        {
            if (board[_coordinates[0] - 1, _coordinates[1] + 1].IsEmpty() == true || board[_coordinates[0] - 1, _coordinates[1] + 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 1, _coordinates[1] + 1] = true;
        }
        
        // Down-Left
        if (_coordinates[0] - 1 >= 0 && _coordinates[1] - 1 >= 0)
        {
            if (board[_coordinates[0] - 1, _coordinates[1] - 1].IsEmpty() == true || board[_coordinates[0] - 1, _coordinates[1] - 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 1, _coordinates[1] - 1] = true;
        }

        return legal;
    }

    public override string GetSymbol()
    {
        if(GetTeam() == 0)
        {
            return "WK";
        }
        else
        {
            return "BK";
        }
    }
}