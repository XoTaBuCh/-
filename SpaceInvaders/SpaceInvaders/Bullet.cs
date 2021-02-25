using System;

namespace SpaceInvaders {
    public class Bullet : Moving {
        private Directions direct;
        public Bullet(Game game, String sign, int x, int y, Directions direct) : base(game, sign, x, y)
        {
            this.direct = direct;
            Draw();
        }
        public override void Draw()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            base.Draw();
            Console.ForegroundColor = color;
        }
        public void NewStep()
        {
            Step(direct);
        }
    }
}