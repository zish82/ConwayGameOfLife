namespace GameOfLife
{
    public class BoardService
    {
        private Board board;

        public BoardService()
        {
        }

        public Board GetBoard(int width, int height)
        {
            return board = new Board(width, height); 
        }

        public void NextGeneration()
        {
            var copiedCells = (bool[,])board.Cells.Clone();

            for(int dimension = 1; dimension < board.Dimension - 1; dimension++)
                for(int item = 1; item < board.Length - 1; item++)
            {
                    copiedCells[dimension, item] = board.CanStayAlive(dimension, item);
            }

            board.Cells = copiedCells;
        }
    }
}