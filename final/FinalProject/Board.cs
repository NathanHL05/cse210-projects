using System;
using System.Collections.Generic;

public class Board
{
    private Tile[,] _board;
    private bool _checkmate;

    public Tile[,] GetBoard()
    {
        return _board;
    }

    public bool MovePiece(List<int> pieceCoor, List<int> destinationCoor, int team)
    {
        Piece movingPiece = _board[pieceCoor[0], pieceCoor[1]].GetPiece();
        Piece capturedPiece = _board[destinationCoor[0], destinationCoor[1]].GetPiece();
        List<int> kingCoor = new List<int>();

        _board[destinationCoor[0], destinationCoor[1]].SetPiece(movingPiece);
        _board[pieceCoor[0], pieceCoor[1]].SetPiece(null);

        for (int row = 0; row < _board.GetLength(0); row++)
        {
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                Piece p = _board[row, col].GetPiece();
                if (p != null && p is King && p.GetTeam() == team)
                {
                    kingCoor.Add(row);
                    kingCoor.Add(col);
                    break;
                }
            }
            if (kingCoor.Count > 0) break;
        }

        if(IsCheck(kingCoor, team) == true)
        {
            _board[pieceCoor[0], pieceCoor[1]].SetPiece(movingPiece);
            _board[destinationCoor[0], destinationCoor[1]].SetPiece(capturedPiece);

            Console.WriteLine("Invalid move, king is in check");
            return false;
        }

        if(movingPiece is Pawn pawn)
        {
            pawn.SetMoved(true);
        }
        return true;
    }
    

    public void StartGame()
    {
        _board = new Tile[8, 8];

        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                _board[r, c] = new Tile();
            }
        }

        SetupStandardRank(0, 0);
        for (int i = 0; i < 8; i++)
        {
            _board[1, i].SetPiece(new Pawn(new List<int> { 1, i }, 0));
        }

        SetupStandardRank(7, 1);
        for (int i = 0; i < 8; i++)
        {
            _board[6, i].SetPiece(new Pawn(new List<int> { 6, i }, 1));
        }
    }

    private void SetupStandardRank(int row, int team)
    {
        _board[row, 0].SetPiece(new Rook(new List<int> { row, 0 }, team));
        _board[row, 1].SetPiece(new Knight(new List<int> { row, 1 }, team));
        _board[row, 2].SetPiece(new Bishop(new List<int> { row, 2 }, team));
        _board[row, 3].SetPiece(new Queen(new List<int> { row, 3 }, team));
        _board[row, 4].SetPiece(new King(new List<int> { row, 4 }, team));
        _board[row, 5].SetPiece(new Bishop(new List<int> { row, 5 }, team));
        _board[row, 6].SetPiece(new Knight(new List<int> { row, 6 }, team));
        _board[row, 7].SetPiece(new Rook(new List<int> { row, 7 }, team));
    }

    public bool IsCheckmate(int team)
    {
        return CheckStalemate(team) && IsCheck(FindKing(team), team);
    }

    public bool CheckMove(List<int> pieceCoor, int team, List<int> destinationCoor, Tile tile)
    {
        bool[,] legalMoves = tile.GetPiece().GetLegalMoves(pieceCoor, team, _board);
        if (legalMoves[destinationCoor[0], destinationCoor[1]] == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsCheck(List<int> kingCoor, int team)
    {
        for (int row = 0; row < _board.GetLength(0); row++)
        {
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                if (_board[row, col].IsEmpty() == true)
                {}
                else if (_board[row, col].GetPiece().GetTeam() == team){}
                else{
                    bool[,] legalMoves = _board[row, col].GetPiece().GetLegalMoves(new List<int> { row, col }, _board[row, col].GetPiece().GetTeam(), _board);
                    if(legalMoves[kingCoor[0], kingCoor[1]] == true)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool CheckStalemate(int team)
    {
        List<int> kingCoor = FindKing(team);


        for (int row = 0; row < _board.GetLength(0); row++)
        {
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                Tile tile = _board[row, col];
                if (!tile.IsEmpty() && tile.GetPiece().GetTeam() == team)
                {
                    Piece movingPiece = tile.GetPiece();
                    bool[,] legalMoves = movingPiece.GetLegalMoves(new List<int> { row, col }, team, _board);

                    for (int r = 0; r < 8; r++)
                    {
                        for (int c = 0; c < 8; c++)
                        {
                            if (legalMoves[r, c] == true)
                            {
                                Piece capturedPiece = _board[r, c].GetPiece();
                                _board[r, c].SetPiece(movingPiece);
                                _board[row, col].SetPiece(null);

                                bool stillInCheck = IsCheck(FindKing(team), team);

                                _board[row, col].SetPiece(movingPiece);
                                _board[r, c].SetPiece(capturedPiece);

                                if (stillInCheck == false) return false;
                            }
                        }
                    }
                }
            }
        }
        return true;
    }

    private List<int> FindKing(int team)
    {
        List<int> kingCoor = new List<int>();
        for (int row = 0; row < _board.GetLength(0); row++)
        {
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                Piece p = _board[row, col].GetPiece();
                if (p != null && p is King && p.GetTeam() == team)
                {
                    kingCoor.Add(row);
                    kingCoor.Add(col);
                    return kingCoor;
                }
            }
        }
        return kingCoor;
    }

    public void DisplayBoard()
    {
        Console.WriteLine("    a    b    c    d    e    f    g    h");
        Console.WriteLine("  +----+----+----+----+----+----+----+----+");
        for (int r = 7; r >= 0; r--)
        {
            Console.Write($"{r + 1} |");
            for (int c = 0; c < 8; c++)
            {
                Piece p = _board[r, c].GetPiece();
                string symbol = (p == null) ? "  " : p.GetSymbol();
                Console.Write($" {symbol} |");
            }
            Console.WriteLine($" {r + 1}");
            Console.WriteLine("  +----+----+----+----+----+----+----+----+");
        }
        Console.WriteLine("    a    b    c    d    e    f    g    h");
    }
}