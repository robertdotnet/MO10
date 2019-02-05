using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        
        public void ShowData()
        {
            ClearCurrentItems();

            Data.FetchCurrentCollection();
            if(!Data.isEmptyOrNull())
                foreach(MotivationModel motivationModel in Data.GetAll())
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
            ItemsControl itemsControl = new ItemsControl() { Height = 105, Width = 1146 , BorderBrush = Brushes.Black , BorderThickness = new Thickness(5, 5, 5, 5)};
            Label motivationNameLabel = new Label() { Content = motivationModel.Aim, FontSize = 15, FontWeight = FontWeights.Bold, Focusable = false };
            ProgressBar motivationProgress = new ProgressBar() { Height = 25, Width = 1118, Maximum = motivationModel.FinalValue, Focusable = false };



            motivationProgress.Value = motivationModel.CurrentValue;

            Label motivationValueLabel = new Label() { Content = motivationProgress.Value + "/" + motivationProgress.Maximum + "€", FontSize = 13, FontWeight = FontWeights.DemiBold, Focusable = false };

            //the inclusion
            itemsControl.Items.Add(motivationNameLabel);
            itemsControl.Items.Add(motivationValueLabel);
            itemsControl.Items.Add(motivationProgress);
            MainListBox.Items.Add(itemsControl);
        }

        private void DescriptionButton(object sender, RoutedEventArgs e)
        {
            ItemsControl selectedItemsControl = (ItemsControl)MainListBox.SelectedItem;

            if(selectedItemsControl == null)
            {
                MessageBox.Show("Please select an item to show description");
            }
            else
            {
                string fullStringToProcess = selectedItemsControl.Items.GetItemAt(0).ToString();
                string selectedAim = fullStringToProcess.Substring(31);
                MotivationModel motivationForDescription = Data.GetByAim(selectedAim);
                DescriptionWindow descriptionWindow = new DescriptionWindow(motivationForDescription);
                descriptionWindow.Show();
            }
        }

        private void SearchOnlineButton(object sender, RoutedEventArgs e)
        {
            ItemsControl selectedItemsControl = (ItemsControl)MainListBox.SelectedItem;

            if(selectedItemsControl == null)
            {
                MessageBox.Show("Please select an item to be searched online");
            }
            else
            {
                string fullStringToProcess = selectedItemsControl.Items.GetItemAt(0).ToString();
                string selectedAim = fullStringToProcess.Substring(31);
                MotivationModel motivationToSearch = Data.GetByAim(selectedAim);

                string searchString = Regex.Replace(selectedAim, " ", "+");
                
                System.Diagnostics.Process.Start($"https://www.amazon.de/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords={searchString}");
            }
        }

        private void EditMotivationButton(object sender, RoutedEventArgs e)
        {
            ItemsControl selectedItemsControl = (ItemsControl)MainListBox.SelectedItem;
            if(selectedItemsControl == null)
            {
                MessageBox.Show("Please select an item to edit");
            }
            else
            {
                string fullStringToProcess = selectedItemsControl.Items.GetItemAt(0).ToString();
                string selectedAim = fullStringToProcess.Substring(31);
                MotivationModel motivationToEdit = Data.GetByAim(selectedAim);

                EditMotivationWindow editMotivationWindow = new EditMotivationWindow(motivationToEdit);
                editMotivationWindow.Show();
            }
        }

        private void DeleteMotivationButton(object sender, RoutedEventArgs e)
        {
            ItemsControl selectedItemsControl = (ItemsControl)MainListBox.SelectedItem;

            if(selectedItemsControl == null)
            {
                MessageBox.Show("Please select an item to delete");
            }
            else
            {
                string fullStringToProcess = selectedItemsControl.Items.GetItemAt(0).ToString();
                string selectedAim = fullStringToProcess.Substring(31);
                Data.RemoveByAim(selectedAim);
                MessageBox.Show("Getting a " + selectedAim + " no longer motivates you. It's a lost cause.");
                ShowData();
            }
        }

        private void AddMotivationButton(object sender, RoutedEventArgs e)
        {
            NewMotivationWindow newMotivationWindow = new NewMotivationWindow();
            newMotivationWindow.Show();
        }
    }
}
