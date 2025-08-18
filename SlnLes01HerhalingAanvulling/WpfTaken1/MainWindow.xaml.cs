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

namespace WpfTaken1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Toevoegen_Click(object sender, RoutedEventArgs e)
        {
            string errorText = "";
            if (string.IsNullOrWhiteSpace(NaamTxt.Text))
            {
                errorText += $"gelieve een naam te kiezen {Environment.NewLine}";
            }
            else if (PrioriteitCmbbx.SelectedIndex == 0)
            {
                errorText += $"gelieve een prioriteit te kiezen {Environment.NewLine}";
            }
            else if (Datumpicker.SelectedDate == null)
            {
                errorText += $"gelieve een datum te kiezen {Environment.NewLine}";
            }


        }
    }
}
