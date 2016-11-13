using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_2
{
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
        public void SetCellStatus()
        {
            map[5, 5] = true;
        }

        [Test]
        public void ReturnCellStatus()
        {
            map[5, 5] = true;
            map[5, 5].Should().BeTrue();
        }

        [Test]
        public void ReturnAliveCellsCount()
        {
            map[5, 5] = true;
            map[4, 5] = true;
            map[4, 4] = false;
            map.NearAliveCount(4, 5).Should().Be(1);
        }
    }
}