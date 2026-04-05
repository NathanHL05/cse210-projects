public class Knight : Piece
{
    public Knight(List<int> coordinates, int team) : base(coordinates, team)
    {
    }

    public override void Move(List<int> _coordinates, List<int> destination)
    {
        
    }

    public override bool[,] GetLegalMoves(List<int> _coordinates, int team, Tile[,] board)
    {
        bool[,] legal = new bool[8, 8];

        if (_coordinates[0] + 2 < 8 && _coordinates[1] + 1 < 8)
        {
            if (board[_coordinates[0] + 2, _coordinates[1] + 1].IsEmpty() == true || board[_coordinates[0] + 2, _coordinates[1] + 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 2, _coordinates[1] + 1] = true;
        }
        if (_coordinates[0] + 2 < 8 && _coordinates[1] - 1 >= 0)
        {
            if (board[_coordinates[0] + 2, _coordinates[1] - 1].IsEmpty() == true || board[_coordinates[0] + 2, _coordinates[1] - 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 2, _coordinates[1] - 1] = true;
        }
        if (_coordinates[0] - 2 >= 0 && _coordinates[1] + 1 < 8)
        {
            if (board[_coordinates[0] - 2, _coordinates[1] + 1].IsEmpty() == true || board[_coordinates[0] - 2, _coordinates[1] + 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 2, _coordinates[1] + 1] = true;
        }
        if (_coordinates[0] - 2 >= 0 && _coordinates[1] - 1 >= 0)
        {
            if (board[_coordinates[0] - 2, _coordinates[1] - 1].IsEmpty() == true || board[_coordinates[0] - 2, _coordinates[1] - 1].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 2, _coordinates[1] - 1] = true;
        }
        if (_coordinates[0] + 1 < 8 && _coordinates[1] + 2 < 8)
        {
            if (board[_coordinates[0] + 1, _coordinates[1] + 2].IsEmpty() == true || board[_coordinates[0] + 1, _coordinates[1] + 2].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 1, _coordinates[1] + 2] = true;
        }
        if (_coordinates[0] + 1 < 8 && _coordinates[1] - 2 >= 0)
        {
            if (board[_coordinates[0] + 1, _coordinates[1] - 2].IsEmpty() == true || board[_coordinates[0] + 1, _coordinates[1] - 2].GetPiece().GetTeam() != team)
                legal[_coordinates[0] + 1, _coordinates[1] - 2] = true;
        }
        if (_coordinates[0] - 1 >= 0 && _coordinates[1] + 2 < 8)
        {
            if (board[_coordinates[0] - 1, _coordinates[1] + 2].IsEmpty() == true || board[_coordinates[0] - 1, _coordinates[1] + 2].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 1, _coordinates[1] + 2] = true;
        }
        if (_coordinates[0] - 1 >= 0 && _coordinates[1] - 2 >= 0)
        {
            if (board[_coordinates[0] - 1, _coordinates[1] - 2].IsEmpty() == true || board[_coordinates[0] - 1, _coordinates[1] - 2].GetPiece().GetTeam() != team)
                legal[_coordinates[0] - 1, _coordinates[1] - 2] = true;
        }

        return legal;
    }

    public override string GetSymbol()
    {
        if(GetTeam() == 0)
        {
            return "WN";
        }
        else
        {
            return "BN";
        }
    }
}