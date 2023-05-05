using Data_access;
using Data_access.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddNoteForm.xaml
    /// </summary>
    public partial class AddNoteForm : Window
    {
        ViewModel viewModel;
        public AddNoteForm()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            //notebox.ItemsSource = viewModel.context.Notes.ToArray();
            this.DataContext= viewModel;
            viewModel.CreateCollection();
        }

    }

    class ViewModel
    {
        ObservableCollection<Note> notes= new ObservableCollection<Note>();
        public NotesDBContext context = new NotesDBContext();
        public ViewModel() {
            
        }
        //public ViewModel(NotesDBContext context) { this.context = context; }
        public IEnumerable<Note> Notes => notes; 
        
        public void CreateCollection() {

            var res = context.Notes.ToArray();
            foreach (var item in res)
            {
                notes.Add(item);
                //context.Notes.Add(item.MessageNote.ToString());
            }
        }


    }
}
