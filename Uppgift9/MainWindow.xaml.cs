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
            if (age < 7)
            {
                //Barntillåten + 7 årsgräns i vuxet sällskap
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se barntillåtna filmer. " +
                    $"Går du tillsammans med en vuxen får du även se filmer med 7-årsgräns.";
            }
           else if (age >= 7 && age < 11)
            {
                //Får se filmer med åldersgräns 7 & barntillåtna filmer + 11 årsgräns i vuxet sällskap
                txbInfo.Text = $"Hej {name}, eftersom att du är {age} år gammal kan du se på filmer med 7-årsgräns. " +
                    $"Går du tillsammans med en vuxen får du även se filmer med 11-årsgräns. " +
                    $"Givetvis får du också titta på barntillåtna filmer utan vuxen.";
            }
            else if (age >=11 && age < 15)
            {
                //Får se filmer med åldersgräns 11, 7 & barntillåtna filmer
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
