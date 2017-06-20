using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Level
    {
        private List<Player> _players;
        private List<string> _names;
        public Dictionary<int, int> snakes;
        public Dictionary<int, int> ladders;
        private readonly Map _map;
        private readonly int _areaDimensions;
        //private readonly Dictionary<int, int> _snake;
        //private readonly Dictionary<int, int> _ladder;
        Dice dice = new Dice();

        public Level(List<Player> players, List<string> names, Map map, int areaDimensions)//, Dictionary<int, int> snake, Dictionary<int, int> ladder)
        {
            _players = players;
            _names = names;
            _map = map;
            _areaDimensions = areaDimensions;
            //_snake = snake;
            //_ladder = ladder;
        }

        public bool isPlaying()
        {
            Snake ular = new Snake(snakes, _map);
            Ladder tangga = new Ladder(ladders, _map);

            //Looping terus sampe ada yang menang
            while (true)
            {
                int counter = 0;

                foreach (Player player in _players)
                {
                    if (!(player.isWin))
                    {
                        counter++;

                        Console.WriteLine("Lokasi player {0}-{1} adalah {2} ", counter, _names[counter-1], player.Location.X);
                        Console.WriteLine("Please ENTER to play");
                        Console.ReadKey();

                        int luckyNumber = dice.getDiceNumber();
						
                        if (player.shouldBounce(player.Location, luckyNumber))
						{
							player.Move(player.goToAfterBounce(player.Location, luckyNumber) - player.Location.X);
                            Console.WriteLine("Player {0}-{1} is BOUNCING to {2}", counter, _names[counter - 1], player.Location.X);
						}
                        else player.Move(luckyNumber);						

						if (player.isWin)
						{
                            Console.WriteLine("Congratulations, player {0}-{1} Won", counter, _names[counter - 1]);
							return false;
						}

						if (ular.isOnSnake(player.Location)) 
						{
                            player.Move(ular.GotoTheSnake(player.Location).X - player.Location.X);
                            Console.WriteLine("Be patient, you {0}-{1} found snake. Sliding down to {2}!", counter, _names[counter - 1], player.Location.X);
						}
						if (tangga.isOnLadder(player.Location))
						{
                            player.Move(tangga.GotoTheLadder(player.Location).X - player.Location.X);
                            Console.WriteLine("Luckily, you {0}-{1} found ladder. Climbing up to {2}!", counter, _names[counter - 1], player.Location.X);
						}

                        //Ulangi giliran kalau dapat 6
                        while(luckyNumber == 6)
                        {
							Console.WriteLine("Lokasi player {0}-{1} adalah {2} ", counter, _names[counter - 1], player.Location.X);

							luckyNumber = dice.getDiceNumber();

							if (player.shouldBounce(player.Location, luckyNumber))
							{
								player.Move(player.goToAfterBounce(player.Location, luckyNumber) - player.Location.X);
								Console.WriteLine("Player {0}-{1} is BOUNCING to {2}", counter, _names[counter - 1], player.Location.X);
							}
							else player.Move(luckyNumber);

							if (player.isWin)
							{
								Console.WriteLine("Congratulations, player {0}-{1} Won", counter, _names[counter - 1]);
								return false;
							}

							if (ular.isOnSnake(player.Location))
							{
								player.Move(ular.GotoTheSnake(player.Location).X - player.Location.X);
								Console.WriteLine("Be patient, you {0}-{1} found snake. Sliding down to {2}!", counter, _names[counter - 1], player.Location.X);
							}
							if (tangga.isOnLadder(player.Location))
							{
								player.Move(tangga.GotoTheLadder(player.Location).X - player.Location.X);
								Console.WriteLine("Luckily, you {0}-{1} found ladder. Climbing up to {2}!", counter, _names[counter - 1], player.Location.X);
							}
                        }
                        Console.WriteLine("Giliran player {0}-{1} selesai di {2} ", counter, _names[counter-1], player.Location.X);
                    }
                }
            }
        }
    }
}
