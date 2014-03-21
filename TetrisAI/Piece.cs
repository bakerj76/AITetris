using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisAI
{
    class Piece
    {
        public int Xpos { get; private set; }
        public int Ypos { get; private set; }
        private BitArray2D _colPiece;
        public Piece(int x, int y, BitArray2D bits)
        {
            Xpos = x;
            Ypos = y;
            _colPiece = bits;
        }
        public void MoveRight()
        {
            ++Ypos;
            ++Xpos;
        }
        public void MoveLeft()
        {

        }
        public void SimulateGravity()
        {

        }
    }
}
