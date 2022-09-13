using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;

namespace ChessConsole.Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return position != null && piece.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            int originalLine = Position.Line;
            int originalColumn = Position.Column;

            Position position = new Position(originalLine, originalColumn);
            if (Color == Color.White)
            {
                position.DefineValues(position.Line - 1, position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position = new Position(originalLine, originalColumn);
                position.DefineValues(position.Line - 2, position.Column);
                if (Board.ValidPosition(position) && Free(position) && NumberOfMoves == 0)
                {
                    mat[position.Line, position.Column] = true;
                }

                position = new Position(originalLine, originalColumn);
                position.DefineValues(position.Line - 1, position.Column - 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position = new Position(originalLine, originalColumn);
                position.DefineValues(position.Line - 1, position.Column + 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.DefineValues(position.Line + 1, position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position = new Position(originalLine, originalColumn);
                position.DefineValues(position.Line + 2, position.Column);
                if (Board.ValidPosition(position) && Free(position) && NumberOfMoves == 0)
                {
                    mat[position.Line, position.Column] = true;
                }

                position = new Position(originalLine, originalColumn);
                position.DefineValues(position.Line + 1, position.Column - 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position = new Position(originalLine, originalColumn);
                position.DefineValues(position.Line + 1, position.Column + 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
            }

            return mat;
        }
    }
}
