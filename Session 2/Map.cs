using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CR_Life.Session_2
{
    public class Map
    {
        private readonly HashSet<Cell> aliveCells;

        public IEnumerable<Cell> AliveCells => aliveCells;

        public Map()
        {
            this.aliveCells = new HashSet<Cell>();
        }

        public int NearAliveCount(int x, int y)
        {
            return new Cell(x, y).GetNeigbours().Count(c => aliveCells.Contains(c));
        }

        public bool this[int x, int y]
        {
            set
            {
                if (value) aliveCells.Add(new Cell(x, y));
                else aliveCells.Remove(new Cell(x, y));
            }
            get { return aliveCells.Contains(new Cell(x, y)); }
        }
    }
}