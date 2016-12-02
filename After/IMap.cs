using System.Collections.Generic;

namespace CR_Life.After
{
    public interface IMap
    {
        IEnumerable<Cell> AliveCells { get; }

        int CountAliveCells { get; }
        int CountNearestAliveCells(Cell position);
        bool IsAlive(Cell position);

        IMap SetCellAlive(Cell position);
        IMap SetCellDead(Cell position);
        IMap SetCellState(Cell position, bool isAlive);

        IMap KillAll();
    }
}