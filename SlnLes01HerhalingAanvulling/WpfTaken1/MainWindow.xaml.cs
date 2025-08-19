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
        Stack<ListBoxItem> verwijderdeItems = new Stack<ListBoxItem>();
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
            if (PrioriteitCmbbx.SelectedItem == selecteer)
            {
                errorText += $"gelieve een prioriteit te kiezen {Environment.NewLine}";
            }
            if (Datumpicker.SelectedDate == null)
            {
                errorText += $"gelieve een datum te kiezen {Environment.NewLine}";
            }
            if (radAdam.IsChecked == false && radBilal.IsChecked == false && radChelsey.IsChecked == false)
            {
                errorText += $"gelieve een uitvoerder te kiezen {Environment.NewLine}";
            }

            ErrorTxt.Text = errorText;

            if (string.IsNullOrEmpty(ErrorTxt.Text))
            {
                string taak = NaamTxt.Text;
                string datum = Datumpicker.SelectedDate.HasValue
                    ? Datumpicker.SelectedDate.Value.ToShortDateString()
    :               ""; ;
                string uitvoerder = "";
                if (radAdam.IsChecked == true)
                {
                    uitvoerder = "Adam";
                }
                else if (radBilal.IsChecked == true)
                {
                    uitvoerder = "Bilal";
                }
                else if (radChelsey.IsChecked == true)
                {
                    uitvoerder = "Chelsey";
                }

                ListBoxItem item = new ListBoxItem();
                item.Content = $"{taak} (deadline: {datum}; door: {uitvoerder})";
                if (PrioriteitCmbbx.SelectedItem == hoog)
                {
                    item.Background = Brushes.LightCoral;
                }
                else if (PrioriteitCmbbx.SelectedItem == gemiddeld)
                {
                    item.Background = Brushes.LightYellow;
                }
                else if (PrioriteitCmbbx.SelectedItem == laag)
                {
                    item.Background = Brushes.LightSeaGreen;
                }

                Lstbx.Items.Add(item);

            }

        }

        private void Lstbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            verwijderenBtn.IsEnabled = true;
        }

        private void verwijderenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Lstbx.SelectedItem != null)
            {
                ListBoxItem geselecteerd = (ListBoxItem)Lstbx.SelectedItem;
                verwijderdeItems.Push(geselecteerd);
                Lstbx.Items.Remove(geselecteerd);
                terugzettenBtn.IsEnabled = true;
                verwijderenBtn.IsEnabled = false;
            }
        }

        private void terugzettenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (verwijderdeItems.Count > 0)
            {
                ListBoxItem terug = verwijderdeItems.Pop();
                Lstbx.Items.Add(terug);
            }
            else if (verwijderdeItems.Count == 0)
            {
                terugzettenBtn.IsEnabled = false;
            }
        }
    }
}
