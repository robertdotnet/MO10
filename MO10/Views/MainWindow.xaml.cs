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

namespace MO10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MotivationModel motivationModel { get; set; }
        public bool ready = false;

        private void AddMotivationButton(object sender, RoutedEventArgs e)
        {
            NewMotivationWindow newMotivationWindow = new NewMotivationWindow();
            newMotivationWindow.Show();
        }


        //private void AddMotivationButton(object sender, RoutedEventArgs e)
        //{
        //    Button dummyButton = new Button() {
        //        Height = 40,
        //        Width = 170,
        //        HorizontalAlignment = HorizontalAlignment.Left,
        //        VerticalAlignment = VerticalAlignment.Bottom,
        //        Content = "dummy"
        //    };

        //    MainGrid.Children.Add(dummyButton);
        //}


    }
}
