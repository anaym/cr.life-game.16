using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.Session_5
{
    public struct Cell
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Cell> Near
        {
            get
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j ==0)
                            continue;
                        yield return new Cell(X + i, Y + j);
                    }
                }
                
            }
        }
    }

    [TestFixture]
    public class Cell_Should
    {
        private Cell cell;

        [SetUp]
        public void SetUp()
        {
            cell = new Cell(10, -10);
        }


        [Test]
        public void ReturnCorrectNear()
        {
            cell.Near.Count().Should().Be(8);
        }
    }
}