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
         
            Map[,] one = new Map[8,8];

            Console.WriteLine("First thing's first, select where your ship is located.");
            int x = 0;
            int y = 0;
            Console.WriteLine("Enter X and Y with a space:");
            string[] entry = Console.ReadLine().Split();
            if (entry.Length != 2) { Console.WriteLine("This entry doesn't look like 2 numbers."); };
            if (!(Int32.TryParse(entry[0], out x))) { Console.WriteLine("Your first entry is not a number.");  };
            if (!(Int32.TryParse(entry[1], out y))) { Console.WriteLine("Your second entry is not a number."); };

            Map.GenerateMap(x, y, one);

            Map.PrintMap(one);

            /*            Console.WriteLine("First thing's first, select where your ship is located.");
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
                        */

            Console.ReadKey();

        }
    }
}
