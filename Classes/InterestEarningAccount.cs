using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class InterestEarningAccount : BankAccount
    {
        // DerivedConstructor
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        // ApplyMonthendInterest
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.Now, "Apply monthly interest");
            }
        }
    }
}
