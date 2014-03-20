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
            CreatePieces();
        }

        /// <summary>
        /// The actual Tetris game.
        /// </summary>
        public Tetris()
        {
            
        }

        public static void CreatePieces()
        {
            using (StreamReader file = new StreamReader(@"C:\Users\Owner\documents\visual studio 2013\Projects\TetrisAI\TetrisAI\pieces.txt"))
            {
                for (int piece = 0; piece < MAX_PIECE_TYPES; piece++)
                {
                    int count = int.Parse(file.ReadLine());
                    _pieces[piece] = new BitArray2D(count, count);

                    for (int line = 0; line < count; line++)
                    {
                        string temp = file.ReadLine();

                        for (int i = 0; i < temp.Length; i++)
                        {
                            _pieces[piece].SetBit(i, line, temp[i] == '1');
                        }
                    }

                    _pieces[piece].PrettyPrint();
                }
            }
        }
    }
}