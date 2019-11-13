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

namespace shj
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
        private void btnLessUnluck_Click(object sender, RoutedEventArgs e)
        {
            double unluckiness = prbUnluckiness.Value;
            unluckiness -= 5;
        }

        private void btnMoreUnluck_Click(object sender, RoutedEventArgs e)
        {
            double unluckiness = prbUnluckiness.Value;
            unluckiness += 5;
        }
    }
}
