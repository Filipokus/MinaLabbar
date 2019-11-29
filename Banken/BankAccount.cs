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
        public List<string> transactions;
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
                string date = DateTime.Now.ToString();
                string withdrawal = $"{date} - Uttag på {amountToWithdraw:C0}";
                transactions.Add(withdrawal);
                return true;
            }
        }
        public void Deposit (decimal amountToDeposit)
        {
            Balance = Balance + amountToDeposit;
            string date = DateTime.Now.ToString();
            string deposition = $"{date} - Insättning på {amountToDeposit:C0}";
            transactions.Add(deposition);
        }
        public List<string> GetTransactions() 
        {
            List <string> latestTransactions = transactions.OrderByDescending(i => i).ToList();
            return latestTransactions;
        }
    }
}
