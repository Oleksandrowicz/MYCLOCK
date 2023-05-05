using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media;

namespace MYCLOCK
{
    /// <summary>
    /// Interaction logic for Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {
        System.Diagnostics.Stopwatch time;
        DispatcherTimer dt;
        System.Diagnostics.Stopwatch sw;
        string currentTime = string.Empty;
        byte clicktimes = 0;
        public Stopwatch()
        {
            //dispatcherTimer = new DispatcherTimer();
            dt = new DispatcherTimer();
            sw = new System.Diagnostics.Stopwatch();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            time = new System.Diagnostics.Stopwatch();
            //time.Interval = new TimeSpan(0, 0, 0, 0, 1);
            clicktimes++;
            if ((clicktimes % 2) != 0)
            {
                time.Start();
                sw.Start();
                dt.Start();
                startbtn.Background = (Brush)new BrushConverter().ConvertFrom("#2f100d");
                startbtn.Foreground = (Brush)new BrushConverter().ConvertFrom("#e0544b");
                startbtn.Content = "Stop";
                lapbtn.Content = "Lap";
                //stopWatch.Start();
                dt.Tick += Dt_Tick;
            }
            else if ((clicktimes % 2) == 0)
            {
                startbtn.Background = (Brush)new BrushConverter().ConvertFrom("#172e1c");
                startbtn.Foreground = (Brush)new BrushConverter().ConvertFrom("#6bc57b");
                startbtn.Content = "Start";

                lapbtn.Content = "Reset";
                if (sw.IsRunning)
                {
                    sw.Stop();
                    dt.Stop();
                }
            }
        }
        private void Dt_Tick(object? sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00},{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                timelb.Content = currentTime;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((clicktimes % 2) != 0)
            {
                
                lapbox.Items.Add(time.Elapsed.ToString(@"mm\:ss\:ff"));
                time.Restart();
                time.Start();
            }
            else if ((clicktimes % 2) == 0)
            {
                
                sw.Reset();
                lapbox.Items.Clear();
                timelb.Content = "00:00,00";
            }
        }
    }
}

