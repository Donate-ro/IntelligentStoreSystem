using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class Buyer : Worker
    {
        public double Amount { get; set; }

        public Buyer(int id, string firstName, string lastName, Profession profession, double amount) : base(id, firstName, lastName, profession)
        {
            Amount = amount;
        }
    }
}
