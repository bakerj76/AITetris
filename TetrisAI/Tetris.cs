using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace TetrisAI
{
    class Tetris
    {
        public const int TETRIS_WIDTH = 10;
        public const int TETRIS_HEIGHT = 22;


        private Piece _mainPiece;

        private Task _drawThread, _inputThread;

        private int _gravityTime;
        //private BitArray2D _board;

        /// <summary>
        /// The actual Tetris game.
        /// </summary>
        public Tetris()
        {
            Random rand = new Random();
            Piece.Pieces RND = (Piece.Pieces)rand.Next(Piece.MAX_PIECE_TYPES);
            _mainPiece = new Piece(4, 0, RND);

            _gravityTime = 500;

            CreateBoard();
            _mainPiece.DrawPiece();

            _drawThread = new Task(new Action(Draw));
            _inputThread = new Task(new Action(Input));
            _drawThread.Start();
            _inputThread.Start();

            while(!_inputThread.IsCompleted)
            {
                _mainPiece.SimulateGravity();
                Thread.Sleep(_gravityTime);
            }
        }


        public void Input()
        {
            while (true)
            {
                //_gravityTime = 500;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        _mainPiece.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        _mainPiece.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        _mainPiece.RotateRight();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.DownArrow:
                        _gravityTime = 1;
                        break;
                }
            }
        }

        public void CreateBoard()
        {
            var board = new BitArray2D(TETRIS_WIDTH, TETRIS_HEIGHT);
            BoardPrettyPrint();
            
            Console.WindowHeight = 23;
            Console.WindowWidth = 46;

            Console.BufferHeight = 23;
            Console.BufferWidth = 46;

            Console.WindowTop = 0;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
        public void BoardPrettyPrint()
        {
            for (var y = 0; y < TETRIS_HEIGHT; y++ )
            {
                for (var x = 0; x < TETRIS_WIDTH + 1; x++)
                {
                    if (x == TETRIS_WIDTH)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                }
            }
        }
        public void Draw()
        {
            while (true)
            {
                _mainPiece.DrawPiece();

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}