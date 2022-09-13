using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;

namespace ChessConsole.Chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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

            // N
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line - 1, position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
            }

            // S
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line + 1, position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line++;
            }

            // E
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line, position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column++;
            }

            // W
            position = new Position(originalLine, originalColumn);
            position.DefineValues(position.Line, position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column--;
            }

            return mat;
        }
    }
}
