using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.After.Tests
{
    [TestFixture]
    public class Map_Should
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            map = new  Map();
        }


        [Test]
        public void CollectAllAliveCells()
        {
            Cell[] cells =
            {
                new Cell(0, 0),
                new Cell(100, 500),
                new Cell(-132, 34)
            };
            var m = map
                .SetCellAlive(cells[0])
                .SetCellAlive(cells[1])
                .SetCellAlive(cells[2]);

            m.CountAliveCells.Should().Be(3);
            m.AliveCells.Should().BeEquivalentTo(cells);
            //TODO: ???
            // map.AliveCells.ShouldBeEquivalentTo(cells, o => o.WithStrictOrdering()); //виснет тут
        }

        [Test]
        public void CorrectRemoveCells()
        {
            var a = new Cell(0, 100);
            var b = new Cell(103, 32);
            var c = new Cell(23, 23);

            var m = map
                .SetCellAlive(a)
                .SetCellAlive(b)
                .SetCellAlive(c);

            m = m.SetCellDead(b);

            m.AliveCells.Should().BeEquivalentTo(new Cell[] {a, c});
        }

        [Test]
        public void CollectAllPreviousStates()
        {
            var first = map
                .SetCellAlive(new Cell(10, 234))
                .SetCellAlive(new Cell(324, 231));
            var firstSaved = first.AliveCells.ToList();

            first.AliveCells.Should().BeEquivalentTo(firstSaved);
        }
    }
}