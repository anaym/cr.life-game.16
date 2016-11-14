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

        public static Map InsertTo(this Map map, Shape shape, Cell position) => shape.InsertTo(map, position);

        public static Map ToMap(this string[] lines, char alive = 'o', char dead = '.')
        {
            var map = new Map();
            var y = lines.Length - 1;
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var c in line)
                {
                    if (c == alive) map = map.SetCellAlive(x, y);
                    x++;
                }
                y--;
            }
            return map;
        }
    }
}