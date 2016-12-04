using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace CR_Life.After.Renderer
{
    public class ConsoleRenderer : IRenderer
    {
        public char RichAliveChar = 'O';
        public char PoorAliveChar = 'o';
        public char RichDeadChar = '.';
        public char PoorDeadChar = ' ';

        public ConsoleColor RichAliveColor = ConsoleColor.Green;
        public ConsoleColor PoorAliveColor = ConsoleColor.DarkGreen;
        public ConsoleColor RichDeadColor = ConsoleColor.DarkGray;
        public ConsoleColor PoorDeadColor = ConsoleColor.DarkGray;

        private readonly Rectangle rectangle;

        public ConsoleRenderer(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public void Render(IMap map)
        {
            Console.Clear();
            for (int y = rectangle.Top; y >= rectangle.Bottom; y--)
            {
                RenderLine(map, y);
            }
        }

        private void RenderLine(IMap map, int y)
        {
            for (int x = rectangle.Left; x <= rectangle.Right; x++)
            {
                var dx = x - rectangle.Left;
                var dy = -y + rectangle.Top;
                if (dx < 0 || dy < 0) continue;
                Console.SetCursorPosition(dx, dy);

                var nearAliveCount = map.CountNearestAliveCells(new Cell(x, y));
                var isAlive = map.IsAlive(new Cell(x, y));
                var isRich = nearAliveCount == 3 || nearAliveCount == 2 && isAlive;


                var chr = isAlive ? (isRich ? RichAliveChar : PoorAliveChar) : (isRich ? RichDeadChar : PoorDeadChar);
                var clr = isAlive ? (isRich ? RichAliveColor : PoorAliveColor) : (isRich ? RichDeadColor : PoorDeadColor);

                if(chr != ' ')
                {
                    Console.ForegroundColor = clr;
                    Console.Write(chr);
                }
            }
        }
    }
}
