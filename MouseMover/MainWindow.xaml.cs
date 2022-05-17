using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MouseMover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        bool moving = false;
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void enableButton_Click(object sender, RoutedEventArgs e)
        {
            enableButton.IsEnabled = false;
            disableButton.IsEnabled = true;
            moving = true;
            statusLabel.Content = "Moving enabled";
        }

        private void disableButton_Click(object sender, RoutedEventArgs e)
        {
            enableButton.IsEnabled = true;
            disableButton.IsEnabled = false;
            moving = false;
            statusLabel.Content = "Moving disabled";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            enableButton.IsEnabled = true;
            disableButton.IsEnabled = false;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (moving)
            {
                // move mouse to a random position
                Random rnd = new Random();
                int x = rnd.Next(0, (int)SystemParameters.PrimaryScreenWidth);
                int y = rnd.Next(0, (int)SystemParameters.PrimaryScreenHeight);
                SetCursorPos(x, y);
            }
        }
    }
}
