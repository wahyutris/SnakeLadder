using System;
namespace Project4SnakeLadder
{
    public class Player
    {
		private readonly Path _path;
		private int _pathStep = 0;
		//protected virtual int stepSize { get; } = 1; //protected anaknya bisa ngambil data dari ortunya, tapi kelas lain

		public Player(Path path)
        {
            _path = path;
        }

		public MapLocation Location
		{
            get
			{
                return _path.getLocationAt(_pathStep);
			}
		}

		public void Move(int stepSize) //STEPSIZE dari dice.getnumber
		{
			_pathStep += stepSize;
		}

        public bool isWin
		{
			get
			{
				return _pathStep == _path.Length;
			}
		}

        public bool shouldBounce(MapLocation player, int stepSize)
        {
            return player.X + stepSize > _path.Length;
        }

        public int goToAfterBounce(MapLocation player, int stepSize)
        {
            return _path.Length - (stepSize - (_path.Length - player.X));
        }
	}
}
