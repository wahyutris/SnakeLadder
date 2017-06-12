using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    class Game
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Snake Ladder Game");

            Console.Write("Input dimensions = ");
            int dimensions = int.Parse(Console.ReadLine());

            int areaDimensions = dimensions * dimensions;
            Map map = new Map(areaDimensions, 1);

            //Console.WriteLine("----------- CHECKIN IN MAP -------------");
            //Point point = new Point(1,0);
            //bool isOnMap = map.onMap(point);
            //Console.WriteLine(isOnMap);
            //Console.WriteLine();

            //Console.WriteLine("----------- GET DICE NUMBER -------------");
            //Dice dice = new Dice();
            //Console.WriteLine(dice.getDiceNumber());

            Random randomGenerator = new Random();

            try
            {
				//Dekalarasi posisi yang available buat di move
				List<MapLocation> loc = new List<MapLocation>();
				for (int i = 0; i < areaDimensions; i++)
				{
					loc.Add(new MapLocation(i, 0, map));
				}
				Path path = new Path(loc);
                Console.WriteLine("START from {0} and FINISH at {1}", 0, path.Length);

                //Deklarasi player
                List<Player> players = new List<Player>();
                List<string> names = new List<string>();
                Console.Write("Masukin jumlah player = ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    players.Add(new Player(path));
                    Console.Write("Name player {0} = ", i + 1);
                    names.Add(Console.ReadLine());
                }
                	

                //Deklarasi Snake
                Console.Write("Total snakes = ");
                int snake = int.Parse(Console.ReadLine());
                Dictionary<int, int> ular = new Dictionary<int, int>();
                //{
                //    {17, 7},
                //    {54, 34},
                //    {62, 19},
                //    {27, 1},
                //    {34, 21},
                //    {48, 23}
                //    //{new MapLocation(17,0,map), new MapLocation(7,0,map)},
                //    //{new MapLocation(54,0,map), new MapLocation(34,0,map)},
                //    //{new MapLocation(62,0,map), new MapLocation(19,0,map)},
                //    //{new MapLocation(27,0,map), new MapLocation(1,0,map)},
                //    //{new MapLocation(34,0,map), new MapLocation(21,0,map)},
                //    //{new MapLocation(48,0,map), new MapLocation(23,0,map)}
                //};

                //RANDOM Snake Position
                for (int i = 0; i < snake; i++)
                {
	                // Snake head
	                int snakeHead = randomGenerator.Next(snake + 1, areaDimensions);

                    //ngecek biar head gada yang sama
                    while(ular.ContainsKey(snakeHead))
                        snakeHead = randomGenerator.Next(snake + 1, areaDimensions);

                    // Snake tail
                    int snakeTail = randomGenerator.Next(1, snakeHead - 1);

                    Console.WriteLine("Lokasi ular ke-{0} di {1},{2}", i+1, snakeHead, snakeTail);
                    ular.Add(snakeHead, snakeTail);
                }

				//Tes ular
				//Console.WriteLine("----------- GET SNAKE -------------");
				//Snake snake = new Snake(ular,map);
				//Console.WriteLine("Ada di ular gak ? {0}", snake.isOnSnake(new MapLocation(61,0,map)));


				//Deklarasi tangga
				Console.Write("Total ladders = ");
				int ladder = int.Parse(Console.ReadLine());
                Dictionary<int, int> tangga = new Dictionary<int, int>();

                //RANDOM position ladder
                for (int i = 0; i < ladder; i++)
                {
                    //Ladder bottom
                    int ladderBottom = randomGenerator.Next(1, areaDimensions - ladder);
                    while (tangga.ContainsKey(ladderBottom))
	                    ladderBottom = randomGenerator.Next(1, areaDimensions - ladder);

                    //Ladder top
                    int ladderTop = randomGenerator.Next(ladderBottom + 1, areaDimensions);

					Console.WriteLine("Lokasi tangga ke-{0} di {1},{2}", i+1, ladderBottom, ladderTop);
					tangga.Add(ladderBottom, ladderTop);
                }

                //Game on
                Level level = new Level(players, names, map, areaDimensions)// , ular, tangga);
                {
                    snakes = ular,
				    ladders = tangga,
                };

                Console.WriteLine();
                bool playingStatus = level.isPlaying();
                if (!playingStatus)
                {
                    Console.WriteLine("Game Over");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		}
    }
}
