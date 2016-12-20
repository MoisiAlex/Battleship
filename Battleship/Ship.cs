using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship : Point
    {
        private int health { get; set; } = 2;
        public Ship(int x, int y): base(x,y)
        {

        }

         public void Hit(Point playerChoice)
        {
            if (playerChoice.X == X && playerChoice.Y == Y)
            {
                Console.WriteLine("HIT!");
            }

            else { Console.WriteLine("MISS!"); }
        }

    }

}
