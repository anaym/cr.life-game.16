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
            var width = Console.WindowWidth - 1;
            var height = Console.WindowHeight - 1;

            var map = new ToroidalMap(new Rectangle(-width/2, height/2, width/2, -height/2))
                //.InsertTo(Shape.Glider, new Cell(0, 0));
                .FillRandom(new Cell(-width/2, -height/2), new Cell(width/2, height/2));

            var game = new Game(map);

            var renderer = new ConsoleRenderer(new Cell(-width/2, -height/2), new Cell(width/2, height/2));

            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                renderer.Render(game.CurrentMap);
                Console.Title = game.CurrentMap.CountAliveCells.ToString().PadRight(4, ' ') +  String.Concat(Enumerable.Repeat<char>('|', game.CurrentMap.CountAliveCells/10));
                game.TurnForward();
                //Console.ReadKey();
                Thread.Sleep(100);
            }
        }
    }
}