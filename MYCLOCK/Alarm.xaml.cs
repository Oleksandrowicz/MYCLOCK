using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data_access;
using Data_access.Entities;
using System.Diagnostics.Metrics;
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
using System.Windows.Forms;


namespace MYCLOCK
{
    /// <summary>
    /// Interaction logic for Alarm.xaml
    /// </summary>
    public partial class Alarm : Page
    {
        Viewmodel viewModel;
        AddAlarmForm addAlarmForm;
        AlarmItem alarm;
        int EditClickTimes = 0;
        DispatcherTimer timer;
        System.Windows.Forms.NotifyIcon notify;
        //public event Action FlashFunctionRequested;
        public Alarm()
        {

        }
        public Alarm(System.Windows.Forms.NotifyIcon notifyIcon)
        {
            InitializeComponent();
            notify = new System.Windows.Forms.NotifyIcon();
            notify = notifyIcon;
            alarm = null;
            
            viewModel = new Viewmodel();
            this.DataContext = viewModel;
            viewModel.CreateAlarmCollection();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EditClickTimes==1)
            {
                try
                {
                    if (viewModel.SelectedAlarm != null)
                    {
                        viewModel.RemoveItem(viewModel.SelectedAlarm);
                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else if (EditClickTimes != 1)
            {
                alarm = new AlarmItem();
                addAlarmForm = new AddAlarmForm(alarm);
                addAlarmForm.Show();
            }
        }
        partial class Viewmodel
        {
            ObservableCollection<AlarmItem> alarms = new ObservableCollection<AlarmItem>();
            public IEnumerable<AlarmItem> Alarmbox => alarms;
            public AlarmItem SelectedAlarm { get; set; }
            public Viewmodel() { }
            public void CreateAlarmCollection()
            {

                using (NotesDBContext context = new NotesDBContext())
                {
                    var res = context.Alarms.ToArray();
                    foreach (var item in res)
                    {

                        alarms.Add(item);
                        //context.Notes.Add(item.MessageNote.ToString());
                    }
                }
            }
            public void AddNewItem(AlarmItem alarm1)
            {
                //alarms.Add(SelectedAlarm);
                using (NotesDBContext context = new NotesDBContext())
                {
                    alarms.Add(alarm1);
                    context.Alarms.Add(alarm1);
                    context.SaveChanges();
                }

            }
            public void RemoveItem(AlarmItem alarm1)
            {
                using (NotesDBContext context = new NotesDBContext())
                {
                    alarms.Remove(alarm1);
                    context.Alarms.Remove(alarm1);
                    context.SaveChanges();
                }
            }
        }

            private void EditButtonClick(object sender, MouseButtonEventArgs e)
            {
                //MessageBox.Show("test");
                if (EditClickTimes == 0)
                {
                    try
                    {
                        if (alarm != null)
                        {
                            viewModel.AddNewItem(alarm);
                            alarm = null;
                        }
                    }
                    catch (Exception ex)
                    {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                    PlusLb.Content = "Delete";
                PlusLb.Foreground = Brushes.DarkRed;
                PlusLb.FontSize = 14;
                EditClickTimes++;
                }
                else if (EditClickTimes == 1)
                {
                    PlusLb.Content = "+";
                PlusLb.FontSize = 18;
                PlusLb.Foreground = Brushes.Orange;
                EditClickTimes--;
                }

            }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            //notify.ShowBalloonTip(500, "Hide", "Close", System.Windows.Forms.ToolTipIcon.Info);

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime current = DateTime.Now;
            foreach (var item in viewModel.Alarmbox)
            {
                if (current.Hour == item.Time.Hour && current.Minute == item.Time.Minute)
                {
                    notify.ShowBalloonTip(500, "Alarm", item.Title, System.Windows.Forms.ToolTipIcon.Info);
                    //System.Windows.Forms.MessageBox.Show("test");
                }
            }
        }

    }
    }

