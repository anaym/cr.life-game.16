using System;
using System.Linq;
using System.Linq.Expressions;

namespace CR_Life.After
{
    public class Game
    {
        public Map CurrentMap { get; private set; }
        public Game(Map map)
        {
            CurrentMap = map;
            if (map == null)
                throw new NullReferenceException(nameof(map));
        }

        public void TurnForward()
        {
            CurrentMap = new Map(CurrentMap
                .AliveCells
                .SelectMany(c => c.Nearest)
                .Distinct()
                .Where(c => GetNextState(CurrentMap.IsAlive(c), CurrentMap.CountNearestAliveCells(c))));
        }

        public static bool GetNextState(bool currentState, int aliveCount)
        {
            if (aliveCount == 2) return currentState;
            return aliveCount == 3;
        }
    }
}