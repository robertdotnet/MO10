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
using System.Windows.Shapes;

namespace MO10.Views
{
    /// <summary>
    /// Interaction logic for EditMotivationWindow.xaml
    /// </summary>
    public partial class EditMotivationWindow : Window
    {
        public EditMotivationWindow()
        {
            InitializeComponent();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            //to implement save feature logic for update
        }
    }
}