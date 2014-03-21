using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TetrisAI
{
    class Piece
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Pieces Type { get; private set; }

        private BitArray2D _colPiece;
        public enum Pieces { IBLOCK, OBLOCK, TBLOCK, SBLOCK, ZBLOCK, JBLOCK, LBLOCK }

        public const int MAX_PIECE_TYPES = 7;

        private static BitArray2D[] _pieces;
        private static ConsoleColor[] _colors;

        private int _lastDrawX, _lastDrawY;
        
        static Piece()
        {
            _pieces = new BitArray2D[MAX_PIECE_TYPES];
            _colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.DarkMagenta, ConsoleColor.Gray };
            CreatePieces();
        }

        public Piece(int x, int y, Pieces type)
        {
            X = x;
            Y = y;
            Type = type;

            _colPiece = _pieces[(int)type];

            Width = _colPiece.Width;
            Height = _colPiece.Height;
        }

        public void MoveRight()
        {
            if (X + Width >= Tetris.TETRIS_WIDTH)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (_colPiece[Tetris.TETRIS_WIDTH - X - 1, y]) return;
                }
            }

            ++X;
        }

        public void MoveLeft()
        {
            if (X <= 0)
            {
                return;
            }

            --X;
        }

        public void RotateLeft()
        {
            var rotated = _colPiece.RotateLeft();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (rotated[x, y])
                    {
                        if (X + x >= Tetris.TETRIS_WIDTH || X + x < 0)
                        {
                            return;
                        }
                    }
                }
            }

            _colPiece = rotated;
        }

        public void RotateRight()
        {
            var rotated = _colPiece.RotateRight();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (rotated[x, y])
                    {
                        if (X + x >= Tetris.TETRIS_WIDTH || X + x < 0)
                        {
                            return;
                        }
                    }
                }
            }

            _colPiece = rotated;
        }

        public void SimulateGravity()
        {
            if (Y + Height >= Tetris.TETRIS_HEIGHT)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_colPiece[x, Tetris.TETRIS_HEIGHT - Y - 1]) return;
                }
                return;
            }

            ++Y;
        }

        public void DrawPiece()
        {
            int _tempX = X;
            int _tempY = Y;

            Console.BackgroundColor = ConsoleColor.Black;

            for (int piece_y = 0; piece_y < Height; piece_y++)
            {
                for (int piece_x = 0; piece_x < Width; piece_x++)
                {
                    int eraseX = _lastDrawX + piece_x;
                    int eraseY = _lastDrawY + piece_y;

                    if (eraseX < Tetris.TETRIS_WIDTH && eraseY < Tetris.TETRIS_HEIGHT) 
                    {
                        Console.SetCursorPosition(_lastDrawX + piece_x, _lastDrawY + piece_y);
                        Console.Write(" ");
                    }
                }
            }

            Console.BackgroundColor = _colors[(int)Type];

            for (int piece_y = 0; piece_y < Height; piece_y++)
            {
                for (int piece_x = 0; piece_x < Width; piece_x++)
                {
                    if (_colPiece[piece_x, piece_y])
                    {
                        Console.SetCursorPosition(_tempX + piece_x, _tempY + piece_y);
                        Console.Write(" ");
                    }
                }
            }

            _lastDrawX = _tempX;
            _lastDrawY = _tempY;

            Console.BackgroundColor = ConsoleColor.Black;
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
    }
}
