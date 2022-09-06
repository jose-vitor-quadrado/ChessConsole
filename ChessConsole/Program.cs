using System;
using ChessConsole.GameBoard;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board gb = new Board(8, 8);

            Screen.PrintBoard(gb);
        }
    }
}
