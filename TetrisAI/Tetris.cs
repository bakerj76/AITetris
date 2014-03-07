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

        private static BitArray2D[] _pieces;
        private BitArray2D _board;

        static Tetris()
        {
            _pieces = new BitArray2D[MAX_PIECE_TYPES];
            CreatePieces();
        }

        /// <summary>
        /// The actual Tetris game.
        /// </summary>
        public Tetris()
        {
            _board = new BitArray2D(TETRIS_WIDTH, TETRIS_HEIGHT);
            //_board.SetBit(0, 0, true);

            //_board.PrettyPrint();
            //Console.ReadKey();

            //Console.ReadKey();
        }

        public static void CreatePieces()
        {
            _pieces[(int)Pieces.SQUAREBLOCK] = new BitArray2D(new[] {
                new[] {0, 1, 1, 0},
                new[] {0, 1, 1, 0},
                new[] {0, 0, 0, 0},
                new[] {0, 0, 0, 0}});

            _pieces[(int)Pieces.TBLOCK] = new BitArray2D(new[] {
                new[] {0, 1, 0, 0},
                new[] {1, 1, 1, 0},
                new[] {0, 0, 0, 0},
                new[] {0, 0, 0, 0}
            });

            _pieces[(int)Pieces.SBLOCK] = new BitArray2D(new[] {
                new[] {0, 1, 1, 0},
                new[] {1, 1, 0, 0},
                new[] {0, 0, 0, 0},
                new[] {0, 0, 0, 0}
            });

            _pieces[(int)Pieces.ZBLOCK] = new BitArray2D(new[] {
                new[] {1, 1, 0, 0},
                new[] {0, 1, 1, 0},
                new[] {0, 0, 0, 0},
                new[] {0, 0, 0, 0}
            });

            _pieces[(int)Pieces.JBLOCK] = new BitArray2D(new[] {
                new[] {0, 1, 0, 0},
                new[] {0, 1, 0, 0},
                new[] {1, 1, 0, 0},
                new[] {0, 0, 0, 0}
            });

            _pieces[(int)Pieces.LBLOCK] = new BitArray2D(new[] {
                new[] {0, 1, 0, 0},
                new[] {0, 1, 0, 0},
                new[] {0, 1, 1, 0},
                new[] {0, 0, 0, 0}
            });

            _pieces[(int)Pieces.IBLOCK] = new BitArray2D(new[] {
                new[] {0, 1, 0, 0},
                new[] {0, 1, 0, 0},
                new[] {0, 1, 0, 0},
                new[] {0, 1, 0, 0}
            });
        }

        


    }
}
