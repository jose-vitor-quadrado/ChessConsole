using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;

namespace ChessConsole.Chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
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

            // NW
            Position position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Line - 1, position.Column - 1);
            }

            // NE
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Line - 1, position.Column + 1);
            }

            // SE
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Line + 1, position.Column + 1);
            }

            // SW
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.DefineValues(position.Line + 1, position.Column - 1);
            }

            return mat;
        }
    }
}
