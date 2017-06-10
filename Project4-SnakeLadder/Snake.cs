using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Snake
    {
        private readonly Dictionary<MapLocation, MapLocation> _locationSnakes;

        public Snake(Dictionary<MapLocation, MapLocation> snakes)
        {
            _locationSnakes = snakes;
        }

        public bool isOnSnake(MapLocation player)
        {
            return (_locationSnakes.ContainsKey(player)) ? true : false;
        }

        public MapLocation GotoTheSnake(MapLocation player)
        {
            return _locationSnakes[player];
        }
    }
}
