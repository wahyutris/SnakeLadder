using System;
namespace Project4SnakeLadder
{
    public class Map
    {
		public readonly int Height; //default access modifier is private if it's not declared
		public readonly int Width; //readonly so the value didn't change when looping program

		public Map(int width, int height) //harus sama *, constructor buat objek
		{
			Width = width;
			Height = height;
		}

		public bool onMap(Point point)
		{
			bool panjang = point.X < Width && point.X >= 0; //karena mulainya dari 0, maka batasnya < width
			bool lebar = point.Y < Height && point.Y >= 0;

			return panjang && lebar;
		}
    }
}
