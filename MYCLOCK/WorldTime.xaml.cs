﻿using System;
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

namespace MYCLOCK
{
    /// <summary>
    /// Interaction logic for WorldTime.xaml
    /// </summary>
    public partial class WorldTime : Page
    {
        public WorldTime()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            worldtimetb.Content = DateTime.Now.ToString(@"HH:mm");
            worldtimetb2.Content = DateTime.UtcNow.ToString(@"HH:mm");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            worldtimetb.Content = DateTime.Now.ToString(@"HH:mm");
            worldtimetb2.Content = DateTime.UtcNow.ToString(@"HH:mm");
        }
    }
}
