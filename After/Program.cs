using System;
using System.Threading;
using CR_Life.After.Renderer;

namespace CR_Life.After
{
    public class Program
    {
        public static void Main()
        {
            var map = Shape.Glider.InsertTo(new Map(), new Cell(-20, 20));

            var game = new Game(map);

            var renderer = new ConsoleRenderer(new Cell(-20, -20), new Cell(20, 20))
            {
                AliveChar = 'O',
                DeadChar = '-'
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                renderer.Render(game.CurrentMap);
                game.TurnForward();
                Thread.Sleep(100);
            }
        }
    }
}