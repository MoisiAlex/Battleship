using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player : Map
    {
        private string[,] _map;
        public string[,] _playerMap;
        public List<Point> _ships = new List<Point>();


        public Player(string[,] map): base( map)
        {   _map = map;
            _playerMap = _map;

        }

        

        public void addShip(Point location)
        {
            _map[location.X, location.Y] = "S";
            _playerMap[location.X, location.Y] = "-";
            _ships.Add(location);
        }

        public void removeShip(Point location)
        {
            _playerMap[location.X, location.Y] = "X";
            _map[location.X, location.Y] = "O";
            _ships.RemoveAll(a => a.X == location.X && a.Y == location.Y);
        }

        public void addMiss(Point location)
        {
            _playerMap[location.X, location.Y] = "M";
        }

        public bool isAlive()
        {
            if (_ships.Count > 0)
            { return true; }
            else
            { return false; }
        }

        public bool radius(Point playerChoice)
        {
            foreach (Point i in _ships)
            {
                if (playerChoice.DistanceTo(i) <= 2)
                { return true; }

            }

            return false;
        }

        public int hit(Point playerChoice)
        {
            if (_map[playerChoice.X, playerChoice.Y] == "S")
            {
                removeShip(playerChoice);
                return 1;
            }

            else if (radius(playerChoice))
            {
                addMiss(playerChoice);
                return 2;
            }
            else
            { addMiss(playerChoice);
                return 0; }
        }

        public static void printPlayerMap(Player foo)
        {
            Map.printMap(foo._playerMap);
        }

    }
}
