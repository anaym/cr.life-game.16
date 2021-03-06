﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CR_Life.After
{
    public static class MapHelper
    {
        public static IMap SetCellAlive(this IMap map, int x, int y) => map.SetCellAlive(new Cell(x, y));

        public static IMap SetManyAlive(this IMap map, IEnumerable<Cell> alive)
        {
            return alive.Aggregate(map, (current, cell) => current.SetCellAlive(cell));
        }

        public static IMap InsertTo(this IMap map, Shape shape, Cell position) => shape.InsertTo(map, position);

        public static IMap ToMap(this string[] lines, char alive = 'o', char dead = '.')
        {
            IMap map = new Map();
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

        public static IMap FillRandom(this IMap map, Rectangle rect)
        {
            var rnd = new Random();
            for (int x = rect.Left; x <= rect.Right; x++)
                for (int y = rect.Bottom; y <= rect.Top; y++)
                    if (rnd.Next()%2 == 1)
                        map = map.SetCellAlive(new Cell(x, y));
            return map;
        }
    }
}