﻿using Data_access;
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

namespace MYCLOCK
{

    /// <summary>
    /// Interaction logic for Notesform.xaml
    /// </summary>
    public partial class Notesform : Page
    {

        AddNoteForm addNote;

        NotesDBContext context = new NotesDBContext();
 
        public Notesform()
        {
            addNote = new AddNoteForm();
            InitializeComponent();
            var res = context.Notes;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addNote.Show();
        }
    }
}
