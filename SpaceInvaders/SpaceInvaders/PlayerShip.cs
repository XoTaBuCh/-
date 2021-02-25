using System;

namespace SpaceInvaders 
{
    public class PlayerShip : Moving 
    {
        public PlayerShip(Game game, String sign, int x, int y, int strength) : base(game, sign, x, y)
        {
            this.Strength = strength;
        }
        public const String PLAYER = "/(^)\\";
        public int Strength { get; protected set; }
        public override void Step(Directions direction)
        {
            switch (direction)
            {
                case Directions.Left:
                    X = Math.Max(X - 1, 1);
                    break;
                case Directions.Right:
                    X = Math.Min(X + 1, 1 + game.screen.Width - Length);
                    break;
                case Directions.Up:
                    Y = Math.Max(Y - 1, 1);
                    break;
                case Directions.Down:
                    Y = Math.Min(Y + 1, 1 + game.screen.Height - 1);
                    break;
            }
        }
        public void Fire()
        {
            game.bullets.Add(new Bullet(game, "|", X + Length / 2, Y - 1, Directions.Up));
        }
        public bool Alive()
        {
            return --Strength <= 0;
        }
        public override void Draw()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            base.Draw();
            Console.ForegroundColor = color;
        }
    }
}