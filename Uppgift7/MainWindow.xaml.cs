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

namespace Uppgift7
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
            int integer = (int)numberOne / (int)numberTwo;
            txtInteger.Text = integer.ToString();
            double residual = numberOne % numberTwo;
            txtResidual.Text = residual.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumberOne.Clear();
            txtNumberTwo.Clear();
            txtInteger.Clear();
            txtResidual.Clear();
        }
    }
}
