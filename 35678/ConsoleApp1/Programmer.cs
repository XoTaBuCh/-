﻿using System;

namespace Project
{
    class Programmer : Worker
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
        public void NewProjects(int projects)
        {
            Projects = projects;
        }
        public override void Work(int days)
        {
            Info.Salary *= Projects * 10;
            Console.WriteLine("Зарплата для прогера {1} изменилась на {0}$", Projects * 10, FullName);
            base.Work(days);
        }
    }
}