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
            CreateBox();
            this.Close();
        }

        private void CreateBox()
        {
            ItemsControl MotivationBox;
            Label MotivationName, MotivationValues;
            ProgressBar MotivationProgress;
            DefineBox(out MotivationBox, out MotivationName, out MotivationProgress, out MotivationValues);
            SetupBox(MotivationBox, MotivationName, MotivationProgress, MotivationValues);
            ShowBox(MotivationBox);
            UpdateData();
        }

        private void UpdateData()
        {
            ((MainWindow)Application.Current.MainWindow).Data.Add(new MotivationModel(AimTextBox.Text, Convert.ToDouble(ValueTextBox.Text), DescriptionTextBox.Text));
        }

        private static void DefineBox(out ItemsControl MotivationBox, out Label MotivationName, out ProgressBar MotivationProgress, out Label MotivationValues)
        {
            MotivationBox = new ItemsControl() { Height = 90, Width = 370, };
            MotivationName = new Label() { Content = ((MainWindow)Application.Current.MainWindow).InsertionModel.Aim, FontWeight = FontWeights.Bold, Focusable = false };
            MotivationProgress = new ProgressBar() { Height = 16, Width = 350, Focusable = false };
            MotivationProgress.Maximum = ((MainWindow)Application.Current.MainWindow).InsertionModel.Value;
            MotivationValues = new Label() { Content = MotivationProgress.Value + "/" + MotivationProgress.Maximum + "€", Focusable = false };
        }

        private static void ShowBox(ItemsControl MotivationBox)
        {
            ((MainWindow)Application.Current.MainWindow).MainListBox.Items.Add(MotivationBox);
        }

        private static void SetupBox(ItemsControl MotivationBox, Label MotivationName, ProgressBar MotivationProgress, Label MotivationValues)
        {
            MotivationBox.Items.Add(MotivationName);
            MotivationBox.Items.Add(MotivationProgress);
            MotivationBox.Items.Add(MotivationValues);
        }
    }
}
