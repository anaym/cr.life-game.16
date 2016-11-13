using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_3
{
    public class Map
    {
        public readonly ImmutableHashSet<Cell> AliveCells;

        public Map() : this(ImmutableHashSet<Cell>.Empty)
        { }

        public Map(ImmutableHashSet<Cell> aliveCells)
        {
            this.AliveCells = aliveCells;
        }

        public Map SetCellStatus(int x, int y, bool isAlive) => SetCellStatus(new Cell(x, y), isAlive);

        public Map SetCellStatus(Cell pos, bool isAlive)
        {
            var cells = isAlive ? AliveCells.Add(pos) : AliveCells.Remove(pos);
            return new Map(cells);
        }

        public bool GetCellStatus(Cell pos)
        {
            return AliveCells.Contains(pos);
        }

        public int AliveCellCount(Cell cell)
        {
            return cell.GetNear().Count(GetCellStatus);
        }
    }

    [TestFixture]
    public class Map_Should
    {
        private Map map;
        private Cell cell;

        [SetUp]
        public void SetUp()
        {
            map = new Map();
            cell = new Cell(100500, -454);
        }


        [TestCase(true, TestName = "alive")]
        [TestCase(false, TestName = "dead")]
        public void CorrectSetCell(bool status)
        {
            map.SetCellStatus(cell, status)
                .GetCellStatus(cell)
                .Should().Be(status);
        }

        [Test]
        public void CorrectCalculateNearAliveCount()
        {
            var now = map
                .SetCellStatus(new Cell(0, 0), true)
                .SetCellStatus(new Cell(1, 0), true)
                .SetCellStatus(new Cell(2, 0), true);
            now.AliveCellCount(new Cell(1, 0)).Should().Be(2);
        }
    }
}