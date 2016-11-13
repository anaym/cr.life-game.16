using System.Threading;

namespace CR_Life.Session_1
{
    public class Game
    {
        public Map CurrentMap;
        private readonly MapRendererBase renderer;

        public Game(Map map, MapRendererBase renderer)
        {
            CurrentMap = map;
            this.renderer = renderer;
        }

        public void Run(int delay)
        {
            while (true)
            {
                Iteration();
                Thread.Sleep(delay);
            }
        }

        public void Iteration()
        {
            var map = new Map(CurrentMap.Width, CurrentMap.Height);
            for (int x = 0; x < CurrentMap.Width; x++)
            {
                for (int y = 0; y < CurrentMap.Height; y++)
                {
                    var acount = CurrentMap.GetAliveNeighboursCount(x, y);
                    if (acount == 2) map[x, y] = CurrentMap[x, y];
                    else map[x, y] = acount == 3;
                }
            }
            CurrentMap = map;
            renderer.Render(map);
        }
    }
}