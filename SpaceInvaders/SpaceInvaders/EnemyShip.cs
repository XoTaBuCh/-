using System;

namespace SpaceInvaders 
{
    public class EnemyShip : Moving
    {
        public EnemyShip(Game game, String sign, int x, int y, int strength) : base(game, sign, x, y)
        {
            this.Strength = strength;
        }

        private int Strength { get; set; }
        private DateTime lastStep;
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
        public void NewStep()
        {
            if ((DateTime.Now - lastStep).TotalMilliseconds >= 500)
            {
                Step(Directions.Down);
                lastStep = DateTime.Now;
            }
        }
        public override void Draw()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            base.Draw();
            Console.ForegroundColor = color;
        }
        public bool Alive()
        {
            return --Strength <= 0;
        }
    }
}