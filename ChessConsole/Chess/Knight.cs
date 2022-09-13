using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;

namespace ChessConsole.Chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "H";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            int originalLine = Position.Line;
            int originalColumn = Position.Column;

            Position position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 2, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 2, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 2, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 2, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            return mat;
        }
    }
}
