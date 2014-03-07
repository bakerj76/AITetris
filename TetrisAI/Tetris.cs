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

        private enum Pieces { IBLOCK, OBLOCK, TBLOCK, SBLOCK, ZBLOCK, JBLOCK, LBLOCK }

        private static int[][][] _pieces;
        //private BitArray2D _board;

        static Tetris()
        {
            _pieces = new int[MAX_PIECE_TYPES][][];
            CreatePieces();
        }

        /// <summary>
        /// The actual Tetris game.
        /// </summary>
        public Tetris()
        {
            int i = 0;
            var piece = new BitArray2D(_pieces[0]);

            while (true)
            {
                piece.PrettyPrint();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.LeftArrow:
                        i = i - 1 < 0 ? MAX_PIECE_TYPES - 1 : i - 1;
                        piece = new BitArray2D(_pieces[i]);
                        break;
                    case ConsoleKey.RightArrow:
                        i++;
                        i %= MAX_PIECE_TYPES;
                        piece = new BitArray2D(_pieces[i]);
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.X:
                        piece.RotateRight();
                        break;
                    case ConsoleKey.Z:
                        piece.RotateLeft();
                        break;
                }

                Console.Clear();
            }
        }

        public static void CreatePieces()
        {
            _pieces[(int)Pieces.IBLOCK] = new[] {
                new[] {0, 0, 0, 0},
                new[] {1, 1, 1, 1},
                new[] {0, 0, 0, 0},
                new[] {0, 0, 0, 0}
            };

            _pieces[(int)Pieces.OBLOCK] = new[] {
                new[] {1, 1},
                new[] {1, 1}
            };

            _pieces[(int)Pieces.TBLOCK] = new[] {
                new[] {0, 1, 0},
                new[] {1, 1, 1},
                new[] {0, 0, 0}
            };

            _pieces[(int)Pieces.SBLOCK] = new[] {
                new[] {0, 1, 1},
                new[] {1, 1, 0},
                new[] {0, 0, 0}
            };

            _pieces[(int)Pieces.ZBLOCK] = new[] {
                new[] {1, 1, 0},
                new[] {0, 1, 1},
                new[] {0, 0, 0}
            };

            _pieces[(int)Pieces.JBLOCK] = new[] {
                new[] {1, 0, 0},
                new[] {1, 1, 1},
                new[] {0, 0, 0}
            };

            _pieces[(int)Pieces.LBLOCK] = new[] {
                new[] {0, 0, 1},
                new[] {1, 1, 1},
                new[] {0, 0, 0}
            };
        }
    }
}
