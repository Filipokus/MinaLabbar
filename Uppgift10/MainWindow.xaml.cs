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

namespace Uppgift10
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

        private void btnRandomNumber_Click(object sender, RoutedEventArgs e)
        {
            Random slump = new Random();
            int slumptal = slump.Next(500);
            if (slumptal < 0)
            {
                btnGuess.IsEnabled = false;
            }
            else
            {
                btnGuess.IsEnabled = true;
            }
            txbGuess.Text = "Skriv in din gissning! Det slumpade talet är mellan 0-1000.";
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
