using System.Collections.Generic;
using System.Linq;

namespace CR_Life.After
{
    public static class MapHelper
    {
        public static Map SetCellAlive(this Map map, int x, int y) => map.SetCellAlive(new Cell(x, y));

        public static Map SetManyAlive(this Map map, IEnumerable<Cell> alive)
        {
            return alive.Aggregate(map, (current, cell) => current.SetCellAlive(cell));
        }
    }
}