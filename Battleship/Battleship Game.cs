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

            Map player1 = new Map(new int[8,8]);

            Random rand1 = new Random();
            

            Point baz = new Point(rand1.Next(0,8), rand1.Next(0, 8));
                 
            Map.printMap(player1);

            player1.addShip(baz);


            var valid = 0;
            while(player1.isAlive())
            {
                valid = player1.hit(Point.playerEntry(player1));

                if (valid == 2)
                { Console.WriteLine("You are close, try again"); }
                else if (valid == 0)
                { Console.WriteLine("Complete miss, try again"); }
                else if (valid == 1)
                { Console.WriteLine("You hit!"); }
            
            }

            Console.ReadKey();

            Map.printMap(player1);

            Console.ReadKey();

        }
    }
}
