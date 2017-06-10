using System;
using System.Collections.Generic;

namespace Project4SnakeLadder
{
    public class Level
    {
        private List<Player> _players;
        Dice dice = new Dice();
        public Dictionary<MapLocation, MapLocation> snakes { get; set; }

        public Level(List<Player> players)
        {
            _players = players;
        }

        public bool isPlaying()
        {
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
                        //foreach(Snake ular in snakes)
                        //{
                        //    if (ular.isOnSnake(player.Location)) player.Location = ular.GotoTheSnake(player.Location);
                        //}

                        if (player.isWin)
                        {
                            Console.WriteLine("The Winner is player {0}", counter);
                            return false;
                        }
                        Console.WriteLine("Lokasi player {0} adalah {1} ", counter, player.Location.X);
                    }
                }
            }
        }
    }
}
