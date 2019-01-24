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
    public partial class DescriptionWindow : Window
    {
        public DescriptionWindow(MotivationModel motivationModel)
        {
            InitializeComponent();
            LoadContent(motivationModel);
        }

        private void LoadContent(MotivationModel motivationModel)
        {
            TitleBlock.Text = motivationModel.Aim;
            DescriptionBlock.Text = motivationModel.Description;
        }
    }
}
