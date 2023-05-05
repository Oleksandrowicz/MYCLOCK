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

namespace MYCLOCK
{
    public partial class Timerform : Page
    {
        private DispatcherTimer timer;
        private int hours, minutes, seconds;
        private bool addHourBtnPressed = false;
        private DateTime addHourBtnPressedTime;
        private TimeSpan addHourBtnFastPressDuration = TimeSpan.FromMilliseconds(500);

        public Timerform()
        {
            InitializeComponent();

            // Ініціалізуємо таймер
           
        }

        // Метод, що буде викликатися кожну секунду для відліку
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hours == 0 && minutes == 0 && seconds == 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up!");
            }
            else
            {
                if (seconds == 0)
                {
                    if (minutes > 0)
                    {
                        minutes--;
                        seconds = 59;
                    }
                    else
                    {
                        hours--;
                        minutes = 59;
                        seconds = 59;
                    }
                }
                else
                {
                    seconds--;
                }

                hoursLabel.Content = hours.ToString();
                minutesLabel.Content = minutes.ToString();
                secondsLabel.Content = seconds.ToString();
            }
        }

        private int minNumber = 0;
        private int maxNumber = 23;
        private int minNumber1 = 0;
        private int maxNumber1 = 59;

        private void increaseButton_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(hoursLabel.Content.ToString());
            if (currentValue < maxNumber)
            {
                currentValue++;
                hoursLabel.Content = currentValue.ToString();
            }
        }

        private void decreaseButton_Click(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(hoursLabel.Content.ToString());
            if (currentValue > minNumber)
            {
                currentValue--;
                hoursLabel.Content = currentValue.ToString();
            }
        }

        

        private void increaseButton_Click3(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(secondsLabel.Content.ToString());
            if (currentValue < maxNumber1)
            {
                currentValue++;
                secondsLabel.Content = currentValue.ToString();
            }
        }

        private void decreaseButton_Click3(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(secondsLabel.Content.ToString());
            if (currentValue > minNumber1)
            {
                currentValue--;
                secondsLabel.Content = currentValue.ToString();
            }
        }

       

        private void increaseButton_Click2(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(minutesLabel.Content.ToString());
            if (currentValue < maxNumber1)
            {
                currentValue++;
                minutesLabel.Content = currentValue.ToString();
            }
        }

        private void decreaseButton_Click2(object sender, RoutedEventArgs e)
        {
            int currentValue = int.Parse(minutesLabel.Content.ToString());
            if (currentValue > minNumber1)
            {
                currentValue--;
                minutesLabel.Content = currentValue.ToString();
            }
        }
        // Обробник кліку на кнопку "Start"
        private void startButton_Click(object sender, RoutedEventArgs e)
        {



            // Перетворюємо введені значення у числа та перевіряємо на правильність
            // Перетворюємо введені значення у числа та перевіряємо на правильність
            hours = int.Parse(hoursLabel.Content.ToString());
            minutes = int.Parse(minutesLabel.Content.ToString());
            seconds = int.Parse(secondsLabel.Content.ToString());

            timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // Обробник кліку на кнопку "Stop"
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            // Зупиняємо таймер
            timer.Stop();
            hoursLabel.Content = "0";
            minutesLabel.Content = "0";
            secondsLabel.Content = "0";
        }
    }
}
