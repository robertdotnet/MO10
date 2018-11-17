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
        public MotivationModel InsertionModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            Data.FetchCurrentCollection();
        }


        private void AddMotivationButton(object sender, RoutedEventArgs e)
        {
            NewMotivationWindow newMotivationWindow = new NewMotivationWindow();
            newMotivationWindow.Show();
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
        //    MotivationViewModel mvm = new MotivationViewModel();
        //    MotivationModel motivation1 = new MotivationModel("test1", 210);
        //    MotivationModel motivation2 = new MotivationModel("test2", 230);
        //    mvm.models.Add(motivation1);
        //    mvm.models.Add(motivation2);
        //    mvm.UpdateData();
        }
    }
}
