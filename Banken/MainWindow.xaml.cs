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
        Customer selectedCustomer;
        public MainWindow()
        {
            InitializeComponent();
            //Om det finns sparade kunder presenteras kundregistret
            if (File.Exists("customers.bin"))
            {
                customers = (List<Customer>)FileOperations.Deserialize("customers.bin");
                CboCustomer.ItemsSource = customers;
            }
        }
        /// <summary>
        /// Skapar en kund som läggs in i kundregistret om alla strängar innehåller < 0 tecken
        /// </summary>
        /// <param name="cellphone"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="adress"></param>
        /// <param name="socialSecurityNumber"></param>
        /// <returns></returns>
        public bool CreateCustomer(string cellphone, string firstName, string lastName, string adress, string socialSecurityNumber) 
        {
            if (cellphone.Length != 0 && firstName.Length != 0 && lastName.Length != 0 && adress.Length != 0 && socialSecurityNumber.Length != 0)
            {
            customer = new Customer(cellphone, firstName, lastName, adress, socialSecurityNumber);
            customers.Add(customer);
            FileOperations.Serialize(customers, "customers.bin");
            return true;
            }
            return false;
        }
        /// <summary>
        /// Kod för att välja kund i ComboBoxen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            selectedCustomer = (Customer)CboCustomer.SelectedItem;
            CboSelectAccount.ItemsSource = null;
            if (selectedCustomer != null) //Om en kund valts presenteras dess bankkonton
            {
                CboSelectAccount.ItemsSource = selectedCustomer.GetBankAccounts();
            }
            else
            {
                MessageBox.Show("Välj en kund först");
            }
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
            LstTransactions.ItemsSource = null;
            if (selectedAccount != null) //Presenterar de senaste transaktionerna på kontot OM ett konto valts
            {
                LstTransactions.ItemsSource = selectedAccount.GetTransactions();
            }
            else
            {
                MessageBox.Show("Välj ett konto först");
            }
        }

        /// <summary>
        /// Insättningar och uttag från valt bankkonto = en transaktion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAccount != null) //Om konto valts kan koden köras
            {
                if (TxtAmount.Text.Length != 0) //Om användaren fyllt i belopp kan koden köras
                {
                    if (OptDeposit.IsChecked == true) //Om användaren vill sätta in pengar
                    {
                        decimal amountToDeposit = decimal.Parse(TxtAmount.Text);
                        selectedAccount.Deposit(amountToDeposit);
                        MessageBox.Show($"{amountToDeposit:C0} har satts in på kontot {selectedAccount}");
                    }
                    else
                    {
                        decimal amountToWithdraw = decimal.Parse(TxtAmount.Text);
                        if (selectedAccount.Withdrawal(amountToWithdraw) == true) //Om användaren vill ta ut pengar
                        {
                            MessageBox.Show($"Ditt uttag på {amountToWithdraw:C0} från konto {selectedAccount} lyckades!");
                        }
                        else
                        {
                            MessageBox.Show($"Du saknar täckning på kontot");
                        }
                    }
                    //Sparar transaktionen hos kunden samt visar de senaste transaktionerna i gränssnittet
                    FileOperations.Serialize(customers, "customers.bin");
                    LstTransactions.ItemsSource = null;
                    LstTransactions.ItemsSource = selectedAccount.GetTransactions();
                }
                else //Körs om användaren glömt skriva belopp
                {
                    MessageBox.Show("Specificera belopp först");
                }
            }
            else if (selectedCustomer != null) //Om inget konto valts
            {
                MessageBox.Show("Välj ett konto först");
            }
            else //Om inga val har gjorts
            {
                MessageBox.Show("Välj en kund och specificera vilket bankkonto först");
            }
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
            //Skapar en kund om samtliga fält är ifyllda
            if (CreateCustomer(cellphone, firstName, lastName, adress, socialSecurityNumber) == true)
            {
                message = $"{firstName} {lastName} ({socialSecurityNumber}) är tillagd som kund";
                //Sparar kunden i kundregistret samt i dokumentet customers.bin
                //Uppdaterar sedan gränssnittet med kundlistan
                customers = (List<Customer>)FileOperations.Deserialize("customers.bin");
                CboCustomer.ItemsSource = null;
                CboCustomer.ItemsSource = customers;
            }
            else
            {
                message = $"Fyll i samtliga fält, tack.";
            }
            MessageBox.Show(message);
        }

        /// <summary>
        /// Skapa nytt bankkonto till aktiv kund
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            selectedCustomer = (Customer)CboCustomer.SelectedItem;
            string accountName = TxtAccountName.Text;
            string requestedAccountType;
            if (selectedCustomer != null)
            {
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
                    if (TxtCredit.Text.Length == 0)
                    {
                        requestedAccountType = "CheckingAccount";
                        selectedCustomer.OpenNewAccount(requestedAccountType, accountName);
                    }
                    else
                    {
                        requestedAccountType = "CheckingAccount";
                        decimal credit = decimal.Parse(TxtCredit.Text);
                        selectedCustomer.OpenNewAccount(credit, accountName);
                    }
                }
                CboSelectAccount.ItemsSource = null;
                CboSelectAccount.ItemsSource = selectedCustomer.GetBankAccounts();
                FileOperations.Serialize(customers, "customers.bin");
                MessageBox.Show($"Kontot har öppnats");
            }
            else
            {
                MessageBox.Show("Välj en kund först");
            }
        }
    }
}
