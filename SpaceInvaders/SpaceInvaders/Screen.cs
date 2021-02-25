using System;

namespace SpaceInvaders 
{
    public class Screen 
    {
        public Screen(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('+');
            for (int i = 0; i < Width; i++)
                Console.Write('-');
            Console.Write('+');
            for (int i = 1; i < 1 + Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('#');
                Console.SetCursorPosition(1 + Width, i);
                Console.Write('#');
            }
            Console.SetCursorPosition(0, 1 + Height);
            Console.Write('+');
            for (int i = 0; i < Width; i++)
                Console.Write('-');
            Console.Write('+');
        }
    }
}