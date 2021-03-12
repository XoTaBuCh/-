using System;

namespace Lab2
{
    static class StringIntoFloat
    {
        public static double ConvertStringIntoFloat(string from)
        {
            from = from.Trim();
            if (from.Length == 0 || from.Split(' ').Length > 1)
            {
                throw new Exception("Ошибка перевода строки в вещественное число");
            }
            bool minus = false;
            if (from[0] == '-')
            {
                minus = true;
            }
            double t = 0;
            int i = Convert.ToInt32(minus);
            for (; i < from.Length; i++)
            {
                if (from[i] == '.' || from[i] == ',')
                {
                    if (i == Convert.ToInt32(minus))
                    {
                        throw new Exception("Ошибка перевода строки в вещественное число");
                    }
                    i++;
                    break;
                }
                else if (from[i] < '0' || from[i] > '9')
                {
                    throw new Exception("Ошибка перевода строки в вещественное число");
                }
                else
                {
                    t *= 10;
                    t += (from[i] - '0');
                }
            }
            double p = 1;
            for (; i < from.Length; i++)
            {
                if (from[i] < '0' || from[i] > '9')
                {
                    throw new Exception("Ошибка перевода строки в вещественное число");
                }
                else
                {
                    p /= 10;
                    t += p * (from[i] - '0');
                }
            }
            if (minus)
            {
                t = -t;
            }
            return t;
        }
    }
}
