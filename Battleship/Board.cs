using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        public readonly int Width;
        public readonly int Height;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool onMap(Point point)
        {
            return (point.X >=0 && point.Y>= 0 && point.X <= Width && point.Y <= this.Height);
        }
    }
}
