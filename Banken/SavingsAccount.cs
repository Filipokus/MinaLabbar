using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    [Serializable]
    class SavingsAccount : BankAccount
    {
        public SavingsAccount()
        {
            AccountType = "Sparkonto";
        }
        public SavingsAccount(string accountName)
        {
            AccountType = "Sparkonto";
            AccountName = accountName;
        }
    }
}
