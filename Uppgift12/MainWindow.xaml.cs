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

namespace Uppgift12
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
        int timesClicked = 0;
        int[] numbers = new int[5];
        double average;
        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int number = int.Parse(txtNumber.Text);
            lbxNumbers.ItemsSource = null;
            for (int i = timesClicked; i < timesClicked+1; i++)
            {
                numbers[i] = number;
            }
            timesClicked++;
            lbxNumbers.ItemsSource = numbers;
            if (lbxNumbers.HasItems == true)
            {
                average = (double)numbers.Sum()/ (double)timesClicked;
                txtAverage.Text = average.ToString();
            }
            if (timesClicked == 5)
            {
                btnNumber.IsEnabled = false;
                txtAverage.Focus();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                numbers[i]= 0;
            }
            lbxNumbers.ItemsSource = null;
            txtNumber.Clear();
            txtAverage.Clear();
            btnNumber.IsEnabled = true;
            timesClicked = 0;
            txtNumber.Focus();
        }
    }
}
