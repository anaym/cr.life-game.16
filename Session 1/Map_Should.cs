using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_1
{
    [TestFixture]
    public class Map_Should
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            map = new Map(10, 10);
        }

        [Test]
        public void Find_AliveNeighbours()
        {
            map[3, 3] = true;
            map[3, 2] = true;
            map[3, 1] = true;
            map.GetAliveNeighboursCount(3, 2).Should().Be(2);
        }
        [Test]
        public void Find_DeadNeighbors()
        {
            map[3, 3] = false;
            map[3, 2] = true;
            map[3, 1] = false;
            map.GetAliveNeighboursCount(3, 2).Should().Be(0);
        }

        [Test]
        public void Calculate_AliveCellsCount()
        {
            map[3, 3] = false;
            map[3, 2] = true;
            map[3, 1] = false;
            map.AliveCount.Should().Be(1);
      }
    }
}