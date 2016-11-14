using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CR_Life.After
{
    public class Map : ICloneable
    {
        public readonly bool ToroidalSpace;
        public IEnumerable<Cell> AliveCells => aliveCells;

        public int CountAliveCells => aliveCells.Count;

        private readonly ImmutableHashSet<Cell> aliveCells;
        private readonly Cell leftBottom;
        private readonly int width;
        private readonly int height;

        public static Map Toroidal(Cell leftBottom, Cell rightTop)
        {
            return new Map(ImmutableHashSet<Cell>.Empty, leftBottom, rightTop);
        }

        public static Map Toroidal(IEnumerable<Cell> aliveCells, Cell leftBottom, Cell rightTop)
        {
            return new Map(aliveCells.ToImmutableHashSet(), leftBottom, rightTop);
        }

        public Map(IEnumerable<Cell> aliveCells) : this(aliveCells.ToImmutableHashSet(), null, null)
        { }

        public Map() : this(ImmutableHashSet<Cell>.Empty, null, null)
        { }
        
        private Map(ImmutableHashSet<Cell> aliveCells, Cell? leftBottom, Cell? rightTop)
        {
            this.aliveCells = aliveCells;
            this.leftBottom = leftBottom ?? default(Cell);
            var rtop = rightTop ?? default(Cell);
            ToroidalSpace = leftBottom != null && rightTop != null;
            if (ToroidalSpace)
            {
                width = rtop.X - this.leftBottom.X + 1;
                height = rtop.Y - this.leftBottom.Y + 1;
                if (width <= 1) throw new ArgumentException("left bottom x should be < rigth top x");
                if (height <= 1) throw new ArgumentException("left bottom y should be < rigth top y");
            }
        }

        public int CountNearestAliveCells(Cell position) => position.Nearest.Count(IsAlive);

        public Map SetCellState(Cell position, bool isAlive) => isAlive ? SetCellAlive(position) : SetCellDead(position);
        public Map SetCellAlive(Cell position) => Clone(aliveCells.Add(TranslateCoordinates(position)));
        public Map SetCellDead(Cell position) => Clone(aliveCells.Remove(TranslateCoordinates(position)));

        public bool IsAlive(Cell position) => aliveCells.Contains(TranslateCoordinates(position));

        public Cell TranslateCoordinates(Cell cell)
        {
            if (!ToroidalSpace) return cell;
            var dx = cell.X - leftBottom.X;
            var dy = cell.Y - leftBottom.Y;
            var x = (dx % width + width)%width + leftBottom.X;
            var y = (dy % height + height)%height + leftBottom.Y;
            return new Cell(x, y);
        }

        public Map Clone(IEnumerable<Cell> alive)
        {
            if (!ToroidalSpace) return new Map(alive);
            return new Map(alive.ToImmutableHashSet(), leftBottom, new Cell(leftBottom.X + width - 1, leftBottom.Y + height - 1));
        }

        public object Clone() => Clone(aliveCells);
    }
}