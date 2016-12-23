using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship 
    {

        private Point _location;
        private int _health { get; set;}
        public Ship(Point Location, int Health)
        {
            _location = Location;
            _health = Health;
        }

        public bool IsNeutralized { get { return _health <= 0; } }

        public bool Hit(Point playerChoice)
        {
            if (playerChoice.X == _location.X && playerChoice.Y==_location.Y) 
            {
                return true;  
            }

            else {return false; }
        }

        public void DecreaseHealth(int factor)
        {
            _health -= factor;
        }
    }

}
