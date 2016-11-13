namespace CR_Life.Session_4
{
    public class Game
    {
        public Map CurrentMap;
        public void Iteration()
        {
            var map = new Map();
            foreach (var cell in CurrentMap.PossibleAlive)
            {
                CurrentMap.RequestAliveCount(cell);
                CurrentMap.RequestCellStatus(cell);
                if (CurrentMap.IntResult == 2) map.SetCellStatus(cell, CurrentMap.BoolResult);
                else map.SetCellStatus(cell, CurrentMap.IntResult == 3);
            }
            CurrentMap = map;
        }
    }
}