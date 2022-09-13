using System;
using System.Collections.Generic;
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
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            InsertPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementNumberOfMoves();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.InsertPiece(piece, destiny);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecrementNumberOfMoves();
            if (capturedPiece != null)
            {
                Board.InsertPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.InsertPiece(piece, origin);
        }

        public void MakeMovement(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can not put yourself in check!");
            }

            if (IsInCheck(Enemy(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheckmate(Enemy(CurrentPlayer)))
            {
                Finished = true;
            }

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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Captured)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardException($"There is no {color} king on the board!");
            }
            foreach (Piece piece in PiecesInGame(Enemy(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if (mat[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void InsertNewPiece(char column, int line, Piece piece)
        {
            Board.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Rook(Board, Color.White));
            InsertNewPiece('c', 2, new Rook(Board, Color.White));
            InsertNewPiece('d', 2, new Rook(Board, Color.White));
            InsertNewPiece('e', 2, new Rook(Board, Color.White));
            InsertNewPiece('e', 1, new Rook(Board, Color.White));
            InsertNewPiece('d', 1, new King(Board, Color.White));

            InsertNewPiece('c', 8, new Rook(Board, Color.Black));
            InsertNewPiece('c', 7, new Rook(Board, Color.Black));
            InsertNewPiece('d', 7, new Rook(Board, Color.Black));
            InsertNewPiece('e', 8, new Rook(Board, Color.Black));
            InsertNewPiece('e', 7, new Rook(Board, Color.Black));
            InsertNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}
