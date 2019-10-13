using FluentAssertions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

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
            board.SetState(new (int, int)[] { (2, 3) });
            
            board.Cells[2, 3].Should().Be(true);
        }

        [Test]
        public void CellWithFewerThan2LiveNeighboursDie()
        {
            board.SetState(new (int, int)[] { (2, 3) });

            var isAlive = board.CanStayAlive(2, 3);

            isAlive.Should().Be(false);
        }

        [Test]
        public void CellWith2Or3LiveNeighboursSurvive()
        {
            board.SetState(new (int, int)[] {
                (1, 3),
                (2, 3),
                (3, 3)
            });

            var isAlive = board.CanStayAlive(2, 3);

            isAlive.Should().Be(true);
        }

        [Test]
        public void DeadCellWith3LiveNeighboursBecomeALive()
        {
            board.SetState(new (int, int)[] {
                (1, 3),
                (2, 4),
                (3, 3)
            });
            
            var isAlive = board.CanStayAlive(2, 3);

            isAlive.Should().Be(true);
        }

        [Test, TestCaseSource(typeof(TestDataSourceClass), "TestCases")]
        public bool CellsWhichSatisfyConwaysRulesCanGoToNextGeneration(List<(int, int)> states)
        {
            //Arrange
            board.SetState(states.ToArray());

            //Act
            var canGoToNextGen = board.CanStayAlive(2, 3);

            //Assert
            return canGoToNextGen;
        }        
    }

    public class TestDataSourceClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<(int, int)> { (1, 3), (2, 4), (3, 3) }).Returns(true).SetDescription("Dead cell has 3 live neighbours");
                yield return new TestCaseData(new List<(int, int)>  { (1, 3), (2, 3), (3, 3) }).Returns(true).SetDescription("Alive cell has 2 live neighbours");
                yield return new TestCaseData(new List<(int, int)> { (5, 3), (2, 3), (3, 3) }).Returns(false).SetDescription("live cell has less than 2 live neighbours");
                yield return new TestCaseData(new List<(int, int)> { (1, 3), (2, 3), (3, 3), (2, 4), (2, 2) }).Returns(false).SetDescription("live cell has more than 3 live neighbours");
            }
        }
    }
}