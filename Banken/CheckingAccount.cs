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
            transactions = new List<string>();
        }
        public CheckingAccount(decimal credit, string accountName)
        {
            AccountType = "Lönekonto";
            Credit = credit;
            AccountName = accountName;
            transactions = new List<string>();
        }
        public CheckingAccount(decimal credit)
        {
            AccountType = "Lönekonto";
            Credit = credit;
            transactions = new List<string>();
        }
        protected decimal Credit { get; set; }
        private decimal AvailableBalance()
        {
            decimal availableBalance = Balance + Credit;
            return availableBalance;
        }
        public override bool Withdrawal(decimal amountToWithdraw)
        {
            string date = DateTime.Now.ToString();
            string withdrawal = $"{date} - Uttag på {amountToWithdraw:C0}";
            if (amountToWithdraw > AvailableBalance())
            {
                return false;
            }
            else if (amountToWithdraw > Balance)
            {
                decimal amountToWithdrawLeft = amountToWithdraw - Balance;
                Balance = Balance - amountToWithdraw;
                //Credit = Credit - amountToWithdrawLeft;
                transactions.Add(withdrawal);
                return true;
            }
            else
            {
                Balance = Balance - amountToWithdraw;
                transactions.Add(withdrawal);
                return true;
            }
        }
    }
}
