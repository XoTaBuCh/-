using System;

namespace Project
{
    class Cleaner : Worker, IWork
    {
        public int CleaningRooms;
        public Cleaner() : base()
        {
            CleaningRooms = 1;
        }
        public Cleaner(string fullName, string identifier) : base(fullName, identifier)
        {
            CleaningRooms = 1;
        }
        public Cleaner(string fullName, string identifier, bool isMale, DateTime dateOfBirth, Human mother, Human father, int salary, WorkingHours hours, int rooms) : base(fullName, identifier, isMale, dateOfBirth, mother, father, salary, hours)
        {
            CleaningRooms = rooms;
        }
        public override string ToString()
        {
            return string.Format("{0}, id={1}, salary={2}$, cleaned rooms={3}", FullName, Identifier, Info.Salary, CleaningRooms);
        }
        void IWork.Working(int roomsInDay)
        {
            CleaningRooms += roomsInDay;
            Console.WriteLine("Уборщик {1} поработал, почистив {0} комнат", roomsInDay, FullName);
        }
        public override void Work(int days)
        {
            Info.Salary *= CleaningRooms / 10;
            Console.WriteLine("Зарплата для уборщика {1} изменилась на {0}$", CleaningRooms / 10, FullName);
            base.Work(days);
        }
    }
}
