using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.After.Tests
{
    [TestFixture]
    public class Cell_Should
    {
        private Cell cell;

        [SetUp]
        public void SetUp()
        {
            cell = new Cell(100, -31);
        }


        [Test]
        public void ReturnCorrectedNearestCells()
        {
            var nearest = cell.Nearest.ToList();
            nearest.Count().Should().Be(8);
            nearest.Distinct().Count().Should().Be(8);
            nearest.All(p => Math.Abs(p.X - cell.X) <= 1 && Math.Abs(p.Y - cell.Y) <= 1).Should().Be(true);
            nearest.Any(p => p.Equals(cell)).Should().Be(false);
        }
    }
}