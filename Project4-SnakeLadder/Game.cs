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

            try
            {
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
                Dictionary<MapLocation, MapLocation> ular = new Dictionary<MapLocation, MapLocation>()
                {
                    {new MapLocation(17,0,map), new MapLocation(7,0,map)},
                    {new MapLocation(54,0,map), new MapLocation(34,0,map)},
                    {new MapLocation(62,0,map), new MapLocation(19,0,map)},
                    {new MapLocation(27,0,map), new MapLocation(1,0,map)},
                    {new MapLocation(34,0,map), new MapLocation(21,0,map)},
                    {new MapLocation(48,0,map), new MapLocation(23,0,map)}
                };

                //Game on
                Level level = new Level(players)
                {
                    snakes = ular
                };

                bool playingStatus = level.isPlaying();
                if (playingStatus == false)
                {
                    //var winner = 
                    Console.WriteLine("Game Over");
                }

                    

                //TES GALIH
                //Player player1 = new Player(path);
                //Player player2 = new Player(path);

                //while(player1.Location.X <= 64)
                //{
                //    player1.Move(dice.getDiceNumber());
                //    Console.WriteLine("Lokasi player 1 = {0}", player1.Location.X);
                //    //player2.Move(dice.getDiceNumber());
                //    //Console.WriteLine("Lokasi player 2 = {0}", player2.Location.X);
                //}
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		}
    }
}
