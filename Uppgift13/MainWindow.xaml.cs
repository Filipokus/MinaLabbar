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

namespace Uppgift13
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
            string textToInspect = txtText.Text;
            char charToSearchFor = char.Parse(txtLetter.Text);
            int letterCount = 0;
            foreach (char a in textToInspect)
            {
                if (charToSearchFor == a)
                {
                    letterCount++;
                }
            }
            lblResult.Content = $"Hittade bokstaven {charToSearchFor} {letterCount}" +
                $" gånger.";
        }
    }
}
