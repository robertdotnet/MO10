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
using System.Windows.Shapes;

namespace MO10
{
    public partial class NewMotivationWindow : Window
    {
        public NewMotivationWindow()
        {
            InitializeComponent();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GetStartedButton(object sender, RoutedEventArgs e)
        {
            if (DescriptionTextBox.Text == null || DescriptionTextBox.Text == "")
                UpdateData(AimTextBox.Text, Convert.ToDouble(ValueTextBox.Text));
            else
                UpdateData(AimTextBox.Text, Convert.ToDouble(ValueTextBox.Text), DescriptionTextBox.Text);

            ((MainWindow)Application.Current.MainWindow).UpdateData();
            ((MainWindow)Application.Current.MainWindow).ShowData();
            this.Close();
        }

        public void UpdateData(string aim, double value)
        {
            ((MainWindow)Application.Current.MainWindow).Data.Add(new MotivationModel(aim,value));
        }

        public void UpdateData(string aim, double value, string description)
        {
            ((MainWindow)Application.Current.MainWindow).Data.Add(new MotivationModel(aim, value, description));
        }
    }
}
