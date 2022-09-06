using System;
using ChessConsole.GameBoard;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);
            Console.WriteLine("Position: " + p);
        }
    }
}
