using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Level
    {
        private List<Player> _players;
        public Dictionary<int, int> snakes;
        private readonly Map _map;
        Dice dice = new Dice();

        public Level(List<Player> players, Map map)
        {
            _players = players;
            _map = map;
        }

        public bool isPlaying()
        {
            Snake ular = new Snake(snakes,_map);

            //Looping terus sampe ada yang menang
            while (true)
            {
                int counter = 0;

                foreach (Player player in _players)
                {
                    if (!(player.isWin))
                    {
                        counter++;
						
                        player.Move(dice.getDiceNumber());
						if (player.isWin)
						{
							Console.WriteLine("Congratulations, player {0} Won", counter);
							return false;
						}

					    if (ular.isOnSnake(player.Location)) 
                        {
                            Console.WriteLine("Ketemu ular");
                            player.Move(ular.GotoTheSnake(player.Location).X - player.Location.X);
                        }    
						Console.WriteLine("Lokasi player {0} adalah {1} ", counter, player.Location.X);
                    }
                }
            }
        }
    }
}
