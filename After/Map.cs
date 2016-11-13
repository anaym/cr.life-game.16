using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CR_Life.After
{
    public class Map
    {
        private readonly ImmutableHashSet<Cell> aliveCells;
        public IEnumerable<Cell> AliveCells => aliveCells;

        public int CountAliveCells => aliveCells.Count;

        public Map(IEnumerable<Cell> aliveCells) : this(aliveCells.ToImmutableHashSet())
        { }

        public Map() : this(ImmutableHashSet<Cell>.Empty)
        { }

        private Map(ImmutableHashSet<Cell> aliveCells)
        {
            this.aliveCells = aliveCells;
        }

        public int CountNearestAliveCells(Cell position) => position.Nearest.Count(IsAlive);

        public Map SetCellState(Cell position, bool isAlive) => isAlive ? SetCellAlive(position) : SetCellDead(position);
        public Map SetCellAlive(Cell position) => new Map(aliveCells.Add(position));
        public Map SetCellDead(Cell position) => new Map(aliveCells.Remove(position));

        public bool IsAlive(Cell position) => aliveCells.Contains(position);
    }
}