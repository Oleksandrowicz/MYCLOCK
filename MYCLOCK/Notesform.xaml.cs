using Data_access;
using Data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace MYCLOCK
{

    /// <summary>
    /// Interaction logic for Notesform.xaml
    /// </summary>
    public partial class Notesform : Page
    {
        Viewmodel viewModel;


     

        NotesDBContext context = new NotesDBContext();
 
        public Notesform()
        {
            InitializeComponent();
            viewModel = new Viewmodel();
            //notebox.ItemsSource = viewModel.context.Notes.ToArray();
            this.DataContext = viewModel;
            viewModel.CreateCollection();

        }

        
        

        private void Add_New_Note(object sender, RoutedEventArgs e)
        {
            viewModel.Add_New_Note(TxtBox1.Text);

        }

        private void Remuve_Note(object sender, RoutedEventArgs e)
        {
            viewModel.Remuve_SelectedNote(ListBox.SelectedItem as Note);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(viewModel.SelectedItem != null) 
                TxtBox1.Text = viewModel.SelectedItem.MessageNote;
        }

        private void Edit_Note(object sender, RoutedEventArgs e)
        {
            viewModel.Edit_SelectedNote(TxtBox1.Text, ListBox.SelectedItem as Note);
            

        }
    }
    [AddINotifyPropertyChangedInterface]
    public partial class Viewmodel
    {
        ObservableCollection<Note> notes = new ObservableCollection<Note>();


        public Viewmodel()
        {

        }
        //public ViewModel(NotesDBContext context) { this.context = context; }
        public IEnumerable<Note> Notes => notes;
        public Note SelectedItem { get; set; }

        public void CreateCollection()
        {

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
        public void Add_New_Note(string Name) { 
            Note NewNote = new Note(Name, DateTime.Now); 
            notes.Add(NewNote);
            using (NotesDBContext context = new NotesDBContext())
            {
                context.Notes.Add(NewNote);
                context.SaveChanges();
               
            }

        }
        public void Remuve_SelectedNote(Note note){
            if(note != null)
            {
                notes.Remove(note);
            }
            using (NotesDBContext context = new NotesDBContext())
            {
                context.Notes.Remove(note);
                context.SaveChanges();

            }
            

        }

            public void Edit_SelectedNote(string Name, Note note)
        {
          



            //Note NewNote = new Note(Name, DateTime.Now);
            //notes.Add(NewNote);
            using (NotesDBContext context = new NotesDBContext())
            {
                
                var res = context.Notes.Find(note.ID);

                
                if (res != null )
                {
                    
                    res.MessageNote = Name;
                    //notes.Add(res);
                    //notes.Remove(SelectedItem);
                    var res2 = notes.FirstOrDefault(n => n.ID == note.ID);
                    res2.MessageNote = Name;

                }

                context.SaveChanges();
                notes.Clear();
                var a = context.Notes.ToList();
                foreach (var item in a)
                {
                    notes.Add(item);
                }


            }
            




        }


    }
}
