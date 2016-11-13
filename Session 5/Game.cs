using System;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_5
{
    public static class Program
    {
        public static void Main()
        {
            var map = new Map();
            map[0, 0] = true;
            map[1, 0] = true;
            map[2, 0] = true;
            var game = new Game(map);
            while (true)
            {
                game.CurrentMap.Print();
                game.Iteration();
                Console.ReadKey();
            }
        }

        private static void Print(this Map map)
        {
            Console.Clear();
            for (int i = -20; i <= 20; i++)
            {
                for (int j = -20; j <= 20; j++)
                {
                    var s = map[i, j];
                    Console.Write(s ? "+" : " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Game
    {
        public Map CurrentMap { get; private set; }

        public Game(Map currentMap)
        {
            CurrentMap = currentMap;
        }
        public void Iteration()
        {
            var map = new Map();
            foreach (var cell in CurrentMap.PossibleAlive)
            {
                map[cell.X, cell.Y] = GetNextStatus(CurrentMap[cell.X, cell.Y], CurrentMap.GetAliveCount(cell.X, cell.Y));
            }
            CurrentMap = map;
        }

        internal static bool GetNextStatus(bool nowStatus, int aliveCount)
        {
            return aliveCount == 3 || aliveCount == 2 && nowStatus;
        }
    }

    [TestFixture]
    public class Game_Should
    {
        [TestCase(true, 0, ExpectedResult = false, TestName = "0t")]
        [TestCase(false, 0, ExpectedResult = false, TestName = "0f")]

        [TestCase(true, 1, ExpectedResult = false, TestName = "1t")]
        [TestCase(false, 1, ExpectedResult = false, TestName = "1f")]

        [TestCase(true, 2, ExpectedResult = true, TestName = "2t")]
        [TestCase(false, 2, ExpectedResult = false, TestName = "2f")]

        [TestCase(true, 3, ExpectedResult = true, TestName = "3t")]
        [TestCase(false, 3, ExpectedResult = true, TestName = "3f")]

        [TestCase(true, 4, ExpectedResult = false, TestName = "4t")]
        [TestCase(false, 4, ExpectedResult = false, TestName = "4f")]
        public bool CorrectRecalculateStatus(bool prev, int aliveCount)
        {
            return Game.GetNextStatus(prev, aliveCount);
        }

        [Test]
        public void KillSingletoneCell()
        {
            var game = new Game(new Map());
            game.CurrentMap[0, 0] = true;
            game.Iteration();
            game.CurrentMap[0, 0].Should().BeFalse();
        }

        [Test]
        public void NotKillFriendlyCells()
        {
            var game = new Game(new Map());
            game.CurrentMap[-1, 0] = true;
            game.CurrentMap[0, 0] = true;
            game.CurrentMap[1, 0] = true;
            game.Iteration();
            game.CurrentMap[0, 0].Should().BeFalse();
        }
    }
}