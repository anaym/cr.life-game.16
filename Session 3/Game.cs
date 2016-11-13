using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NUnit.Framework;

namespace CR_Life.Session_3
{
    public class Game
    {
        public IEnumerable<Map> Play(Map start)
        {
            var current = start;
            return new InfinityEnumrable<int>()
                .Select(i =>
                    {
                        if (i != 0) current = MakeTurn(current);
                        return current;
                    });
        }

        internal Map MakeTurn(Map current)
        {
            var newMap = current.AliveCells
                .SelectMany(c => c.GetNear())
                .Where(n => GetStatus(current.GetCellStatus(n), current.AliveCellCount(n)))
                .ToImmutableHashSet();
            return new Map(newMap);
        }

        internal bool GetStatus(bool nowStatus, int aliveCount)
        {
            if (aliveCount == 2) return nowStatus;
            return aliveCount == 3;
        }
    }

    [TestFixture]
    public class Game_Should
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }


        #region Cases
        [TestCase(false, 0, ExpectedResult = false, TestName = "0f")]
        [TestCase(true, 0, ExpectedResult = false, TestName = "0t")]

        [TestCase(false, 1, ExpectedResult = false, TestName = "1f")]
        [TestCase(true, 1, ExpectedResult = false, TestName = "1t")]

        [TestCase(false, 2, ExpectedResult = false, TestName = "2f")]
        [TestCase(true, 2, ExpectedResult = true, TestName = "2t")]

        [TestCase(false, 3, ExpectedResult = true, TestName = "3f")]
        [TestCase(true, 3, ExpectedResult = true, TestName = "3t")]

        [TestCase(false, 4, ExpectedResult = false, TestName = "4f")]
        [TestCase(true, 4, ExpectedResult = false, TestName = "4t")]
        #endregion

        public bool CorrectCalulateStatus(bool nowStatus, int aliveCount)
        {
            return game.GetStatus(nowStatus, aliveCount);
        }
    }
}