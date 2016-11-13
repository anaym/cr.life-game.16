namespace CR_Life.Session_1
{
    class Program
    {
        static void Main100500(string[] args)
        {
            bool[,] map = new bool[,]
            {
                {false, false, false, false, false },
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false },
            };
            var game = new Game(new Map(map), new MapRenderer());
            game.Run(1000);
        }

    }
}
