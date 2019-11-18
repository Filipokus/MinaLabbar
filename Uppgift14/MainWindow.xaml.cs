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

namespace Uppgift14
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
        ProgramLogic programLogic = new ProgramLogic();
        private void btnCalculateAge_Click(object sender, RoutedEventArgs e)
        {
            string birthYear = txtBirthYear.Text;
            bool IsBirthYearValid = programLogic.IsInputOk(birthYear);
            if (IsBirthYearValid == true)
            {
                int age = programLogic.CalculateAge(birthYear);
                MessageBox.Show($"Du är {age} år gammal");
            }
            else
            {
                MessageBox.Show($"Du måste mata in enbart siffror");
            }
        }
    }
}
