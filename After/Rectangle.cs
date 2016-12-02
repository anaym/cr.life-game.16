using System;

namespace CR_Life.After
{
    public struct Rectangle
    {
        public readonly int Left;
        public readonly int Right;
        public readonly int Top;
        public readonly int Bottom;

        public Cell LeftTop => new Cell(Left, Top);
        public Cell RightBottom => new Cell(Right, Bottom);
        public Cell LeftBottom => new Cell(Left, Bottom);
        public Cell RightTop => new Cell(Right, Top);
        
        public int Width => Right - Left + 1;
        public int Height => Top - Bottom + 1;

        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = Math.Min(left, right);
            Right = Math.Max(left, right);
            Top = Math.Max(top, bottom);
            Bottom = Math.Min(top, bottom);
        }

        public bool Contains(Cell cell)
        {
            return (cell.X <= Right && cell.Y <= Top) && (cell.X >= Left && cell.Y >= Bottom);
        }

        public Cell TranslateCell(Cell cell)
        {
            if (Contains(cell)) return cell;
            var dx = (Width + (cell.X - Left)%Width)%Width;
            var dy = (Height + (cell.Y - Bottom)%Height)%Height;
            return new Cell(Left + dx, Bottom + dy);
        }

        public override string ToString() => $"({Left}, {Top}, {Right}, {Bottom})";
    }
}