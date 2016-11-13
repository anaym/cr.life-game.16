using System.Linq;

namespace CR_Life.Session_2
{
    public abstract class MapRendererBase
    {
        public abstract void WriteAlive();
        public abstract void WriteDead();
        public abstract void WriteLineEnd();
        public abstract void Clear();

        public void Render(Map map)
        {
            Clear();
            var minx = map.AliveCells.Min(c => c.X);
            var miny = map.AliveCells.Min(c => c.Y);
            var maxx = map.AliveCells.Max(c => c.X);
            var maxy = map.AliveCells.Max(c => c.Y);
            for (int y = miny; y <= maxy; y++)
            {
                for (int x = minx; x <= maxx; x++)
                {
                    if (map[x, y])
                        WriteAlive();
                    else
                        WriteDead();
                }
                WriteLineEnd();
            }
        }
    }
}