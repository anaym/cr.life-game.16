using System.Collections.Generic;
using System.Linq;

namespace CR_Life.Session_3
{
    public class Cell
    {
        protected bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Cell> GetNear()
        {
            return Enumerable.Range(-1, 3)
                .SelectMany(x => Enumerable.Range(-1, 3).Select(y => new Cell(X + x, Y + y)))
                .Where(c => c.X != X || c.Y != Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Cell)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}