using System;

namespace Tests
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] Cells;

        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            Cells = new bool[width, height];
        }

        public void SetState(int dimension, int length)
        {
            Cells[dimension, length] = true;
        }

        public bool CanStayAlive(int dimension, int cell)
        {
            //if (Cells[dimension, cell] == false)
            //    return false;
            int aliveNeighbours = GetLiveNeighbours(dimension, cell);

            return aliveNeighbours == 2 || aliveNeighbours == 3;
        }

        private int GetLiveNeighbours(int dimension, int cell)
        {
            int aliveNeighbours = 0;

            if (Cells[dimension, cell - 1] == true)
                aliveNeighbours++;
            if (Cells[dimension, cell + 1] == true)
                aliveNeighbours++;
            if (Cells[dimension + 1, cell] == true)
                aliveNeighbours++;
            if (Cells[dimension + 1, cell - 1] == true)
                aliveNeighbours++;
            if (Cells[dimension + 1, cell + 1] == true)
                aliveNeighbours++;
            if (Cells[dimension - 1, cell] == true)
                aliveNeighbours++;
            if (Cells[dimension - 1, cell - 1] == true)
                aliveNeighbours++;
            if (Cells[dimension - 1, cell + 1] == true)
                aliveNeighbours++;
            return aliveNeighbours;
        }
    }
}