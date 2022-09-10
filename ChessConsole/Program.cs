using System;
using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;
using ChessConsole.GameBoard.Exceptions;
using ChessConsole.Chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMovement(origin, destiny);
                }
            }
            catch (BoardException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
