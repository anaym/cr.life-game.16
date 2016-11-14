using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace CR_Life.After.Renderer
{
    public class ConsoleRenderer : TextStreamRenderer
    {
        public ConsoleRenderer(Cell leftBottom, Cell rightTop) : base(Console.Out, leftBottom, rightTop)
        {
        }
    }
}
