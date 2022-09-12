using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;
using ChessConsole.GameBoard.Exceptions;

namespace ChessConsole.Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            InsertPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementNumberOfMoves();
            Piece CapturedPiece = Board.RemovePiece(destiny);
            Board.InsertPiece(piece, destiny);
        }

        public void MakesMove(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in the defined origin position!");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The piece you chosed is not yours!");
            }
            if (!Board.Piece(position).ExistPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen piece!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void InsertPieces()
        {
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.InsertPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.InsertPiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.InsertPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
