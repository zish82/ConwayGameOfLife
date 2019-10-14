using System;

namespace GameOfLife
{
    public class Board
    {
        public int Dimension { get; set; }
        public int Length { get; set; }
        public bool[,] Cells;

        public Board(int dimension, int length)
        {
            Dimension = dimension;
            Length = length;
            Cells = new bool[dimension, length];
        }

        public bool CanStayAlive(int dimension, int cell)
        {
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

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    aliveNeighbours += Cells[dimension + i, cell + j] ? 1 : 0;

            aliveNeighbours -= Cells[dimension, cell] ? 1 : 0;
            
            return aliveNeighbours;
        }
    }
}