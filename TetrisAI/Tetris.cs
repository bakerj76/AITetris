using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisAI
{
    class Tetris
    {
        private const int TETRIS_WIDTH = 10;
        private const int TETRIS_HEIGHT = 22;
        private const int MAX_PIECE_TYPES = 7;

        private enum Pieces { SQUAREBLOCK, TBLOCK, SBLOCK, ZBLOCK, LBLOCK, JBLOCK, IBLOCK }
        private BitArray2D _board;

        /// <summary>
        /// The actual Tetris game.
        /// </summary>
        public Tetris()
        {
            _board = new BitArray2D(TETRIS_HEIGHT, TETRIS_HEIGHT);

            _board.PrettyPrint();
            Console.ReadKey();
        }


        


    }
}
