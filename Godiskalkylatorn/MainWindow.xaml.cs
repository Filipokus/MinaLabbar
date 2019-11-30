using System;
using System.Collections.Generic;
using System.IO;
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

namespace Godiskalkylatorn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CandyCalculator candyCalculator = new CandyCalculator();
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("people.bin"))
            {
                lbxDistribution.ItemsSource = null;
                lbxDistribution.ItemsSource = candyCalculator.GetPeopleFromFile();
            }
        }
        /// <summary>
        /// Rensar alla Text Boxes
        /// </summary>
        public void ClearTextBoxes()
        {
            txtAge.Clear();
            txtName.Clear();
            txtNumberOfCandies.Clear();
        }
        /// <summary>
        /// Lägg till en person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string rawAge = txtAge.Text;
            if (int.TryParse(rawAge, out int age))
            {
                if (candyCalculator.AddPerson(name, age) == true)
                {
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Fyll i vad personen heter först");
                }
            }
            else
            {
                string infoMissing;
                if (name.Length == 0)
                {
                    infoMissing = "namn & ålder";
                }
                else
                {
                    infoMissing = "åldern";
                }
                MessageBox.Show($"Fyll i {infoMissing} först. Åldern ska anges i heltal.");
            }
            lbxDistribution.ItemsSource = null;
            lbxDistribution.ItemsSource = candyCalculator.GetPeople();
        }
        /// <summary>
        /// Fördelar godis mellan personerna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistribute_Click(object sender, RoutedEventArgs e)
        {
            string rawNumberOfCandies = txtNumberOfCandies.Text;
            if (int.TryParse(rawNumberOfCandies, out int numberOfCandies) == true)
            {
                lbxDistribution.ItemsSource = null;
                if (optOriginal.IsChecked == true)
                {
                    lbxDistribution.ItemsSource = candyCalculator.DivideCandy(numberOfCandies);
                }
                else if (optAge.IsChecked == true)
                {
                    lbxDistribution.ItemsSource = candyCalculator.DivideCandyByAge(numberOfCandies);
                }
                else
                {
                    lbxDistribution.ItemsSource = candyCalculator.DivideCandyByName(numberOfCandies);
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Skriv hur många godisar som ska fördelas först. Antalet ska ges i heltal");
            }
        }
        /// <summary>
        /// Rensar alla rutor samt raderar filen med personer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            lbxDistribution.ItemsSource = null;
            lbxDistribution.ItemsSource = candyCalculator.DeletePeople();
        }
        /// <summary>
        /// Sparar internminnets lista över i personer i en fil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePeople_Click(object sender, RoutedEventArgs e)
        {
            candyCalculator.SavePeopleToFile();
            ClearTextBoxes();
            MessageBox.Show("Personerna har sparats!");
        }
    }
}
