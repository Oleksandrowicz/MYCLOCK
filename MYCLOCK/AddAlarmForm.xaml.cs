using Data_access.Entities;
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
using System.Windows.Shapes;

namespace MYCLOCK
{
    /// <summary>
    /// Interaction logic for AddAlarmForm.xaml
    /// </summary>
    public partial class AddAlarmForm : Window
    {
        AlarmItem alarminfo;
        public AddAlarmForm()
        {
            
            
            InitializeComponent();
        }
        public AddAlarmForm(AlarmItem alarm)
        {
            
            InitializeComponent();
            alarminfo = alarm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            createAlarm();
            if (alarminfo == null)
            {
                MessageBox.Show("Null");
            }
            //MessageBox.Show(alarminfo.Title);
            //MessageBox.Show(alarminfo.Time.ToString());
            this.Hide();
        }
        void createAlarm()
        {
            int m = int.Parse(minuteLb.Content.ToString());
            int s = int.Parse(secondLb.Content.ToString());
            //DateTime dateTime = new DateTime(dataPICKER.DisplayDate.Year, dataPICKER.DisplayDate.Month, dataPICKER.DisplayDate.Day, 10, 10);
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, m, s, 0);
            //dateTime.Minute = minuteLb;

            alarminfo.Title = labelTb.Text;
            alarminfo.Time = dateTime;

            //return alarmItem;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            minuteLb.Content = DateTime.Now.Hour;
            secondLb.Content = DateTime.Now.Minute;
        }

        private void minuteUP_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(minuteLb.Content.ToString());
            a++;
            if (a == 24)
                a = 0;
            minuteLb.Content = a.ToString();

        }

        private void secondUP_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(secondLb.Content.ToString());
            a++;
            if (a == 60)
                a = 0;
            secondLb.Content = a.ToString();
        }

        private void minuteDOWN_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(minuteLb.Content.ToString());
            a--;
            if (a == -1)
                a = 23;
            minuteLb.Content = a.ToString();
        }

        private void secondDOWN_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(secondLb.Content.ToString());
            a--;
            if (a == -1)
                a = 59;
            secondLb.Content = a.ToString();
        }
    }
}
