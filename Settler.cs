using System;
using System.Collections.Generic;
using System.Text;

namespace Settler
{
    class Settler
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Life { get; set; }
        public bool Alive { get; set; }

        public void Move(Cell[,] board)
        {
            Random random = new Random();
            int direction = random.Next(0, 4);
            int newX = X;
            int newY = Y;
            switch (direction)
            {
                case 0: // lewo
                    newX = X - 1;
                    break;
                case 1: // prawo
                    newX = X + 1;
                    break;
                case 2: // góra
                    newY = Y - 1;
                    break;
                case 3: // dół
                    newY = Y + 1;
                    break;
            }
            if (IsValidPosition(newX, newY, board))
            {
                board[X, Y].Settler = null; // Usunięcie osadnika z poprzedniej pozycji
                X = newX;
                Y = newY;
                board[X, Y].Settler = this; // Ustawienie osadnika na nowej pozycji

                Life--;

                Console.WriteLine($"Osadnik przesunięty na pozycję [{X}, {Y}]");

                if (Life == 0)
                {
                    Console.WriteLine("Osadnik stracił wszystkie życie. Koniec gry.");
                    return;
                }
            }
        }
        private bool IsValidPosition(int x, int y, Cell[,] board)
        {
            return x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1);
        }
    }
}
