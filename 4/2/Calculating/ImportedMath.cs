using System.Runtime.InteropServices;


namespace Calculating
{
    class ImportedMath
    {
        [DllImport("MathLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int a, int b);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Subtract(int a, int b);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(int a, int b);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float Divide(float a, float b);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Power(int a, int b);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Factorial(int a);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GCD(int a, int b);

        [DllImport("MathLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int LCM(int a, int b);
    }
}
