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
        DispatcherTimer time;
        DispatcherTimer dt;
        System.Diagnostics.Stopwatch sw;
        string currentTime = string.Empty;
        byte clicktimes = 0;
        // Декларуємо змінні для таймера
        private DispatcherTimer _timer;
        private int _totalSeconds;

        public Timerform()
        {
            InitializeComponent();

            // Ініціалізуємо таймер
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }

        // Метод, що буде викликатися кожну секунду для відліку
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_totalSeconds > 0)
            {
                _totalSeconds--;

                // Розраховуємо години, хвилини та секунди з відповідного кількості секунд
                int hours = _totalSeconds / 3600;
                int minutes = (_totalSeconds - hours * 3600) / 60;
                int seconds = _totalSeconds - hours * 3600 - minutes * 60;

                // Оновлюємо значення на label-ах
                hoursLabel.Content = hours.ToString("00");
                minutesLabel.Content = minutes.ToString("00");
                secondsLabel.Content = seconds.ToString("00");
            }
            else
            {
                // Зупиняємо таймер, якщо минув встановлений час
                _timer.Stop();
            }
        }

        private int minNumber = 1;
        private int maxNumber = 23;
        private int minNumber1 = 1;
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
        int hours = 0;
            int minutes = 0;
            int seconds = 0;
            int.TryParse(hoursLabel.Content.ToString(), out hours);
            int.TryParse(minutesLabel.Content.ToString(), out minutes);
            int.TryParse(secondsLabel.Content.ToString(), out seconds);

            // Розраховуємо загальну кількість секунд
            int totalSeconds = hours * 3600 + minutes * 60 + seconds;

            // Якщо невірно введені дані, то відображаємо початковий час
            if (totalSeconds == 0)
            {
                hoursLabel.Content = "00";
                minutesLabel.Content = "00";
                secondsLabel.Content = "00";
                return;
            }

            // Запускаємо таймер
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) =>
            {
                totalSeconds--;
                if (totalSeconds == 0)
                {
                    timer.Stop();
                }
                // Розраховуємо години, хвилини та секунди
                var hoursLeft = totalSeconds / 3600;
                var minutesLeft = (totalSeconds - hoursLeft * 3600) / 60;
                var secondsLeft = totalSeconds - hoursLeft * 3600 - minutesLeft * 60;

                // Оновлюємо значення на label-ах
                hoursLabel.Content = hoursLeft.ToString("D2");
                minutesLabel.Content = minutesLeft.ToString("D2");
                secondsLabel.Content = secondsLeft.ToString("D2");
            };
            timer.Start();
        }

        // Обробник кліку на кнопку "Stop"
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            // Зупиняємо таймер
            _timer.Stop();

            // Скидаємо значення на label-ах
            _totalSeconds = 0;
            hoursLabel.Content = "00";
            minutesLabel.Content = "00";
            secondsLabel.Content = "00";
        }
    }
}
