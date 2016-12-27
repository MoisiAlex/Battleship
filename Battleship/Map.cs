using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Map
    {
        private int[,] _map;
        public int Length1 => _map.GetUpperBound(0);
        public int Length2 => _map.GetUpperBound(1);
        public List<Point> _ships = new List<Point>();

        public Map(int[,] map)
        { _map = map; }
        public bool OnMap(Point point)
        {
            return (point.X >= 0 && point.Y >= 0 && point.X <= Length1 && point.Y <= Length2);
        }
        public int onPath(Point point)
        {
            return onPath(point.X, point.Y);
        }

        public int onPath(int x, int y)
        {
            return (_map[x, y]);
        }

        public static void printMap(Map foo)
        {
            // Get upper bounds for the array
            int bound0 = foo.Length1;
            int bound1 = foo.Length2;


            // generate border
            Console.Write("  | ");
            for (int variable2 = 0; variable2 <= bound1; variable2++)
            {
                Console.Write(" " + variable2 + " ");
            }
            Console.WriteLine();
            Console.Write("--+");
            for (int variable2 = 0; variable2 <= bound1; variable2++)
            {
                Console.Write("---");
            }
            Console.WriteLine();

            // Use for-loops to iterate over the array elements
            for (int variable1 = 0; variable1 <= bound0; variable1++)
            {
                Console.Write(variable1 + " | ");
                for (int variable2 = 0; variable2 <= bound1; variable2++)
                {
                    int value = foo.onPath(variable1, variable2);
                    
                    Console.Write(" "+value+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void addShip(Point location)
            {
            _map[location.X, location.Y] = 1;
            _ships.Add(location);
            }

        public void removeShip(Point location)
        {
            _map[location.X, location.Y] = 0;
            _ships.RemoveAll(a => a.X == location.X && a.Y == location.Y);


        }

        public bool isAlive()
        {
            if(_ships.Count > 0)
                { return true; }
            else
                { return false; }
        }

        public bool radius(Point playerChoice)
        {
            foreach(Point i in _ships)
            {
                if (playerChoice.DistanceTo(i) <=2)
                { return true; }

            }

           return false;
        }

       public int hit(Point playerChoice)
        {
            if (_map[playerChoice.X, playerChoice.Y] == 1)
            {
                removeShip(playerChoice);
                return 1;
            }

            else if (radius(playerChoice))
              {
               return 2;
              }
            else
            { return 0; }
        }
    }
}
