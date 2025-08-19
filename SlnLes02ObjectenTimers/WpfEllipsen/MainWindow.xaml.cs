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

namespace WpfEllipsen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        Random rnd = new Random();
        int aantalElipsen = 0;
        const int Max_Elipsen = 25;
        public MainWindow()
        {
            InitializeComponent();
            // maak de ellips
            Ellipse newEllipse = new Ellipse()
            {
                Width = 150,
                Height = 60,
                Fill = new SolidColorBrush(Color.FromRgb(122, 78, 200))
            };
            double xPos = 50;
            double yPos = 85;
            newEllipse.SetValue(Canvas.LeftProperty, xPos);
            newEllipse.SetValue(Canvas.TopProperty, yPos);
            //voeg ellips toe aan het canvas
            canvas1.Children.Add(newEllipse);

            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (aantalElipsen >=  Max_Elipsen)
            {
                timer.Stop();
                return;
            }

            Ellipse newEllipse = new Ellipse()
            {
                Width = rnd.Next(20, 101),
                Height = rnd.Next(20, 101),
                Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256)))
            };
            double xPos = rnd.Next(0, (int)(canvas1.Width - newEllipse.Width));
            double yPos = rnd.Next(0, (int)(canvas1.Height - newEllipse.Height));
            newEllipse.SetValue(Canvas.LeftProperty, xPos);
            newEllipse.SetValue(Canvas.TopProperty, yPos);
            canvas1.Children.Add(newEllipse);
            aantalElipsen++;

        }

        private void btnTekenen_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            aantalElipsen = 0;
            timer.Start();
        }
    }
}
