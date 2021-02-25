using System;

namespace SpaceInvaders
{
    public class Moving : Object
    {
        public Moving(Game game, String sign, int x, int y) : base(game, sign, x, y)
        {
            this.LastX = x;
            this.LastY = y;
        }
        public int LastX { get; protected set; }
        public int LastY { get; protected set; }
        public void Move()
        {
            if (X != LastX || Y != LastY)
            {
                Console.SetCursorPosition(LastX, LastY);
                Console.Write(new String(' ', Length));
            }
        }
        public void Clear()
        {
            Console.SetCursorPosition(LastX, LastY);
            Console.Write(new String(' ', Length));
        }
        public void Redraw()
        {
            if (X != LastX || Y != LastY)
            {
                Draw();
                LastX = X;
                LastY = Y;
            }
        }
        public virtual void Step(Directions direction)
        {
            switch (direction)
            {
                case Directions.Down: Y++; break;
                case Directions.Up: Y--; break;
                case Directions.Right: X++; break;
                case Directions.Left: X--; break;
            }
        }
    }

}