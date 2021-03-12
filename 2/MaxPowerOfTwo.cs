using System;

namespace Lab2
{
    class MaxPowerOfTwo
    {
        public static ulong FindMaxPowerOfTwo(ulong a, ulong b)
        {
            if (a == 0 || a > b)
            {
                throw new Exception("Неправильно введены числа\n");
            }
            return (Solve(b) - Solve(a - 1));
        }
        static ulong Solve(ulong n)
        {
            ulong sum = 0;
            ulong d = 2;
            for (int i = 1; i < 64; i++)
            {
                sum += (n / d);
                d *= 2;
            }
            return sum;
        }
    }
}
