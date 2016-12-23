using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
       static void Main(string[] args)
        {
         
            Map one = new Map(8, 8);

            Console.WriteLine("First thing's first, select where your ship is located.");
            Ship basic = new Ship(Point.mapLocationEntry(one), 2);

            Console.WriteLine("Perfect, try to hit it now.");

            while (!basic.IsNeutralized)
            { 
            if (basic.Hit(Point.mapLocationEntry(one)))
            {
                Console.WriteLine("HIT");
                    basic.DecreaseHealth(1);
                    
            }
            else
            {
                Console.WriteLine("MISS");
            }

            }

            Console.ReadKey();

        }
    }
}
