﻿using System;
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

namespace Uppgift5
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
            int numberOne = int.Parse(numberOneBox.Text);
            int numberTwo = int.Parse(numberTwoBox.Text);
            int sum = numberOne + numberTwo;
            sumBox.Text = $"{sum}";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            numberOneBox.Clear();
            numberTwoBox.Clear();
            sumBox.Clear();
        }
    }
}
