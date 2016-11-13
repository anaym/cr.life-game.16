using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_1
{
    [TestFixture]
    public class Game_Should
    {
        private Map map;
        private Game game;

        [SetUp]
        public void SetUp()
        {
            map = new Map(10, 10);
            game = new Game(map, new NullRenderer());
        }

        [Test]
        public void Kill_AloneCell()
        {
            game.CurrentMap[5, 5] = true;
            game.Iteration();
            game.CurrentMap[5, 5].Should().BeFalse();
            game.CurrentMap.AliveCount.Should().Be(0);
        }
    }
}