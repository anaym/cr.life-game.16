using System;
using System.Collections.Generic;
using System.Linq;

namespace CR_Life.Session_3
{
    public class Renderer
    {
        public  static readonly char AliveChar = '@';
        public  static readonly char DeadChar = ' ';

        private readonly Cell _leftBottom;
        private readonly Cell _rightTop;

        public int Width => _rightTop.X - _leftBottom.X + 1;
        public int Height => _rightTop.Y - _leftBottom.Y + 1;

        public Renderer(Cell leftBottom, Cell rightTop)
        {
            _leftBottom = leftBottom;
            _rightTop = rightTop;
        }

        public IEnumerable<string> Render(IEnumerable<Map> map)
        {
            return map.Select(RenderFrame);
        }

        public string RenderFrame(Map map)
        {
            return String.Join("\n", Enumerable.Range(_leftBottom.Y, Height)
                .Select(y => RenderLine(map, y)));
        }

        public string RenderLine(Map map, int line)
        {
            return String.Join("", Enumerable.Range(_leftBottom.X, Width)
                .Select(x => new Cell(x, line))
                .Select(map.GetCellStatus)
                .Select(s => s ? AliveChar : DeadChar));
        }
    }
}