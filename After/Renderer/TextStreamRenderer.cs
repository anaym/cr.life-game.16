using System.IO;

namespace CR_Life.After.Renderer
{
    public class TextStreamRenderer : IRenderer
    {
        public readonly TextWriter Writer;

        public char AliveChar = 'o';
        public char DeadChar = '.';

        public bool EveryCharFlush = false;
        public bool EveryLineFlush = false;

        private readonly Cell leftBottom;
        private readonly Cell rightTop;


        public TextStreamRenderer(TextWriter writer, Cell leftBottom, Cell rightTop)
        {
            this.Writer = writer;
            this.leftBottom = leftBottom;
            this.rightTop = rightTop;
        }

        public void Render(IMap map)
        {
            for (int y = rightTop.Y; y >= leftBottom.Y; y--)
            {
                RenderLine(map, y);
                Writer.WriteLine();
                if (EveryLineFlush) Writer.Flush();
            }
        }

        private void RenderLine(IMap map, int y)
        {
            for (int x = leftBottom.X; x <= rightTop.X; x++)
            {
                Writer.Write(map.IsAlive(new Cell(x, y)) ? AliveChar : DeadChar);
                if (EveryCharFlush) Writer.Flush();
            }
        }
    }
}