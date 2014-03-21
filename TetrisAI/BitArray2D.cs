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

        public BitArray2D RotateLeft()
        {
            var temp = new BitArray2D(Width, Height);
            
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    temp.SetBit(x, y, _map[Height - y - 1, x]);
                }
            }

            return temp;
        }

        public BitArray2D RotateRight()
        {
            var temp = new BitArray2D(Width, Height);

            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                   temp.SetBit(x,y,_map[y, Width - x - 1]);
                }
            }

            return temp;
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
                    Console.Write(_map[x, y] ? 'X' : '.');
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
