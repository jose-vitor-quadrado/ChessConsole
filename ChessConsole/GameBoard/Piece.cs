using ChessConsole.GameBoard.Enums;

namespace ChessConsole.GameBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public Board Board { get; protected set; }
        
        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfMoves = 0;
        }

        public void IncrementNumberOfMoves()
        {
            NumberOfMoves++;
        }

        public bool ExistPossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
