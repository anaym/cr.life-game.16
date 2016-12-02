using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.After.Tests
{
    [TestFixture]
    public class ToroidalMap_Should
    {
        private ToroidalMap map;

        [SetUp]
        public void SetUp()
        {
            map = new ToroidalMap(new Rectangle(-10, 20, 10, -20));
        }


        [Test]
        public void DontTranslatePointIntoBorder()
        {
            var setted = map.SetCellAlive(new Cell(-10, 20));
            setted.AliveCells.Contains(new Cell(-10, 20)).Should().BeTrue();
        }


        [Test]
        public void CorrectRememberPointOutBorder()
        {
            var point = new Cell(11, 20);
            var setted = map.SetCellAlive(point);
            setted.IsAlive(point).Should().BeTrue();
        }

        [Test]
        public void HungUpSpace()
        {
            var setted = map.SetCellAlive(new Cell(11, -21));
            setted.AliveCells.Contains(new Cell(-10, 20)).Should().BeTrue();
        }

    }
}