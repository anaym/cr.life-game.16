using System;

namespace CR_Life.Session_5
{
    public static class Program
    {
        public static void Main100500()
        {
            var map = new Map();
            map[0, 0] = true;
            map[1, 0] = true;
            map[2, 0] = true;
            var game = new Game(map);
            while (true)
            {
                game.CurrentMap.Print();
                game.Iteration();
                Console.ReadKey();
            }
        }

        private static void Print(this Map map)
        {
            Console.Clear();
            for (int i = -20; i <= 20; i++)
            {
                for (int j = -20; j <= 20; j++)
                {
                    var s = map[i, j];
                    Console.Write(s ? "+" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}