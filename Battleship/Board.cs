using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        private string[,] _map;
      
        public Board(string[,] map1)
        {
            _map = Board.generateEmptyMap(map1);

        }


        public static string[,] generateEmptyMap (string[,] map1)
        {// Method filling the 2D string array with waves -
            int bound0 = map1.GetUpperBound(0);
            int bound1 = map1.GetUpperBound(1);
            for (int variable1 = 0; variable1 <= bound0; variable1++)
            {
                for (int variable2 = 0; variable2 <= bound1; variable2++)
                {
                    map1[variable1, variable2] = "-";
                }
            }

            return map1;
        }

        public bool OnMap(Point point)
        {
            return (point.X >= 0 && point.Y >= 0 && point.X <= _map.GetUpperBound(0) && point.Y <= _map.GetUpperBound(1));
        }
        public string returnValue(Point point)
        { //Overload the returnValue method in case I decide to pass a point instead of coordinates
            return returnValue(point.X, point.Y);
        }

        public string returnValue(int x, int y)
        {
            return (_map[x, y]);
        }

        public void setValue(int x, int y, string value)
        {
            _map[x, y] = value;
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
        public static void printMap(Board foo)
        {
           printMap(foo._map);
        }

    }
}
