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
using System.Windows.Threading;
using System.Diagnostics;


namespace WpfRaadLand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Random rnd = new Random();
        List<string> landen = new List<string> { "argentinie", "finland", "marokko", "japan", "nieuwzeeland" };
        string land = "";
        int score = 0;
        int aantalRondes = 0;
        private Stopwatch sw = new Stopwatch();
        private List<TimeSpan> tijden = new List<TimeSpan>();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            resultaatTxt.Text = "Kies het juiste land!";
        }

        private string GemiddeldeTijdTekst()
        {
            List<TimeSpan> juiste = new List<TimeSpan>();
            for (int i = 0; i < tijden.Count; i++)
            {
                if (tijden[i] > TimeSpan.Zero)
                    juiste.Add(tijden[i]);
            }

            if (juiste.Count == 0) return "—";

            double somMs = 0.0;
            for (int i = 0; i < juiste.Count; i++)
                somMs += juiste[i].TotalMilliseconds;

            double avgMs = somMs / juiste.Count;
            TimeSpan avg = TimeSpan.FromMilliseconds(avgMs);
            return avg.TotalSeconds.ToString("0.00") + " s";
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            tijdRectangle.Width -= 1;

            if (tijdRectangle.Width <= 0)
            {
                timer.Stop();
                tijden.Add(sw.Elapsed);
                tijden.Add(TimeSpan.Zero);
                aantalRondes++;
                resultaatTxt.Text = $"Tijd voorbij. Je hebt {score}/{aantalRondes}. Je gemiddelde tijd is {GemiddeldeTijdTekst()}";
                startBtn.IsEnabled = true;
            }
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            startBtn.IsEnabled = false;
            tijdRectangle.Width = 500;
            int i = rnd.Next(0, landen.Count);
            land = landen[i];
            resultaatTxt.Text = $"Duid {land} aan!";
            sw.Restart();
            timer.Start();

            

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e) 
        {
            if (startBtn.IsEnabled == false) 
            { 
                Image img = (Image)sender;
                string gekozen = img.Tag.ToString();
                if (land == gekozen)
                {
                    score++;
                    aantalRondes++;
                    timer.Stop();
                    resultaatTxt.Text = $"Correct. Je hebt {score}/{aantalRondes}. Je gemiddelde tijd is {GemiddeldeTijdTekst()}";
                    startBtn.IsEnabled = true;
                }
                else if (land != gekozen)
                {
                    aantalRondes++;
                    timer.Stop();
                    resultaatTxt.Text = $"Fout. Je hebt {score}/{aantalRondes}. Je gemiddelde tijd is {GemiddeldeTijdTekst()}";
                    startBtn.IsEnabled = true;
                }

            }
        }

    }
}
