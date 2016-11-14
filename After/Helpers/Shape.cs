using System.Linq;

namespace CR_Life.After
{
    public class Shape
    {
        public static readonly Shape Glider;
        public static readonly Shape Blinker;
        public static readonly Shape Beehive;
        public static readonly Shape Box;

        static Shape()
        {
            Beehive = new Shape(new[] {".o.", "o.o", "o.o", ".o."}.ToMap());
            Glider = new Shape(new[] {".o.", "..o", "ooo"}.ToMap());
            Blinker = new Shape(new[] {"ooo"}.ToMap());
            Box = new Shape(new[] {"oo", "oo"}.ToMap());
        }

        public readonly Map Cells;
        public Shape(Map cells)
        {
            Cells = cells;
        }

        public Map InsertTo(Map other, Cell position)
        {
            return other.SetManyAlive(Cells.AliveCells.Select(c => new Cell(c.X + position.X, c.Y + position.Y)));
        }
    }
}