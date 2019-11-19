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

namespace Uppgift15
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
        private void BtnTranslate_Click(object sender, RoutedEventArgs e)
        {
            string textToTranslate = txtOriginal.Text;

            int NumberOfVowels = programLogic.NumberOfVowels(textToTranslate);
            lblNumberOfVowels.Content = $"Antal vokaler: {NumberOfVowels}";

            string translatedText = programLogic.Jibberish(textToTranslate);
            txtTranslation.Text = translatedText;
        }
    }
}
