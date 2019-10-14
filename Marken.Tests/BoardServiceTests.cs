using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class BoardServiceTests
    {
        private const int width = 32;
        private const int height = 32;

        [Test]
        public void WhenUpdatingGeneration()
        {
            var service = new BoardService();
            var board = service.GetBoard(width, height);
            board.SetState(new (int, int)[] {(1, 3), (2, 3), (3, 3)});

            service.NextGeneration();

            board.Cells[1, 2].Should().Be(true);
            board.Cells[1, 3].Should().Be(false);
            board.Cells[1, 4].Should().Be(true);
            board.Cells[2, 2].Should().Be(true);
            board.Cells[2, 3].Should().Be(true);
            board.Cells[2, 4].Should().Be(true);
            board.Cells[3, 2].Should().Be(true);
            board.Cells[3, 3].Should().Be(false);
            board.Cells[3, 4].Should().Be(true);
        }
    }
}