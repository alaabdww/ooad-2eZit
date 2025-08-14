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

namespace WpfComplexiteit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtWoord.Text = null;
        }

        private bool IsKlinker(char C)
        {
            if (C == 'a' || C == 'e' || C == 'i' || C == 'o' || C == 'u' || C == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int AantalLettergrepen(string a)
        {
            if (string.IsNullOrEmpty(a))
            {
                return 0;
            }
            a = a.ToLower();
            bool vorigeWasKlinker = false;
            string klinkers = "aeiouy";
            int aantal = 0;

            foreach (char c in a)
            {
                if (klinkers.Contains(c))
                {
                    if (vorigeWasKlinker == false)
                    {
                        aantal++;
                        vorigeWasKlinker = true;
                    }
                    else
                    {
                        vorigeWasKlinker = true;
                    }
                }
                else
                {
                    vorigeWasKlinker = false;
                }
            }

            return aantal;



        }

        private double Complexiteit(string a)
        {
            a = a.ToLower();
            int lettergrepen = AantalLettergrepen(a);
            int lengte = a.Length;
            double complexiteit = 0;
            int letters = 0;

            foreach (char c in a)
            {
                if (c == 'x' || c == 'y' || c == 'q')
                { letters++; }
            }

            complexiteit = (double)lettergrepen + (double)lengte / 3 + (double)letters;
            complexiteit = Math.Round(complexiteit, 1);
            return complexiteit;

        }

        private void btnAnalyseer_Click(object sender, RoutedEventArgs e)
        {
            string woord = txtWoord.Text;
            txtResultaat.Text = $"aantal karakters: {woord.Length} {Environment.NewLine}aantal lettergrepen: {AantalLettergrepen(woord)} {Environment.NewLine}complexiteit: {Complexiteit(woord)}";
        }
    }
}
