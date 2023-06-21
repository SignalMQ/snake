namespace Snake
{
    internal class Program
    {
        public static Random random = new Random();

        public static string[][] Map = new string[5][]
        {
            new string[5],
            new string[5],
            new string[5],
            new string[5],
            new string[5]
        };

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        class Target
        {
            public int X     { get; set; }
            public int Y     { get; set; }
            public int Count { get; set; }
        }

        static void MoveTo(int key, Point p, Target t)
        {
            //move
            switch (key)
            {
                case 1: if (p.X != 0) p.X--;             break;
                case 2: if (p.Y != Map[0].Length) p.Y++; break;
                case 3: if (p.X != Map.Length) p.X++;    break;
                case 4: if (p.Y != 0) p.Y--;             break;
            }

            //clear
            for (int j = 0; j < Map.Length; j++)
            {
                for (int i = 0; i < Map[j].Length; i++)
                {
                    if (Map[j][i] != "X")
                    Map[j][i] = "#";
                }
            }

            //draw target
            Map[t.Y][t.X] = "X";

            //draw
            for (int j = 0; j < Map.Length; j++)
            {
                for (int i = 0; i < Map[j].Length; i++)
                {
                    if (Map.Length != p.Y && Map[j].Length != p.X)
                    {
                        Map[p.Y][p.X] = "@";
                    }
                }
            }

            //out
            for (int j = 0; j < Map.Length; j++)
            {
                for (int i = 0; i < Map[j].Length; i++)
                {
                    Console.Write(Map[j][i]);
                }
                Console.WriteLine();
            }

            if (p.X == t.X && p.Y == t.Y)
            {
                t.X = random.Next(5);
                t.Y = random.Next(5);
            }
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;
            Point point = new Point();
            Target target = new Target();

            target.X = random.Next(Map[0].Length);
            target.Y = random.Next(Map.Length);

            while (true)
            {
                keyInfo = Console.ReadKey();
                Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A: MoveTo(1, point, target); break;
                    case ConsoleKey.S: MoveTo(2, point, target); break;
                    case ConsoleKey.D: MoveTo(3, point, target); break;
                    case ConsoleKey.W: MoveTo(4, point, target); break;
                }
            }
        }
    }
}