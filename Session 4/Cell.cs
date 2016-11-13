using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CR_Life.Session_4
{
    public struct Cell
    {
        public readonly int X;
        public readonly int Y;
     
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Near = null;
        }

        public ImmutableList<Cell> Near { get; private set; } //TODO: сравнение идет и по свойствам. Заменить на что-то, или перенести
        public void RequestNear()
        {
            var near = ImmutableList<Cell>.Empty;
            for (int i = X - 1; i <= X + 1; i++)
            {
                for (int j = Y - 1; j <= Y + 1; j++)
                {
                    if (i != X || j != Y)
                        near = near.Add(new Cell(i, j));
                }
            }
            Near = near;
        }
    }
}