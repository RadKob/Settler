using System;

namespace Settler
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[,] board = new Cell[10, 10];
            Random random = new Random();

            // Generowanie planszy
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    board[x, y] = new Cell
                    {
                        X = x,
                        Y = y,
                    };
                }
            }
            // Dodanie osadnika
            int settlerX = random.Next(0, 10);
            int settlerY = random.Next(0, 10);
            Settler settler = new Settler
            {
                X = settlerX,
                Y = settlerY,
                Life = 5,
                Alive = true
            };
            board[settlerX, settlerY].Settler = settler;

            // Wyświetlenie planszy
            while (settler.Life > 0)
            {
                settler.Move(board);
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        Cell cell = board[x, y];
                        if (cell.Settler != null)
                        {
                            Console.Write("[O]");
                        }
                        else
                        {
                            Console.Write("[ ]");
                        }
                    }
                    Console.WriteLine();
                }
            }
            /*
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Cell cell = board[x, y];
                    Console.WriteLine($"Komórka [{cell.X},{cell.Y},{cell.Settler}]");
                }
            }*/
        }
    }
}
