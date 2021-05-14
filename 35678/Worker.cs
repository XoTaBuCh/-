using System;

namespace Project
{
    public enum WorkingHours
    {
        FullWeek = 1,
        TwoThroughTwo,
        PartTime
    }
    public struct HumanInfo
    {
        public int Salary;
        public int Money;
        public WorkingHours Hours;
    }
    class Worker : Human
    {
        public HumanInfo Info;
        public Worker() : base()
        {
            Info = new HumanInfo();
            Info.Salary = 100;
            Info.Money = 100;
            Info.Hours = WorkingHours.FullWeek;
        }
        public Worker(string fullName, string identifier) : base(fullName, identifier)
        {
            Info = new HumanInfo();
            Info.Salary = 100;
            Info.Money = 100;
            Info.Hours = WorkingHours.FullWeek;
        }
        public Worker(string fullName, string identifier, bool isMale, DateTime dateOfBirth, Human mother, Human father, int salary, WorkingHours hours) : base(fullName, identifier, isMale, dateOfBirth, mother, father)
        {
            Info = new HumanInfo();
            Info.Salary = salary;
            Info.Hours = hours;
            Info.Money = 100;
        }
        public override string ToString()
        {
            return string.Format("{0}, id={1}, salary={2}", FullName, Identifier, Info.Salary);
        }
        public void ChangeSalary(int salary)
        {
            Info.Salary = salary;
        }
        public void ChangeWorkingHours(int workNum)
        {
            switch (workNum)
            {
                case 1: Info.Hours = WorkingHours.FullWeek; break;
                case 2: Info.Hours = WorkingHours.TwoThroughTwo; break;
                case 3: Info.Hours = WorkingHours.PartTime; break;
                default: throw new Exception("Wrong work number");
            }
        }
        public virtual void Work(int days)
        {
            Info.Money += Info.Salary * days / 30;
            Console.WriteLine("Работник получил ЗП\n");
        }
    }
}
