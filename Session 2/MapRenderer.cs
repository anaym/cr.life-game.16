using System;

namespace CR_Life.Session_2
{
    public class MapRenderer : MapRendererBase
    {
        public static char Alive = '#';
        public static char Dead = '.';

        public override void WriteAlive() => Console.Write(Alive);

        public override void WriteDead() => Console.Write(Dead);

        public override void WriteLineEnd() => Console.WriteLine();
        public override void Clear() => Console.Clear();
    }
}