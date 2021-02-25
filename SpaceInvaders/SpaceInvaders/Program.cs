using System;
using System.Threading;

namespace SpaceInvaders 
{
    static class Program 
    {
        private static Game game;
        static void Main(string[] args) {
            while (true)
            {
                Settings();
                var text = "Press ENTER to start!";
                Console.SetCursorPosition((game.screen.Width - text.Length) / 2, (game.screen.Height / 2) + 3);
                Console.Write("Press ENTER to start!");
                text = "Use arrows to move (Spacebar - FIRE)";
                Console.SetCursorPosition((game.screen.Width - text.Length) / 2, (game.screen.Height / 2) + 4);
                Console.Write("Use arrows to move (Spacebar - FIRE)");
                Console.ReadLine();
                Console.Clear();
                game.Draw();
                while (game.GamePlaying)
                {
                    ReadInput();
                    game.Update();
                    Console.SetCursorPosition(0, 2 * 1 + game.screen.Height);
                    Console.Write("Score: {0}", game.score);
                    Thread.Sleep(30);
                }
                Console.Clear();
                text = "G A M E   O V E R";
                Console.SetCursorPosition((game.screen.Width - text.Length) / 2, (game.screen.Height / 2) + 2);
                Console.Write("G A M E   O V E R");
                text = "Score: 100";
                Console.SetCursorPosition((game.screen.Width - text.Length) / 2, (game.screen.Height / 2) + 4);
                Console.Write("Score: {0}", game.score);
                text = "Created by XoT@B";
                Console.SetCursorPosition((game.screen.Width - text.Length) / 2, (game.screen.Height / 2) + 10);
                Console.Write("Created by XoT@B");
                Console.ReadLine();
            }
        }
        private static void Settings()
        {
            int Width = 50;
            int Height = 25;
            game = new Game(Width, Height);
            Console.CursorVisible = false;
            Console.SetWindowSize(2 + Width, game.screen.Height + 3);
            Console.SetBufferSize(2 + Width, game.screen.Height + 3);
        }
        private static void ReadInput()
        {
            while (game.playerShip != null && Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow: game.playerShip.Step(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow: game.playerShip.Step(Directions.Right);
                        break;
                    case ConsoleKey.UpArrow: game.playerShip.Step(Directions.Up);
                        break;
                    case ConsoleKey.DownArrow: game.playerShip.Step(Directions.Down);
                        break;
                    case ConsoleKey.Spacebar: game.playerShip.Fire();
                        break;
                }
            }
        }
    }
}