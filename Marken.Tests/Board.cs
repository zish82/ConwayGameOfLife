using System;
using System.Linq;

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

        public bool CanStayAlive(int dimension, int cell)
        {
            //if (Cells[dimension, cell] == false)
            //    return false;
            int aliveNeighbours = GetLiveNeighbours(dimension, cell);

            return aliveNeighbours == 2 || aliveNeighbours == 3;
        }

        public void SetState((int, int)[] p)
        {
            Array.ForEach(p, e =>
            {
                Cells[e.Item1, e.Item2] = true;
            });
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