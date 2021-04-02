using System;

namespace Player
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("MP3 Player");
                Console.WriteLine("Press:");
                Console.WriteLine("Space - Pause/Start");
                Console.WriteLine("Arrows Up/Down - volume Increase/Decrease");
                Console.WriteLine("Esc - stop");
                Mp3Player game = new Mp3Player();
                while (true)
                {
                    Console.WriteLine("Enter the full path to song:");
                    string path = Console.ReadLine();
                    if (!game.Path(path))
                    {
                        Console.WriteLine("Wrong path! Enter again");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                bool flag = true;
                while (flag)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            game.Stop();
                            flag = false;
                            break;
                        case ConsoleKey.Spacebar:
                            game.Pause();
                            break;
                        case ConsoleKey.UpArrow:
                            game.Volume += 10;
                            break;
                        case ConsoleKey.DownArrow:
                            game.Volume -= 10;
                            break;
                    }
                }
            }
        }
    }
}
