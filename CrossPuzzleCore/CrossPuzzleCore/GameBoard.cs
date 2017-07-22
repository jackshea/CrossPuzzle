using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CrossPuzzleCore
{
    public class GameBoard
    {
        public int Height { get; }
        public int Width { get; }
        private Piece[,] pieces;

        public GameBoard(int height, int width)
        {
            Height = height;
            Width = width;
            pieces = new Piece[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    pieces[i, j] = new Piece
                    {
                        Position = new Vector(j, i),
                        PieceDir = PieceDirection.Up,
                        Value = 0
                    };
                }
            }
        }

        public void TurnPiece(int x, int y)
        {
            Piece piece = GetPiece(x, y);
            if (piece == null)
            {
                return;
            }

            piece.Turn();
            Piece nextPiece = GetNextPiece(piece);
            while (nextPiece != null)
            {
                nextPiece.Turn();
                nextPiece = GetNextPiece(nextPiece);
            }
        }

        public Piece GetNextPiece(Piece currentPiece)
        {
            return GetNextPiece(currentPiece.Position.X, currentPiece.Position.Y, currentPiece.PieceDir);
        }

        public Piece GetNextPiece(int x, int y, PieceDirection dir)
        {
            switch (dir)
            {
            case PieceDirection.Up:
                y--;
                break;
            case PieceDirection.Down:
                y++;
                break;
            case PieceDirection.Left:
                x--;
                break;
            case PieceDirection.Right:
                x++;
                break;
            }

            return GetPiece(x, y);
        }

        public Piece GetPiece(int x, int y)
        {
            if (x < 0 || x >= Width)
            {
                return null;
            }

            if (y < 0 || y >= Height)
            {
                return null;
            }

            return pieces[y, x];
        }

        public void CalcValue(Piece piece)
        {
            if (piece.Value.HasValue)
            {
                return;
            }
            int value = 0;
            var pieceStack = new Stack<Piece>();
            pieceStack.Push(piece);
            Piece nextPiece = GetNextPiece(piece.Position.X, piece.Position.Y, piece.PieceDir.GetNextDirection());
            while (nextPiece != null)
            {
                if (nextPiece.Value.HasValue)
                {
                    value = nextPiece.Value.Value;
                    break;
                }

                pieceStack.Push(nextPiece);
                nextPiece = GetNextPiece(nextPiece.Position.X, nextPiece.Position.Y, nextPiece.PieceDir.GetNextDirection());
            }


            foreach (Piece piece1 in pieceStack)
            {
                value++;
                piece1.Value = value;
            }
        }

        public void CalcValue()
        {
            ResetValue();
            foreach (Piece piece in pieces)
            {
                if (piece.Value.HasValue)
                {
                    continue;
                }

                CalcValue(piece);
            }
        }

        public string ShowValueString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    string s = pieces[i, j].ToValueString();
                    sb.Append(s);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void ResetValue()
        {
            foreach (Piece piece in pieces)
            {
                piece.Value = null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(pieces[i, j].ToArrowString());
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}