using System;
using System.Collections.Generic;

namespace Project
{
    class Humans
    {
        int countOfHumans = 0;
        private Dictionary<string, Human> humans;
        public Humans()
        {
            humans = new Dictionary<string, Human>();
        }
        public Human this[string index]
        {
            get
            {
                if (Program.FindHuman(index) == null)
                {
                    throw new Exception("There is no Human with such ID\n");
                }
                return humans[index];
            }
            set
            {
                if (Program.FindHuman(index) == null)
                {
                    throw new Exception("There is no Human with such ID\n");
                }
                humans[index] = value;
                countOfHumans++;
            }
        }
}
