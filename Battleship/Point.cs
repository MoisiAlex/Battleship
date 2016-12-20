using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int foo, int bar)
            {
            X = foo;
            Y = bar;
            }

        
    }
}
