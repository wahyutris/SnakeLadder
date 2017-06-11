using System;
using System.Collections.Generic;
namespace Project4SnakeLadder
{
	public class Path
	{
        //private readonly MapLocation[] _path; //biasanya kalau private pake underscore
        private readonly List<MapLocation> _path;

		public Path(List<MapLocation> path) //general constructor
		{
			_path = path;
		}

		public MapLocation getLocationAt(int pathStep)
		{
            return (pathStep < _path.Count) ? _path[pathStep] : null;// _path[Math.Abs(_path.Count - pathStep)]; //ternary if
            //return _path[pathStep];
		}

		public int Length
		{
			get
			{
				return _path.Count;
			}
		}
	}
}
