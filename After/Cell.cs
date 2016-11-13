using System.Collections.Generic;

namespace CR_Life.After
{
    //УйEquals && GetHashCode работают через поля X, Y, т.к. это структура
    public struct Cell
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Cell> Nearest
        {
            get
            {
                for (int x = X - 1; x <= X + 1; x++)
                    for (int y = Y - 1; y <= Y + 1; y++)
                        if (x != X || y != Y)
                            yield return new Cell(x, y);
            }
        }

        public override string ToString() => $"({X}, {Y})";
    }
}