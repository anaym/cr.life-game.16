using System;
using System.Collections.Generic;
using System.Linq;

namespace CR_Life.Session_4
{
    public class Map
    {
        private HashSet<Cell> alive;

        public IEnumerable<Cell> Alive => alive;
        public IEnumerable<Cell> PossibleAlive => Alive.SelectMany(c =>
        {
            c.RequestNear();
            return c.Near;
        });

        public void SetCellStatus(int x, int y, bool status)
        {
            SetCellStatus(new Cell(x, y), status);
        }

        public void SetCellStatus(Cell cell, bool status)
        {
            if (status) alive.Add(cell);
            else alive.Remove(cell);
        }

        public bool BoolResult { get; private set; }
        public void RequestCellStatus(Cell cell)
        {
            BoolResult = alive.Contains(cell);
        }

        public int IntResult;

        public Map()
        {
            this.alive = new HashSet<Cell>();
        }

        public void RequestAliveCount(Cell cell)
        {
            cell.RequestNear();
            IntResult = cell.Near.Count(c => alive.Contains(c));
        }
    }
}