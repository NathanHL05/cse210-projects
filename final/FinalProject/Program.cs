using System;

class Program
{
    

    static void Main(string[] args)
    {
        while(true)
        {
            Board board = new Board();
            bool checkMate = false;
            bool stalemate = false;

            Console.WriteLine("Welcome the Chess!");
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();
            board.StartGame();

            int turn = 0;
            while(checkMate == false && stalemate == false)
            {
                int team = 0;
                board.DisplayBoard();
                if(turn%2 == 0)
                {
                    team = 0;
                    Console.WriteLine("White to play");
                }
                else
                {
                    team = 1;
                    Console.WriteLine("Black to play");
                }
                bool turnComplete = false;
                while (!turnComplete)
                {
                    string pieceCoordinates = "";
                    List<int> pieceCoor = new List<int>();

                    // Piece Selection
                    while (true)
                    {
                        Console.WriteLine("Which piece would you like to move? ex: a2");
                        pieceCoordinates = GetCoordinates();
                        pieceCoor = UserInputToBoard(pieceCoordinates);

                        if (board.GetBoard()[pieceCoor[0], pieceCoor[1]].IsEmpty() == true)
                        {
                            Console.WriteLine("There is no piece there.");
                        }
                        else if (CheckTeam(pieceCoor, team, board.GetBoard()) == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Selected piece is not on your team.");
                        }
                    }

                    Tile tile = board.GetBoard()[pieceCoor[0], pieceCoor[1]];
                    while (true)
                    {
                        Console.WriteLine("Where would you like to move it? ex: a4 (or 'q' to pick a different piece)");
                        
                        string destinationInput = GetCoordinates();
                        if (destinationInput == "q")
                        {
                            break; 
                        }
                        

                        List<int> destinationCoor = UserInputToBoard(destinationInput);
                        if (board.CheckMove(pieceCoor, team, destinationCoor, tile) == true)
                        {
                            if (board.MovePiece(pieceCoor, destinationCoor, team))
                            {
                                turnComplete = true;
                                break;
                            }
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("Invalid move");
                        }
                    }
                }

                int opponent; 
                if(team == 0)
                {
                    opponent = 1;
                }
                else
                {
                    opponent = 0;
                }


                if (board.IsCheckmate(opponent))
                {
                    checkMate = true;
                    board.DisplayBoard();
                    Console.WriteLine("Checkmate!");
                    if (team == 0)
                    {
                        Console.WriteLine("White wins!");
                    }
                    else
                    {
                        Console.WriteLine("Black wins!");
                    }
                    
                    break;
                }
                else if (board.CheckStalemate(opponent))
                {
                    board.DisplayBoard();
                    stalemate = true;
                    Console.WriteLine("Stalemate!");
                    Console.WriteLine("Nobody wins!");
                    break;
                }
                turn++; 
            }
            Console.WriteLine("Would you like to play again? (y/n)");
            string playAgain = Console.ReadLine();
            if(playAgain == "n")
            {
                break;
            }
        }
    }

    
    public static bool CheckTeam(List<int> coordinates, int team, Tile[,] board)
    {
        if(board[coordinates[0], coordinates[1]].GetPiece().GetTeam() == team)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string GetCoordinates()
    {
        bool complete = false;
        string coordinates = "";
        while (complete == false)
        {
            coordinates = Console.ReadLine().ToLower();
            if (coordinates == "q") return "q";

            if (coordinates.Length != 2)
            {
                Console.WriteLine("Invalid input");
            }
            else if(coordinates[0] < 'a' || coordinates[0] > 'h' || coordinates[1] < '1' || coordinates[1] > '8')
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                complete = true;
            }
        }
        return coordinates;
    }
    public static List<int> UserInputToBoard(string userCoordinate)
    {
        List<int> boardCoordinate = new List<int>();
        int coor = int.Parse(userCoordinate[1].ToString());
        boardCoordinate.Add(coor-1);
        switch (userCoordinate[0])
        {
            case 'a':
                boardCoordinate.Add(0);
                break;
            case 'b':
                boardCoordinate.Add(1);
                break;
            case 'c':
                boardCoordinate.Add(2);
                break;
            case 'd':
                boardCoordinate.Add(3);
                break;
            case 'e':
                boardCoordinate.Add(4);
                break;
            case 'f':
                boardCoordinate.Add(5);
                break;
            case 'g':
                boardCoordinate.Add(6);
                break;
            case 'h':
                boardCoordinate.Add(7);
                break;
            default:
                break;
        }
        
        return boardCoordinate;
    }
}