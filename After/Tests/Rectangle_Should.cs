using FluentAssertions;
using NUnit.Framework;

namespace CR_Life.After.Tests
{
    [TestFixture]
    public class Rectangle_Should
    {
        private Rectangle rectangle;

        [SetUp]
        public void SetUp()
        {
            rectangle = new Rectangle(-10, 20, 30, -10);
        }

        [TestCase(-10, 10, TestName = "on border")]
        [TestCase(-5, 15, TestName = "in rectangle")]
        public void ContainsPoint_WhenPoint(int x, int y)
        {
            var point = new Cell(x, y);
            rectangle.Contains(point).Should().BeTrue();
        }

        [Test]
        public void NotContainsPoint_WhenPointOutsideRectangle()
        {
            var point = new Cell(100, 500);
            rectangle.Contains(point).Should().BeFalse();
        }

        [Test]
        public void NotTranslatePoint_WhenContainsIts()
        {
            var point = new Cell(-5, 15);
            rectangle.TranslateCell(point).Should().Be(point);
        }

        [TestCase(-11, 10, ExpectedResult = "(30, 10)", TestName = "out on ox")]
        [TestCase(-10, 21, ExpectedResult = "(-10, -10)", TestName = "out on oy")]
        [TestCase(-11, 21, ExpectedResult = "(30, -10)", TestName = "out on ox and oy")]
        public string CorrectTranslatePointOutsideRectangle_WhenPoint(int x, int y)
        {
            return rectangle.TranslateCell(new Cell(x, y)).ToString();
        }
    }
}