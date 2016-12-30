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

            Player player1 = new Player(new string[10,10],new string[10,10]);         
           


            player1.AIaddShip(player1, 5);
            player1.AIaddShip(player1, 4);
            player1.AIaddShip(player1, 3);
            player1.AIaddShip(player1, 3);
            player1.AIaddShip(player1, 2);

       //     Player.printGameMap(player1);





            var valid = 0;
            while(player1.isAlive())
            {
                valid = player1.hit(Point.playerEntry(player1,player1));

                if (valid == 2)
                { Console.WriteLine("You are close, try again");
                }
                else if (valid == 0)
                { Console.WriteLine("Complete miss, try again");
                }
                else if (valid == 1)
                { Console.WriteLine("You hit!"); }
            
            }

            Console.WriteLine("You SMOKED him and you only missed: "+player1.attempts+" hits! You're a WINNER!");
                    

            Console.ReadKey();

        }
    }
}
