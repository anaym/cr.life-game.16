using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_2
{
    [TestFixture]
    public class Game_Should
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game(new Map(), new NullRenderer());
        }


        [Test]
        public void KillSingletone()
        {
            game.CurrentMap[10, -10] = true;
            game.Iteration();
            game.CurrentMap[10, -10].Should().BeFalse();
        }


        [Test]
        public void ThreeAdjacentCells_should_Create_new_cells()
        {
            game.CurrentMap[10, 10] = true;
            game.CurrentMap[10, 9] = true;
            game.CurrentMap[10, 8] = true;

            game.Iteration();

            game.CurrentMap[9, 9].Should().BeTrue();
            game.CurrentMap[11, 9].Should().BeTrue();

            game.CurrentMap[10, 10].Should().BeFalse();
            game.CurrentMap[10, 8].Should().BeFalse();
        }

    }
}