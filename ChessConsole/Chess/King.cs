using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;

namespace ChessConsole.Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
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

            // N
            position.DefineValues(position.Line - 1, position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // NE
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // E
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // SE
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // S
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // SW
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // W
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // NW
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            return mat;
        }
    }
}
