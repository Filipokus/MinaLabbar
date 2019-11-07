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

namespace Uppgift6
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double numberOne = double.Parse(numberOneBox.Text);
            double numberTwo = double.Parse(numberTwoBox.Text);
            double sum = numberOne + numberTwo;
            resultBox.Text = $"{sum}";
            resultLabel.Content = "Summa";
        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            double numberOne = double.Parse(numberOneBox.Text);
            double numberTwo = double.Parse(numberTwoBox.Text);
            double difference = numberOne - numberTwo;
            resultBox.Text = $"{difference}";
            resultLabel.Content = "Differens";
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            double numberOne = double.Parse(numberOneBox.Text);
            double numberTwo = double.Parse(numberTwoBox.Text);
            double product = numberOne * numberTwo;
            resultBox.Text = $"{product}";
            resultLabel.Content = "Produkt";
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            double numberOne = double.Parse(numberOneBox.Text);
            double numberTwo = double.Parse(numberTwoBox.Text);
            double quotient = numberOne / numberTwo;
            resultBox.Text = $"{Math.Round(quotient, 4)}";
            resultLabel.Content = "Kvot";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            numberOneBox.Clear();
            numberTwoBox.Clear();
            resultBox.Clear();
        }
    }
}
