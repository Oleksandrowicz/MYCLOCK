using Microsoft.EntityFrameworkCore.ChangeTracking;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Note
    {
        public int ID { get; set; }
        public string MessageNote { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"{MessageNote} {Date.ToShortDateString()}";
        }
        public Note(string messageNote, DateTime date)
        { 
            MessageNote = messageNote;
            Date = date;
        }
        public Note()
        {

        }
    }
    
}
