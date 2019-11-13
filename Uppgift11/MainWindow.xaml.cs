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

namespace Uppgift11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        double unluckiness = 50;
        private void btnLessUnluck_Click(object sender, RoutedEventArgs e)
        {
            unluckiness -= 5;
            prbUnluckiness.Value = unluckiness;
            lblUnluckiness.Content = $"{prbUnluckiness.Value}%";
        }

        private void btnMoreUnluck_Click(object sender, RoutedEventArgs e)
        {
            unluckiness += 5;
            prbUnluckiness.Value = unluckiness;
            lblUnluckiness.Content = $"{prbUnluckiness.Value}%";
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int numberOfTries = int.Parse(txtNumberOfTries.Text);
            int [] result = new int[numberOfTries];
            int rightWay = 0;
            int wrongWay = 0;
            foreach (int tries in result)
            {
                int sandwich = random.Next(2);
                if (sandwich == 0)
                {
                    rightWay++;
                }
                else
                {
                    wrongWay++;
                }
            }
            lblRightWay.Content = $"Antal åt rätt håll:{rightWay}";
            lblWrongWay.Content = $"Antal åt rätt håll:{wrongWay}";

        }
    }
}
