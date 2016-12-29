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

       static public Point playerEntry(Map map,Player p1)
        {
            //Validate input. Will return a point if valid, or loop until entry is corect.
            bool valid = false;
            Point bar = new Point(1, 1);

            while (!valid)
            {
                int x = 0;
                int y = 0;
                Console.WriteLine("Enter X and Y with a space:");
                string[] entry = Console.ReadLine().Split();
                if (entry[0] == "m") { Player.printPlayerMap(p1); continue; }
                if (entry.Length != 2) { Console.WriteLine("This entry doesn't look like 2 numbers."); continue; };
                if (!(Int32.TryParse(entry[0], out x))) { Console.WriteLine("Your first entry is not a number." ); continue; };
                if (!(Int32.TryParse(entry[1], out y))) { Console.WriteLine("Your second entry is not a number."); continue; };

            //Validate the point is on the map we created.
                Point foo = new Point(x, y);
                if (map.OnMap(foo))
                {
                    valid = true;
                    return foo;
                }
                else
                { Console.WriteLine("That is not on the board."); }
            }
            return bar;
        }

        public int DistanceTo(int x, int y)
        {
            return (int)Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2));
        }
        public int DistanceTo(Point point)
        {
            return DistanceTo(point.X, point.Y);
        }

    }
}
