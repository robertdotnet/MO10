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
        public MotivationViewModel Data = new MotivationViewModel();

        public MainWindow()
        {
            InitializeComponent();
            ShowData();
        }

        // public for test
        public void ShowData()
        {
            ClearCurrentItems();
            Data.FetchCurrentCollection();

            foreach (MotivationModel motivationModel in Data.GetAll())
            {
                CreateAndAddBox(motivationModel);
            }

        }

        public void UpdateData()
        {
            Data.UpdateData();
        }

        private void ClearCurrentItems()
        {
            MainListBox.Items.Clear();
        }

        private void CreateAndAddBox(MotivationModel motivationModel)
        {
            //actual creation
            ItemsControl itemsControl = new ItemsControl() { Height = 90, Width = 370, Background=Brushes.Coral };
            Label motivationNameLabel = new Label() { Content = motivationModel.Aim, FontWeight = FontWeights.Bold, Focusable = false };
            ProgressBar motivationProgress = new ProgressBar() { Height = 16, Width = 350, Maximum = motivationModel.FinalValue, Focusable = false };

            //test value
            motivationProgress.Value = motivationModel.CurrentValue;

            Label motivationValueLabel = new Label() { Content = motivationProgress.Value + "/" + motivationProgress.Maximum + "€", Focusable = false };

            //the inclusion
            itemsControl.Items.Add(motivationNameLabel);
            itemsControl.Items.Add(motivationProgress);
            itemsControl.Items.Add(motivationValueLabel);
            MainListBox.Items.Add(itemsControl);
        }


        private void AddMotivationButton(object sender, RoutedEventArgs e)
        {
            NewMotivationWindow newMotivationWindow = new NewMotivationWindow();
            newMotivationWindow.Show();
        }
    }
}
