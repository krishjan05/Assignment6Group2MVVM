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

namespace Assignment8Group2MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        carRepair cr;
        public MainWindow()
        {
            InitializeComponent();
            cr = new carRepair();
            DataContext = cr;
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            cr.TotalCharges();
        }
    }
}
