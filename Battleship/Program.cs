using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static public Point mapLocationEntry(Board map)
        {
            bool valid = false;
            Point bar = new Point(1, 1);

            while (!valid)
            {
                int x = 0;
                int y = 0;
                Console.WriteLine("Enter X and Y with a space:");
                string[] entry = Console.ReadLine().Split();
                if (entry.Length !=2) { Console.WriteLine("This entry doesn't look like 2 numbers."); continue; };
                if  (!(Int32.TryParse(entry[0], out x))) { Console.WriteLine("Your first entry is not a number."); continue; };
                if (!(Int32.TryParse(entry[1], out y))) { Console.WriteLine("Your second entry is not a number."); continue; };
               

                Point foo = new Point(x, y);
                if (map.onMap(foo))
                { valid = true;
                  return foo;
                }
                else
                { Console.WriteLine("That is not on the board."); }
              }
            return bar;           
        }

        static void Main(string[] args)
        {
         
            Board one = new Board(8, 8);
            Ship basic = new Ship(2, 2);

            Console.WriteLine(basic.X);
            basic.Hit(mapLocationEntry(one));

            Console.ReadKey();

        }
    }
}
