using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    [Serializable]
    class CheckingAccount : BankAccount
    {
        public CheckingAccount()
        {
            AccountType = "Lönekonto";
        }
        public CheckingAccount(decimal credit, string accountName)
        {
            AccountType = "Lönekonto";
            Credit = credit;
            AccountName = accountName;
        }
        public CheckingAccount(decimal credit)
        {
            AccountType = "Lönekonto";
            Credit = credit;
        }
        protected decimal Credit { get; set; }
        private decimal AvailableBalance()
        {
            decimal availableBalance = Balance + Credit;
            return availableBalance;
        }
        public override bool Withdrawal(decimal amountToWithdraw)
        {
            if (amountToWithdraw > AvailableBalance())
            {
                return false;
            }
            else if (amountToWithdraw > Balance)
            {
                decimal amountToWithdrawLeft = amountToWithdraw - Balance;
                Balance = Balance - amountToWithdraw;
                Credit = Credit - amountToWithdrawLeft;
                return true;
            }
            else
            {
                Balance = Balance - amountToWithdraw;
                return true;
            }
        }
        public override void Deposit(decimal amountToDeposit)
        {
            if (Balance < 0)
            {

            }
            Balance = Balance + amountToDeposit;
        }
    }
}
