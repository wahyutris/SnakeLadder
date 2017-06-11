using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Snake
    {
        private readonly Dictionary<int, int> _locationSnakes;
        //private readonly Dictionary<MapLocation, MapLocation> _locationSankes;
        private readonly Map _map;

        public Snake(Dictionary<int, int> snakes, Map map)
        {
            _locationSnakes = snakes;
            _map = map;
        }

        public bool isOnSnake(MapLocation player)
        {
            return _locationSnakes.ContainsKey(player.X) ? true : false;
        }

        public MapLocation GotoTheSnake(MapLocation player)
        {
			//Console.WriteLine("Ketemu ular");
			return new MapLocation(_locationSnakes[player.X], 0, _map);
        }
    }
}
