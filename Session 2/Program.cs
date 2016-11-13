using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Life.Session_2
{
    class Program
    {
        public static void Main100500(string[] args)
        {
            var map = new Map
            {
                [0, 0] = true,
                [1, 0] = true,
                [2, 0] = true,
                [2, 1] = true,
                [1, 2] = true
            };

            var game = new Game(map, new MapRenderer());

            while (true)
            {
                game.Iteration();
                Console.ReadKey();
            }
        }
    }
}
