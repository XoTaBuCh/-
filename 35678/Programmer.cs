using System;

namespace Project
{
    class Programmer : Worker, IWork
    {
        public int Projects;
        public Programmer() : base()
        {
            Projects = 1;
        }
        public Programmer(string fullName, string identifier) : base(fullName, identifier)
        {
            Projects = 1;
        }
        public Programmer(string fullName, string identifier, bool isMale, DateTime dateOfBirth, Human mother, Human father, int salary, WorkingHours hours, int projects) : base(fullName, identifier, isMale, dateOfBirth, mother, father, salary, hours)
        {
            Projects = projects;
        }
        public override string ToString()
        {
            return string.Format("{0}, id={1}, salary={2}$, projects={3}", FullName, Identifier, Info.Salary, Projects);
        }
        public void Working(int projects)
        {
            Projects += projects;
            Console.WriteLine("Программист {1} поработал, написав {0} проектов", projects, FullName);
        }
        public delegate void Messange(string mes);
        Messange _del;
        public void RegisterHandler(Messange del)
        {
            _del = del;
        }
        public override void Work(int days)
        {
            if (days < 0)
            {
                throw new Exception("Количество дней не может быть меньше нуля.");
            }
            Info.Salary *= Projects * 10;

            _del($"Зарплата для прогера {FullName} изменилась на {Projects * 10}$");
            base.Work(days);
        }
    }
}
