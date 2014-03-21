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
            CreateBoard();
            int i = 0;
            BitArray2D s_piece = _pieces[i];
/*            while(true)
            {
                Console.Clear();
                s_piece.PrettyPrint();
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.RightArrow:
                        s_piece = s_piece.RotateRight();
                        break;
                    case ConsoleKey.UpArrow:
                        ++i;
                        i = i % MAX_PIECE_TYPES;
                        s_piece = _pieces[i];
                        break;
                }
            }*/
        }
        /// <summary>
        /// Creates the pieces on the console, from a text file.
        /// </summary>
        public static void CreatePieces()
        {
            /*This reads the size of the array and pieces from pieces.txt */
            using (StringReader file = new StringReader(Resource.pieces))
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
                }
            }
        }
        public void CreateBoard()
        {
            var board = new BitArray2D(TETRIS_WIDTH, TETRIS_HEIGHT);
            board.PrettyPrint();
            Console.BufferHeight = 23;
            Console.BufferWidth = 46;
            Console.WindowHeight = 23;
            Console.WindowWidth = 46;
            Console.WindowTop = 0;
        }
    }
}