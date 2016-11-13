using System.Collections.Generic;
using System.Linq;

namespace CR_Life.Session_1
{
    public class Map
    {
        private readonly bool[,] cells;

        public int Width => cells.GetLength(0);
        public int Height => cells.GetLength(1);
        public int AliveCount => Cells.Count(p => p);

        public IEnumerable<bool> Cells
        {
            get
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        yield return this[x, y];
                    }
                }
            }
        }

        public Map(int width, int height) : this(new bool[width, height])
        { }

        public Map(bool[,] cells)
        {
            this.cells = cells;
        }

        public bool this[int x, int y]
        {
            get { return cells[x, y]; }
            set { cells[x, y] = value; }
        }

        public bool HasAvailableCoordinates(int x, int y)
            => x >= 0 && y >= 0 && x < Width && y < Height;

        public int GetAliveNeighboursCount(int x, int y)
        {
            var cx = 0;
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    if (!(dx == 0 && dy == 0))
                    {
                        var nx = x + dx;
                        var ny = y + dy;
                        if (HasAvailableCoordinates(nx, ny) && this[nx, ny]) cx++;
                    }
                }
            }
            return cx;
        }

    }
}
