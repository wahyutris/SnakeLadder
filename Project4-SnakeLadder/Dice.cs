using System;
namespace Project4SnakeLadder
{
    public class Dice
    {
        private static Random randomgenerator = new Random();

        public int getDiceNumber()
		{
            int number = randomgenerator.Next(1, 7);
            Console.WriteLine("Random Dice Number = {0}", number);
            return number;
        }
    }
}
