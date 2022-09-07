using System;

namespace ChessConsole.GameBoard.Exceptions
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}
