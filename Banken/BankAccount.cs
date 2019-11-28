using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    [Serializable]
    abstract class BankAccount
    {
        protected string AccountType { get; set; }
        protected string AccountName { get; set; }
        protected decimal Balance { get; set; }
        public override string ToString()
        {
            return $"{AccountType} - {AccountName} {Balance:C0}".ToString();
        }
        public virtual bool Withdrawal(decimal amountToWithdraw) 
        {
            if (Balance < amountToWithdraw)
            {
                return false;
            }
            else
            {
                Balance = Balance - amountToWithdraw;
                return true;
            }
        }
        public virtual void Deposit (decimal amountToDeposit)
        {
            Balance = Balance + amountToDeposit;
        }
    }
}
