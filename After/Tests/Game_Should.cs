using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.After.Tests
{
    [TestFixture]
    public class Game_Should
    {
        private Game game;
        private Cell single;
        private Cell a;
        private Cell b;
        private Cell c;

        [SetUp]
        public void SetUp()
        {
            single = new Cell(100, 100);

            a = new Cell(0, 0);
            b = new Cell(1, 0);
            c = new Cell(2, 0);

            game = new Game(new Map(new []{single, a, b, c}));
        }


        #region Cases
        [TestCase(false, 0, ExpectedResult = false, TestName = "now dead, near alive - 0")]
        [TestCase(true, 0, ExpectedResult = false, TestName = "now alive, near alive - 0")]

        [TestCase(false, 1, ExpectedResult = false, TestName = "now dead, near alive - 1")]
        [TestCase(true, 1, ExpectedResult = false, TestName = "now alive, near alive - 1")]

        [TestCase(false, 2, ExpectedResult = false, TestName = "now dead, near alive - 2")]
        [TestCase(true, 2, ExpectedResult = true, TestName = "now alive, near alive - 2")]

        [TestCase(false, 3, ExpectedResult = true, TestName = "now dead, near alive - 3")]
        [TestCase(true, 3, ExpectedResult = true, TestName = "now alive, near alive - 3")]

        [TestCase(false, 4, ExpectedResult = false, TestName = "now dead, near alive - 4")]
        [TestCase(true, 4, ExpectedResult = false, TestName = "now alive, near alive - 4")]
        #endregion
        public bool CorrectCalculateNextState(bool currentState, int aliveCount)
        {
            return Game.GetNextState(currentState, aliveCount);
        }

        [Test]
        public void KillSingleCell()
        {
            game.TurnForward();
            game.CurrentMap.IsAlive(single).Should().Be(false);
        }

        [Test]
        public void NotKillNonSingleCell()
        {
            game.TurnForward();
            game.CurrentMap.IsAlive(b).Should().Be(true);
        }
    }
}