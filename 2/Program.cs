using System;
using System.Threading;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1) С помощью класса DateTime вывести на консоль названия месяцев на французском языке. По желанию обобщить на случай, когда язык задается с клавиатуры. \n");
                Console.WriteLine("2) Дана строка, содержащая число с десятичной точкой. Преобразовать эту строку в число действительного типа (не пользуясь стандартным Parse/TryParse). \n");
                Console.WriteLine("3) Рассчитать максимальную степень двойки, на которую делится произведение под-ряд идущих чисел от a до b (числа целые 64-битные без знака). \n");
                Console.WriteLine("Esc - выход \n ");
                bool tmp = true;
                while (tmp)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("Created by XoT@B");
                            return;
                        case ConsoleKey.D1:
                            tmp = false;
                            MonthsLanguagesFunction();
                            break;
                        case ConsoleKey.D2:
                            tmp = false;
                            StringIntoFloatFunction();
                            break;
                        case ConsoleKey.D3:
                            tmp = false;
                            MaxPowerOfTwoFunction();
                            break;
                        default: break;
                    }
                }
                Console.WriteLine("Нажмите любую клавишу для выхода в меню");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        static void StringIntoFloatFunction()
        {
            double ans; // decimal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите строку с вещественным числом: ");
                string str = Console.ReadLine();
                try
                {
                    ans = StringIntoFloat.ConvertStringIntoFloat(str);
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод");
                    Thread.Sleep(1000);
                    continue;
                }
                Console.WriteLine("{0}", ans);
                break;
            }
        }
        static void MaxPowerOfTwoFunction()
        {
            ulong a, b;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите числа a и b через пробел: ");
                try
                {
                    string str = Console.ReadLine().Trim();
                    while (str[str.IndexOf(' ')] == str[str.IndexOf(' ') + 1])
                    {
                        str = str.Remove(str.IndexOf(' '), 1);
                    }
                    if (str.Split(' ').Length != 2)
                    {
                        throw new Exception("Чисел не два\n");
                    }
                    a = Convert.ToUInt64(str.Split(' ')[0]);
                    b = Convert.ToUInt64(str.Split(' ')[1]);
                    Console.WriteLine("Максимальная степень двойки: {0}", MaxPowerOfTwo.FindMaxPowerOfTwo(a, b - 1));
                }
                catch (Exception)
                {
                    Console.WriteLine("Неправильно введены числа");
                    Thread.Sleep(1000);
                    continue;
                }
                break;
            }
        }
        static void MonthsLanguagesFunction()
        {
            string str;
            string ans;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите / язык на английском / язык в формате TwoLetterISO: ");
                str = Console.ReadLine().Trim();
                try
                {
                    ans = MonthsLanguages.OutputMonthsLanguages(MonthsLanguages.LanguageToCulture(str));
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод!");
                    Thread.Sleep(1000);
                    continue;
                }
                Console.WriteLine(ans);
                break;
            }
        }
    }
}
