using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPuzzleCore;

namespace CrossPuzzelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new GameBoard(4, 4);
            Console.WriteLine(gameBoard);
            Console.WriteLine();

            gameBoard.TurnPiece(0, 0);
            //gameBoard.TurnPiece(0, 0);
            //gameBoard.TurnPiece(0, 1);
            Console.WriteLine(gameBoard);

            gameBoard.ResetValue();
            Piece piece = gameBoard.GetPiece(0,0);
            gameBoard.CalcValue(piece);
            Console.WriteLine(piece.Value);
            Console.WriteLine();

            gameBoard.CalcValue();
            Console.WriteLine(gameBoard.ShowValueString());

            Console.ReadLine();
        }
    }
}
