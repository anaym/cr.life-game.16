using System;
using System.Linq;
using System.Threading;
using CR_Life.After.Renderer;
using Ninject;

namespace CR_Life.After
{
    public class Program
    {
        public static void Main()
        {
            var width = Console.WindowWidth - 1;
            var height = Console.WindowHeight - 1;

            var kernel = new StandardKernel();
            kernel.Bind<Rectangle>().ToConstant(new Rectangle(-width/2, height/2, width/2, -height/2));
            //kernel.Bind<IMap>().ToMethod(c => new ToroidalMap(kernel.Get<Rectangle>()).FillRandom(kernel.Get<Rectangle>()));
            kernel.Bind<IMap>().ToMethod(c => new ToroidalMap(kernel.Get<Rectangle>()).InsertTo(Shape.Glider, new Cell(0, 0)));
            kernel.Bind<Game>().To<Game>();
            kernel.Bind<IRenderer>().To<ConsoleRenderer>();

            var game = kernel.Get<Game>();
            var renderer = kernel.Get<IRenderer>();

            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                renderer.Render(game.CurrentMap);
                Console.Title = game.CurrentMap.CountAliveCells.ToString().PadRight(4, ' ') + String.Concat(Enumerable.Repeat<char>('|', game.CurrentMap.CountAliveCells/10));
                game.TurnForward();
                //Console.ReadKey();
                Thread.Sleep(100);
            }
        }
    }
}