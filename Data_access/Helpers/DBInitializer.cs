using Data_access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Helpers
{
    internal static class DBInitializer
    {
        public static void SeedNotes( this ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Note>().HasData(new Note[]
           {
                new Note(){ ID = 1, MessageNote = "Go to dantest", Date = new DateTime(2023,5,15)},
                new Note(){ ID = 2, MessageNote = "Exam Task", Date = new DateTime(2023,5,30)},
                new Note(){ ID = 3, MessageNote = "sait potato", Date = new DateTime(2023,5,18)},
                new Note(){ ID = 4, MessageNote = "by car", Date = new DateTime(2023,6,17)},
           });
        }
        public static void SeedAlarms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlarmItem>().HasData(new AlarmItem[]
            {
                new AlarmItem(){ ID = 1, Title = "Example alarm", Time = new DateTime(2023,5,8,17,10,00)},
            });
        }
    }
}
