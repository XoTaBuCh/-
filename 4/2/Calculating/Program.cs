using System;

namespace Calculating
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int a, b;
                Console.WriteLine("Enter 2 integer numbers for some calculations on them:");
                Console.WriteLine("P.s. Exponentiation does not work with large numbers");
                Console.WriteLine("Enter a: ");
                while (!Int32.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input! Try again: ");
                }
                Console.WriteLine("Enter b: ");
                while (!Int32.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Wrong input! Try again: ");
                }

                Console.WriteLine("Calculations:");
                Console.WriteLine("a + b = {0};", ImportedMath.Add(a, b));
                Console.WriteLine("a - b = {0};", ImportedMath.Subtract(a, b));
                Console.WriteLine("a * b = {0};", ImportedMath.Multiply(a, b));
                if (b != 0)
                {
                    Console.WriteLine("a / b = {0};", ImportedMath.Divide(a, b));
                }
                else
                {
                    Console.WriteLine("Error! b = 0;");
                }
                if (a != 0)
                {
                    Console.WriteLine("b / a = {0};", ImportedMath.Divide(b, a));
                }
                else
                {
                    Console.WriteLine("Error! a = 0;");
                }

                if (b >= 0)
                {
                    Console.WriteLine("a ^ b = {0};", ImportedMath.Power(a, b));

                    if (b <= 12)
                    {
                        Console.WriteLine("b! = {0};", ImportedMath.Factorial(b));
                    }
                    else
                    {
                        Console.WriteLine("b is too large to calculate the factorial;");
                    }
                }
                else
                {
                    Console.WriteLine("b < 0, so the app can't perform a ^ b and b!;");
                }

                if (a >= 0)
                {
                    Console.WriteLine("b ^ a = {0};", ImportedMath.Power(b, a));
                    if (a <= 12)
                    {
                        Console.WriteLine("a! = {0};", ImportedMath.Factorial(a));
                    }
                    else
                    {
                        Console.WriteLine("a is too large to calculate the factorial;");
                    }
                }
                else
                {
                    Console.WriteLine("a < 0, so the app can't perform b ^ a and a!;");
                }

                if (a == 0 && b == 0)
                {
                    Console.WriteLine("For two zeros gcd and lcm are undefined;");
                }
                else
                {
                    Console.WriteLine("gcd(a, b) = {0};", ImportedMath.GCD(a, b));
                    Console.WriteLine("lcm(a, b) = {0};", ImportedMath.LCM(a, b));
                }
                Console.ReadLine();
            }
        }
    }
}
