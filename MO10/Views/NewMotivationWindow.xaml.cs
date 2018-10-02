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
            ((MainWindow)Application.Current.MainWindow).motivationModel = new MotivationModel(AimTextBox.Text, Convert.ToDouble(ValueTextBox.Text));
            ((MainWindow)Application.Current.MainWindow).ready = true;
            CreateBox();
            this.Close();
        }

        private void CreateBox()
        {
            ListBox MotivationBox = new ListBox() { Height = 90, Width = 370, };
            Label MotivationName = new Label() { Content = ((MainWindow)Application.Current.MainWindow).motivationModel.Aim, FontWeight = FontWeights.Bold, Focusable = false };
            ProgressBar MotivationProgress = new ProgressBar() { Height = 16, Width = 350, Focusable = false };
            MotivationProgress.Maximum = ((MainWindow)Application.Current.MainWindow).motivationModel.Value;
            Label MotivationValues = new Label() { Content = MotivationProgress.Value + "/" + MotivationProgress.Maximum + "€", Focusable = false };



            MotivationBox.Items.Add(MotivationName);
            MotivationBox.Items.Add(MotivationProgress);
            MotivationBox.Items.Add(MotivationValues);

            ((MainWindow)Application.Current.MainWindow).MainListBox.Items.Add(MotivationBox);
            ((MainWindow)Application.Current.MainWindow).ready = false;
        }
    }
}
