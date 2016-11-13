using System.Linq;

namespace CR_Life.After
{
    public class Shape
    {
        public static readonly Shape Glider;

        static Shape()
        {
            Glider = new Shape(new Map().SetCellAlive(0, 0).SetCellAlive(1, 0).SetCellAlive(2, 0).SetCellAlive(2, 1).SetCellAlive(1, 2));    
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