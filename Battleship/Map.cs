using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Map
    {
     /*   public readonly int Width;
        public readonly int Height;
        */
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Occupied { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        
        public bool OnMap(Point point)
        {
            return (point.X >= 0 && point.Y >= 0 && point.X <= Width && point.Y <= this.Height);
        }

        public static void GenerateMap (int x, int y, Map[,] bar)
            {
            bar[x, y].Occupied = 1;

            }

        public static void PrintMap(Map[,] bar)
        {
            for (int i=0; i < bar.Rank; i++)
            {
                Console.WriteLine(" " + bar[i, i].Occupied + " ");

            }
        }


    }
}
