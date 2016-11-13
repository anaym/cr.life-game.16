using System;
using System.IO;

namespace CR_Life.After.Renderer
{
    public class ConsoleRenderer : TextStreamRenderer
    {
        public ConsoleRenderer(Cell leftBottom, Cell rightTop) : base(Console.Out, leftBottom, rightTop)
        {
        }
    }
}