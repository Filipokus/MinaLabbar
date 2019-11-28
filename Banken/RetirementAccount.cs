using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    [Serializable]
    class RetirementAccount : BankAccount
    {
        public RetirementAccount()
        {
            AccountType = "Pensionsspar";
        }
        public RetirementAccount(string accountName)
        {
            AccountType = "Pensionsspar";
            AccountName = accountName;
        }
        protected decimal WithdrawalFee (decimal amountToWithdraw) 
        {
            decimal withdrawalFee = amountToWithdraw/10;
            return withdrawalFee;
        }
        public override bool Withdrawal(decimal amountToWithdraw)
        {
            if (Balance < amountToWithdraw + WithdrawalFee(amountToWithdraw))
            {
                return false;
            }
            else
            {
                Balance = Balance - (amountToWithdraw + WithdrawalFee(amountToWithdraw));
                return true;
            }
        }
    }
}
