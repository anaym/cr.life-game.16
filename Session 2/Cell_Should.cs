using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_2
{
    [TestFixture]
    public class Cell_Should
    {
        [SetUp]
        public void SetUp()
        {
            cell = new Cell(1, 1);
        }

        private Cell cell;

        [Test]
        public void GetNeighbours_should_return_some_cells()
        {
            var adjacentCells = cell.GetNeigbours().ToList();

            adjacentCells.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetNeighbours_should_return_eight_neighbours()
        {

            var neighbours = cell.GetNeigbours().ToList();

            neighbours.Count.Should().Be(8);
        }

        [Test]
        public void GetNeighbours_should_return_correct_cells()
        {
            var neighbours = cell.GetNeigbours().Distinct().ToList();
            neighbours.Count.Should().Be(8);

            neighbours
                .All(c => Math.Abs(c.X - cell.X) <= 1 && Math.Abs(c.Y - cell.Y) <= 1)
                .Should().BeTrue();
        }
    }
}