using System;
using ChessConsole.GameBoard;
using ChessConsole.GameBoard.Enums;

namespace ChessConsole.Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
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
