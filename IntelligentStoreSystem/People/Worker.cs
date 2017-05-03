using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class Worker : Person
    {
        public Profession Profession { get; private set; }

        public Worker(int id, string firstName, string lastName, Profession profession) : base(id, firstName, lastName)
        {
            Profession = profession;
        }
    }
}
