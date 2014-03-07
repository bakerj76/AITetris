using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisAI
{
    class BitArray2D
    {
        #region Public Variables
        /// <summary> 
        /// The width of the array. 
        /// </summary>
        public int Width { get; private set; }
        /// <summary> 
        /// The height of the array. 
        /// </summary>
        public int Height { get; private set; }
        #endregion

        #region Private Variables
        /// <summary>
        /// A 2D array of booleans representing the actual array.
        /// </summary>
        private bool[,] _map;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a 2D array of bits.
        /// </summary>
        /// <param name="width">The width of the array.</param>
        /// <param name="height">The height of the array.</param>
        public BitArray2D(int width, int height)
        {
            Width = width;
            Height = height;

            _map = new bool[width, height];
        }

        public BitArray2D(int[][] map)
        {
            Height = map.Length;
            Width = map[0].Length;

            _map = new bool[Width, Height];
            
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    _map[x, y] = map[y][x] == 1;
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Sets the value of a bit at x and y.
        /// </summary>
        /// <param name="x">The x-coordinate of the bit to set.</param>
        /// <param name="y">The y-coordinate of the bit to set.</param>
        /// <param name="value">The value to set the bit to at (x,y).</param>
        public void SetBit(int x, int y, bool value)
        {
            _map[x, y] = value;
        }

        public bool[,] GetBoolArray()
        {
            var temp = new bool[Width, Height];
            _map.CopyTo(temp, 0);

            return temp;
        }

        public void RotateLeft()
        {
            var temp = new bool[Height, Width];
            
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    temp[x, y] = _map[Height - y - 1, x];
                }
            }

            _map = temp;
        }

        public void RotateRight()
        {
            var temp = new bool[Height, Width];

            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    temp[x, y] = _map[y, Width - x - 1];
                }
            }

            _map = temp;
        }

        /// <summary>
        /// Prettily prints the array.
        /// </summary>
        public void PrettyPrint()
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    Console.Write(_map[x, y] ? '█' : ' ');
                }
                Console.WriteLine();
            }
        }
        #endregion

        /*public static int Mod(int a, int b)
        {
            return a - b * (a / b);
        }*/
    }
}
