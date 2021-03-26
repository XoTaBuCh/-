using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static List<Human> humans = new List<Human>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter:\n" +
                                  "1. Show full list\n" +
                                  "2. Add new Human (Full Name, ID, Gender)\n" +
                                  "3. Add new Human (Full Name, ID, Gender, Date Of Birth, Mother's ID, Father's ID)\n" +
                                  "4. Find human\n" +
                                  "5. Remove human from list\n" +
                                  "6. Sort by age\n" +
                                  "7. Add parent-son relationship\n" +
                                  "8. Arrange a marriage\n" +
                                  "9. Make a divorce\n" +
                                  "0. Exit\n");
                ConsoleKey key = Console.ReadKey(true).Key;
                string identifier;
                Human human, parent, child, human1, human2;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        if (humans.Count == 0)
                        {
                            Console.WriteLine("List is empty");
                        }
                        else
                        {
                            Console.WriteLine("Full list:");
                            for (int i = 0; i < humans.Count; i++)
                            {
                                Console.WriteLine();
                                Console.Write(i + 1 + ".) ");
                                Console.WriteLine(humans[i]);
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        human = ReadHuman(true);
                        if (human == null)
                        {
                            Console.WriteLine("Error!");
                        }
                        else
                        {
                            Console.WriteLine("Successfully!");
                            humans.Add(human);
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        human = ReadHuman(false);
                        if (human == null)
                        {
                            Console.WriteLine("Error!");
                        }
                        else
                        {
                            Console.WriteLine("Successfully!");
                            humans.Add(human);
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine("Enter identifier");
                        identifier = Console.ReadLine();

                        human = FindHuman(identifier);

                        Console.WriteLine();
                        if (human == null)
                        {
                            Console.WriteLine("Human not found!");
                        }
                        else
                        {
                            Console.WriteLine("Human found:");
                            Console.WriteLine(human);
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Enter identifier");
                        identifier = Console.ReadLine();

                        human = FindHuman(identifier);

                        Console.WriteLine();
                        if (human == null)
                        {
                            Console.WriteLine("Human not found!");
                        }
                        else
                        {
                            human.Delete();
                            humans.Remove(human);
                            Console.WriteLine("Human successfully removed");
                        }
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        humans.Sort();
                        Console.WriteLine("Successfully!");
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        Console.WriteLine("Enter parent identifier");
                        identifier = Console.ReadLine();
                        parent = FindHuman(identifier);
                        if (parent == null)
                        {
                            Console.WriteLine("Parent not found!");
                            break;
                        }

                        Console.WriteLine("Enter child identifier");
                        identifier = Console.ReadLine();
                        child = FindHuman(identifier);
                        if (child == null)
                        {
                            Console.WriteLine("Child not found!");
                            break;
                        }

                        if (child.SetParent(parent))
                        {
                            Console.WriteLine("Successfully!");
                        }
                        else
                        {
                            if (parent.Gender == Genders.Male)
                                Console.WriteLine("Error! This child already has a male parent");
                            else
                                Console.WriteLine("Error! This child already has a female parent");
                        }
                        break;
                    case ConsoleKey.D8:
                        Console.Clear();
                        Console.WriteLine("Enter first human identifier");
                        identifier = Console.ReadLine();

                        human1 = FindHuman(identifier);
                        if (human1 == null)
                        {
                            Console.WriteLine("Human not found!");
                            break;
                        }
                        else if (human1.Partner != null)
                        {
                            Console.WriteLine("This human already has a partner");
                            break;
                        }

                        Console.WriteLine("Enter second human identifier");
                        identifier = Console.ReadLine();
                        human2 = FindHuman(identifier);
                        if (human2 == null)
                        {
                            Console.WriteLine("Human not found!");
                            break;
                        }
                        else if (human2.Partner != null)
                        {
                            Console.WriteLine("This human already has a partner");
                            break;
                        }

                        if (Human.Marriage(human1, human2))
                        {
                            Console.WriteLine("Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Same-sex marriage is prohibited!");
                        }
                        break;
                    case ConsoleKey.D9:
                        Console.Clear();
                        Console.WriteLine("Enter the identifier of one of the partners");
                        identifier = Console.ReadLine();
                        human = FindHuman(identifier);
                        if (human == null)
                        {
                            Console.WriteLine("Human not found!");
                            break;
                        }
                        else if (human.Partner == null)
                        {
                            Console.WriteLine("This human has no partner");
                            break;
                        }
                        human.Divorce();
                        Console.WriteLine("Successfully!");
                        break;
                    case ConsoleKey.D0:
                        return;
                }
                Console.WriteLine();
            }
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
