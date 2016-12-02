using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CR_Life.After
{
    public class ToroidalMap : IMap
    {
        private readonly ImmutableHashSet<Cell> aliveCells;
        private readonly Rectangle border;

        public ToroidalMap(Rectangle border) : this(ImmutableHashSet<Cell>.Empty, border)
        { }

        public ToroidalMap(IEnumerable<Cell> aliveCells, Rectangle border) : this(aliveCells.ToImmutableHashSet(), border)
        { }

        protected ToroidalMap(ImmutableHashSet<Cell> aliveCells, Rectangle border)
        {
            this.aliveCells = aliveCells.Select(border.TranslateCell).ToImmutableHashSet();
            this.border = border;
        }

        public IEnumerable<Cell> AliveCells => aliveCells;
        public int CountAliveCells => aliveCells.Count;
        public int CountNearestAliveCells(Cell position)
        {
            return position.Nearest.Select(border.TranslateCell).Count(aliveCells.Contains);
        }

        public bool IsAlive(Cell position)
        {
            return aliveCells.Contains(border.TranslateCell(position));
        }

        public IMap SetCellAlive(Cell position)
        {
            return new ToroidalMap(aliveCells.Add(border.TranslateCell(position)), border);
        }

        public IMap SetCellDead(Cell position)
        {
            return new ToroidalMap(aliveCells.Remove(border.TranslateCell(position)), border);
        }

        public IMap SetCellState(Cell position, bool isAlive)
        {
            return isAlive ? SetCellAlive(position) : SetCellDead(position);
        }

        public IMap KillAll()
        {
            return new ToroidalMap(border);
        }
    }
}