using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private const int width = 32;
        private const int height = 32;
        private BoardService service;
        private Board board;

        [SetUp]
        public void Setup()
        {
            service = new BoardService();
            board = service.GetBoard(width, height);
        }

        [Test]
        public void WhenInitializingBoard()
        {
            board.Width.Should().Be(width);
            board.Height.Should().Be(height);
        }

        [Test]
        public void InitializeBoardWithInitialState()
        {
            board.SetState(2, 3);
            
            board.Cells[2, 3].Should().Be(true);
        }

        [Test]
        public void CellWithFewerThan2LiveNeighboursDie()
        {
            board.SetState(2, 3);

            var isAlive = board.CanStayAlive(2, 3);

            isAlive.Should().Be(false);
        }

        [Test]
        public void CellWith2Or3LiveNeighboursSurvive()
        {
            board.SetState(1, 3);
            board.SetState(2, 3);
            board.SetState(3, 3);

            var isAlive = board.CanStayAlive(2, 3);

            isAlive.Should().Be(true);
        }

        [Test]
        public void DeadCellWith3LiveNeighboursBecomeALive()
        {
            board.SetState(1, 3);
            //board.SetState(2, 3);
            board.SetState(3, 3);
            board.SetState(2, 4);

            var isAlive = board.CanStayAlive(2, 3);

            isAlive.Should().Be(true);
        }
    }
}