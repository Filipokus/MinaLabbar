using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uppgift8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            double numberOne = double.Parse(txtNumberOne.Text);
            double numberTwo = double.Parse(txtNumberTwo.Text);
            double result;
           if (rbtnAdd.IsChecked == true)
            {
                result = numberOne + numberTwo;
                txtResult.Text = result.ToString();
                lblResult.Content = "Summa";
            }
            else if (rbtnSubtract.IsChecked == true)
            {
                result = numberOne - numberTwo;
                txtResult.Text = result.ToString();
                lblResult.Content = "Differens";
            }
            else if (rbtnMultiply.IsChecked == true)
            {
                result = numberOne * numberTwo;
                txtResult.Text = result.ToString();
                lblResult.Content = "Produkt";
            }
            else if (rbtnDivide.IsChecked == true)
            {
                result = numberOne / numberTwo;
                txtResult.Text = result.ToString();
                lblResult.Content = "Kvot";
            }
            else
            {
                txtResult.Text = "Välj räknesätt";
                lblResult.Content = "Kunde inte visa svar";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumberOne.Clear();
            txtNumberTwo.Clear();
            txtResult.Clear();
            lblResult.Content="Resultat";
        }
    }
}
