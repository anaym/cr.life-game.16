using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_5
{
    public class Map
    {
        private readonly HashSet<Cell> alive;

        public Map()
        {
            alive = new HashSet<Cell>();
        }

        public IEnumerable<Cell> PossibleAlive
            => alive.SelectMany(c => c.Near).Distinct();

        public bool this[int x, int y]
        {
            get { return alive.Contains(new Cell(x, y)); }
            set
            {
                if (value) alive.Add(new Cell(x, y));
                else alive.Remove(new Cell(x, y));
            }
        }

        public int GetAliveCount(int x, int y)
        {
            return new Cell(x, y).Near.Count(c => this[c.X, c.Y]);
        }
    }

    [TestFixture]
    public class Map_Should
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            map = new Map();
        }


        [Test]
        public void DoSomething_WhenSomething()
        {
            map[0, 0] = true;
            map[1, 0] = true;
            map[2, 0] = true;
            map.GetAliveCount(1, 0).Should().Be(2);
        }
    }
}