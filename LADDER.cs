using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace SnakeAndLadders
{
    public enum UserChoice
    {
        Start = 0,
        Reset,
        Quit
    }
    public class Positions
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Positions(int col, int row)
        {
            Column = col;
            Row = row;
        }
    }
    public class SnakeLadder
    {
        Dictionary<int, Positions> Boxes;
        Dictionary<int, int> Ladders;
        Dictionary<int, int> Snakes;
        System.Timers.Timer ForFunTimer;

        public SnakeLadder()
        {
            Boxes = new Dictionary<int, Positions>();
            InitializeMapStructure();

            ForFunTimer = new System.Timers.Timer(1000);
            ForFunTimer.Elapsed += ForFunTimer_Elapsed;
            ForFunTimer.Enabled = true;

        }
        private void InitializeMapStructure()
        {
            Positions[] positions = new Positions[100];
            int i = 0; int row = 38;
            while (row > 0)
            {
                GoAhead(ref positions, ref i, ref row);
                row -= 4;

                GoBack(ref positions, ref i, ref row);
                row -= 4;
            }
            for (int j = 1, k = 0; j <= 100; j++, k++)
            {
                Boxes.Add(j, positions[k]);
            }
        }
        void ForFunTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RotateTitle();
        }
        public void RotateTitle()
        {
            string RotateTitle = "";
            for (int i = 1; i < Console.Title.Length; i++)
            {
                RotateTitle += Console.Title[i];
            }
            RotateTitle += Console.Title[0];
            Console.Title = RotateTitle;
        }

        private void GoAhead(ref Positions[] positions, ref int i, ref int row)
        {
            for (int Col = 5; Col < 100; Col += 10) { positions[i++] = new Positions(Col, row); }
        }
        private void GoBack(ref Positions[] positions, ref int i, ref int row)
        {
            for (int Col = 95; Col > 0; Col -= 10)
            {
                positions[i++] = new Positions(Col, row);
            }
        }
        public UserChoice StartMenu()
        {
            string Down = "DownArrow";
            string Enter = "Enter";
            int Col = 45, Row = 20;
            ConsoleKeyInfo MoveCursor;

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(Col, 20);
            Console.WriteLine("     Start    ");
            Console.SetCursorPosition(Col, 22);
            Console.WriteLine("     Reset    ");
            Console.SetCursorPosition(Col, 24);
            Console.WriteLine("     Quit     ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Col -= 2, Row);
            Console.Write("*");

            while (true)
            {
                Console.SetCursorPosition(Col, Row);
                MoveCursor = Console.ReadKey();

                if (MoveCursor.Key.ToString().Equals(Enter))
                {
                    if (Row == 20)
                        return UserChoice.Start;
                    else if (Row == 22)
                        return UserChoice.Reset;
                    else
                        return UserChoice.Quit;

                }
                else if (MoveCursor.Key.ToString().Equals(Down))
                {
                    Console.SetCursorPosition(Col, Row += 2);
                    if (Row > 24)
                    {
                        Row = 20;
                        Console.SetCursorPosition(Col, Row);
                    }
                    Console.Write("*");

                }
                else
                {
                    Console.SetCursorPosition(Col, Row -= 2);
                    if (Row < 20)
                    {
                        Row = 24;
                        Console.SetCursorPosition(Col, Row);
                    }
                    Console.Write("*");
                }

            }

        }

        public void StartGame()
        {
            DrawMap();
            StartPlaying();

        }

        private void DrawMap()
        {
            DrawHorizontalLines();
            DrawVerticalLines();
            DrawNumbers();
            DrawSnakeLdder();
        }
        private void DrawHorizontalLines()
        {
            for (int Row = 0; Row < 44; Row += 4)
            {
                for (int Col = 0, j = 0; Col < 100; Col++)
                {
                    Console.SetCursorPosition(Col, Row);
                    Console.Write("{0}", (char)230);
                }
            }
        }
        private void DrawVerticalLines()
        {
            for (int Col = 0; Col < 100; Col += 10)
            {
                for (int Row = 0; Row < 40; Row++)
                {
                    Console.SetCursorPosition(Col, Row);
                    Console.Write("{0}", (char)124);
                }
            }
        }
        private void DrawNumbers()
        {
            int number = 1;
            foreach (Positions PositionOfBlocks in Boxes.Values)
            {
                Console.SetCursorPosition(PositionOfBlocks.Column + 3, PositionOfBlocks.Row + 1);
                if (number == 100)
                    Console.SetCursorPosition(PositionOfBlocks.Column + 2, PositionOfBlocks.Row + 1);
                Console.Write("{0}", number++);
            }
        }
        private void DrawSnakeLdder()
        {
            Ladders = new Dictionary<int, int>();
            Snakes = new Dictionary<int, int>();

            Ladders.Add(4, 14); Ladders.Add(9, 31); Ladders.Add(19, 38); Ladders.Add(21, 42); Ladders.Add(38, 84); Ladders.Add(71, 91); Ladders.Add(80, 100);
            Snakes.Add(17, 7); Snakes.Add(54, 34); Snakes.Add(62, 19); Snakes.Add(64, 60); Snakes.Add(87, 24); Snakes.Add(93, 79); Snakes.Add(95, 75); Snakes.Add(98, 79);

            Positions position;
            int number = 0;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            foreach (KeyValuePair<int, int> LadderPoints in Ladders)
            {
                position = Boxes[LadderPoints.Key];
                number++;
                Console.SetCursorPosition(position.Column + 1, position.Row - 1);
                Console.Write("L=>{0}", number);
                position = Boxes[LadderPoints.Value];
                Console.SetCursorPosition(position.Column + 1, position.Row - 1);
                Console.Write("L=>{0}", number);
            }
            number = 0;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            foreach (KeyValuePair<int, int> SnakePoints in Snakes)
            {
                position = Boxes[SnakePoints.Key];
                number++;
                Console.SetCursorPosition(position.Column + 1, position.Row - 1);
                Console.Write("S=>{0}", number);
                position = Boxes[SnakePoints.Value];
                Console.SetCursorPosition(position.Column + 1, position.Row - 1);
                Console.Write("S=>{0}", number);
            }

        }

        private void StartPlaying()
        {
            int UserLocation = 0;
            int CompLocation = 0;
            int numberForUser = 0;
            int numberForComp = 0;
            Positions PositionForUser = null;
            Positions PositionForComp = null;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 41);
            Console.Write("Comp");
            Console.SetCursorPosition(1, 42);
            Console.Write("User");

            bool IsUserTurn = true;

            while (true)
            {
                if (IsUserTurn)
                {

                    Console.SetCursorPosition(1, 43);
                    Console.Write("User Turn => Plz Roll Dice");
                    int tempNumber = 0;
                    Console.ReadKey();

                    tempNumber = GenerateTurn();
                    numberForUser += tempNumber;

                    if (numberForUser > 100) { numberForUser -= tempNumber; }
                    else
                        UserLocation += tempNumber;

                    if (IsOnLadder(UserLocation))
                    { UserLocation = GotoTheLadder(UserLocation); }
                    else if (IsOnSnake(UserLocation))
                    { UserLocation = GotoTheSnake(UserLocation); }

                    if (UserLocation == 100)
                    {
                        Console.Clear();
                        Console.Write("User Won");
                        Thread.Sleep(5000);
                        break;
                    }

                    if (PositionForUser != null)
                    {
                        Console.SetCursorPosition(PositionForUser.Column - 4, PositionForUser.Row + 1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("    ");
                    }

                    PositionForUser = Boxes[UserLocation];

                    Thread.Sleep(1000);

                    Console.SetCursorPosition(PositionForUser.Column - 4, PositionForUser.Row + 1);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("User");
                    IsUserTurn = false;
                }
                else
                {
                    Console.SetCursorPosition(1, 43);
                    Console.Write("Comp Turn => Plz Roll Dice");
                    int tempNumber = 0;
                    Console.ReadKey();

                    tempNumber = GenerateTurn();
                    numberForComp += tempNumber;

                    if (numberForComp > 100) { numberForComp -= tempNumber; }
                    else
                        CompLocation += tempNumber;

                    if (IsOnLadder(CompLocation))
                    { CompLocation = GotoTheLadder(CompLocation); }
                    else if (IsOnSnake(CompLocation))
                    { CompLocation = GotoTheSnake(CompLocation); }

                    if (CompLocation == 100)
                    {
                        Console.Clear();
                        Console.Write("Computer Won");
                        Thread.Sleep(5000);
                        break;
                    }

                    if (PositionForComp != null)
                    {
                        Console.SetCursorPosition(PositionForComp.Column - 4, PositionForComp.Row);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("    ");
                    }

                    PositionForComp = Boxes[CompLocation];

                    Thread.Sleep(1000);

                    Console.SetCursorPosition(PositionForComp.Column - 4, PositionForComp.Row);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("Comp");
                    IsUserTurn = true;
                }
            }
        }
        private int GenerateTurn()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int number = 0;
            for (int i = 0; i < 5000; i++)
            {
                //Thread.Sleep(1);
                Console.SetCursorPosition(30, 43);
                number = random.Next(1, 6);
                Console.Write(number);

            }

            return number;
        }
        private bool IsOnLadder(int Box)
        {
            if (Ladders.ContainsKey(Box))
                return true;
            return false;
        }
        private bool IsOnSnake(int Box)
        {
            if (Snakes.ContainsKey(Box))
                return true;
            return false;
        }
        private int GotoTheLadder(int Box)
        {
            return Ladders[Box];
        }
        private int GotoTheSnake(int Box)
        { return Snakes[Box]; }
    }
}