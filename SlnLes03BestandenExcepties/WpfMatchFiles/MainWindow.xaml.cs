using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfMatchFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string> LeesTriplets(string path)
        {

            string tekst;
            try 
            {
                tekst = File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Bestand niet gevonden");
                return new List<string>();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Je hebt de rechten niet om dit bestand te openen");
                return new List<string>();
            }
            catch (IOException)
            {
                MessageBox.Show("I/O fouten bij het lezen van bestand");
                return new List<string>();
            }
            

            // alles behalve A-Z vervangen door spatie; spaties samenvoegen; lowercasing
            tekst = Regex.Replace(tekst, "[^A-Za-z]+", " ");
            tekst = Regex.Replace(tekst, @"\s+", " ").Trim().ToLowerInvariant();

            string[] w = tekst.Length == 0 ? new string[0] : tekst.Split(' ');
            HashSet<string> set = new HashSet<string>();                 // unieke triplets
            for (int i = 0; i <= w.Length - 3; i++)
                set.Add($"{w[i]} {w[i + 1]} {w[i + 2]}");

            return set.OrderBy(s => s).ToList();
        }

        private double BerekenOvereenkomst(List<string> lijst1, List<string> lijst2)
        {
            HashSet<string> a = new HashSet<string>(lijst1);
            HashSet<string> b = new HashSet<string>(lijst2);
            int intersect = a.Intersect(b).Count();
            int union = a.Union(b).Count();
            if (union == 0) return 0.0;
            return 100.0 * intersect / union;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBestand1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            string chosenFileName;
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult == true)
            {
                // user picked a file and pressed OK
                chosenFileName = dialog.FileName;
                txtBestand1.Text = chosenFileName;
            }
            else
            {
                // user cancelled or escaped dialog window
            }
        }

        private void btnBestand2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            string chosenFileName;
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult == true)
            {
                // user picked a file and pressed OK
                chosenFileName = dialog.FileName;
                txtBestand2.Text = chosenFileName;
            }
            else
            {
                // user cancelled or escaped dialog window
            }
        }

        private void btnVergelijk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBestand1.Text) || string.IsNullOrEmpty(txtBestand2.Text))
            {
                txtResultaat.Text = "Gelieve een bestand te kiezen of een path in te vullen";
                return;
            }
            if (!File.Exists(txtBestand1.Text) || !File.Exists(txtBestand2.Text))
            {
                txtResultaat.Text = "1 van de bestanden bestaat niet! Gelieve een correcte bestand te kiezen";
                return;
            }

            List<string> t1 = LeesTriplets(txtBestand1.Text);
            List<string> t2 = LeesTriplets(txtBestand2.Text);

            double pct = BerekenOvereenkomst(t1, t2);
            txtResultaat.Text = $"Overeenkomst: {pct.ToString()}%";
        }
    }
}
