using System;
using System.Threading;
using CR_Life.After.Renderer;

namespace CR_Life.After
{
    public class Program
    {
        public static void Main()
        {
            var map = Shape.Glider.InsertTo(new Map(), new Cell(0, 0));

            var game = new Game(map);

            var renderer = new ConsoleRenderer(new Cell(-20, -20), new Cell(20, 20));
            renderer.DeadChar = ' ';

            while (true)
            {
                Console.Clear();
                Thread.Sleep(1);
                renderer.Render(game.CurrentMap);
                renderer.Writer.Flush();
                game.TurnForward();
                Thread.Sleep(100);
            }
        }
    }
}