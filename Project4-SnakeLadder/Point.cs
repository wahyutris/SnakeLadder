using System;
namespace Project4SnakeLadder
{
    public class Point
    {
		public int X; //default access modifier is private if it's not declared
		public int Y; //readonly so the value didn't change when looping program

		public Point(int x, int y) //harus sama *, general constructor
		{
			X = x;
			Y = y;
		}
    }
}
