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
                Board board = new Board(8, 8);

                board.InsertPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.InsertPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.InsertPiece(new King(board, Color.Black), new Position(2, 4));

                Screen.PrintBoard(board);
            }
            catch (BoardException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
