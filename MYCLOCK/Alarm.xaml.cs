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

namespace MYCLOCK
{
    /// <summary>
    /// Interaction logic for Alarm.xaml
    /// </summary>
    public partial class Alarm : Page
    {
        Viewmodel viewModel;
        public Alarm()
        {
            InitializeComponent();
            viewModel = new Viewmodel();
            this.DataContext = viewModel;
            viewModel.CreateAlarmCollection();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        partial class Viewmodel
        {
            ObservableCollection<AlarmItem> alarms = new ObservableCollection<AlarmItem>();
            public IEnumerable<AlarmItem> Alarmbox => alarms;
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
        }
    }
}
