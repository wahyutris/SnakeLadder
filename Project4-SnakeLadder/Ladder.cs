using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Ladder
    {
		private readonly Dictionary<int, int> _locationLadders;
		private readonly Map _mapLadder;

		public Ladder(Dictionary<int, int> ladders, Map map)
		{
			_locationLadders = ladders;
			_mapLadder = map;
		}

		public bool isOnLadder(MapLocation player)
		{
			return _locationLadders.ContainsKey(player.X) ? true : false;
		}

		public MapLocation GotoTheLadder(MapLocation player)
		{
			//Console.WriteLine("Tanggaaaaaaaa");
			return new MapLocation(_locationLadders[player.X], 0, _mapLadder);
		}
    }
}
