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

namespace Uppgift4
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
            private void btnMonday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Måndag";      
        }
        private void btnTuesday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Tisdag";
        }
        private void btnWednesday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Onsdag";
        }
        private void btnThursday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Torsdag";
        }
        private void btnFriday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Fredag";
        }
        private void btnSaturday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Lördag";
        }
        private void btnSunday_Click(object sender, RoutedEventArgs e)
        {
            dayField.Content = $"Din favoritdag är Söndag";
        }
    }
}
