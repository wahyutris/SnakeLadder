using System;
namespace Project4SnakeLadder
{
    public class MapLocation : Point
    {
		public MapLocation(int x, int y, Map map) : base(x, y) //mengambil dari base nilai x dan y
		{
            if (!map.onMap(this)) //jika titik ini tidak di map
            {
                throw new Exception("point ga di map");
			}
		}

        //public MapLocation(Point point) : base(point.X,point.Y)
        //{
            
        //}
    }
}
