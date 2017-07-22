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
            var gameBoard = new GameBoard(4, 3);
            Console.WriteLine(gameBoard);
            gameBoard.CalcValue();
            Console.WriteLine(gameBoard.ShowValueString());

            string input = null;
            do
            {
                input = Console.ReadLine();
                var inputPos = input.Split(',');
                int x = Convert.ToInt32(inputPos[0]);
                int y = Convert.ToInt32(inputPos[1]);
                gameBoard.TurnPiece(x, y);
                Console.WriteLine(gameBoard);
                gameBoard.CalcValue();
                Console.WriteLine(gameBoard.ShowValueString());

            } while (!string.IsNullOrEmpty(input));

            Console.ReadLine();
        }
    }
}
