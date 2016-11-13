using System;

namespace CR_Life.Session_3
{
    public class Program
    {
        public static void Main100500()
        {
            var map = new Map()
                .SetCellStatus(0, 0, true)
                .SetCellStatus(1, 0, true)
                .SetCellStatus(2, 0, true)
                .SetCellStatus(2, 1, true)
                .SetCellStatus(1, 2, true);
            var game = new Game();
            var renderer = new Renderer(new Cell(-20, -20), new Cell(20, 20));
            foreach (var frame in renderer.Render(game.Play(map)))
            {
                Console.Clear();
                Console.WriteLine(frame);
                Console.ReadKey();
            }
            
        }
    }
}