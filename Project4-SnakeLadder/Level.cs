using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Level
    {
        private List<Player> _players;
        public Dictionary<int, int> snakes;
        public Dictionary<int, int> ladders;
        private readonly Map _map;
        private readonly int _areaDimensions;
        //private readonly Dictionary<int, int> _snake;
        //private readonly Dictionary<int, int> _ladder;
        Dice dice = new Dice();

        public Level(List<Player> players, Map map, int areaDimensions)//, Dictionary<int, int> snake, Dictionary<int, int> ladder)
        {
            _players = players;
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

                        Console.WriteLine("Lokasi player {0} adalah {1} ", counter, player.Location.X);

                        int luckyNumber = dice.getDiceNumber();
						
                        if (player.shouldBounce(player.Location, luckyNumber))
						{
							player.Move(player.goToAfterBounce(player.Location, luckyNumber) - player.Location.X);
                            Console.WriteLine("Player {0} is BOUNCING to {1}", counter, player.Location.X);
						}
                        else player.Move(luckyNumber);						

						if (player.isWin)
						{
							Console.WriteLine("Congratulations, player {0} Won", counter);
							return false;
						}

						if (ular.isOnSnake(player.Location)) 
						{
                            Console.WriteLine("Be patient, you {0} found snake. Sliding down!",counter);;
						    player.Move(ular.GotoTheSnake(player.Location).X - player.Location.X);
						}
						if (tangga.isOnLadder(player.Location))
						{
                            Console.WriteLine("Luckily, you {0} found ladder. Climbing up!", counter);
							player.Move(tangga.GotoTheLadder(player.Location).X - player.Location.X);
						}						
                    }
                }
            }
        }
    }
}
