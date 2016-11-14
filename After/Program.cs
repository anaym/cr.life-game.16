using System;
using System.Linq;
using System.Threading;
using CR_Life.After.Renderer;

namespace CR_Life.After
{
    public class Program
    {
        public static void Main()
        {
            var map = Map.Toroidal(new Cell(-5, -5), new Cell(5, 5))
                //.InsertTo(Shape.Glider, new Cell(0, -10))
                //.InsertTo(Shape.Blinker, new Cell(18, 6))
                //.InsertTo(Shape.Beehive, new Cell(-21, 3))
                .InsertTo(Shape.Box, new Cell(-6, -6))
                ;

            var game = new Game(map);

            var renderer = new ConsoleRenderer(new Cell(-8, -8), new Cell(8, 8))
            {
                AliveChar = '█',
                DeadChar = '-'
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                renderer.Render(game.CurrentMap);
                game.TurnForward();
                Console.ReadKey();
                Thread.Sleep(100);
            }
        }
    }
}