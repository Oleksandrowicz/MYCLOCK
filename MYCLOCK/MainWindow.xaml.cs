﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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

namespace MYCLOCK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Alarm alarm;
        Stopwatch stopwatch;
        Timerform timerform;
        WorldTime worldtime;
        Notesform notesform;

        System.Windows.Forms.NotifyIcon notifyIcon;

        
        

        public MainWindow()
        {
            InitializeComponent();
            
            stopwatch = new Stopwatch();
            timerform = new Timerform();
            notesform = new Notesform();
            worldtime = new WorldTime();
            notifyIcon = new System.Windows.Forms.NotifyIcon();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainForm.Content = alarm;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainForm.Content = stopwatch;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainForm.Content = timerform;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MainForm.Content = worldtime;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            MainForm.Content = notesform;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove(); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notifyIcon.Icon = new System.Drawing.Icon("ICON.ico");
            notifyIcon.Visible = true;
            notifyIcon.Text = "MYCLOCK";
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            alarm = new Alarm(notifyIcon);
        }

        private void NotifyIcon_MouseClick(object? sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
