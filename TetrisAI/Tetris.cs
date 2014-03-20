using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TetrisAI
{
    class Tetris
    {
        private const int TETRIS_WIDTH = 10;
        private const int TETRIS_HEIGHT = 22;
        private const int MAX_PIECE_TYPES = 7;

        private enum Pieces { IBLOCK, OBLOCK, TBLOCK, SBLOCK, ZBLOCK, JBLOCK, LBLOCK }

        private static BitArray2D[] _pieces;
        //private BitArray2D _board;

        static Tetris()
        {
            _pieces = new BitArray2D[MAX_PIECE_TYPES];
           // CreatePieces();
        }

        /// <summary>
        /// The actual Tetris game.
        /// </summary>
        public Tetris()
        {
/*            int i = 0;
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
            }*/
        }

        public void CreatePieces()
        {
              StreamReader temp = new StreamReader(@"C:\code\Tetris\pieces.txt");
              int count = int.Parse(temp.ReadLine());
              string[][] test;
              string _temp;
              test = new string[count][];
              int externalcount = 0;
              while ((_temp = temp.ReadLine()) != null)
               {
                   if (externalcount>4)
                   {
                       externalcount = 0;
                   }
                   ++externalcount;
                   test[externalcount-1]= new string[count];
                   for (int i = 0; i < _temp.Length; i++)
                   {
                   Console.Write(test[externalcount - 1][i] = _temp[i].ToString());
                   }
               }
             
            //while (StreamReader(@"C:\code\Tetris\IBLOCK.txt").ReadLine() != null)
           /* for (int i = 0; i < lines.Length; i++ )
            {
                temp = lines[i];
                for (int j = 0; j<temp.Length; j++)
                {
                    _pieces[(int)Pieces.IBLOCK][i][j] = temp[j]-'0';
                }
            }
            var temptest = new BitArray2D(_pieces[(int)Pieces.IBLOCK]);
            temptest.PrettyPrint();*/
            /*for (int x = 0; x < MAX_PIECE_TYPES; x++)
            {
                _pieces[x] = new[] { new[] { 0 } };
            }*/
            /**            }
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
                        }*/
            }
        }
}