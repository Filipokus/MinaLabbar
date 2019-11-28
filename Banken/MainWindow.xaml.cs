using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Banken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Customer customer;
        List<Customer> customers = new List<Customer>();
        BankAccount selectedAccount;
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("customers.bin"))
            {
                customers = (List<Customer>)FileOperations.Deserialize("customers.bin");
                CboCustomer.ItemsSource = customers;
            }
        }

        public bool CreateCustomer(string cellphone, string firstName, string lastName, string adress, string socialSecurityNumber) 
        {
            customer = new Customer(cellphone, firstName, lastName, adress, socialSecurityNumber);
            customers.Add(customer);
            FileOperations.Serialize(customers, "customers.bin");
            return true;
        }
        //public bool IsValidNumber(string stringToTest)
        //{
        //    foreach (char i in stringToTest)
        //    {
        //        if (!(stringToTest[i] == 0 || stringToTest[i] == 1 || stringToTest[i] == 2))
        //        {
        //            return true;
        //        }
        //        else if (!(stringToTest[i] == 3 || stringToTest[i] == 4 || stringToTest[i] == 5))
        //        {
        //            return true;
        //        }
        //        else if (!(stringToTest[i] == 6 || stringToTest[i] == 7 || stringToTest[i] == 8 || stringToTest[i] == 9))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        /// <summary>
        /// Kod för att välja kund i ComboBoxen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer;
            selectedCustomer = (Customer)CboCustomer.SelectedItem;
            CboSelectAccount.ItemsSource = null;
            CboSelectAccount.ItemsSource = selectedCustomer.GetBankAccounts();
        }

        /// <summary>
        /// Kod för att välja konto från aktiv kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectAccount_Click(object sender, RoutedEventArgs e)
        {
            selectedAccount = null;
            selectedAccount = (BankAccount)CboSelectAccount.SelectedItem;
        }

        /// <summary>
        /// Insättningar och uttag från valt bankkonto = en transaktion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (OptDeposit.IsChecked == true)
            {
                decimal amountToDeposit = decimal.Parse(TxtAmount.Text);
                selectedAccount.Deposit(amountToDeposit);
                MessageBox.Show($"{amountToDeposit:C0} har satts in på kontot {selectedAccount}");
            }
            else
            {
                decimal amountToWithdraw = decimal.Parse(TxtAmount.Text);
                if (selectedAccount.Withdrawal(amountToWithdraw) == true)
                {
                    MessageBox.Show($"Ditt uttag på {amountToWithdraw:C0} från konto {selectedAccount} lyckades!");
                }
                else
                {
                    MessageBox.Show($"Det saknas täckning");
                }
            }
            FileOperations.Serialize(customers, "customers.bin");
        }

        /// <summary>
        /// Skapa ny kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            string cellphone, firstName, lastName, adress, socialSecurityNumber, message;
            socialSecurityNumber = TxtSocialSecurityNumber.Text;
            firstName = TxtFirstname.Text;
            lastName = TxtLastname.Text;
            cellphone = TxtPhone.Text;
            adress = TxtAdress.Text;

            if (CreateCustomer(cellphone, firstName, lastName, adress, socialSecurityNumber) == true)
            {
                message = $"{firstName} {lastName} ({socialSecurityNumber}) är tillagd som kund";
            }
            else
            {
                message = $"Fyll i samtliga fält, tack.";
            }
            customers = (List <Customer>)FileOperations.Deserialize("customers.bin");
            CboCustomer.ItemsSource = null;
            CboCustomer.ItemsSource = customers;
            MessageBox.Show(message);
        }

        /// <summary>
        /// Skapa nytt bankkonto till aktiv kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            //Måste fixa så att det går att lägga till konto hos kund 1 sedan kund 2 
            //och sedan ytterliggare ett konto till kund 1 igen
            //CboCustomer.SelectedItem.Equals(null);
            //CboCustomer.SelectedItem.Equals(customer);
            Customer selectedCustomer;
            selectedCustomer = (Customer)CboCustomer.SelectedItem;
            string accountName = TxtAccountName.Text;
            string requestedAccountType;
            if (OptSavings.IsChecked == true)
            {
                requestedAccountType = "SavingsAccount";
                selectedCustomer.OpenNewAccount(requestedAccountType, accountName);
            }
            else if (OptRetirement.IsChecked == true)
            {
                requestedAccountType = "RetirementAccount";
                selectedCustomer.OpenNewAccount(requestedAccountType, accountName);
            }
            else
            {
                if (TxtCredit.Text.Length.Equals(0) == true)
                {
                    requestedAccountType = "CheckingAccount";
                    selectedCustomer.OpenNewAccount(requestedAccountType, accountName);
                }
                //else if (IsValidNumber(TxtCredit.Text.ToString()))
                //{
                //    decimal credit = decimal.Parse(TxtCredit.Text);
                //    selectedCustomer.OpenNewAccount(credit);
                //}
                else
                {
                    decimal credit = decimal.Parse(TxtCredit.Text);
                    selectedCustomer.OpenNewAccount(credit);
                }
            }
            CboSelectAccount.ItemsSource = null;
            CboSelectAccount.ItemsSource = selectedCustomer.GetBankAccounts();
            FileOperations.Serialize(customers, "customers.bin");
        }
    }
}
