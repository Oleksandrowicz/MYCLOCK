﻿using System;
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
        DispatcherTimer time;
        DispatcherTimer dt;
        System.Diagnostics.Stopwatch sw;
        string currentTime = string.Empty;
        byte clicktimes=0;
        public Stopwatch()
        {
            //dispatcherTimer = new DispatcherTimer();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            time = new DispatcherTimer();
            clicktimes++;
            if ((clicktimes % 2) != 0)
            {
                time.Start();
                time.Interval = new TimeSpan(0, 0, 0, 0, 1);
                dt = new DispatcherTimer();
                sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                dt.Start();
                startbtn.Background = (Brush)new BrushConverter().ConvertFrom("#2f100d"); 
                startbtn.Foreground = (Brush)new BrushConverter().ConvertFrom("#e0544b"); 
                startbtn.Content = "Stop";
                dt.Interval = new TimeSpan(0, 0, 0, 0, 1);

                //stopWatch.Start();
                dt.Tick += Dt_Tick;
            }
            else if ((clicktimes % 2) == 0)
            {
                startbtn.Background = (Brush)new BrushConverter().ConvertFrom("#172e1c");
                startbtn.Foreground = (Brush)new BrushConverter().ConvertFrom("#6bc57b");
                startbtn.Content = "Start";
                if (sw.IsRunning)
                {
                    sw.Stop();
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
                lapbtn.Content = "Lap";
                time.Stop();
                lapbox.Items.Add(currentTime);
                time.Start();
            }
            else if ((clicktimes % 2) == 0)
            {
                lapbtn.Content = "Reset";
                sw.Reset();
                timelb.Content = "00:00,00";
            }



        }
    }
}

