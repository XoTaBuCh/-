using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static List<Human> humans = new List<Human>();

        static void Main()
        {
            Cleaner man = new Cleaner("Worker1", "1");
            ((IWork)man).Working(30);
            man.Work(5);
            Programmer woman = new Programmer("Worker2", "2");
            woman.Work(5);
            Worker newMan = new Admin("Worker3", "3");
            newMan.Work(5);
            IWork newWoman = new Cleaner("Worker4", "4");

            
        }

        static Human ReadHuman(bool isSimpleAdd)
        {
            string fullName;
            while (true)
            {
                Console.WriteLine("Enter full name");
                fullName = Console.ReadLine();
                if (fullName.Length == 0)
                {
                    Console.WriteLine("\nThe name must not be empty");
                }
                else
                {
                    break;
                }
            }
            string identifier;
            while (true)
            {
                Console.WriteLine("Enter identifier");
                identifier = Console.ReadLine();
                if (identifier.Length == 0)
                {
                    Console.WriteLine("\nThe identifier must not be empty");
                }
                else if (FindHuman(identifier) != null)
                {
                    Console.WriteLine("\nThe identifier must be individual");
                }
                else
                {
                    break;
                }
            }
            bool isMale;
            string gender;
            while (true)
            {
                Console.WriteLine("Enter gender (M - male, F - female)");
                gender = Console.ReadLine();
                if (gender.ToUpper() == "M")
                {
                    isMale = true;
                    break;
                }
                else if (gender.ToUpper() == "F")
                {
                    isMale = false;
                    break;
                }
                else
                {
                    Console.WriteLine("\nWrong format");
                }
            }
            if (isSimpleAdd)
            {
                return new Human(fullName, identifier, isMale);
            }
            int year, month, day;
            while (true)
            {
                Console.WriteLine("Enter year of birth");
                year = Convert.ToInt32(Console.ReadLine());
                if (year > 2021 || year < 0)
                {
                    Console.WriteLine("\nWrong format");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter month of birth");
                month = Convert.ToInt32(Console.ReadLine());
                if (month > 12 || month < 1)
                {
                    Console.WriteLine("\nWrong format");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter day of birth");
                day = Convert.ToInt32(Console.ReadLine());
                if (day > 28 || day < 1)
                {
                    Console.WriteLine("\nWrong format");
                }
                else
                {
                    break;
                }
            }
            DateTime dateOfBirth = new DateTime(year, month, day);
            string motherIdentifier;
            Human mother;
            while (true)
            {
                Console.WriteLine("Enter mother identifier or leave it");
                motherIdentifier = Console.ReadLine();
                if (motherIdentifier == "")
                {
                    mother = null;
                    break;
                }
                else
                {
                    mother = FindHuman(motherIdentifier);
                    if (mother == null)
                    {
                        Console.WriteLine("\nMother not found");
                    }
                    else if (mother.Gender == Genders.Male)
                    {
                        Console.WriteLine("\nThis human is a male");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            string fatherIdentifier;
            Human father;
            while (true)
            {
                Console.WriteLine("Enter father identifier or leave it");
                fatherIdentifier = Console.ReadLine();
                if (fatherIdentifier == "")
                {
                    father = null;
                    break;
                }
                else
                {
                    father = FindHuman(fatherIdentifier);
                    if (father == null)
                    {
                        Console.WriteLine("\nFather not found");
                    }
                    else if (father.Gender == Genders.Female)
                    {
                        Console.WriteLine("\nThis human is a female");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine();
            return new Human(fullName, identifier, isMale, dateOfBirth, mother, father);
        }

        public static Human FindHuman(string identifier)
        {
            for (int i = 0; i < humans.Count; i++)
            {
                if (humans[i].Identifier == identifier)
                {
                    return humans[i];
                }
            }
            return null;
        }
    }
}
