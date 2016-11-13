using System.Collections.Generic;

namespace CR_Life.Session_2
{
    public class Cell
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object other)
        {
            if (!(other is Cell)) return false;
            return (other as Cell).X == X && (other as Cell).Y == Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public IEnumerable<Cell> GetNeigbours()
        {
            for (int i = -1; i <= 1; i++) 
                for (int j = -1; j <= 1; j++)
                    if (i != 0 || j != 0)
                        yield return new Cell(X + i, Y + j);
        }
    }
}