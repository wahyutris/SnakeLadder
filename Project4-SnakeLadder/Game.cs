using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    class Game
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Snake Ladder Game");

            Map map = new Map(64,1);

            //Console.WriteLine("----------- CHECKIN IN MAP -------------");
            //Point point = new Point(1,0);
            //bool isOnMap = map.onMap(point);
            //Console.WriteLine(isOnMap);
            //Console.WriteLine();

            //Console.WriteLine("----------- GET DICE NUMBER -------------");
            Dice dice = new Dice();
            //Console.WriteLine(dice.getDiceNumber());

            //try
            //{
				//Dekalarasi posisi yang available buat di move
				List<MapLocation> loc = new List<MapLocation>();
				for (int i = 0; i < 64; i++)
				{
					loc.Add(new MapLocation(i, 0, map));
				}
				Path path = new Path(loc);

                //Deklarasi player
                List<Player> players = new List<Player>();
                Console.Write("Masukkin jumlah player = ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                	players.Add(new Player(path));

	            //Deklarasi Snake
	            Dictionary<int, int> ular = new Dictionary<int, int>()
	            {
	                {17, 7},
	                {54, 34},
	                {62, 19},
	                {27, 1},
	                {34, 21},
	                {48, 23}
	                //{new MapLocation(17,0,map), new MapLocation(7,0,map)},
	                //{new MapLocation(54,0,map), new MapLocation(34,0,map)},
	                //{new MapLocation(62,0,map), new MapLocation(19,0,map)},
	                //{new MapLocation(27,0,map), new MapLocation(1,0,map)},
	                //{new MapLocation(34,0,map), new MapLocation(21,0,map)},
	                //{new MapLocation(48,0,map), new MapLocation(23,0,map)}
	            };

                //Tes ular
                //Console.WriteLine("----------- GET SNAKE -------------");
                //Snake snake = new Snake(ular,map);
                //Console.WriteLine("Ada di ular gak ? {0}", snake.isOnSnake(new MapLocation(61,0,map)));

                //Game on
                Level level = new Level(players,map)
                {
                    snakes = ular
                };

                bool playingStatus = level.isPlaying();
                if (playingStatus == false)
                {
                    Console.WriteLine("Game Over");
                }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
		}
    }
}
