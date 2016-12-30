using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player : Board
    {
        private Board _map;
        private string[,] _playerMap;
        private List<Point> _ships = new List<Point>();
        public int attempts = 0;

        //Instance constructor
        public Player(string[,] map, string[,] map1): base(map)
        {   _map = new Board(map);
            _playerMap = Board.generateEmptyMap(map1);
        }

        // Game logic for working with the maps
        private int upCount = 0;
        private int sideCount = 0;
       
        private int dir = new Random().Next(0, 2); //0 == up; 1 == side


        private void removeShip(Point location)
        {
            _playerMap[location.X, location.Y] = "X";
            _map.setValue(location.X, location.Y,"O");
            _ships.RemoveAll(a => a.X == location.X && a.Y == location.Y);
        }

        private void addMiss(Point location)
        {
            _playerMap[location.X, location.Y] = "M";
            attempts += 1;
        }

        private bool radius(Point playerChoice)
        {
            foreach (Point i in _ships)
            {
                if (playerChoice.DistanceTo(i) <= 2)
                { return true; }
            }
            return false;
        }

        private bool addShip(Point location, int shipSize, int orientation)
        { 
            if (orientation == 0)
            {
                  for (int i = 0; i < shipSize; i++)
                {
                    Point ship = new Point(location.X + i, location.Y);
                    _map.setValue(location.X + i, location.Y, "S");
                    _ships.Add(ship);
                    upCount = 0;
                }
                return true;
            }
            else if (orientation == 1)
            {
                for (int i = 0; i < shipSize; i++)
                {
                    Point ship = new Point(location.X, location.Y + i);
                    _map.setValue(location.X, location.Y + i, "S");
                    _ships.Add(ship);
                    sideCount = 0;
                }
                return true;
            }
            else
            { return false; }
        }

        private bool shipCollision(Point start, Point end, int dir)
        {
            if (dir == 0)
            {
                for (int i = start.X; i < end.X; i++)
                {
                    if(_map.returnValue(i, start.Y) == "S")
                    {
                        upCount += 1;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = start.Y; i < end.Y; i++)
                {
                    if (_map.returnValue(start.X, i) == "S")
                    {
                        sideCount += 1;
                        return true;
                    }
                }
                return false;
            }

        }

        private Point findValidLoctaion (Player p1, int shipSize, int dir)
        {
            Random rand1 = new Random();
            Point shipStart = new Point(rand1.Next(0, p1._playerMap.GetUpperBound(0)-1), rand1.Next(0, p1._playerMap.GetUpperBound(1)-1));

            
            if (dir == 0)
            { 
                Point shipEnd = new Point(shipStart.X + shipSize, shipStart.Y);
                while (!p1.OnMap(shipStart) || !p1.OnMap(shipEnd) || (p1.shipCollision(shipStart, shipEnd, dir)))
                {
                    shipStart = new Point(rand1.Next(0, p1._playerMap.GetUpperBound(0)+1), rand1.Next(0, p1._playerMap.GetUpperBound(1)+1));
                    shipEnd = new Point(shipStart.X + shipSize, shipStart.Y);
                    if (upCount > 5)
                    { dir = 1; }
                }
                
            }
            else
            { 
                Point shipEnd = new Point(shipStart.X, shipStart.Y + shipSize);
                while (!p1.OnMap(shipStart) || !p1.OnMap(shipEnd) || (p1.shipCollision(shipStart, shipEnd, dir)))
                {
                    shipStart = new Point(rand1.Next(0, p1._playerMap.GetUpperBound(0)+1), rand1.Next(0, p1._playerMap.GetUpperBound(1)+1));
                    shipEnd = new Point(shipStart.X, shipStart.Y + shipSize);
                    if (sideCount > 5)
                    { dir = 0; }
                }

            }

            return shipStart;
        }

        public void AIaddShip(Player p1, int shipSize) /// only pass through board. 
        {
            dir = new Random().Next(0, 2); //0 == up; 1 == side

            Point shipLocation = findValidLoctaion(p1, shipSize, dir);
            p1.addShip(shipLocation, shipSize, dir);
                      
        }

//------------------------------------------------------------------------


        public bool isAlive()
        {
            if (_ships.Count > 0)
            { return true; }
            else
            { return false; }
        }

       public int hit(Point playerChoice)
        {
            if (_map.returnValue(playerChoice.X, playerChoice.Y) == "S")
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
            Board.printMap(foo._playerMap);         
        }

        public static void printGameMap(Player foo)
        {
            Board.printMap(foo._map);
        }

        
    }
}
