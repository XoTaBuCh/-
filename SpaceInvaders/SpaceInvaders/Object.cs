using System;
using System.Collections.Generic;


namespace SpaceInvaders 
{
    public class Object 
    {
        public Object(Game game, String sign, int x, int y) {
            this.game = game;
            this.sign = sign;

            this.X = x; 
            this.Y = y;
        }
        public Game game { get; set; }
        public String sign { get; set; }
        public int Length { get { return sign.Length; } }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual void Draw() 
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(sign);
        }
        public bool InScreen()
        {
            return Y >= 1 && Y <= game.screen.Height - 1;
        }
        public bool Hit(int x, int y) 
        {
            return y == Y && x >= X && x < X + Length;
        }
        public IEnumerable<int> GetXValues()
        {
            for (int x = X; x < X + Length; x++)
                yield return x;
        }
    }
}