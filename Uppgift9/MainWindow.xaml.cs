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

namespace Uppgift9
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

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);
            if (age < 15 && rbtnWithAdult.IsChecked == false && rbtnWithoutAdult.IsChecked == false)
            {
                //Felmeddelande
                txbInfo.Text = "Du måste fylla i om du går tillsamans med en vuxen eller ej för att få ett korrekt svar.";
            }
            else if (age < 7 && rbtnWithoutAdult.IsChecked == true)
            {
                //Barntillåten
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se barntillåtna filmer.";
            }
            else if (age < 7 && rbtnWithAdult.IsChecked == true)
            {
                //Barntillåten + 7-årsgräns
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se barntillåtna filmer. " +
                    $"Eftersom du går tillsammans med en vuxen får du även se filmer med 7-årsgräns.";

            }
           else if (age >= 7 && age < 11 && rbtnWithoutAdult.IsChecked == true)
            {
                //Får se filmer med åldersgräns 7 & barntillåtna filmer
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se på filmer med 7-årsgräns. " +
                    $"Givetvis får du även titta på barntillåtna filmer utan vuxen.";
            }
            else if (age >= 7 && age < 11 && rbtnWithAdult.IsChecked == true)
            {
                //Åldersgräns 7 & barntillåtna filmer + 11 årsgräns
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se på filmer med 7-årsgräns. " +
                    $"Eftersom du går tillsammans med en vuxen får du även se filmer med 11-årsgräns. " +
                    $"Givetvis får ni också titta på barntillåtna filmer.";
            }
            else if (age >=11 && age < 15 && rbtnWithoutAdult.IsChecked == true)
            {
                //Får se filmer med åldersgräns 11, 7 & barntillåtna filmer
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se på filmer med 11-årsgräns. " +
                    $"Givetvis får du också titta på barntillåtna filmer eller filmer med 7-årsgräns.";
            }
            else if (age >= 11 && age < 15 && rbtnWithAdult.IsChecked == true)
            {
                //Får se filmer med åldersgräns 11, 7 & barntillåtna filmer oavsett vuxet sällskap
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se på filmer med 11-årsgräns. " +
                    $"Det spelar ingen roll om du går tillsamans med en vuxen. " +
                    $"Givetvis får du också titta på barntillåtna filmer eller filmer med 7-årsgräns.";
            }
            else if (age == 15)
            {
                txbInfo.Text = $"Grattis {name}! Från och med i år har du tillåtelse att se alla filmer, eftersom du fyllt {age} år.";
            }
            else
            {
                //Får se alla filmer
                txbInfo.Text = $"Hej på dig {name}! Eftersom du är {age} år har du tillåtelse att gå på alla filmer.";
            }
        }
    }
}
