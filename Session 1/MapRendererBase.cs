namespace CR_Life.Session_1
{
    public abstract class MapRendererBase
    {
        public abstract void WriteAlive();
        public abstract void WriteDead();
        public abstract void WriteLineEnd();
        public abstract void Clear();

        public void Render(Map map)
        {
            Clear();
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map[x, y])
                        WriteAlive();
                    else
                        WriteDead();
                }
                WriteLineEnd();
            }
        }
    }
}