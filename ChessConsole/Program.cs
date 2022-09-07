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
            ChessPosition position = new ChessPosition('c', 7);
            Console.WriteLine(position);
            Console.WriteLine(position.ToPosition());
        }
    }
}
