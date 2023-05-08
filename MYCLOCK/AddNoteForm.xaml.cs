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
        Viewmodel viewModel;
        public AddNoteForm()
        {
            InitializeComponent();
            viewModel = new Viewmodel();
            //notebox.ItemsSource = viewModel.context.Notes.ToArray();
            this.DataContext= viewModel;
            viewModel.CreateCollection();
        }

    }

    partial class Viewmodel
    {
        ObservableCollection<Note> notes= new ObservableCollection<Note>();
       
        public Viewmodel() {
            
        }
        //public ViewModel(NotesDBContext context) { this.context = context; }
        public IEnumerable<Note> Notes => notes; 
        
        public void CreateCollection() {

            using (NotesDBContext context = new NotesDBContext())
            {
                var res = context.Notes.ToArray();
                foreach (var item in res)
                {
                    notes.Add(item);
                    //context.Notes.Add(item.MessageNote.ToString());
                }
            }
        }


    }
}
