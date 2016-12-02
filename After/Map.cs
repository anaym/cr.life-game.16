using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CR_Life.After
{
    public class Map : IMap
    {
        private readonly ImmutableHashSet<Cell> aliveCells;

        public Map() : this(ImmutableHashSet<Cell>.Empty)
        { }

        public Map(IEnumerable<Cell> aliveCells) : this(aliveCells.ToImmutableHashSet())
        { }

        protected Map(ImmutableHashSet<Cell> aliveCells)
        {
            this.aliveCells = aliveCells;
        }

        public IEnumerable<Cell> AliveCells => aliveCells;
        public int CountAliveCells => aliveCells.Count;
        public int CountNearestAliveCells(Cell position)
        {
            return position.Nearest.Count(aliveCells.Contains);
        }

        public bool IsAlive(Cell position)
        {
            return aliveCells.Contains(position);
        }

        public IMap SetCellAlive(Cell position)
        {
            return new Map(aliveCells.Add(position));
        }

        public IMap SetCellDead(Cell position)
        {
            return new Map(aliveCells.Remove(position));
        }

        public IMap SetCellState(Cell position, bool isAlive)
        {
            return isAlive ? SetCellAlive(position) : SetCellDead(position);
        }

        public IMap KillAll()
        {
            return new Map();
        }
    }
}