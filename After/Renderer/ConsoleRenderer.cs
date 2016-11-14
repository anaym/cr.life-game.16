using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace CR_Life.After.Renderer
{
    public class ConsoleRenderer : IRenderer
    {
        private readonly Cell leftBottom;
        private readonly Cell rightTop;

        public char RichAliveChar = 'O';
        public char PoorAliveChar = 'o';
        public char RichDeadChar = '.';
        public char PoorDeadChar = ' ';

        public ConsoleColor RichAliveColor = ConsoleColor.Green;
        public ConsoleColor PoorAliveColor = ConsoleColor.DarkGreen;
        public ConsoleColor RichDeadColor = ConsoleColor.DarkGray;
        public ConsoleColor PoorDeadColor = ConsoleColor.DarkGray;

        public ConsoleRenderer(Cell leftBottom, Cell rightTop)
        {
            this.leftBottom = leftBottom;
            this.rightTop = rightTop;
        }

        public void Render(Map map)
        {
            Console.Clear();
            for (int y = rightTop.Y; y >= leftBottom.Y; y--)
            {
                RenderLine(map, y);
            }
        }

        private void RenderLine(Map map, int y)
        {
            for (int x = leftBottom.X; x <= rightTop.X; x++)
            {
                var dx = x - leftBottom.X;
                var dy = -y + rightTop.Y;
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
