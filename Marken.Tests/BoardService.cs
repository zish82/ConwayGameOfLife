using System;

namespace Tests
{
    public class BoardService
    {
        public BoardService()
        {
        }

        public Board GetBoard(int width, int height)
        {
            return new Board(width, height);
        }

        public void SetBoardSate()
        {
            throw new NotImplementedException();
        }
    }
}