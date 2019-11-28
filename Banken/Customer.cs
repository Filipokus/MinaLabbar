using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banken
{
    [Serializable]
    class Customer
    {
        protected string SocialSecurityNumber { get; set; }
        protected string Cellphone { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected string Address { get; set; }
        protected List <BankAccount> bankAccounts;
        public Customer(string cellphone, string firstName, string lastName, string adress, string socialSecurityNumber) 
        {
            SocialSecurityNumber = socialSecurityNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = adress;
            Cellphone = cellphone;
            bankAccounts = new List<BankAccount>();
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {SocialSecurityNumber}".ToString();
        }
        public BankAccount OpenNewAccount(string requestedAccountType) 
        {
            BankAccount accountType;
            if (requestedAccountType == "RetirementAccount")
            {
                accountType = new RetirementAccount();
            }
            else if (requestedAccountType == "SavingsAccount")
            {
                accountType = new SavingsAccount();
            }
            else
            {
                accountType = new CheckingAccount();
            }
            bankAccounts.Add(accountType);
            return accountType;
        }
        public BankAccount OpenNewAccount(string requestedAccountType, string accountName)
        {
            BankAccount accountType;
            if (requestedAccountType == "RetirementAccount")
            {
                accountType = new RetirementAccount(accountName);
            }
            else
            {
                accountType = new SavingsAccount(accountName);
            }
            bankAccounts.Add(accountType);
            return accountType;
        }
        public BankAccount OpenNewAccount(decimal credit)
        {
            BankAccount accountType = new CheckingAccount(credit);
            bankAccounts.Add(accountType);
            return accountType;
        }
        public BankAccount OpenNewAccount(decimal credit, string accountName)
        {
            BankAccount accountType = new CheckingAccount(credit, accountName);
            bankAccounts.Add(accountType);
            return accountType;
        }
        public List <BankAccount> GetBankAccounts()
        {
            return bankAccounts;
        }
    }
}
