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
        Random slump = new Random();
        private void btnRandomNumber_Click(object sender, RoutedEventArgs e)
        {
            int slumptal = slump.Next(1001);
            if (slumptal >= 0)
            {
                btnGuess.IsEnabled = true;
            }
            txbGuess.Text = "Skriv in din gissning! Det slumpade talet är mellan 0-1000.";
            lblRandomNumber.Content = slumptal;
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            int guess = int.Parse(txtGuess.Text);
            string randomNumber = lblRandomNumber.Content.ToString();
            int slumptal = int.Parse(randomNumber);
            //int numberOfTries = btnGuess;
            if (guess == slumptal)
            {
                txbGuess.Text = $"Grattis du gissade {slumptal}, vilket var rätt på !";
            }
            if (guess < slumptal - 100)
            {
                if (guess < slumptal && guess > slumptal - 100 )
                {
                    txbGuess.Text = $"Nämen! Det slumpade talet är bara lite högre än {guess}!";
                }
                else
                {
                    txbGuess.Text = $"OJOJ! Det slumpade talet är mycket högre än {guess}!";
                }
            }
            if (guess > slumptal + 100)
            {
                if (guess > slumptal && guess < slumptal + 100)
                {
                    txbGuess.Text = $"Nämen! Det slumpade talet är bara lite lägre än {guess}!";
                }
                else
                {
                    txbGuess.Text = $"OJOJ! Det slumpade talet är mycket lägre än {guess}!";
                }
            }
        }
    }
}
