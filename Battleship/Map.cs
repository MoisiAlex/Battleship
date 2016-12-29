using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Map
    {
        private string[,] _map;
        public int maxX => _map.GetUpperBound(0);
        public int maxY => _map.GetUpperBound(1);
        

        public Map(string[,] map)
        {
            int bound0 = map.GetUpperBound(0); 
            int bound1 = map.GetUpperBound(1);
            for (int variable1 = 0; variable1 <= bound0; variable1++)
            {
                for (int variable2 = 0; variable2 <= bound1; variable2++)
                {
                    map[variable1, variable2] = "-";     
                }
            }

            _map = map;
        }
        public bool OnMap(Point point)
        {
            return (point.X >= 0 && point.Y >= 0 && point.X <= maxX && point.Y <= maxY);
        }
        public string returnValue(Point point)
        {
            return returnValue(point.X, point.Y);
        }

        public string returnValue(int x, int y)
        {
            return (_map[x, y]);
        }

        public static void printMap(string[,] foo)
        {
            // Get upper bounds for the array
            int bound0 = foo.GetUpperBound(0);
            int bound1 = foo.GetUpperBound(1);


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
                    string value = foo[variable1, variable2];
                    
                    Console.Write(" "+value+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

   
    }
}
