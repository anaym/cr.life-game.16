using System;

namespace CR_Life.Session_4
{
    public class Program
    {
        public static void Main100500()
        {
            var game = new Game();
            game.CurrentMap = new Map();
            game.CurrentMap.SetCellStatus(0, 0, true);
            game.CurrentMap.SetCellStatus(1, 0, true);
            game.CurrentMap.SetCellStatus(2, 0, true);
            game.CurrentMap.SetCellStatus(2, 1, true);
            game.CurrentMap.SetCellStatus(1, 2, true);
            while (true)
            {
                Console.Clear();
                for (int x = -20; x < 20; x++)
                {
                    for (int y = -20; y < 20; y++)
                    {
                        game.CurrentMap.RequestCellStatus(new Cell(x, y));
                        if (game.CurrentMap.BoolResult) Console.Write("D");
                        else Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                game.Iteration();
                Console.ReadKey();
            }
        }
    }
}