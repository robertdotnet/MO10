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
    public partial class EditMotivationWindow : Window
    {
        private MotivationModel motivationToEdit;
        private MotivationModel originalMotivation;
        public EditMotivationWindow(MotivationModel model)
        {
            InitializeComponent();
            LoadContent(model);
        }

        private void LoadContent(MotivationModel model)
        {
            motivationToEdit = model;
            originalMotivation = model;
            AimNameText.Text = model.Aim;
            CurrentValueText.Text = model.CurrentValue.ToString();
            AimValueText.Text = model.FinalValue.ToString();
            DescriptionText.Text = model.Description;
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            MotivationModel newModel = new MotivationModel();
            newModel.Aim = AimNameText.Text;
            newModel.CurrentValue = Convert.ToDouble(CurrentValueText.Text);
            newModel.FinalValue = Convert.ToDouble(AimValueText.Text);
            newModel.Description = DescriptionText.Text;

            if(newModel.CurrentValue > newModel.FinalValue)
            {
                MessageBox.Show("You can't go above the target value");
                this.Close();
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).Data.EditUsingName(newModel, originalMotivation);
                ((MainWindow)Application.Current.MainWindow).ShowData();
                this.Close();
            }
        }
    }
}
