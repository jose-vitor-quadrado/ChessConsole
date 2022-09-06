using ChessConsole.GameBoard.Enums;

namespace ChessConsole.GameBoard
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public Board Board { get; protected set; }
        
        public Piece(Position position, Board board, Color color)
        {
            Position = position;
            Board = board;
            Color = color;
            NumberOfMoves = 0;
        }
    }
}
