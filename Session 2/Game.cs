using System.Linq;

namespace CR_Life.Session_2
{
    public class Game
    {
        public Map CurrentMap;
        private readonly MapRendererBase _renderer;

        public Game(Map currentMap, MapRendererBase renderer)
        {
            this.CurrentMap = currentMap;
            this._renderer = renderer;
        }

        public void Iteration()
        {
            var map = new Map();
            _renderer.Render(CurrentMap);
            foreach (var potential in CurrentMap.AliveCells.SelectMany(p => p.GetNeigbours()).Distinct())
            {
                var acount = CurrentMap.NearAliveCount(potential.X, potential.Y);
                if (acount == 2) map[potential.X, potential.Y] = CurrentMap[potential.X, potential.Y];
                else map[potential.X, potential.Y] = acount == 3;
            }
            CurrentMap = map;
        }
    }
}